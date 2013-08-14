#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.Notification
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

            ExhibitionRequestReset();
            if (HasExhibitionRequestPreCondition())
                tabControl1.Controls.Add(exhibitionRequestTabPage);

            SaloonRequestReset();
            if (HasSaloonRequestPreCondition())
                tabControl1.Controls.Add(saloonRequestTabPage);

            BoothRequestReset();
            if (HasBoothRequestPreCondition())
                tabControl1.Controls.Add(boothRequestTabPage);

            InspectionRequestReset();
            if (HasInspectionRequestPreCondition())
                tabControl1.Controls.Add(InspectionRequestTabPage);
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

        private void AgreeResponse(Request request)
        {
            request.Agreed = true;
            request.NotifyAgree();
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("با درخواست موافقت گردید.");
        }

        // Exhibition Request

        private bool HasExhibitionRequestPreCondition()
        {
            return Program.Exhibition.HasRole<ExecutionRole>(Program.User);
        }

        private void ExhibitionRequestReset()
        {
            ResetHelper.Empty(exhibitionRequestsComboBox, exhibitionRequestTitleTextBox, exhibitionRequestContentTextBox,
                exhibitionRequestResponseTextBox);
            ResetHelper.Refresh(exhibitionRequestsComboBox,
                Program.Exhibition.GetSpecialRequests<ExhibitionRequest>().ToArray());
            exhibitionRequestResponseButton.Enabled = false;
            exhibitionAgreeButton.Enabled = false;
        }

        private void exhibitionShowButton_Click(object sender, EventArgs e)
        {
            var request = exhibitionRequestsComboBox.SelectedItem as ExhibitionRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            exhibitionRequestTitleTextBox.Text = request.Title;
            exhibitionRequestContentTextBox.Text = request.Content;
            exhibitionRequestResponseTextBox.Text = request.Response;
            exhibitionRequestResponseButton.Enabled = !request.Responsed;
            exhibitionRequestResponseTextBox.ReadOnly = request.Responsed;
            exhibitionAgreeButton.Enabled = !request.Agreed;
        }

        private void exhibitionRequestResponse_Click(object sender, EventArgs e)
        {
            var request = exhibitionRequestsComboBox.SelectedItem as ExhibitionRequest;
            var response = exhibitionRequestResponseTextBox.Text;
            if (GeneralErrors.IsEmptyField(response, "پاسخ"))
                return;

            SendResponse(request, response);
            ExhibitionRequestReset();
        }

        private void exhibitionAgreeButton_Click(object sender, EventArgs e)
        {
            var request = exhibitionRequestsComboBox.SelectedItem as ExhibitionRequest;
            var user = request.User;
            var exhibition = request.Exhibition;
            var userExhibitionRole = new UserExhibitionRole
            {
                Exhibition = exhibition,
                ExhibitionRole = new ECustomerRole(),
                User = user
            };
            DataManager.DataContext.UserExhibitionRoles.Add(userExhibitionRole);
            userExhibitionRole.NotifyAdd();
            AgreeResponse(request);
        }

        // Saloon Request

        private bool HasSaloonRequestPreCondition()
        {
            return Program.Exhibition.HasRole<BoothManagerRole>(Program.User);
        }

        private void SaloonRequestReset()
        {
            ResetHelper.Empty(saloonRequestComboBox, saloonRequestTitleTextBox, saloonRequestContentTextBox,
                saloonRequestNameTextBox, saloonRequestAreaTextBox, saloonRequestHeightTextBox,
                saloonRequestWidthTextBox, saloonRequestResponseTextBox);
            ResetHelper.Refresh(exhibitionRequestsComboBox,
                Program.Exhibition.GetSpecialRequests<SaloonRequest>().ToArray());

            saloonAgreeButton.Enabled = false;
            saloonRequestResponseButton.Enabled = false;
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
            DataManager.DataContext.Saloons.Add(saloon);
            AgreeResponse(request);
        }

        // Booth Request

        private bool HasBoothRequestPreCondition()
        {
            return Program.Exhibition.HasRole<BoothManagerRole>(Program.User);
        }

        private void BoothRequestReset()
        {
            ResetHelper.Empty(boothRequestComboBox, boothRequestTitleTextBox, boothRequestContentTextBox,
                boothRequestOperatorTextBox, boothRequestQualityTextBox, boothRequestForSellCheckBox,
                boothRequestForVitrinCheckBox, boothRequestForCommisionCheckBox, boothRequestHasPhoneCheckBox,
                boothRequestHasCardReaderCheckBox, boothRequestResponseTextBox);

            ResetHelper.Refresh(boothRequestComboBox, Program.Exhibition.GetSpecialRequests<BoothRequest>().ToArray());

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

            throw new Exception("Not Yet Implemented.");
        }

        // Inspection Request
        private bool HasInspectionRequestPreCondition()
        {
            return Program.Exhibition.HasRole<InspectorRole>(Program.User);
        }

        private void InspectionRequestReset()
        {
            ResetHelper.Empty(inspectionRequestsComboBox, inspectionRequestSaloonTextBox, inspectionRequestBoothTextBox,
                inspectionRequestJudgeTypeComboBox, inspectionRequestFineTextBox, inspectionRequestResponseTextBox);

            ResetHelper.Refresh(inspectionRequestsComboBox,
                Program.Exhibition.GetSpecialRequests<InspectionRequest>().ToArray());
            ResetHelper.Refresh(inspectionRequestJudgeTypeComboBox, JudgeTypeWrapper.JudgeTypes);

            inspectionRequestResponseButton.Enabled = false;
        }

        private void inspectionShowButton_Click(object sender, EventArgs e)
        {
            var request = inspectionRequestsComboBox.SelectedItem as InspectionRequest;
            if (GeneralErrors.IsNull(request, "درخواست"))
                return;

            inspectionRequestSaloonTextBox.Text = request.Booth.Map.Saloon.ToString();
            inspectionRequestBoothTextBox.Text = request.Booth.ToString();

            inspectionRequestJudgeTypeComboBox.Text = JudgeTypeWrapper.GetWrapper(request.JudgeType).ToString();
            inspectionRequestJudgeTypeComboBox.Enabled = !request.Responsed;
            inspectionRequestFineTextBox.Visible = request.JudgeType == JudgeType.Fine;
            inspectionRequestFineTextBox.Enabled = !request.Responsed;
            inspectionRequestResponseButton.Enabled = !request.Responsed;
            inspectionRequestResponseTextBox.ReadOnly = request.Responsed;
        }

        private void inspectionRequestJudgeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var judgeType = (inspectionRequestJudgeTypeComboBox.SelectedItem as JudgeTypeWrapper).Type;
            inspectionRequestFineTextBox.Visible = judgeType == JudgeType.Fine;
        }

        private void inspectionRequestResponseButton_Click(object sender, EventArgs e)
        {
            var request = inspectionRequestsComboBox.SelectedItem as InspectionRequest;
            var response = inspectionRequestResponseTextBox.Text;
            var fine = inspectionRequestFineTextBox.Text;
            var judgeType = inspectionRequestJudgeTypeComboBox.SelectedItem as JudgeTypeWrapper;
            if (GeneralErrors.IsEmptyField(response, "پاسخ")
                || GeneralErrors.IsNull(judgeType, "نوع قضاوت")
                || (judgeType.Type == JudgeType.Fine && GeneralErrors.IsNotValidInt(fine, 0, "هیزان جریمه")))
                return;

            request.JudgeType = judgeType.Type;
            if (request.JudgeType == JudgeType.Fine)
                request.Fine = int.Parse(fine);
            SendResponse(request, response);
            InspectionRequestReset();


            switch (request.JudgeType)
            {
                case JudgeType.NothingImportant:
                    return;
                case JudgeType.Fine:
                    request.User.Fine(request);
                    DataManager.DataContext.SaveChanges();
                    return;
                case JudgeType.Deposal:
                    var db = DataManager.DataContext;
                    var exhibition = request.Exhibition;
                    var user = request.User;
                    var userExhibitionRole = db.UserExhibitionRoles
                        .Where(role => role.Exhibition.Id == exhibition.Id)
                        .Where(role => role.User.Id == user.Id)
                        .First(role => role.ExhibitionRole is ECustomerRole);
                    userExhibitionRole.NotifyRemove();
                    db.UserExhibitionRoles.Remove(userExhibitionRole);
                    db.SaveChanges();
                    return;
            }
        }
    }
}