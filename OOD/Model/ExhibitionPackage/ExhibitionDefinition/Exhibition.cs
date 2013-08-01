using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OOD.Model.ExhibitionPackage.ExhibitionRole;
using OOD.Model.UserManagingPackage;

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public class Exhibition
    {
        public Exhibition()
        {
            UserExhibitionRoles = new HashSet<UserExhibitionRole>();
            CreationTime = DateTime.Now;
            State = ExhibitionState.Created;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string Owner { get; set; }
        public ExhibitionState State { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual ICollection<UserExhibitionRole> UserExhibitionRoles { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}