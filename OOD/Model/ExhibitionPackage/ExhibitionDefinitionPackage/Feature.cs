#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage
{
    public class Feature
    {
        [Key, ForeignKey("Exhibition")]
        public int Id { get; set; }

        public bool HasWareHouse { get; set; }
        public bool HasPostOffice { get; set; }
        public bool HasSell { get; set; }
        public bool HasDifferentBooth { get; set; }

        public virtual Exhibition Exhibition { get; set; }

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
            var feature = obj as Feature;
            if (feature == null || feature.Id != Id)
                return false;
            return true;
        }
    }
}