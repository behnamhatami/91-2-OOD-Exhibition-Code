using System.Data.Entity;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRole;
using OOD.Model.UserManagingPackage;

namespace OOD.Model.ModelContext
{
    public class OodContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Exhibition> Exhibitions { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<ExhibitionRole> ExhibitionRoles { get; set; }
        public DbSet<UserExhibitionRole> UserExhibitionRoles { get; set; }

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