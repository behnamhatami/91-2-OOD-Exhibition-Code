#region

using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;

#endregion

namespace OOD.Model.NotificationPackage
{
    public class VisitorReport
    {
        public int Id { get; set; }
        public virtual Booth Booth { get; set; }
        public string Content { get; set; }


        public override string ToString()
        {
            return Content;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var report = obj as VisitorReport;
            if (report == null || report.Id != Id)
                return false;
            return true;
        }
    }
}