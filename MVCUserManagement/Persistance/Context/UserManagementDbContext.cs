using System.Data.Entity;
using UserManagement.Models;
using UserManagement.Persistance.Configurations;
//using MVCUserManagement.Migrations;

namespace UserManagement.Persistance.Context
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext() : base("name=MVCUserManagementDB")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserManagementDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserManagementDbContext>());
            //Database.SetInitializer<UserManagementDbContext>(new CreateDatabaseIfNotExists<UserManagementDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            EntityConfigurations.Configure(builder);
        }

        public static UserManagementDbContext Create()
        {
            return new UserManagementDbContext();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}