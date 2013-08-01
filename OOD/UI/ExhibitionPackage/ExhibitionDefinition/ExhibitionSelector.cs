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
            Close();
            EnterExhibition(exhibition);
        }

        public static void EnterExhibition(Model.ExhibitionPackage.ExhibitionDefinition.Exhibition exhibition)
        {
            Program.Exhibition = exhibition;
            Utility.PopUp.PopUp.ShowSuccess(String.Format("شما وارد نمایشگاه {0} شدید.", exhibition));
        }

        public static void ExitExhibition()
        {
            var exhibition = Program.Exhibition;
            Utility.PopUp.PopUp.ShowSuccess(String.Format("شما از نمایشگاه {0} خارج شدید.", exhibition));
            Program.Exhibition = null;
        }
    }
}