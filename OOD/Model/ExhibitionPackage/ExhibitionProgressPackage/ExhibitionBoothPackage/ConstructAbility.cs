using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class ConstructAbility
    {
        [Key, ForeignKey("BoothConstructor")]
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
        
        public virtual Profession Profession { get; set; }
        public virtual BoothConstructor BoothConstructor { get; set; }


        public override string ToString()
        {
            return BoothConstructor + ": " +
                   Profession.ToString() + ", "
                   + Cost;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var ability = obj as ConstructAbility;
            if (ability == null || ability.Id != Id)
                return false;
            return true;
        }
    }
}