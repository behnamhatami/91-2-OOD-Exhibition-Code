using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionRole;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class Configuration : MainWindow
    {
        public Configuration()
        {
            InitializeComponent();
        }

        public override bool NeedExhibition()
        {
            return true;
        }

        private void Configuration_Load(object sender, System.EventArgs e)
        {
            ResetFeaturePage();
            ResetRolePage();
        }

        // Feature

        private void ResetFeaturePage()
        {
            var exhibition = Program.Exhibition;
            ResetHelper.Empty(InitialConfigurationComboBox);
            InitialConfigurationComboBox.Items.Clear();
            InitialConfigurationComboBox.Items.AddRange(DataManager.DataContext.Exhibitions.ToArray());

            if (exhibition != null)
            {
                var feature = exhibition.Feature;
                PostOfficeCheckBox.Checked = feature.HasPostOffice;
                WareHouseCheckBox.Checked = feature.HasWareHouse;
                SellRadioButton.Checked = feature.HasSell;
                NoSellRadioButton.Checked = !feature.HasSell;
                DifferentBoothCheckBox.Checked = feature.HasDifferentBooth;
            }
            else
            {
                ResetHelper.Empty(PostOfficeCheckBox, WareHouseCheckBox, SellRadioButton, DifferentBoothCheckBox);
                NoSellRadioButton.Checked = true;
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ResetFeaturePage();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var feature = Program.Exhibition.Feature;
            feature.HasPostOffice = PostOfficeCheckBox.Checked;
            feature.HasWareHouse = WareHouseCheckBox.Checked;
            feature.HasSell = SellRadioButton.Checked;
            feature.HasDifferentBooth = DifferentBoothCheckBox.Checked;
            var db = DataManager.DataContext;
            db.SaveChanges();
            PopUp.ShowSuccess("تغییرات مد نظر با موفقیت اعمال گردید.");
            ResetFeaturePage();
        }

        // Rolls

        private void ResetRolePage()
        {
            ResetHelper.Empty(ExhibitionRoleComboBox, ExhibitionRoleUserComboBox);
            ResetHelper.Empty(ExhibitionRoleUserlistBox);

            var db = DataManager.DataContext;

            ExhibitionRoleUserlistBox.Items.Clear();
            ExhibitionRoleUserlistBox.Items.AddRange(db.UserExhibitionRoles.ToArray());

            ExhibitionRoleComboBox.Items.Clear();
            ExhibitionRoleComboBox.Items.AddRange(ExhibitionRole.GetChoices());

            ExhibitionRoleUserComboBox.Items.Clear();
            ExhibitionRoleUserComboBox.Items.AddRange(db.UserExhibitionRoles.ToArray());
        }
    }
}