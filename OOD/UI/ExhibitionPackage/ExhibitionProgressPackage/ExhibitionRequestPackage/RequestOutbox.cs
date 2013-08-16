#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public partial class RequestOutbox : MainWindow
    {
        private BoothExtensionRequest _boothExtensionRequest;

        public RequestOutbox()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            base.Reset();
            TabControl.Controls.Clear();

            if (HasExhibitionRequestPreCondition())
            {
                ExhibitionRequestReset();
                TabControl.Controls.Add(exhibitionRequestTabPage);
            }

            if (HasSaloonRequestPreCondition())
            {
                SaloonRequestReset();
                TabControl.Controls.Add(saloonRequestTabPage);
            }

            if (HasBoothRequestPreCondition())
            {
                BoothRequestReset();
                TabControl.Controls.Add(boothRequestTabPage);
            }

            if (HasInspectionRequestPreCondition())
            {
                InspectionRequestReset();
                TabControl.Controls.Add(InspectionRequestTabPage);
            }

            if (HasPollRequestPreCondition())
            {
                PollRequestReset();
                TabControl.Controls.Add(pollRequestTabPage);
            }

            if (HasBoothExtensionPreCondition())
            {
                BoothExtensionReset();
                TabControl.Controls.Add(boothExtensionRequestTabPage);
            }

            if (HasListRequestPreCondition())
            {
                ListRequestReset();
                TabControl.Controls.Add(listRequestTabPage);
            }
        }

        // IPrecondition

        public override bool NeedUser()
        {
            return true;
        }


        public override bool NeedExhibition()
        {
            return true;
        }

        public override bool ValidatePreConditions()
        {
            if (!base.ValidatePreConditions())
                return false;

            var user = Program.User;
            var exhibition = Program.Exhibition;
            if (exhibition.HasRole<ExecutionRole>(user)
                || exhibition.HasRole<ECustomerRole>(user)
                || Program.User.UserRole is CustomerRole)
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("درخواست ها");
                return false;
            }
            GeneralErrors.AccessDenied();
            return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 3;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        // Finish

        public void SendRequest(Request request)
        {
            var db = DataManager.DataContext;
            db.Requests.Add(request);
            db.SaveChanges();
            PopUp.ShowSuccess("درخواست جدید ارسال گردید.");
            ListRequestReset();
        }

        // Exhibition Request

        private bool HasExhibitionRequestPreCondition()
        {
            var processManager = Program.ProcessManager;
            var user = Program.User;
            var exhibition = Program.Exhibition;
            return (user.UserRole is CustomerRole && !exhibition.HasRole<ECustomerRole>(user) &&
                    processManager.IsProcessRunning(ProcessType.ExhibitionRegistration))
                   ||
                   (exhibition.HasRole<ECustomerRole>(user)
                    || processManager.IsProcessRunning(ProcessType.CustommerRequest));
        }

        private void ExhibitionRequestReset()
        {
            ResetHelper.Empty(exhibitionRequestTitleTextBox, exhibitionRequestContentTextBox);
            exhibitionRequestTypeTextBox.Text = Program.Exhibition.HasRole<ECustomerRole>(Program.User)
                ? ExhibitionRequestTypeWrapper.GetWrapper(ExhibitionRequestType.Exit).ToString()
                : ExhibitionRequestTypeWrapper.GetWrapper(ExhibitionRequestType.Entrance).ToString();
        }

        private void exhibitionCancelButton_Click(object sender, EventArgs e)
        {
            ExhibitionRequestReset();
        }

        private void exhibitionRequestButton_Click(object sender, EventArgs e)
        {
            var title = exhibitionRequestTitleTextBox.Text;
            var content = exhibitionRequestContentTextBox.Text;

            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "محتوای درخواست"))
                return;

            var exhibition = Program.Exhibition;
            var user = Program.User;
            var type = exhibition.HasRole<ECustomerRole>(user)
                ? ExhibitionRequestType.Exit
                : ExhibitionRequestType.Entrance;

            var request = new ExhibitionRequest
            {
                Agreed = false,
                Responsed = false,
                Content = content,
                CreationDate = DateTimeManager.Today,
                Exhibition = exhibition,
                RequestType = type,
                Title = title,
                User = user
            };
            SendRequest(request);
            ExhibitionRequestReset();
        }

        // Saloon Request
        private bool HasSaloonRequestPreCondition()
        {
            return (Program.Exhibition.HasRole<ECustomerRole>(Program.User)
                    || Program.Exhibition.HasRole<ExecutionRole>(Program.User))
                   && Program.ProcessManager.IsProcessRunning(ProcessType.RequestForBooth);
        }

        private void SaloonRequestReset()
        {
            ResetHelper.Empty(saloonRequestTitleTextBox, saloonRequestContentTextBox, saloonRequestNameTextBox,
                saloonRequestAreaTextBox, saloonRequestHeightTextBox, SaloonRequestWidthTextBox);
        }

        private void saloonCancelButton_Click(object sender, EventArgs e)
        {
            SaloonRequestReset();
        }

        private void saloonRequestButton_Click(object sender, EventArgs e)
        {
            var title = saloonRequestTitleTextBox.Text;
            var content = saloonRequestContentTextBox.Text;
            var name = saloonRequestNameTextBox.Text;
            var area = saloonRequestAreaTextBox.Text;
            var height = saloonRequestHeightTextBox.Text;
            var width = SaloonRequestWidthTextBox.Text;

            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "متن درخواست")
                || GeneralErrors.IsEmptyField(name, "نام سالن")
                || GeneralErrors.IsNotValidInt(area, 1, "مساحت سالن")
                || GeneralErrors.IsNotValidInt(height, 1, "تعداد ردیف سالن")
                || GeneralErrors.IsNotValidInt(width, 1, "تعداد  ستون سالن"))
                return;

            var request = new SaloonRequest
            {
                Agreed = false,
                Area = int.Parse(area),
                Responsed = false,
                Content = content,
                CreationDate = DateTimeManager.Today,
                Exhibition = Program.Exhibition,
                Height = int.Parse(height),
                Name = name,
                Title = title,
                User = Program.User,
                Width = int.Parse(width)
            };
            SendRequest(request);
            SaloonRequestReset();
        }

        // Booth Request

        private bool HasBoothRequestPreCondition()
        {
            return Program.Exhibition.HasRole<ECustomerRole>(Program.User)
                   && Program.ProcessManager.IsProcessRunning(ProcessType.RequestForBooth);
        }

        private void BoothRequestReset()
        {
            ResetHelper.Empty(boothRequestTitleTextBox, boothRequestContentTextBox, boothRequestOperatorTextBox,
                boothRequestQualityComboBox, boothRequestForSellCheckBox, boothRequestForVitrinCheckBox,
                boothRequestForCommisionCheckBox, boothRequestPhoneCheckBox, boothRequestCardReaderCheckBox,
                boothRequestCountTextBox, boothRequestAreaTextBox);
            ResetHelper.Refresh(boothRequestQualityComboBox, BoothQualityWrapper.BoothQualities);
        }

        private void boothCancelButton_Click(object sender, EventArgs e)
        {
            BoothRequestReset();
        }

        private void boothRequestButton_Click(object sender, EventArgs e)
        {
            var title = boothRequestTitleTextBox.Text;
            var content = boothRequestContentTextBox.Text;
            var operatorCount = boothRequestOperatorTextBox.Text;
            var quality = boothRequestQualityComboBox.SelectedItem as BoothQualityWrapper;
            var count = boothRequestCountTextBox.Text;
            var area = boothRequestAreaTextBox.Text;

            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "محتوای درخواست")
                || GeneralErrors.IsNotValidInt(operatorCount, 1, "تعداد متصدیان")
                || GeneralErrors.IsNull(quality, "کیفیت")
                || GeneralErrors.IsNotValidInt(count, 1, "تعداد غرفه")
                || GeneralErrors.IsNotValidInt(area, 1, "مساحت غرفه"))
                return;

            var request = new BoothRequest
            {
                Agreed = false,
                Area = int.Parse(area),
                Responsed = false,
                Count = int.Parse(count),
                Content = content,
                CreationDate = DateTimeManager.Today,
                Exhibition = Program.Exhibition,
                ForCommision = boothRequestForCommisionCheckBox.Checked,
                ForSell = boothRequestForSellCheckBox.Checked,
                ForVitrin = boothRequestForVitrinCheckBox.Checked,
                HasCardReader = boothRequestCardReaderCheckBox.Checked,
                HasPhone = boothRequestPhoneCheckBox.Checked,
                OperatorCount = int.Parse(operatorCount),
                Quality = quality.Quality,
                Title = title,
                User = Program.User
            };
            SendRequest(request);
            BoothRequestReset();
        }

        // Inspection Request
        private bool HasInspectionRequestPreCondition()
        {
            return (Program.Exhibition.HasRole<ECustomerRole>(Program.User)
                    || Program.Exhibition.HasRole<ExecutionRole>(Program.User)) &&
                   Program.ProcessManager.IsProcessRunning(ProcessType.BoothInspection);
        }

        private void InspectionRequestReset()
        {
            ResetHelper.Empty(inspectionRequestTitleTextBox, inspectionRequestContentTextBox,
                inspectionRequestSaloonComboBox, inspectionRequestBoothComboBox);
            ResetHelper.Refresh(inspectionRequestSaloonComboBox, Program.Exhibition.Saloons);
        }

        private void inspectionCancelButton_Click(object sender, EventArgs e)
        {
            InspectionRequestReset();
        }

        private void inspectionRequestSaloonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetHelper.Empty(inspectionRequestBoothComboBox);
            var saloon = inspectionRequestSaloonComboBox.SelectedItem as Saloon;
            if (saloon != null)
                ResetHelper.Refresh(inspectionRequestBoothComboBox,
                    saloon.Map.Booths.Where(booth => booth.Enabled && booth.Request != null));
            else
            {
                ResetHelper.Empty(inspectionRequestBoothComboBox);
                inspectionRequestBoothComboBox.Items.Clear();
            }
        }

        private void inspectionRequestButton_Click(object sender, EventArgs e)
        {
            var title = inspectionRequestTitleTextBox.Text;
            var content = inspectionRequestContentTextBox.Text;
            var saloon = inspectionRequestSaloonComboBox.SelectedItem as Saloon;
            var booth = inspectionRequestBoothComboBox.SelectedItem as Booth;
            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "محتوای درخواست")
                || GeneralErrors.IsNull(saloon, "سالن نمایشگاه")
                || GeneralErrors.IsNull(booth, "غرفه نمایشگاه"))
                return;

            var request = new InspectionRequest
            {
                Agreed = false,
                Booth = booth,
                Responsed = false,
                Content = content,
                CreationDate = DateTimeManager.Today,
                Exhibition = Program.Exhibition,
                Fine = 0,
                JudgeType = JudgeType.NothingImportant,
                Title = title,
                User = Program.User
            };
            SendRequest(request);
            InspectionRequestReset();
        }

        // Poll Request

        public bool HasPollRequestPreCondition()
        {
            return Program.Exhibition.HasRole<ECustomerRole>(Program.User)
                   && Program.ProcessManager.IsProcessRunning(ProcessType.CustommerRequest);
        }

        public void PollRequestReset()
        {
            ResetHelper.Empty(pollRrequestTitleTextBox, pollRequestContentTextBox, pollRequestPollsComboBox);
            ResetHelper.Refresh(pollRequestPollsComboBox, Program.User.CreatorPolls
                .Where(poll => poll.Exhibition.Id == Program.Exhibition.Id));
        }


        private void pollRequestCancelButton_Click(object sender, EventArgs e)
        {
            PollRequestReset();
        }

        private void pollRequestButton_Click(object sender, EventArgs e)
        {
            var title = pollRrequestTitleTextBox.Text;
            var content = pollRequestContentTextBox.Text;
            var poll = pollRequestPollsComboBox.SelectedItem as Poll;

            if (GeneralErrors.IsNull(poll, "نظرسنجی"))
                return;

            var request = new PollRequest
            {
                Agreed = false,
                Content = content,
                CreationDate = DateTimeManager.Today,
                Exhibition = Program.Exhibition,
                Poll = poll,
                Responsed = false,
                Title = title,
                User = Program.User
            };
            var db = DataManager.DataContext;
            db.Requests.Add(request);
            db.SaveChanges();
            PollRequestReset();
            PopUp.ShowSuccess("درخواست شما در سیستم ثبت گردید.");
        }

        // List Requests

        private bool HasListRequestPreCondition()
        {
            return true;
        }

        private void ListRequestReset()
        {
            ResetHelper.Empty(requestListComboBox, requestTitleTextBox, requestContentTextBox, requestResponseTextBox);
            ResetHelper.Refresh(requestListComboBox,
                Program.Exhibition.Requests
                    .Where(request => request.User.Id == Program.User.Id));
        }

        private void requestListShowButton_Click(object sender, EventArgs e)
        {
            var request = requestListComboBox.SelectedItem as Request;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            requestTitleTextBox.Text = request.Title;
            requestContentTextBox.Text = request.Content;
            requestResponseTextBox.Text = request.Response;
        }

        // Booth Extension Request

        private bool HasBoothExtensionPreCondition()
        {
            return Program.Exhibition.HasRole<ECustomerRole>(Program.User)
                   && Program.User.GetAssignedBooths(Program.Exhibition).Any()
                   && (Program.ProcessManager.IsProcessRunning(ProcessType.CustommerRequest)
                       || Program.ProcessManager.IsProcessRunning(ProcessType.BoothAssignment));
        }

        private void BoothExtensionReset()
        {
            var user = Program.User;
            var exhibition = Program.Exhibition;
            _boothExtensionRequest = new BoothExtensionRequest
            {
                CreationDate = DateTimeManager.Today,
                Exhibition = exhibition,
                User = user,
                Agreed = false,
                Responsed = false,
                IsCustomerRequest = Program.ProcessManager.IsProcessRunning(ProcessType.CustommerRequest)
            };

            ResetHelper.Empty(boothExtensionTitleTextBox, boothExtensionContentTextBox, boothExtensionAbilityListListBox,
                boothExtensionAreaTextBox);
            ResetHelper.Refresh(boothExtensionBoothsComboBox, user.GetAssignedBooths(exhibition));

            ResetHelper.Refresh(boothExtensionQualityComboBox, ProfessionQualityWrapper.Types);
            ResetHelper.Refresh(boothExtensionProfessionComboBox, ProfessionTypeWrapper.Types);

            groupBox2.Visible = !Program.ProcessManager.IsProcessRunning(ProcessType.CustommerRequest);
        }

        private void boothExtensionAbilityAddButton_Click(object sender, EventArgs e)
        {
            var professionType = boothExtensionProfessionComboBox.SelectedItem as ProfessionTypeWrapper;
            var quality = boothExtensionQualityComboBox.SelectedItem as ProfessionQualityWrapper;

            if (GeneralErrors.IsNull(professionType, "خدمت")
                || GeneralErrors.IsNull(quality, "کیفیت خدمت"))
                return;

            var assignment = new ProfessionAssignment
            {
                Profession = new Profession
                {
                    ProfessionType = professionType.Profession,
                    Quality = quality.Quality
                },
                Request = _boothExtensionRequest
            };
            if (boothExtensionAbilityListListBox.Items.Contains(assignment))
            {
                PopUp.ShowError("مورد انتخابی تکراری است.");
                return;
            }
            boothExtensionAbilityListListBox.Items.Add(assignment);
        }

        private void boothExtensionAbilityRemoveButton_Click(object sender, EventArgs e)
        {
            var assignment = boothExtensionAbilityListListBox.SelectedItem as ProfessionAssignment;
            if (GeneralErrors.IsNull(assignment, "خدمت"))
                return;
            boothExtensionAbilityListListBox.Items.Remove(assignment);
        }

        private void boothExtensionCancelButton_Click(object sender, EventArgs e)
        {
            BoothExtensionReset();
        }

        private void boothExtensionButton_Click(object sender, EventArgs e)
        {
            var title = boothExtensionTitleTextBox.Text;
            var content = boothExtensionContentTextBox.Text;
            var booth = boothExtensionBoothsComboBox.SelectedItem as Booth;
            var area = boothExtensionAreaTextBox.Text;
            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "محتوای درخواست")
                || GeneralErrors.IsNull(booth, "غرفه مد نظر")
                || GeneralErrors.IsNotValidInt(area, 1, "مساحت غرفه"))
                return;

            _boothExtensionRequest.Area = int.Parse(area);
            _boothExtensionRequest.Content = content;
            _boothExtensionRequest.Title = title;
            _boothExtensionRequest.Booth = booth;

            foreach (var item in boothExtensionAbilityListListBox.Items)
                DataManager.DataContext.ProfessionAssignments.Add(item as ProfessionAssignment);

            ResetHelper.RemoveItems(boothExtensionAbilityListListBox);
            SendRequest(_boothExtensionRequest);
            BoothExtensionReset();
        }
    }
}