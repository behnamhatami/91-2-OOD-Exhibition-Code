using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRole;

namespace OOD.Model.UserManagingPackage
{
    public class User
    {
        public User()
        {
            UserExhibitionRoles = new HashSet<UserExhibitionRole>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Username { get; set; }
        public string FamilyName { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<UserExhibitionRole> UserExhibitionRoles { get; set; }

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
            byte[] buffer = enc.GetBytes(text);
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
    }
}