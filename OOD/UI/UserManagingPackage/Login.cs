using System;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

namespace OOD.UI.UserManagingPackage
{
    public partial class Login : BaseForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            var user = UserErrors.GetUserOrError(username);
            if (user == null)
                return;

            if (UserErrors.AuthenticateIsNotValid(user, password))
                return;

            Hide();
            PasswordTextBox.Text = "";
            Program.User = user;
            new MainWindow().ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string username = "guest";

            var user = UserErrors.GetUserOrError(username);
            if (user == null)
                return;

            Hide();
            PasswordTextBox.Text = "";
            Program.User = user;
            using (var form = new MainWindow())
                form.ShowDialog();
            Show();
        }

        public static void ExitUser()
        {
            var user = Program.User;
            Utility.PopUp.PopUp.ShowSuccess(String.Format("شما از کاربر {0} خارج شدید.", user));
            Program.User = null;
        }
    }
}