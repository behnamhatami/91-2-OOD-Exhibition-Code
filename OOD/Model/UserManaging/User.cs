using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace OOD.Model.UserManaging
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

        [ForeignKey("Id")]
        public virtual UserRole UserRole { get; set; }

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