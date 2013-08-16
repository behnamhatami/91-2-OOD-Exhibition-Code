#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public partial class RequestInbox : MainWindow
    {
        public RequestInbox()
        {
            InitializeComponent();
        }


        // IResetAble

        public override void Reset()
        {
            tabControl1.Controls.Clear();

            if (HasExhibitionRequestPreCondition())
            {
                tabControl1.Controls.Add(exhibitionRequestTabPage);
                ExhibitionRequestReset();
            }

            if (HasSaloonRequestPreCondition())
            {
                tabControl1.Controls.Add(saloonRequestTabPage);
                SaloonRequestReset();
            }

            if (HasBoothRequestPreCondition())
            {
                tabControl1.Controls.Add(boothRequestTabPage);
                BoothRequestReset();
            }

            if (HasPollRequestPreCondition())
            {
                tabControl1.Controls.Add(pollRequestTabPage);
                PollRequestReset();
            }


            if (HasInspectionRequestPreCondition())
            {
                tabControl1.Controls.Add(InspectionRequestTabPage);
                InspectionRequestReset();
            }

            if (HasBoothExtensionRequestPreCondition())
            {
                tabControl1.Controls.Add(boothExtensionRequestTabPage);
                BoothExtensionRequestReset();
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
                || exhibition.HasRole<BoothManagerRole>(user)
                || exhibition.HasRole<InspectorRole>(user))
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

        private void SendResponse(Request request, string response)
        {
            request.Response = response;
            request.Responsed = true;
            request.NotifyResponse();
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("پاسخ ارسال گردید.");
        }

        private void AgreeRequest(Request request)
        {
            request.Agreed = true;
            request.NotifyAgree();
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("با درخواست موافقت گردید.");
        }

        // Exhibition Request

        private bool HasExhibitionRequestPreCondition()
        {
            return Program.Exhibition.HasRole<ExecutionRole>(Program.User)
                   && Program.Exhibition.GetSpecialRequests<ExhibitionRequest>().Any();
        }

        private void ExhibitionRequestReset()
        {
            ResetHelper.Empty(exhibitionRequestTitleTextBox, exhibitionRequestContentTextBox,
                exhibitionRequestResponseTextBox, exhibitionRequestTypeTextBox);

            ResetHelper.Refresh(exhibitionRequestListComboBox,
                Program.Exhibition.GetSpecialRequests<ExhibitionRequest>());
            exhibitionRequestResponseButton.Enabled = false;
            exhibitionAgreeButton.Enabled = false;
        }

        private void exhibitionShowButton_Click(object sender, EventArgs e)
        {
            var request = exhibitionRequestListComboBox.SelectedItem as ExhibitionRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            exhibitionRequestTitleTextBox.Text = request.Title;
            exhibitionRequestContentTextBox.Text = request.Content;
            exhibitionRequestResponseTextBox.Text = request.Response;
            exhibitionRequestTypeTextBox.Text = ExhibitionRequestTypeWrapper.GetWrapper(request.RequestType).ToString();

            exhibitionRequestResponseButton.Enabled = !request.Responsed;
            exhibitionRequestResponseTextBox.ReadOnly = request.Responsed;
            exhibitionAgreeButton.Enabled = !request.Agreed;
        }

        private void exhibitionRequestResponseButton_Click(object sender, EventArgs e)
        {
            var request = exhibitionRequestListComboBox.SelectedItem as ExhibitionRequest;
            var response = exhibitionRequestResponseTextBox.Text;
            if (GeneralErrors.IsEmptyField(response, "پاسخ"))
                return;

            SendResponse(request, response);
            ExhibitionRequestReset();
        }

        private void exhibitionAgreeButton_Click(object sender, EventArgs e)
        {
            var request = exhibitionRequestListComboBox.SelectedItem as ExhibitionRequest;
            var user = request.User;
            var exhibition = request.Exhibition;
            if (!exhibition.HasRole<ECustomerRole>(user))
            {
                var userExhibitionRole = new UserExhibitionRole
                {
                    Exhibition = exhibition,
                    ExhibitionRole = new ECustomerRole(),
                    User = user
                };
                DataManager.DataContext.UserExhibitionRoles.Add(userExhibitionRole);
                userExhibitionRole.NotifyAdd();
            }
            else
            {
                exhibition.DisposeUser(user);
            }

            AgreeRequest(request);
            ExhibitionRequestReset();
        }

        // Saloon Request

        private bool HasSaloonRequestPreCondition()
        {
            return Program.Exhibition.HasRole<BoothManagerRole>(Program.User)
                   && Program.Exhibition.GetSpecialRequests<SaloonRequest>().Any();
        }

        private void SaloonRequestReset()
        {
            ResetHelper.Empty(saloonRequestComboBox, saloonRequestTitleTextBox, saloonRequestContentTextBox,
                saloonRequestNameTextBox, saloonRequestAreaTextBox, saloonRequestHeightTextBox,
                saloonRequestWidthTextBox, saloonRequestResponseTextBox);
            ResetHelper.Refresh(saloonRequestComboBox,
                Program.Exhibition.GetSpecialRequests<SaloonRequest>());

            saloonAgreeButton.Enabled = false;
            saloonRequestResponseButton.Enabled = false;
            saloonRequestResponseTextBox.ReadOnly = true;
        }

        private void saloonShowButton_Click(object sender, EventArgs e)
        {
            var request = saloonRequestComboBox.SelectedItem as SaloonRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;
            saloonRequestTitleTextBox.Text = request.Title;
            saloonRequestContentTextBox.Text = request.Content;
            saloonRequestNameTextBox.Text = request.Name;
            saloonRequestAreaTextBox.Text = request.Area + "";
            saloonRequestHeightTextBox.Text = request.Height + "";
            saloonRequestWidthTextBox.Text = request.Width + "";
            saloonRequestResponseTextBox.Text = request.Response + "";

            saloonRequestResponseTextBox.ReadOnly = request.Responsed;
            saloonRequestResponseButton.Enabled = !request.Responsed;
            saloonAgreeButton.Enabled = !request.Agreed;
        }

        private void saloonRequestResponseButton_Click(object sender, EventArgs e)
        {
            var request = saloonRequestComboBox.SelectedItem as SaloonRequest;
            var response = saloonRequestResponseTextBox.Text;
            if (GeneralErrors.IsEmptyField(response, "پاسخ"))
                return;
            SendResponse(request, response);
            SaloonRequestReset();
        }

        private void saloonAgreeButton_Click(object sender, EventArgs e)
        {
            var request = saloonRequestComboBox.SelectedItem as SaloonRequest;
            var saloon = new Saloon
            {
                Exhibition = request.Exhibition,
                Map = new Map
                {
                    Height = request.Height,
                    Width = request.Width,
                },
                Name = request.Name,
                Area = request.Area
            };
            var db = DataManager.DataContext;

            for (var i = 0; i < saloon.Map.Width*saloon.Map.Height; i++)
            {
                db.Booths.Add(new Booth
                {
                    Enabled = true,
                    Index = i,
                    Map = saloon.Map,
                });
            }
            db.Saloons.Add(saloon);
            AgreeRequest(request);
            SaloonRequestReset();
        }

        // Booth Request

        private bool HasBoothRequestPreCondition()
        {
            return Program.Exhibition.HasRole<BoothManagerRole>(Program.User)
                   && Program.Exhibition.GetSpecialRequests<BoothRequest>().Any();
        }

        private void BoothRequestReset()
        {
            ResetHelper.Empty(boothRequestComboBox, boothRequestTitleTextBox, boothRequestContentTextBox,
                boothRequestOperatorTextBox, boothRequestQualityTextBox, boothRequestForSellCheckBox,
                boothRequestForVitrinCheckBox, boothRequestForCommisionCheckBox, boothRequestHasPhoneCheckBox,
                boothRequestHasCardReaderCheckBox, boothRequestResponseTextBox, boothRequestCountTextBox);

            ResetHelper.Refresh(boothRequestComboBox, Program.Exhibition.GetSpecialRequests<BoothRequest>());

            boothResponseButton.Enabled = false;
            boothAgreeButton.Enabled = false;
        }

        private void boothShowButton_Click(object sender, EventArgs e)
        {
            var request = boothRequestComboBox.SelectedItem as BoothRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            boothRequestTitleTextBox.Text = request.Title;
            boothRequestContentTextBox.Text = request.Content;
            boothRequestOperatorTextBox.Text = request.OperatorCount + "";
            boothRequestQualityTextBox.Text = BoothQualityWrapper.GetWrapper(request.Quality).ToString();
            boothRequestForSellCheckBox.Checked = request.ForSell;
            boothRequestForVitrinCheckBox.Checked = request.ForVitrin;
            boothRequestForCommisionCheckBox.Checked = request.ForCommision;
            boothRequestHasPhoneCheckBox.Checked = request.HasPhone;
            boothRequestHasCardReaderCheckBox.Checked = request.HasCardReader;
            boothRequestResponseTextBox.Text = request.Response;
            boothRequestCountTextBox.Text = request.Count + "";

            boothRequestResponseTextBox.ReadOnly = request.Responsed;
            boothResponseButton.Enabled = !request.Responsed;
            boothAgreeButton.Enabled = !request.Agreed;
        }

        private void boothResponseButton_Click(object sender, EventArgs e)
        {
            var request = boothRequestComboBox.SelectedItem as BoothRequest;
            var response = boothRequestResponseTextBox.Text;
            if (GeneralErrors.IsEmptyField(response, "پاسخ"))
                return;
            SendResponse(request, response);
            BoothRequestReset();
        }

        private void boothAgreeButton_Click(object sender, EventArgs e)
        {
            var request = boothRequestComboBox.SelectedItem as BoothRequest;
            GoNext(new BoothSelector(request));
            if (request.Agreed)
                AgreeRequest(request);
            DataManager.DataContext.SaveChanges();
            BoothRequestReset();
        }

        // Inspection Request
        private bool HasInspectionRequestPreCondition()
        {
            return Program.Exhibition.HasRole<InspectorRole>(Program.User)
                   && Program.Exhibition.GetSpecialRequests<InspectionRequest>().Any();
        }

        private void InspectionRequestReset()
        {
            ResetHelper.Empty(inspectionRequestsComboBox, inspectionRequestSaloonTextBox, inspectionRequestBoothTextBox,
                inspectionRequestJudgeTypeComboBox, inspectionRequestFineTextBox, inspectionRequestResponseTextBox);

            ResetHelper.Refresh(inspectionRequestsComboBox,
                Program.Exhibition.GetSpecialRequests<InspectionRequest>());
            ResetHelper.Refresh(inspectionRequestJudgeTypeComboBox, JudgeTypeWrapper.JudgeTypes);

            inspectionRequestResponseButton.Enabled = false;
            inspectionRequestJudgeResponseButton.Enabled = false;
        }

        private void inspectionShowButton_Click(object sender, EventArgs e)
        {
            var request = inspectionRequestsComboBox.SelectedItem as InspectionRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            inspectionRequestSaloonTextBox.Text = request.Booth.Map.Saloon.ToString();
            inspectionRequestBoothTextBox.Text = request.Booth.ToString();
            inspectionRequestJudgeTypeComboBox.Text = JudgeTypeWrapper.GetWrapper(request.JudgeType).ToString();
            inspectionRequestFineTextBox.Text = request.Fine + "";
            inspectionRequestResponseTextBox.Text = request.Response;

            var inspectionPhase = !request.Responsed;
            var judgePhase = request.Responsed && !request.Agreed;
            var finishPhase = request.Responsed && request.Agreed;

            inspectionRequestJudgeTypeComboBox.Enabled = judgePhase;
            inspectionRequestJudgeTypeComboBox.Visible = judgePhase || finishPhase;
            label27.Visible = judgePhase || finishPhase;

            inspectionRequestFineTextBox.ReadOnly = !judgePhase;
            inspectionRequestFineTextBox.Visible = (judgePhase || finishPhase) && request.JudgeType == JudgeType.Fine;
            label28.Visible = (judgePhase || finishPhase) && request.JudgeType == JudgeType.Fine;

            inspectionRequestResponseTextBox.ReadOnly = !inspectionPhase;
            inspectionRequestResponseButton.Enabled = inspectionPhase;
            inspectionRequestJudgeResponseButton.Enabled = judgePhase;
        }

        private void inspectionRequestJudgeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isNull = inspectionRequestJudgeTypeComboBox.SelectedItem as JudgeTypeWrapper == null;
            var judgeType = isNull
                ? JudgeType.NothingImportant
                : (inspectionRequestJudgeTypeComboBox.SelectedItem as JudgeTypeWrapper).Type;
            inspectionRequestFineTextBox.Visible = judgeType == JudgeType.Fine;
            label28.Visible = judgeType == JudgeType.Fine;
        }

        private void inspectionRequestResponseButton_Click(object sender, EventArgs e)
        {
            var request = inspectionRequestsComboBox.SelectedItem as InspectionRequest;
            var response = inspectionRequestResponseTextBox.Text;

            if (GeneralErrors.IsEmptyField(response, "پاسخ"))
                return;

            SendResponse(request, response);
            InspectionRequestReset();
        }

        private void inspectionRequestJudgeResponseButton_Click(object sender, EventArgs e)
        {
            var request = inspectionRequestsComboBox.SelectedItem as InspectionRequest;
            var fine = inspectionRequestFineTextBox.Text;
            var judgeType = inspectionRequestJudgeTypeComboBox.SelectedItem as JudgeTypeWrapper;

            if (GeneralErrors.IsNull(judgeType, "نوع قضاوت")
                || (judgeType.Type == JudgeType.Fine && GeneralErrors.IsNotValidInt(fine, 0, "هیزان جریمه")))
                return;

            request.JudgeType = judgeType.Type;
            if (request.JudgeType == JudgeType.Fine)
                request.Fine = int.Parse(fine);

            switch (request.JudgeType)
            {
                case JudgeType.NothingImportant:
                    break;
                case JudgeType.Fine:
                    request.User.Fine(request);
                    break;
                case JudgeType.Deposal:
                    var exhibition = request.Exhibition;
                    var user = request.User;
                    exhibition.DisposeUser(user);
                    break;
            }

            AgreeRequest(request);
            InspectionRequestReset();
        }

        // Poll Request


        public bool HasPollRequestPreCondition()
        {
            return Program.Exhibition.GetSpecialRequests<PollRequest>().Any();
        }

        public void PollRequestReset()
        {
            ResetHelper.Empty(pollRequestTitleTextBox, pollRequestContentTextBox, pollRequestPollTextBox,
                pollRequestResponseTextBox, pollRequestsComboBox);
            ResetHelper.Refresh(pollRequestsComboBox, Program.Exhibition.GetSpecialRequests<PollRequest>());
            pollRequestResponseButton.Enabled = false;
            pollRequestAgreeButton.Enabled = false;
        }

        private void pollRequestShowButton_Click(object sender, EventArgs e)
        {
            var request = pollRequestsComboBox.SelectedItem as PollRequest;
            if (GeneralErrors.IsNull(request, "درخواست نظرسنجی"))
                return;

            pollRequestTitleTextBox.Text = request.Title;
            pollRequestContentTextBox.Text = request.Content;
            pollRequestPollTextBox.Text = request.Poll.ToString();
            pollRequestResponseTextBox.Text = request.Response;

            pollRequestResponseTextBox.ReadOnly = request.Responsed;
            pollRequestAgreeButton.Enabled = !request.Agreed;
            pollRequestResponseButton.Enabled = !request.Responsed;
        }

        private void pollRequestAgreeButton_Click(object sender, EventArgs e)
        {
            var request = pollRequestsComboBox.SelectedItem as PollRequest;
            request.Poll.Started = true;
            AgreeRequest(request);
            PollRequestReset();
        }


        private void pollRequestResponseButton_Click(object sender, EventArgs e)
        {
            var request = pollRequestsComboBox.SelectedItem as PollRequest;
            var response = pollRequestResponseTextBox.Text;
            if (GeneralErrors.IsEmptyField(response, "پاسخ درخواست"))
                return;

            SendResponse(request, response);
            PollRequestReset();
        }

        // Booth Extension Request
        private bool HasBoothExtensionRequestPreCondition()
        {
            return Program.Exhibition.GetSpecialRequests<BoothExtensionRequest>().Any();
        }

        private void BoothExtensionRequestReset()
        {
            ResetHelper.Empty(boothExtensionRequestTitleTextBox, boothExtensionRequestContentTextBox,
                boothExtensionRequestBoothTextBox, boothExtensionRequestAreaTextBox, boothExtensionResponseTextBox,
                boothExtensionAbilityListListBox);
            boothExtensionAbilityListListBox.Items.Clear();
            ResetHelper.Refresh(boothExtensionRequestsComboBox,
                Program.Exhibition.GetSpecialRequests<BoothExtensionRequest>());
            boothExtensionRequestAgreeButton.Enabled = false;
            boothExtensionRequestResponseButton.Enabled = false;
        }

        private void boothExtensionRequestAgreeButton_Click(object sender, EventArgs e)
        {
            var request = boothExtensionRequestsComboBox.SelectedItem as BoothExtensionRequest;
            var booth = request.Booth;
            booth.ExtensionRequest = request;
            AgreeRequest(request);
            BoothExtensionRequestReset();
        }

        private void boothExtensionRequestResponseButton_Click(object sender, EventArgs e)
        {
            var request = boothExtensionRequestsComboBox.SelectedItem as BoothExtensionRequest;
            var response = boothExtensionResponseTextBox.Text;
            if (GeneralErrors.IsEmptyField(response, "پاسخ درخواست"))
                return;
            SendResponse(request, response);
            BoothExtensionRequestReset();
        }

        private void boothExtensionRequestShowButton_Click(object sender, EventArgs e)
        {
            var request = boothExtensionRequestsComboBox.SelectedItem as BoothExtensionRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            boothExtensionRequestTitleTextBox.Text = request.Title;
            boothExtensionRequestContentTextBox.Text = request.Content;
            boothExtensionRequestBoothTextBox.Text = request.Booth.ToString();
            boothExtensionRequestAreaTextBox.Text = request.Area + "";
            boothExtensionResponseTextBox.Text = request.Response;
            ResetHelper.Refresh(boothExtensionAbilityListListBox, request.ProfessionsAssignments);

            boothExtensionRequestAgreeButton.Enabled = !request.Agreed;
            boothExtensionRequestResponseButton.Enabled = !request.Responsed;
            boothExtensionResponseTextBox.ReadOnly = request.Responsed;
        }
    }
}