#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class PollForFreeze : MainWindow
    {
        public PollForFreeze()
        {
            InitializeComponent();
        }

        // IResetAble

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
            var poll = exhibition.Polls.First();
            if (exhibition.HasRole<ChairRole>(user))
            {
                if (exhibition.State == ExhibitionState.FreezeStarted && poll.Closed == false)
                {
                    if (poll.Voters.Count(user1 => user1.Id == user.Id) == 0)
                    {
                        drawPoll(poll);
                        return true;
                    }
                    PopUp.ShowError("شما قبلا در این نظرسنجی شرکت کرده اید.");
                    return false;
                }
                GeneralErrors.Closed("انجماد");
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

        private void button2_Click(object sender, EventArgs e)
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
            var exhibition = Program.Exhibition;
            var poll = exhibition.Polls.First();
            var choiceId = int.Parse(radioButtons[index].Name);
            var choice = poll.PollChoices.
                First(pollChoice => pollChoice.Id == choiceId);

            choice.Vote();
            var pollUser = new PollUser
            {
                Poll = poll,
                User = Program.User
            };
            db.PollUsers.Add(pollUser);
            db.SaveChanges();
            PopUp.ShowSuccess("رای شما در سیستم ثبت گردید.");

            if (poll.Voters.Count() == exhibition.ChairUsers.Count())
            {
                PopUp.ShowSuccess("رای گیری به اتمام رسید.");
                poll.FinishDate = DateTime.Now;
                poll.Closed = true;

                if (poll.Voters.Count() == poll.PollChoices.First(pollChoice => pollChoice.Content == "بلی").Hit)
                {
                    exhibition.State = ExhibitionState.Freezed;
                    PopUp.ShowSuccess("انجماد با تایید تمام اعضای هیات مدیره به اتمام رسید.");
                }
                else
                {
                    exhibition.State = ExhibitionState.Configuration;
                    PopUp.ShowSuccess("انجماد به علت عدم توافق اعضای هیات مدیره تایید نگردید");
                }
                db.SaveChanges();
            }
            Close();
        }

        // Finish
    }
}