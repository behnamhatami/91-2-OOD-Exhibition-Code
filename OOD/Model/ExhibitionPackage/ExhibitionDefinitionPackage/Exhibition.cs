#region

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage
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

        [NotMapped]
        public IQueryable<Payment> Payments
        {
            get { return DataManager.DataContext.Payments.Where(payment => payment.Exhibition.Id == Id); }
        }

        [NotMapped]
        public IQueryable<Saloon> Saloons
        {
            get { return DataManager.DataContext.Saloons.Where(saloon => saloon.Exhibition.Id == Id); }
        }

        [NotMapped]
        public IQueryable<Request> Requests
        {
            get { return DataManager.DataContext.Requests.Where(request => request.Exhibition.Id == Id); }
        }

        [NotMapped]
        public IQueryable<BoothConstructor> Constructors
        {
            get { return DataManager.DataContext.Constructors.Where(constructor => constructor.Exhibition.Id == Id); }
        }

        public IQueryable<Request> GetSpecialRequests<T>()
        {
            return Requests.Where(request => request is T)
                .OrderBy(request => request.Responsed)
                .ThenBy(request => request.CreationDate);
        }

        public void ExitUser(User user)
        {
            var db = DataManager.DataContext;
            var userExhibitionRole = db.UserExhibitionRoles
                .Where(role => role.Exhibition.Id == Id)
                .Where(role => role.User.Id == user.Id)
                .First(role => role.ExhibitionRole is ECustomerRole);
            userExhibitionRole.NotifyRemove();
            db.UserExhibitionRoles.Remove(userExhibitionRole);
            var booths = db.Booths
                .Where(booth => booth.Map.Saloon.Exhibition.Id == Id)
                .Where(booth => booth.Request != null && booth.Request.User.Id == user.Id);

            foreach (var booth in booths)
                booth.Request = null;
            db.SaveChanges();
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


        public bool HasRole<T>(User user) where T : ExhibitionRole
        {
            return UserExhibitionRoles
                .Where(role1 => role1.User.Id == user.Id)
                .Any(role1 => role1.ExhibitionRole is T);
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