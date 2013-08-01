using System.ComponentModel.DataAnnotations.Schema;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.UserManagingPackage;

namespace OOD.Model.ExhibitionPackage.ExhibitionRole
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

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}