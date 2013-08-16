#region

using System;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public enum ProfessionQuality
    {
        High,
        Low
    }

    public class ProfessionQualityWrapper
    {
        public static ProfessionQualityWrapper[] Types =
        {
            new ProfessionQualityWrapper(ProfessionQuality.High, "کیفیت بالا"),
            new ProfessionQualityWrapper(ProfessionQuality.Low, "کیفیت پایین")
        };

        private ProfessionQualityWrapper(ProfessionQuality quality, String name)
        {
            Quality = quality;
            Name = name;
        }

        public ProfessionQuality Quality { get; set; }
        private String Name { get; set; }

        public static ProfessionQualityWrapper GetwWrapper(ProfessionQuality quality)
        {
            return Types[(int) quality];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}