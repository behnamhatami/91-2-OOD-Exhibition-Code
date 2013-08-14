﻿#region

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
    public partial class RequestOutbox : MainWindow
    {
        public RequestOutbox()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
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

        public void SendRequest(Request request)
        {
            var db = DataManager.DataContext;
            db.Requests.Add(request);
            db.SaveChanges();
            PopUp.ShowSuccess("درخواست جدید ارسال گردید.");
        }

        // Exhibition Request

        private bool HasExhibitionRequestPreCondition()
        {
            return Program.Exhibition == null;
        }

        private void ExhibitionRequestReset()
        {
            ResetHelper.Empty(exhibitionRequestTitleTextBox, exhibitionRequestContentTextBox,
                exhibitionRequestExhibitionComboBox);
            ResetHelper.Refresh(exhibitionRequestExhibitionComboBox,
                DataManager.DataContext.Exhibitions
                    .Where(exhibition => exhibition.State == ExhibitionState.Started)
                    .ToArray());
        }

        private void exhibitionCancelButton_Click(object sender, EventArgs e)
        {
            ExhibitionRequestReset();
        }

        private void exhibitionRequestButton_Click(object sender, EventArgs e)
        {
            var title = exhibitionRequestTitleTextBox.Text;
            var content = exhibitionRequestContentTextBox.Text;
            var exhibition = exhibitionRequestExhibitionComboBox.SelectedItem as Exhibition;
            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "محتوای درخواست")
                || GeneralErrors.IsNull(exhibition, "نمایشگاه"))
                return;

            var request = new ExhibitionRequest
            {
                Closed = false,
                Content = content,
                CreationDate = DateTime.Today,
                Exhibition = exhibition,
                Title = title,
                User = Program.User
            };
            SendRequest(request);
            ExhibitionRequestReset();
        }

        // Saloon Request
        private bool HasSaloonRequestPreCondition()
        {
            return Program.Exhibition != null && Program.Exhibition.HasRole<ECustomerRole>(Program.User);
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
                Area = int.Parse(area),
                Closed = false,
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
            return Program.Exhibition != null && Program.Exhibition.HasRole<ECustomerRole>(Program.User);
        }

        private void BoothRequestReset()
        {
            ResetHelper.Empty(boothRequestTitleTextBox, boothRequestContentTextBox, boothRequestOperatorTextBox,
                boothRequestQualityComboBox, boothRequestForSellCheckBox, boothRequestForVitrinCheckBox,
                boothRequestForCommisionCheckBox, boothRequestPhoneCheckBox, boothRequestCardReaderCheckBox);
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

            if (GeneralErrors.IsEmptyField(title, "تیتر درخواست")
                || GeneralErrors.IsEmptyField(content, "محتوای درخواست")
                || GeneralErrors.IsNotValidInt(operatorCount, 1, "تعداد متصدیان")
                || GeneralErrors.IsNull(quality, "کیفیت"))
                return;

            var request = new BoothRequest
            {
                Closed = false,
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
            return Program.Exhibition != null;
        }

        private void InspectionRequestReset()
        {
            ResetHelper.Empty(inspectionRequestTitleTextBox, inspectionRequestContentTextBox,
                inspectionRequestSaloonComboBox, inspectionRequestBoothComboBox);
            inspectionRequestBoothComboBox.Items.Clear();
            ResetHelper.Refresh(inspectionRequestSaloonComboBox, Program.Exhibition.Saloons.ToArray());
        }

        private void inspectionCancelButton_Click(object sender, EventArgs e)
        {
            InspectionRequestReset();
        }

        private void inspectionRequestSaloonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetHelper.Empty(inspectionRequestBoothComboBox);
            var saloon = inspectionRequestSaloonComboBox.SelectedItem as Saloon;
            ResetHelper.Refresh(inspectionRequestBoothComboBox, saloon.Map.Booths.ToArray());
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
                Booth = booth,
                Closed = false,
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

        // List Requests

        private bool HasListRequestPreCondition()
        {
            return Program.Exhibition != null;
        }

        private void ListRequestReset()
        {
            ResetHelper.Empty(requestListComboBox, requestTitleTextBox, requestContentTextBox, requestResponseTextBox);
            ResetHelper.Refresh(requestListComboBox,
                Program.Exhibition.Requests
                    .Where(request => request.User.Id == Program.User.Id)
                    .ToArray());
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