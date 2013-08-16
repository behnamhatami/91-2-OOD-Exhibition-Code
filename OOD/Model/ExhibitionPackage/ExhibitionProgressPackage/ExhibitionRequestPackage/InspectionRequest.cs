#region

using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public class InspectionRequest : Request
    {
        public int Fine { get; set; }
        public JudgeType JudgeType { get; set; }

        public virtual Booth Booth { get; set; }
    }
}