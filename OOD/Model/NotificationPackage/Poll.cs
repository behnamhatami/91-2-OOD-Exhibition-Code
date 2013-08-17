#region

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.NotificationPackage
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool Closed { get; set; }
        public bool Started { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool FinishByDate { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public virtual User CreatorUser { get; set; }

        [NotMapped]
        public IQueryable<PollChoice> PollChoices
        {
            get
            {
                return DataManager.DataContext.PollChoices
                    .Where(choice => choice.Poll.Id == Id);
            }
        }

        [NotMapped]
        public IQueryable<User> Voters
        {
            get
            {
                return
                    DataManager.DataContext.PollUsers
                        .Where(pollUser => pollUser.Poll.Id == Id)
                        .Select(pollUser => pollUser.User);
            }
        }

        [NotMapped]
        public int Hit
        {
            get { return Enumerable.Sum(PollChoices, pollChoice => pollChoice.Hit); }
        }

        public void Start()
        {
            Started = true;
            FinishDate = FinishDate.AddDays(DateTimeManager.Today.Subtract(CreationDate).Days);
            DataManager.DataContext.SaveChanges();
        }

        public bool CanFinish()
        {
            if (!FinishByDate)
                return false;
            return DateTimeManager.Today > FinishDate;
        }

        public void Finish()
        {
            Closed = true;
            FinishDate = DateTimeManager.Today;
            var db = DataManager.DataContext;
            db.Notifications.Add(new Notification
            {
                Title = "رای گیری به اتمام رسید",
                Exhibition = Exhibition,
                CreationDate = DateTimeManager.SystemNow,
                Content = String.Format("رای گیری {0} به اتمام رسید.", Question),
                User = CreatorUser
            });

            DataManager.DataContext.SaveChanges();
        }

        public void Reset()
        {
            var db = DataManager.DataContext;

            foreach (var voter in Voters)
                db.PollUsers.Remove(
                    db.PollUsers.First(pollUser => pollUser.Poll.Id == Id && pollUser.User.Id == voter.Id));

            foreach (var pollChoice in PollChoices)
                pollChoice.Hit = 0;

            db.SaveChanges();
        }


        public override string ToString()
        {
            return Question;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var poll = obj as Poll;
            if (poll == null || poll.Id != Id)
                return false;
            return true;
        }
    }
}