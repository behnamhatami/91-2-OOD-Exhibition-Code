using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
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
    }
}
