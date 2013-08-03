#region

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionRoles
{
    public class ExhibitionRole
    {
        public int Id { get; set; }

        [NotMapped]
        public IQueryable<UserExhibitionRole> UserExhibitionRoles
        {
            get { return DataManager.DataContext.UserExhibitionRoles.Where(role => role.ExhibitionRole.Id == Id); }
        }

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
            var role = obj as ExhibitionRole;
            if (role == null || role.Id != Id)
                return false;
            return true;
        }


        public static Object[] GetChoices()
        {
            Object[] output =
            {
                new BoothManagerRole(), new ChairRole(), new ExecutionRole(), new InspectorRole(),
                new WareHouseKeeperRole(), new PostKeeperRole()
            };
            return output;
        }
    }
}