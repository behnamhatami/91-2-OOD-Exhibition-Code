#region

using System;
using OOD.UI.ExhibitionPackage.ExhibitionDefinition;
using OOD.UI.Notification;
using OOD.UI.UserManagingPackage;

#endregion

namespace OOD.UI.Utility.Base
{
    public partial class MainWindow : BaseForm
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected void MainWindow_Load(object sender, EventArgs e)
        {
            Reload();
        }

        //IResetAble


        //IReloadAble
        public override void Reload()
        {
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


        public override int GetLevel()
        {
            return 2;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        //IPrecondition

        public override bool NeedUser()
        {
            return true;
        }

        public override bool NeedExhibition()
        {
            return false;
        }

        // Finish

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
            GoNext(new Home());
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

        private void ExhibitionFreezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new RequestForFreeze());
        }

        private void ExhibitionFreezPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new PollForFreeze());
        }

        private void UserManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new UserCrud());
        }

        private void ExhibitionStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new RequestForStart());
        }

        private void FinilizeExhibitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new RequestForFinish());
        }
    }
}