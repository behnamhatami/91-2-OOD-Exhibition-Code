#region

using System;
using OOD.UI.ExhibitionPackage.ExhibitionDefinition;
using OOD.UI.Notification;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.UserManagingPackage
{
    public partial class Login : BaseForm
    {
        public Login()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            PasswordTextBox.Text = "";
        }

        // IPrecondition

        public override bool NeedUser()
        {
            return false;
        }

        public override bool NeedExhibition()
        {
            return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 1;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        // Finish


        private void button1_Click(object sender, EventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            var user = UserErrors.GetUserOrError(username);
            if (user == null)
                return;

            if (UserErrors.AuthenticateIsNotValid(user, password))
                return;

            Program.User = user;
            Reset();
            GoNext(new Home());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string username = "guest";

            var user = UserErrors.GetUserOrError(username);
            if (user == null)
                return;

            Program.User = user;
            Reset();
            GoNext(new Home());
        }

        public static void ExitUser()
        {
            ExhibitionSelector.ExitExhibition();
            var user = Program.User;
            PopUp.ShowSuccess(String.Format("شما از کاربر {0} خارج شدید.", user));
            Program.User = null;
        }
    }
}