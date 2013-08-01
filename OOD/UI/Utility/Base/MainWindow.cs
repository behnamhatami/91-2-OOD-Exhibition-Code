using System;
using System.Windows.Forms;
using OOD.UI.ExhibitionPackage.ExhibitionDefinition;
using OOD.UI.UserManagingPackage;
using OOD.UI.Utility.Interface;

namespace OOD.UI.Utility.Base
{
    public partial class MainWindow : Form, IPreCondition, IReloadable
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            if (NeedExhibition() && Program.Exhibition == null)
                GoNext(new ExhibitionSelector());
            if (Program.User != null)
                label2.Text = String.Format("شما با نام کاربری \"{0}\" وارد سیستم شده‌اید.", Program.User.FirstName);

            if (Program.Exhibition != null)
                label0.Text = String.Format("نمایشگاه {0}", Program.Exhibition);
            else
                label0.Text = "";

            label3.Text = String.Format("{0:yyyy MMMM dd}", DateTime.Today);

            if (Program.Exhibition == null)
                ExhibitionExitToolStripMenuItem.Enabled = false;
            else ExhibitionExitToolStripMenuItem.Enabled = true;
        }

        public virtual bool NeedExhibition()
        {
            return false;
        }

        protected void MainWindow_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void GoNext(Form form)
        {
            if (form.GetType() == GetType()) return;
            Hide();
            form.ShowDialog();
            form.Dispose();
            Restore();
        }

        private void Restore()
        {
            if (NeedExhibition() && Program.Exhibition == null)
            {
                Close();
                return;
            }
            if (Program.User == null)
            {
                Close();
                return;
            }
            Reload();
            Show();
        }

        private void UserManagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new UserCrud());
        }

        private void ExhibitionDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new CreateExhibition());
        }

        private void BackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new MainWindow());
        }

        private void ExhibitionConfigurtionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new Configuration());
        }

        private void ExhitUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login.ExitUser();
            Restore();
        }

        private void ExhibitionExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExhibitionSelector.ExitExhibition();
            Restore();
        }
    }
}