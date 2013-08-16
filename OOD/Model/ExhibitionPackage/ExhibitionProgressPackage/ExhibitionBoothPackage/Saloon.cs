#region

using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public class Saloon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }

        public virtual Map Map { get; set; }
        public virtual Exhibition Exhibition { get; set; }


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
            var saloon = obj as Saloon;
            if (saloon == null || saloon.Id != Id)
                return false;
            return true;
        }
    }
}