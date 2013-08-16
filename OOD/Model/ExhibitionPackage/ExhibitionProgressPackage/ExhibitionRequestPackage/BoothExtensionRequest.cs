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

        public virtual Booth Booth { get; set; }
        
        [NotMapped]
        public IQueryable<ConstructAbility> Abilities
        {
            get
            {
                return
                    DataManager.DataContext.Abilities.Where(
                        ability => ability.Request != null && ability.Request.Id == Id);
            }
        }
    }
}