#region

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
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
        public DateTime CreationDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool FinishByDate { get; set; }
        public virtual Exhibition Exhibition { get; set; }

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

        public void CheckClosed()
        {
            if (FinishByDate && DateTime.Now > FinishDate)
                Closed = true;
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