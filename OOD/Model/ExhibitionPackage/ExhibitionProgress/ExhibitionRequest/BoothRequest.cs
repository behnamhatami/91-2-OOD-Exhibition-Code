using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth;

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    public class BoothRequest : Request
    {
        public BoothQuality Quality { get; set; }
        public int OperatorCount { get; set; }
        public bool ForSell { get; set; }
        public bool ForVitrin { get; set; }
        public bool ForCommision { get; set; }
        public bool HasPhone { get; set; }
        public bool HasCardReader { get; set; }
    }
}