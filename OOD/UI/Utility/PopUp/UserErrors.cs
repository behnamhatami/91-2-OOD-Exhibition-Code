using System;
using System.Linq;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;

namespace OOD.UI.Utility.PopUp
{
    internal static class UserErrors
    {
        public static User GetUserOrError(string username)
        {
            var db = DataManager.DataContext;
            var user = db.Users.FirstOrDefault(user1 => user1.Username == username);
            if (user != null)
                return user;
            Utility.PopUp.PopUp.ShowError(String.Format("کاربری با نام کاربری \"{0}\" وجود ندارد.", username));
            return null;
        }

        public static bool CheckUserDoesNotExists(string username)
        {
            var db = DataManager.DataContext;
            if (db.Users.FirstOrDefault(user => user.Username == username) == null)
                return true;
            Utility.PopUp.PopUp.ShowError(String.Format("کاربری با نام کاربری \"{0}\" در حال حاضر وجود دارد.", username));
            return false;
        }

        public static bool AuthenticateIsNotValid(User user, string password)
        {
            if (user.Authenticate(password))
                return false;

            Utility.PopUp.PopUp.ShowError("رمز ورود با نام کاربری همخوانی ندارد.");
            return true;
        }

        public static long ParsePhoneNumber(string input)
        {
            try
            {
                return long.Parse(input);
            }
            catch (Exception)
            {
                Utility.PopUp.PopUp.ShowError("شماره تماس وارد شده معتبر نیست.");
                return -1;
            }
        }

        public static bool IsSamePassword(string password, string repeat)
        {
            if (password == repeat)
                return true;

            Utility.PopUp.PopUp.ShowError("تکرار رمز با رمز عبور یکسان نمی باشد.");
            return false;
        }
    }
}