#region

using System;
using OOD.UI.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage;
using OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.UI.NotificationPackage;
using OOD.UI.UserManagingPackage;

#endregion

namespace OOD.UI.UtilityPackage.Base
{
    public partial class MainWindow : BaseForm
    {
        public MainWindow()
        {
            InitializeComponent();
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

            label3.Text = String.Format("{0:yyyy MMMM dd}", DateTimeManager.Today);

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

        private void NotifcationCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new NotificationCenter());
        }

        private void PostOfficeManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new PostOfficeManaging());
        }

        private void WareHouseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new WareHouseManaging());
        }

        private void PaymentManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new PaymentManagemenet());
        }

        private void PollCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new PollCrud());
        }

        private void PollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new Polling());
        }

        private void NewsCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new CallCreation());
        }

        private void RequestInboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new RequestInbox());
        }

        private void RequestOutboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new RequestOutbox());
        }

        private void CallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new CallCreation());
        }

        private void BoothManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoNext(new BoothCrud());
        }
    }
}