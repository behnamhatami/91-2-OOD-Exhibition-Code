using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRole;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class CreateExhibition : MainWindow
    {
        public CreateExhibition()
        {
            InitializeComponent();
        }

        public override bool NeedExhibition()
        {
            return false;
        }

        private void Reset()
        {
            ResetHelper.Empty(ExhibitionDescriptionTextBox, ExhibitionFullDescriptionTextBox, ExhibitionNameTextBox,
                ExhibitionCreatorTextBox);
            ResetHelper.Empty(ExhibitionChairListBox);
            var db = DataManager.DataContext;
            ExhibitionChairListBox.Items.Clear();
            ExhibitionChairListBox.Items.AddRange(db.Users.ToArray());
        }

        private void Exhibition_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = ExhibitionNameTextBox.Text;
            if (GeneralErrors.IsEmptyField(name, "نام نمایشگاه"))
                return;

            var description = ExhibitionDescriptionTextBox.Text;
            var fullDescription = ExhibitionFullDescriptionTextBox.Text;
            var owner = ExhibitionCreatorTextBox.Text;

            if (GeneralErrors.IsZero(ExhibitionChairListBox.SelectedItems.Count, "کاربر را به عنوان عضو اعضای عالی"))
                return;

            var exhibition = new Exhibition
            {
                Name = name,
                Description = description,
                FullDescription = fullDescription,
                Owner = owner,
                Feature = new Feature()
            };

            foreach (var item in ExhibitionChairListBox.CheckedItems)
            {
                var userExhibitionRole = new UserExhibitionRole
                {
                    User = (User) item,
                    ExhibitionRole = new ChairRole(),
                    Exhibition = exhibition
                };
                exhibition.UserExhibitionRoles.Add(userExhibitionRole);
            }

            var db = DataManager.DataContext;
            db.Exhibitions.Add(exhibition);
            db.SaveChanges();
            Utility.PopUp.PopUp.ShowSuccess("نمایشگاه جدید  با موفقت ساخته شد.");
            ExhibitionSelector.EnterExhibition(exhibition);
            Reload();
            Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}