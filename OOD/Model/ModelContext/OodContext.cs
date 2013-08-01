using System.Data.Entity;
using OOD.Model.ExhibitionDefinition;
using OOD.Model.UserManaging;

namespace OOD.Model.ModelContext
{
    public class OodContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<InternalRole> InternalRoles { get; set; }
        public DbSet<CustomerRole> CustomerRoles { get; set; }
        public DbSet<PublicRole> PublicRoles { get; set; }
        public DbSet<AdminRole> AdminRoles { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }

        public OodContext()
            : base(ConnectionString)
        {
        }


        public static string ConnectionString
        {
            get
            {
                return @"Data Source=" +
                       System.Reflection
                           .Assembly
                           .GetExecutingAssembly()
                           .Location
                           .Substring(0,
                               System.Reflection.Assembly.GetExecutingAssembly()
                                   .Location.LastIndexOf("\\", System.StringComparison.Ordinal) + 1)
                       + @"ood.sdf";
            }
        }
    }
}