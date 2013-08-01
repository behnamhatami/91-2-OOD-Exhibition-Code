using System;
using System.Linq;
using OOD.Model.ModelContext;
using OOD.Model.UserManaging;
using OOD.UI.Helper;
using OOD.UI.PopUp;

namespace OOD.UI.ExhibitionDefinition
{
    public partial class Exhibition : MainWindow
    {
        public Exhibition()
        {
            InitializeComponent();
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

            var exhibition = new Model.ExhibitionDefinition.Exhibition
            {
                Name = name,
                Description = description,
                FullDescription = fullDescription,
                Owner = owner,
            };

            foreach (var item in ExhibitionChairListBox.SelectedItems)
                exhibition.Users.Add((User) item);

            var db = DataManager.DataContext;
            db.Exhibitions.Add(exhibition);
            db.SaveChanges();
            PopUp.PopUp.ShowSuccess("نمایشگاه جدید  با موفقت ساخته شد.");
            Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}