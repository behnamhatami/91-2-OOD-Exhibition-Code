using System;
using System.Windows.Forms;
using OOD.UI.PopUp;

namespace OOD.UI.UserManaging
{
    public partial class Login : Form
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
            using(var form = new MainWindow())
                form.ShowDialog();
            Show();
        }
    }
}