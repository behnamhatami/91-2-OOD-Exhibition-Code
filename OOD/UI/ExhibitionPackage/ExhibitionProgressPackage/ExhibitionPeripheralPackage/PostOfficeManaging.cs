#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage
{
    public partial class PostOfficeManaging : MainWindow
    {
        public PostOfficeManaging()
        {
            InitializeComponent();
        }


        // IResetAble

        public override void Reset()
        {
            CreatePageReset();
            ListPageReset();
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
            var processManager = Program.ProcessManager;
            if (exhibition.Feature.HasPostOffice == false)
            {
                PopUp.ShowError("نمایشگاه دارای پست نمی باشد.");
                return false;
            }

            if (exhibition.HasRole<PostKeeperRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started
                    && processManager.IsProcessRunning(ProcessType.PostKeeping))
                    return true;
                GeneralErrors.Closed("پست");
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

        private void CreatePageReset()
        {
            ResetHelper.Empty(createItemTypeTextBox, createItemDestinationTextBox, createItemDateTimePicker);
        }

        private void ListPageReset()
        {
            ResetHelper.Empty(listIdTextBox, listTypeTextBox, listDestinationTextBox, listReleaseDateTextBox);
            var post = Program.Exhibition.PostOffice;
            ResetHelper.Refresh(listListBox, post.PostItems);
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            var type = createItemTypeTextBox.Text;
            var destination = createItemDestinationTextBox.Text;
            var date = createItemDateTimePicker.Value;
            if (GeneralErrors.IsEmptyField(type, "نوع کالا")
                || GeneralErrors.IsEmptyField(destination, "آدرس ارسالی")
                || GeneralErrors.IsNull(date, "تاریخ ارسال"))
                return;

            var office = Program.Exhibition.PostOffice;
            var postItem = new PostItem
            {
                Destination = destination,
                PostOffice = office,
                ReleaseDate = date,
                Type = type
            };
            var db = DataManager.DataContext;
            db.PostItems.Add(postItem);
            db.SaveChanges();
            PopUp.ShowSuccess("کالای درخواستی ارسال گردید.");
            Reset();
        }

        private void listShowButton_Click(object sender, EventArgs e)
        {
            var postItem = listListBox.SelectedItem as PostItem;
            if (GeneralErrors.IsNull(postItem, "کالای پستی"))
                return;

            listIdTextBox.Text = postItem.Id + "";
            listTypeTextBox.Text = postItem.Type;
            listReleaseDateTextBox.Text = postItem.ReleaseDate.ToString();
            listDestinationTextBox.Text = postItem.Destination;
        }
    }
}