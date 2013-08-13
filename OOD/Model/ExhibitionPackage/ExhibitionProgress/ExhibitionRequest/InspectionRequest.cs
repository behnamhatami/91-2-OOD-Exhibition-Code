#region

using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    public class InspectionRequest : Request
    {
        public string Fine { get; set; }
        public JudgeType JudgeType { get; set; }

        public virtual Booth Booth { get; set; }
    }
}