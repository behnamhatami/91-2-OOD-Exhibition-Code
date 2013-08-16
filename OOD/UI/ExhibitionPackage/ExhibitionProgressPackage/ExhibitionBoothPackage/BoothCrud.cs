#region

using System;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public partial class BoothCrud : MainWindow
    {
        public BoothCrud()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            tabControl1.Controls.Clear();

            EditSaloonReset();
            if (HasEditSaloonPreCondition())
                tabControl1.Controls.Add(editSaloonTabPage);
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
            if (exhibition.HasRole<BoothManagerRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("مدیریت غرفه");
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

        private void boothActionButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var booth = GetBooth(button, editSaloonListComboBox.SelectedItem as Saloon);
            booth.SwitchState();
            ButtonReDraw(booth, button);
            DataManager.DataContext.SaveChanges();
        }

        // Finish

        // Edit Saloon

        private bool HasEditSaloonPreCondition()
        {
            return Program.Exhibition.HasRole<BoothManagerRole>(Program.User);
        }

        private void EditSaloonReset()
        {
            ResetHelper.Empty(editSaloonListComboBox);
            ResetHelper.Refresh(editSaloonListComboBox, Program.Exhibition.Saloons);
            flowLayoutPanel1.Controls.Clear();
        }

        private void editSaloonShowButton_Click(object sender, EventArgs e)
        {
            var saloon = editSaloonListComboBox.SelectedItem as Saloon;
            if (GeneralErrors.IsNull(saloon, "سالن"))
                return;
            DrawSaloon(saloon, flowLayoutPanel1);
            foreach (var control in flowLayoutPanel1.Controls)
                (control as Button).Click += boothActionButton_Click;
        }
    }
}