using System.Data.Entity;
using OOD.Model.UserManaging;

namespace OOD.Model.ModelContext
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<OodContext>
    {
        protected override void Seed(OodContext context)
        {
            var adminRole = new AdminRole();
            var publicRole = new PublicRole();
            var user = new User
            {
                Username = "behnam",
                FirstName = "بهنام",
                FamilyName = "حاتمی",
                PhoneNumber = 09134124420,
                UserRole = adminRole,
                Password = User.Encrypt("ensaniat")
            };
            var guest = new User
            {
                Username = "guest",
                FirstName = "میهمان",
                FamilyName = "میهمان",
                UserRole = publicRole,
                Password = User.Encrypt("guest")
            };
            context.Users.Add(user);
            context.Users.Add(guest);
            context.AdminRoles.Add(adminRole);
            context.PublicRoles.Add(publicRole);
            context.SaveChanges();
        }
    }
}