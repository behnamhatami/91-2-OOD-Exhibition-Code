#region

using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class ProfessionAssignment
    {
        public int Id { get; set; }

        public bool Done { get; set; }
        public virtual Profession Profession { get; set; }
        public virtual BoothConstructor Constructor { get; set; }
        public virtual BoothExtensionRequest Request { get; set; }


        public override string ToString()
        {
            return Profession.ToString();
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var assignment = obj as ProfessionAssignment;
            if (assignment == null)
                return false;

            if (Id != 0 || assignment.Id != 0)
                return assignment.Id == Id;

            return Profession.Equals(assignment.Profession)
                   && Request.Equals(assignment.Request);
        }
    }
}