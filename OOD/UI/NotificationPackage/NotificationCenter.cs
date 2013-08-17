#region

using System;
using System.Linq;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.NotificationPackage
{
    public partial class NotificationCenter : MainWindow
    {
        public NotificationCenter()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            base.Reset();
            var user = Program.User;
            var exhibition = Program.Exhibition;

            tabControl1.Controls.Clear();

            if (exhibition != null)
            {
                ResetHelper.Refresh(userNotificationListBox,
                    user.Notifications
                        .Where(notification => notification.Exhibition.Id == exhibition.Id)
                        .OrderBy(notification => notification.CreationDate));

                ResetHelper.Refresh(exhibitionNotificationListBox,
                    exhibition.Notifications
                        .Where(notification => notification.User.Id == Program.System.Id)
                        .OrderBy(notification => notification.CreationDate));

                tabControl1.Controls.Add(exhibitionNotificationPage);
            }
            else
            {
                ResetHelper.Refresh(userNotificationListBox,
                    user.Notifications
                        .OrderBy(notification => notification.CreationDate));
            }
            tabControl1.Controls.Add(userNotificationPage);
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

        //IReloadAble

        public override void Reload()
        {
            base.Reload();
            Reset();
        }


        public override int GetLevel()
        {
            return 3;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        // Finish


        private void showButton1_Click(object sender, EventArgs e)
        {
            var notification = exhibitionNotificationListBox.SelectedItem as Model.NotificationPackage.Notification;
            if (GeneralErrors.IsNull(notification, "رخداد"))
                return;

            exhibitionNotificationTitleTextBox.Text = notification.Title;
            exhibitionNotificationCreationDateTextBox.Text = notification.CreationDate + "";
            exhibitionNotificationContentTextBox.Text = notification.Content;
        }

        private void showButton2_Click(object sender, EventArgs e)
        {
            var notification = userNotificationListBox.SelectedItem as Model.NotificationPackage.Notification;
            if (GeneralErrors.IsNull(notification, "رخداد"))
                return;

            userNotificationTitleTextBox.Text = notification.Title;
            userNotificationCreationDateTextBox.Text = notification.CreationDate + "";
            userNotificationContentTextBox.Text = notification.Content;
        }
    }
}