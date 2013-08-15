#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.NotificationPackage
{
    public class PhoneNews : Notification
    {
        [NotMapped]
        public IQueryable<PhoneInformation> PhoneInformations
        {
            get
            {
                return DataManager.DataContext.PhoneInformations.Where(information => information.PhoneNews.Id == Id);
            }
        }
    }
}