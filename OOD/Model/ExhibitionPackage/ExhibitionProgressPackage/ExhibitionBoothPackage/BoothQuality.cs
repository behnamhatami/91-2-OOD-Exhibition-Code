#region

using System;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public enum BoothQuality
    {
        SuperHigh,
        High,
        Normal,
        Low
    }

    public class BoothQualityWrapper
    {
        public static BoothQualityWrapper[] BoothQualities =
        {
            new BoothQualityWrapper(BoothQuality.SuperHigh, "بسیار بالا"),
            new BoothQualityWrapper(BoothQuality.High, "بالا"),
            new BoothQualityWrapper(BoothQuality.Normal, "متوسط"),
            new BoothQualityWrapper(BoothQuality.Low, "پایین")
        };

        private BoothQualityWrapper(BoothQuality quality, String name)
        {
            Quality = quality;
            Name = name;
        }

        public BoothQuality Quality { get; set; }
        private String Name { get; set; }

        public static BoothQualityWrapper GetWrapper(BoothQuality boothQuality)
        {
            return BoothQualities[(int) boothQuality];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}