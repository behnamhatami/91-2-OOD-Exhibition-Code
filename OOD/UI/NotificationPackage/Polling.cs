#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.NotificationPackage
{
    public partial class Polling : MainWindow
    {
        public Polling()
        {
            InitializeComponent();
        }


        // IResetAble

        public override void Reset()
        {
            var exhibition = Program.Exhibition;
            ResetHelper.Refresh(pollListComboBox, exhibition.Polls.Where(poll => !poll.Closed && poll.Started));
            resetPoll();
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

            var exhibition = Program.Exhibition;
            var processManager = Program.ProcessManager;
            if (exhibition.State == ExhibitionState.Started
                && processManager.IsProcessRunning(ProcessType.Poll))
                return true;
            GeneralErrors.Closed("رای دهی");
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

        private void showButton_Click(object sender, EventArgs e)
        {
            var poll = pollListComboBox.SelectedItem as Poll;
            if (GeneralErrors.IsNull(poll, "نظرسنجی"))
                return;

            resetPoll();
            drawPoll(poll);

            var user = Program.User;
            var db = DataManager.DataContext;
            if (db.PollUsers
                .FirstOrDefault(pollUser1 => pollUser1.User.Id == user.Id
                                             && pollUser1.Poll.Id == poll.Id) != null)
                pollingButton.Enabled = false;
        }

        private void pollingButton_Click(object sender, EventArgs e)
        {
            var index = -1;
            for (var i = 0; index == -1 && i < radioButtons.Length; i++)
                if (radioButtons[i].Checked)
                    index = i;

            if (index == -1)
            {
                PopUp.ShowError("شما باید یک گزینه را انتخاب نمایید.");
                return;
            }

            var db = DataManager.DataContext;
            var choiceId = int.Parse(radioButtons[index].Name);
            var choice = db.PollChoices.
                First(pollChoice => pollChoice.Id == choiceId);
            var poll = choice.Poll;

            choice.Vote();
            var pollUser = new PollUser
            {
                Poll = poll,
                User = Program.User
            };
            db.PollUsers.Add(pollUser);
            db.SaveChanges();
            PopUp.ShowSuccess("رای شما در سیستم ثبت گردید.");
            Reset();
        }

        // Finish
    }
}