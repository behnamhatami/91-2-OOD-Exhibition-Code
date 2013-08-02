using System;
using System.Linq;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
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

        public override bool ValidatePreConditions()
        {
            return true;
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
            var db = DataManager.DataContext;
            ExhibitionComboBox.Items.Clear();
            ExhibitionComboBox.Items.AddRange(db.Exhibitions.ToArray());
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            var exhibition = (Model.ExhibitionPackage.ExhibitionDefinition.Exhibition) ExhibitionComboBox.SelectedItem;
            if (GeneralErrors.IsNull(exhibition, "نمایشگاه"))
                return;
            EnterExhibition(exhibition);
            Close();
        }

        public static void EnterExhibition(Model.ExhibitionPackage.ExhibitionDefinition.Exhibition exhibition)
        {
            Program.Exhibition = exhibition;
            PopUp.ShowSuccess(String.Format("شما وارد نمایشگاه {0} شدید.", exhibition));
        }

        public static void ExitExhibition()
        {
            var exhibition = Program.Exhibition;
            PopUp.ShowSuccess(String.Format("شما از نمایشگاه {0} خارج شدید.", exhibition));
            Program.Exhibition = null;
        }
    }
}