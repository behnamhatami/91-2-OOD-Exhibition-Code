#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth
{
    public class Booth
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public bool Enabled { get; set; }
        public BoothQuality Quality { get; set; }
        public int OperatorCount { get; set; }
        public bool ForSell { get; set; }
        public bool ForVitrin { get; set; }
        public bool ForCommision { get; set; }
        public bool HasPhone { get; set; }
        public bool HasCardReader { get; set; }

        public virtual Request Request { get; set; }
        public virtual Map Map { get; set; }

        [NotMapped]
        public IQueryable<InspectionRequest> InspectionRequests
        {
            get
            {
                return
                    DataManager.DataContext.Requests
                        .Where(request => request is InspectionRequest)
                        .Cast<InspectionRequest>()
                        .Where(request => request.Booth.Id == Id);
            }
        }

        public void SwitchState()
        {
            if (Request != null)
                return;
            Enabled = !Enabled;
        }

        public void Register(BoothRequest request)
        {
            if (!Enabled)
                return;

            if (Request == null)
            {
                if (request.Count == 0)
                    return;

                Quality = request.Quality;
                OperatorCount = request.OperatorCount;
                ForCommision = request.ForCommision;
                ForSell = request.ForSell;
                ForVitrin = request.ForVitrin;
                HasCardReader = request.HasCardReader;
                HasPhone = request.HasPhone;
                Request = request;
                request.Count--;

                if (request.Count == 0)
                    request.Agreed = true;
            }
            else
            {
                if (Request.Id != request.Id) return;
                Request = null;
                if (request.Count == 0)
                    request.Agreed = false;

                request.Count++;
            }
        }

        public override string ToString()
        {
            return Map.Saloon + ":" + Index;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var booth = obj as Booth;
            if (booth == null || booth.Id != Id)
                return false;
            return true;
        }
    }
}