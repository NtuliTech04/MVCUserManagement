using System.Data.Entity;
using MVCUserManagement.Persistence.Migrations;
using MVCUserManagement.Persistence.Configurations;
using MVCUserManagement.Models;

namespace MVCUserManagement.Persistence.Context
{
    public class UserManagementDbContext : DbContext
    {
        public UserManagementDbContext() : base("name=MVCUserManagementDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserManagementDbContext, Configuration>());
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