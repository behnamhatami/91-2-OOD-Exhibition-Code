#region

using OOD.Model.NotificationPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    internal class PollRequest : Request
    {
        public Poll Poll { get; set; }
    }
}