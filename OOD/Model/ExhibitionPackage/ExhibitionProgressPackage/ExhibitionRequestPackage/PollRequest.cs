#region

using OOD.Model.NotificationPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    internal class PollRequest : Request
    {
        public Poll Poll { get; set; }
    }
}