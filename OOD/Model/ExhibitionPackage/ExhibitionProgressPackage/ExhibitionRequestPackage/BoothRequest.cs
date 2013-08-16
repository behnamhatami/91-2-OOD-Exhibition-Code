#region

using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public class BoothRequest : Request
    {
        public BoothQuality Quality { get; set; }
        public int Area { get; set; }
        public int OperatorCount { get; set; }
        public bool ForSell { get; set; }
        public bool ForVitrin { get; set; }
        public bool ForCommision { get; set; }
        public bool HasPhone { get; set; }
        public bool HasCardReader { get; set; }
        public int Count { get; set; }
    }
}