using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class ConstructAbility
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
        public bool Done { get; set; }
        public ProfessionQuality Quality { get; set; }

        public virtual Profession Profession { get; set; }
        public virtual BoothConstructor Constructor { get; set; }
        public virtual BoothExtensionRequest Request { get; set; }


        public override string ToString()
        {
            return Constructor + ": " +
                   ProfessionWrapper.GetWrapper(Profession) + ", "
                   + ProfessionQualityWrapper.GetwWrapper(Quality) + ", "
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