#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinitionPackage
{
    public partial class ExhibitionSelector : BaseForm
    {
        public ExhibitionSelector()
        {
            InitializeComponent();
        }

        // IResetAble

        // IPrecondition

        public override bool NeedUser()
        {
            return true;
        }

        public override bool NeedExhibition()
        {
            return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 4;
        }

        public override bool RestoreAble()
        {
            return false;
        }

        // Finish


        private void ExhibitionSelector_Load(object sender, EventArgs e)
        {
            ResetHelper.Refresh(ExhibitionComboBox, DataManager.DataContext.Exhibitions);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            var exhibition = (Exhibition) ExhibitionComboBox.SelectedItem;
            if (GeneralErrors.IsNull(exhibition, "نمایشگاه"))
                return;
            EnterExhibition(exhibition);
            Close();
        }

        public static void EnterExhibition(Exhibition exhibition)
        {
            Program.ProcessManager = new ProcessManager(Program.Exhibition);
            PopUp.ShowSuccess(String.Format("شما وارد نمایشگاه {0} شدید.", exhibition));
        }

        public static void ExitExhibition()
        {
            var exhibition = Program.Exhibition;
            PopUp.ShowSuccess(String.Format("شما از نمایشگاه {0} خارج شدید.", exhibition));
            Program.Exhibition = null;
            Program.ProcessManager = null;
        }
    }
}