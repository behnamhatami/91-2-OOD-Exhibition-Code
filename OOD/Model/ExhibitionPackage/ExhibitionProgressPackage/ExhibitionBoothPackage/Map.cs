#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class Map
    {
        [Key, ForeignKey("Saloon")]
        public int Id { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public virtual Saloon Saloon { get; set; }

        [NotMapped]
        public IQueryable<Booth> Booths
        {
            get { return DataManager.DataContext.Booths.Where(booth => booth.Map.Id == Id); }
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
            var map = obj as Map;
            if (map == null || map.Id != Id)
                return false;
            return true;
        }
    }
}