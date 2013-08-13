#region

using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.UserManagingPackage;
using OOD.UI.Utility.Helper;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionRoles
{
    public class UserExhibitionRole
    {
        public int Id { get; set; }

        public virtual Exhibition Exhibition { get; set; }
        public virtual User User { get; set; }
        public virtual ExhibitionRole ExhibitionRole { get; set; }

        public override string ToString()
        {
            return Exhibition + "-" + User + "-" + ExhibitionRole;
        }

        public void NotifyAdd()
        {
            User.RecieveNotification(NotificationFactory.ExhibitionRoleAddedTitle,
                NotificationFactory.ExhibitionRoleAddedContent(Exhibition, ExhibitionRole), Exhibition);
        }

        public void NotifyRemove()
        {
            User.RecieveNotification(NotificationFactory.ExhibitionRoleRemovedTitle,
                NotificationFactory.ExhibitionRoleRemovedContent(Exhibition,
                    ExhibitionRole), Exhibition);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var role = obj as UserExhibitionRole;
            if (role == null || role.Id != Id)
                return false;
            return true;
        }
    }
}