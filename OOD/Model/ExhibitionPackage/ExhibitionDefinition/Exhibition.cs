#region

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionPeripheral;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public class Exhibition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string Owner { get; set; }
        public ExhibitionState State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEnter { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual Configuration Configuration { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        public virtual WareHouse WareHouse { get; set; }

        [NotMapped]
        public IQueryable<UserExhibitionRole> UserExhibitionRoles
        {
            get { return DataManager.DataContext.UserExhibitionRoles.Where(role => role.Exhibition.Id == Id); }
        }

        [NotMapped]
        public IQueryable<User> ChairUsers
        {
            get
            {
                return
                    DataManager.DataContext.UserExhibitionRoles
                        .Where(role => role.Exhibition.Id == Id)
                        .Where(role => role.ExhibitionRole is ChairRole)
                        .Select(role => role.User);
            }
        }


        [NotMapped]
        public IQueryable<Poll> Polls
        {
            get { return DataManager.DataContext.Polls.Where(poll => poll.Exhibition.Id == Id); }
        }


        [NotMapped]
        public IQueryable<Notification> Notifications
        {
            get
            {
                return DataManager.DataContext.Notifications.Where(notification => notification.Exhibition.Id == Id);
            }
        }

        public void RecieveNotification(String title, String content)
        {
            var db = DataManager.DataContext;
            db.Notifications.Add(new Notification
            {
                Content = content,
                Title = title,
                CreationDate = DateTime.Now,
                Exhibition = this,
                User = Program.System
            });
        }


        public bool HasRole<T>(User user)
        {
            return UserExhibitionRoles
                .Where(role1 => role1.User.Id == user.Id)
                .Count(role1 => role1.ExhibitionRole is T) > 0;
        }


        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var exhibition = obj as Exhibition;
            if (exhibition == null || exhibition.Id != Id)
                return false;
            return true;
        }
    }
}