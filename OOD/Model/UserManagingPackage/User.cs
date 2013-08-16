#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;

#endregion

namespace OOD.Model.UserManagingPackage
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Username { get; set; }
        public string FamilyName { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }

        public virtual UserRole UserRole { get; set; }

        [NotMapped]
        public IQueryable<UserExhibitionRole> UserExhibitionRoles
        {
            get
            {
                return DataManager.DataContext.UserExhibitionRoles
                    .Where(role => role.User.Id == Id);
            }
        }

        [NotMapped]
        public IQueryable<Poll> Polls
        {
            get
            {
                return
                    DataManager.DataContext.PollUsers
                        .Where(pollUser => pollUser.User.Id == Id)
                        .Select(pollUser => pollUser.Poll);
            }
        }

        [NotMapped]
        public IQueryable<Notification> Notifications
        {
            get
            {
                return
                    DataManager.DataContext.Notifications
                        .Where(notification => notification.User != null && notification.User.Id == Id);
            }
        }

        [NotMapped]
        public IQueryable<PostItem> PostItems
        {
            get { return DataManager.DataContext.PostItems.Where(item => item.User.Id == Id); }
        }

        [NotMapped]
        public IQueryable<WareHouseItem> WareHouseItems
        {
            get { return DataManager.DataContext.WareHouseItems.Where(item => item.User.Id == Id); }
        }

        [NotMapped]
        public IQueryable<Payment> Payments
        {
            get { return DataManager.DataContext.Payments.Where(payment => payment.User.Id == Id); }
        }

        [NotMapped]
        public IQueryable<Request> Requests
        {
            get { return DataManager.DataContext.Requests.Where(request => request.User.Id == Id); }
        }

        [NotMapped]
        public IQueryable<Poll> CreatorPolls
        {
            get { return DataManager.DataContext.Polls.Where(poll => poll.CreatorUser.Id == Id); }
        }

        public void RecieveNotification(String title, String content, Exhibition exhibition)
        {
            DataManager.DataContext.Notifications.Add(new Notification
            {
                Content = content,
                Title = title,
                CreationDate = DateTime.Now,
                Exhibition = exhibition,
                User = this
            });
        }

        public void Fine(InspectionRequest request)
        {
            var title = "شما به علت تخلف جریمه شدید.";
            var content =
                String.Format("شما به علت تخلف در غرفه ی {0} در سالن {1} در نمایشگاه {2} به میزان {3} جریمه شدید.",
                    request.Booth,
                    request.Booth.Map.Saloon,
                    request.Exhibition,
                    request.Fine)
                ;
            RecieveNotification(title, content, request.Exhibition);
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!Authenticate(oldPassword))
                return false;

            Password = Encrypt(newPassword);
            return true;
        }

        public bool Authenticate(string password)
        {
            return Password == Encrypt(password);
        }

        public static string Encrypt(string text)
        {
            var enc = new UTF8Encoding();
            var buffer = enc.GetBytes(text);
            var cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");
        }

        public override string ToString()
        {
            return Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (user == null || user.Username != Username)
                return false;
            return true;
        }
    }
}