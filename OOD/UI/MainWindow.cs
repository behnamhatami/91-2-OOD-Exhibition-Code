using System;
using System.Windows.Forms;
using OOD.UI.ExhibitionDefinition;
using OOD.UI.UserManaging;

namespace OOD.UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected void MainWindow_Load(object sender, EventArgs e)
        {
            if (Program.User != null)
                label2.Text = String.Format("شما با نام کاربری \"{0}\" وارد سیستم شده‌اید.", Program.User.FirstName);
            label3.Text = String.Format("{0:yyyy MMMM dd}", DateTime.Today);
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.User = null;
            Close();
        }

        private void Restore()
        {
            if (Program.User == null)
                Close();
            else Show();
        }

        private void UserManagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            using (var form = new UserCrud())
                form.ShowDialog();
            Restore();
        }

        private void ExhibitionDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            using (var form = new Exhibition())
                form.ShowDialog();
            Restore();
        }
    }
}