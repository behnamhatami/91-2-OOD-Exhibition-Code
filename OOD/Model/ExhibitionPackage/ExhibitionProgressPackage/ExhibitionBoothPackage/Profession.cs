namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class Profession
    {
        public int Id { get; set; }
        public ProfessionType ProfessionType { get; set; }
        public ProfessionQuality Quality { get; set; }

        public override string ToString()
        {
            return ProfessionTypeWrapper.GetWrapper(ProfessionType) + ", " +
                   ProfessionQualityWrapper.GetwWrapper(Quality);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var profession = obj as Profession;
            if (profession == null)
                return false;

            if (Id != 0 || profession.Id != 0)
                return Id == profession.Id;

            if (profession.ProfessionType != ProfessionType
                || profession.Quality != Quality)
                return false;
            return true;
        }
    }
}