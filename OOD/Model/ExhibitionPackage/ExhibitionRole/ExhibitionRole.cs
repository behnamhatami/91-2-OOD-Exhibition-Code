using System;

namespace OOD.Model.ExhibitionPackage.ExhibitionRole
{
    using System.Collections.Generic;

    public class ExhibitionRole
    {
        public ExhibitionRole()
        {
            UserExhibitionRoles = new HashSet<UserExhibitionRole>();
        }

        public int Id { get; set; }

        public virtual ICollection<UserExhibitionRole> UserExhibitionRoles { get; set; }

        public override string ToString()
        {
            return "";
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