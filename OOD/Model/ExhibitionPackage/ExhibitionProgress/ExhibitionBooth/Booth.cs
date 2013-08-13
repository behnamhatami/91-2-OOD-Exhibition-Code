#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth
{
    public class Booth
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public bool Enabled { get; set; }
        public string Quality { get; set; }
        public int OperatorCount { get; set; }
        public bool ForSell { get; set; }
        public bool ForVitrin { get; set; }
        public bool ForCommision { get; set; }
        public bool HasPhone { get; set; }
        public bool HasCardReader { get; set; }

        public virtual Map Map { get; set; }
        public virtual User User { get; set; }


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