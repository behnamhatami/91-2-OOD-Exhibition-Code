using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOD.Model.UserManagingPackage
{
    public class UserRole
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public static Object[] GetChoices()
        {
            Object[] output = {new InternalRole(), new AdminRole(), new PublicRole(), new CustomerRole()};
            return output;
        }
    }
}