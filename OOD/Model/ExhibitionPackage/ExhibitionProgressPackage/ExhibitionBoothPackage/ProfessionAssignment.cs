#region

using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class ProfessionAssignment
    {
        public int Id { get; set; }

        public bool Done { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual BoothConstructor Constructor { get; set; }
        public virtual BoothExtensionRequest Request { get; set; }


        public override string ToString()
        {
            return Profession.ToString();
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var assignment = obj as ProfessionAssignment;
            if (assignment == null)
                return false;

            if (Id != 0 || assignment.Id != 0)
                return assignment.Id == Id;

            return Profession.Equals(assignment.Profession)
                   && Request.Equals(assignment.Request);
        }

        public void NotifyDone()
        {
            Done = true;
            var db = DataManager.DataContext;
            db.Notifications.Add(
                new Notification
                {
                    Content =
                        string.Format("خدمت {0} برای غرفه ی {1} توسط {2} اتمام یافت", Profession, Request.Booth,
                            Constructor),
                    CreationDate = DateTimeManager.SystemNow,
                    Exhibition = Request.Exhibition,
                    Title = "خدمت به پایان رسید",
                    User = Request.User
                });
            db.SaveChanges();
        }
    }
}