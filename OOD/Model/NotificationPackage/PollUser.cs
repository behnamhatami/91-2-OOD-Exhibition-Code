#region

using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.NotificationPackage
{
    public class PollUser
    {
        public int Id { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual User User { get; set; }
    }
}