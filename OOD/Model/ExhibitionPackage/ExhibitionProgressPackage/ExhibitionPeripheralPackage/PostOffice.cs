#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage
{
    public class PostOffice
    {
        [Key, ForeignKey("Exhibition")]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Exhibition Exhibition { get; set; }

        [NotMapped]
        public IQueryable<PostItem> PostItems
        {
            get { return DataManager.DataContext.PostItems.Where(item => item.PostOffice.Id == Id); }
        }


        public override string ToString()
        {
            return Exhibition.Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var office = obj as PostOffice;
            if (office == null || office.Id != Id)
                return false;
            return true;
        }
    }
}