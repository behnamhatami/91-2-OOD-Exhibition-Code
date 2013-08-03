#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace OOD.Model.UserManagingPackage
{
    public class UserRole
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return Id + "";
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var role = obj as UserRole;
            if (role == null || role.Id != Id)
                return false;
            return true;
        }

        public static Object[] GetChoices()
        {
            Object[] output = {new InternalRole(), new AdminRole(), new PublicRole(), new CustomerRole()};
            return output;
        }
    }
}