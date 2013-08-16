#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class BoothConstructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReserverdDays { get; set; }

        public virtual Exhibition Exhibition { get; set; }
        public virtual ConstructAbility Ability { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var constructor = obj as BoothConstructor;
            if (constructor == null || constructor.Id != Id)
                return false;
            return true;
        }
    }
}