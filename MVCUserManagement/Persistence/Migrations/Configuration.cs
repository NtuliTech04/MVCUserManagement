namespace MVCUserManagement.Persistence.Migrations
{
    using MVCUserManagement.Infrastructure.Authentication.Seeds;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.UserManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected async override void Seed(Context.UserManagementDbContext context)
        {
           await new DefaultRoles().SeedUserRoles();
        }
    }
}
