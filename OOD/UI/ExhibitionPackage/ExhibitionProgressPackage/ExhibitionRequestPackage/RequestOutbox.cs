#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public partial class RequestOutbox : MainWindow
    {
        public RequestOutbox()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            base.Reset();
            TabControl.Controls.Clear();

            ExhibitionRequestReset();
            if (HasExhibitionRequestPreCondition())
                TabControl.Controls.Add(exhibitionRequestTabPage);

            SaloonRequestReset();
            if (HasSaloonRequestPreCondition())
                TabControl.Controls.Add(saloonRequestTabPage);

            BoothRequestReset();
            if (HasBoothRequestPreCondition())
                TabControl.Controls.Add(boothRequestTabPage);

            InspectionRequestReset();
            if (HasInspectionRequestPreCondition())
                TabControl.Controls.Add(InspectionRequestTabPage);

            PollRequestReset();
            if (HasPollRequestPreCondition())
                TabControl.Controls.Add(pollRequestTabPage);

            ListRequestReset();
            if (HasListRequestPreCondition())
                TabControl.Controls.Add(listRequestTabPage);
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
                || exhibition.HasRole<ECustomerRole>(user))
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
            return true;
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

            var request = new Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage.ExhibitionRequest
            {
                Agreed = false,
                Responsed = false,
                Content = content,
                CreationDate = DateTime.Today,
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
            return Program.Exhibition.HasRole<ECustomerRole>(Program.User) ||
                   Program.Exhibition.HasRole<ExecutionRole>(Program.User);
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
                CreationDate = DateTime.Today,
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
            return Program.Exhibition.HasRole<ECustomerRole>(Program.User);
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
                CreationDate = DateTime.Today,
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
            return true;
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
                CreationDate = DateTime.Today,
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
            return true;
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
                CreationDate = DateTime.Today,
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
    }
}