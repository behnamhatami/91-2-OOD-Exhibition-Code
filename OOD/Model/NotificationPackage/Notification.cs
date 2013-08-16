#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
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

        public override string ToString()
        {
            return String.Format("رخداد: [تیتر: {0}، تاریخ: {1}]", Title, CreationDate);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var notification = obj as Notification;
            if (notification == null || notification.Id != Id)
                return false;
            return true;
        }
    }
}