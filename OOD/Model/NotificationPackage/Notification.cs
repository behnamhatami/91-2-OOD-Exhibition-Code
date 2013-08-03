#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.NotificationPackage
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }

        public virtual Exhibition Exhibition { get; set; }
        public virtual User User { get; set; }
    }
}