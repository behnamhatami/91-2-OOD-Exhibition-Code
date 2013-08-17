#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.NotificationPackage
{
    public partial class VisitorReportCreation : MainWindow
    {
        public VisitorReportCreation()
        {
            InitializeComponent();
        }

        public override void Reset()
        {
            base.Reset();
            ResetHelper.Empty(visitorReportContentTextBox);
            ResetHelper.Refresh(visitorReportBoothsComboBox, DataManager.DataContext.Booths
                .Where(booth => booth.Map.Saloon.Exhibition.Id == Program.Exhibition.Id)
                .Where(booth => booth.Request != null));
        }

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

            var exhibition = Program.Exhibition;
            var processManager = Program.ProcessManager;
            if (exhibition.State == ExhibitionState.Started
                && processManager.IsProcessRunning(ProcessType.VisitorReport))
                return true;
            GeneralErrors.Closed("گزارش مردمی");
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

        private void visitorReportCancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void visitorReportOkeyButton_Click(object sender, EventArgs e)
        {
            var booth = visitorReportBoothsComboBox.SelectedItem as Booth;
            var content = visitorReportBoothsComboBox.Text;

            if (GeneralErrors.IsEmptyField(content, "محتوای گزارش")
                || GeneralErrors.IsNull(booth, "غرفه"))
                return;
            var db = DataManager.DataContext;
            db.VisitorReports.Add(
                new VisitorReport
                {
                    Booth = booth,
                    Content = content
                });
            db.SaveChanges();
            PopUp.ShowSuccess("گزارش در سیستم ثبت گردید");
            Reset();
        }
    }
}