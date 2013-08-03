#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class CreateExhibition : MainWindow
    {
        public CreateExhibition()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            ResetHelper.Empty(ExhibitionDescriptionTextBox, ExhibitionFullDescriptionTextBox, ExhibitionNameTextBox,
                ExhibitionCreatorTextBox);
            var db = DataManager.DataContext;
            ResetHelper.Refresh(ExhibitionChairListBox, db.Users.ToArray());
        }


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
            if (!base.ValidatePreConditions())
                return false;

            var user = Program.User;
            if (user.UserRole is InternalRole)
                return true;
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


        private void button1_Click(object sender, EventArgs e)
        {
            var name = ExhibitionNameTextBox.Text;
            if (GeneralErrors.IsEmptyField(name, "نام نمایشگاه"))
                return;

            var description = ExhibitionDescriptionTextBox.Text;
            var fullDescription = ExhibitionFullDescriptionTextBox.Text;
            var owner = ExhibitionCreatorTextBox.Text;

            if (GeneralErrors.IsZero(ExhibitionChairListBox.CheckedItems.Count, "کاربر را به عنوان عضو اعضای عالی"))
                return;


            var db = DataManager.DataContext;
            var exhibition = new Exhibition
            {
                Name = name,
                Description = description,
                FullDescription = fullDescription,
                Owner = owner,
                Feature = new Feature(),
                Configuration = new Model.ExhibitionPackage.ExhibitionDefinition.Configuration()
            };

            foreach (var item in ExhibitionChairListBox.CheckedItems)
            {
                var userExhibitionRole = new UserExhibitionRole
                {
                    User = (User) item,
                    ExhibitionRole = new ChairRole(),
                    Exhibition = exhibition
                };
                db.UserExhibitionRoles.Add(userExhibitionRole);
//                exhibition.UserExhibitionRoles.Add(userExhibitionRole);
            }

            var poll = new Poll
            {
                Question = "آیا شما با پیکربندی موجود موافق هستید؟",
                CreationDate = DateTime.Today,
                Exhibition = exhibition,
                FinishDate = DateTime.Today.AddYears(1)
            };

            var pollChoice1 = new PollChoice
            {
                Content = "بلی",
                Poll = poll,
                Hit = 0,
            };
            var pollChoice2 = new PollChoice
            {
                Content = "خیر",
                Poll = poll,
                Hit = 0,
            };


            db.Exhibitions.Add(exhibition);
            db.Polls.Add(poll);
            db.PollChoices.Add(pollChoice1);
            db.PollChoices.Add(pollChoice2);

            db.SaveChanges();
            PopUp.ShowSuccess("نمایشگاه جدید  با موفقت ساخته شد.");
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