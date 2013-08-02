using OOD.Model.UserManagingPackage;

namespace OOD.Model.NotificationPackage
{
    public class PollUser
    {
        public int Id { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual User User { get; set; }
    }
}