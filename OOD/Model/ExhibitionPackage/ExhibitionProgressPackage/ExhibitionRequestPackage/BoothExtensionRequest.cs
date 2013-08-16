#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public class BoothExtensionRequest : Request
    {
        public int Area { get; set; }
        public bool IsCustomerRequest { get; set; }

        public virtual Booth Booth { get; set; }
        
        [NotMapped]
        public IQueryable<ProfessionAssignment> ProfessionsAssignments
        {
            get
            {
                return
                    DataManager.DataContext.ProfessionAssignments.Where(assignment => assignment.Request.Id == Id);
            }
        }
    }
}