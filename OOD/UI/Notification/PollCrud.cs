#region

using System;
using System.Collections.Generic;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.Notification
{
    public partial class PollCrud : MainWindow
    {
        private List<String> _choices;
        private Polling _poll;

        public PollCrud()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            CreatePollTabPageReset();
            ListPollTabPageReset();
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
            if (exhibition.HasRole<ExecutionRole>(user) || exhibition.HasRole<ECustomerRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("مدیریت نظرسنجی");
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

        // Create Poll
        public void CreatePollTabPageReset()
        {
            _poll = new Polling();
            _choices = new List<string>();
            ResetHelper.Empty(createPollQuestionTextBox, createPollFinishByDateCheckBox, createPollDateTimePicker,
                createPollNewPollChoiceTextBox, createPollPollChoiceListBox);
            ResetHelper.Refresh(createPollPollChoiceListBox, _choices.ToArray());
            createPollDateTimePicker.Enabled = false;
        }

        private void createPollFinishByDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            createPollDateTimePicker.Enabled = !createPollDateTimePicker.Enabled;
        }

        private void createPollAddPollChoiceButton_Click(object sender, EventArgs e)
        {
            var content = createPollNewPollChoiceTextBox.Text;
            if (GeneralErrors.IsEmptyField(content, "گزینه"))
                return;

            _choices.Add(content);
            ResetHelper.Refresh(createPollPollChoiceListBox, _choices.ToArray());
        }

        private void createPollRemovePollChoiceButton_Click(object sender, EventArgs e)
        {
            if (GeneralErrors.IsZero(createPollPollChoiceListBox.SelectedItems.Count, "گزینه"))
                return;
            foreach (var content in createPollPollChoiceListBox.SelectedItems)
                _choices.Remove(content as String);
            ResetHelper.Refresh(createPollPollChoiceListBox, _choices.ToArray());
        }

        private void createPollCancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void createPollcreateButton_Click(object sender, EventArgs e)
        {
            var question = createPollQuestionTextBox.Text;
            var finishByDate = createPollFinishByDateCheckBox.Checked;
            var creationDate = DateTime.Today;
            var finishDate = DateTime.Today;
            if (finishByDate)
                finishDate = createPollDateTimePicker.Value;
            if (GeneralErrors.IsEmptyField(question, "سوال نظرسنجی")
                || GeneralErrors.IsNull(finishDate, "تاریخ پایان"))
                return;

            var poll = new Poll
            {
                Closed = false,
                CreationDate = creationDate,
                CreatorUser = Program.User,
                FinishDate = finishDate,
                Exhibition = Program.Exhibition,
                FinishByDate = finishByDate,
                Question = question,
                Started = false
            };

            var db = DataManager.DataContext;
            foreach (var content in _choices)
                db.PollChoices.Add(new PollChoice
                {
                    Content = content,
                    Hit = 0,
                    Poll = poll
                });
            db.Polls.Add(poll);
            db.SaveChanges();
            PopUp.ShowSuccess("نظرسنجی جدید ساخته شد.");
            Reset();
        }

        // List Poll

        public void ListPollTabPageReset()
        {
            ResetHelper.Empty(listPollQuestionTextBox, listPollStateTextBox, listPollFinishDateTextBox,
                listPollPollChoiceListBox);
            var user = Program.User;
            var exhibition = Program.Exhibition;
            var fullAccess = exhibition.HasRole<ExecutionRole>(user);

            if (fullAccess)
                ResetHelper.Refresh(listPollListComboBox,
                    Program.Exhibition.Polls);
            else
                ResetHelper.Refresh(listPollListComboBox,
                    Program.Exhibition.Polls.Where(poll => poll.CreatorUser.Id == Program.User.Id));

            listPollPollChoiceListBox.Items.Clear();
            listPollFinishButton.Enabled = false;
            listPollStartButton.Enabled = false;
        }

        private void listPollShowButton_Click(object sender, EventArgs e)
        {
            var poll = listPollListComboBox.SelectedItem as Poll;
            if (GeneralErrors.IsNull(poll, "نظرسنجی"))
                return;

            listPollQuestionTextBox.Text = poll.Question;
            listPollFinishDateTextBox.Text = poll.FinishDate.ToString();
            listPollStateTextBox.Text = poll.Closed ? "بسته شده" : "باز";

            var fullAccess = Program.Exhibition.HasRole<ExecutionRole>(Program.User);
            listPollStartButton.Enabled = !poll.Started && fullAccess;
            listPollFinishButton.Enabled = poll.Started && poll.FinishByDate == false && poll.Closed == false;
            ResetHelper.Refresh(listPollPollChoiceListBox, poll.PollChoices);
        }

        private void listPollFinishButton_Click(object sender, EventArgs e)
        {
            var poll = listPollListComboBox.SelectedItem as Poll;
            poll.Closed = true;
            poll.FinishDate = DateTime.Today;
            PopUp.ShowSuccess("نظرسنجی اتمام یافت.");
            DataManager.DataContext.SaveChanges();
            Reset();
        }

        private void listPollStartButton_Click(object sender, EventArgs e)
        {
            var poll = listPollListComboBox.SelectedItem as Poll;
            poll.Started = true;
            PopUp.ShowSuccess("نظرسنجی آغاز شد.");
            DataManager.DataContext.SaveChanges();
            Reset();
        }
    }
}