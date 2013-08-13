#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.NotificationPackage
{
    public class News : Notification
    {
        public string Image { get; set; }

        [NotMapped]
        public IQueryable<Attachment> Attachments
        {
            get { return DataManager.DataContext.Attachments.Where(attachment => attachment.News.Id == Id); }
        }
    }
}