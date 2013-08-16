#region

using System;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public enum Profession
    {
        Welder,
        Carpenter,
        Decorator,
    }

    public class ProfessionWrapper
    {
        public static ProfessionWrapper[] Types =
        {
            new ProfessionWrapper(Profession.Welder, "جوشکار"),
            new ProfessionWrapper(Profession.Carpenter, "نجار"),
            new ProfessionWrapper(Profession.Decorator, "دکوراسیون")
        };

        public ProfessionWrapper(Profession profession, String name)
        {
            Profession = profession;
            Name = name;
        }

        public Profession Profession { get; set; }
        private string Name { get; set; }

        public static ProfessionWrapper GetWrapper(Profession profession)
        {
            return Types[(int) profession];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}