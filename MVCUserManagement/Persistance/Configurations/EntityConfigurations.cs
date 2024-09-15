
using System.Data.Entity;
using UserManagement.Models;

namespace UserManagement.Persistance.Configurations
{
    public class EntityConfigurations
    {
        public static void Configure(DbModelBuilder builder)
        {
            UserEntityConfigurations(builder);
            RoleEntityConfigurations(builder);
        }


        private static void UserEntityConfigurations(DbModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(pk => pk.UserId)
                .Ignore(i => i.FullName)
                .Ignore(i => i.ConfirmPassword);

            builder.Entity<UserRole>()
                .HasMany(x => x.Users)
                .WithRequired(r => r.Role)
                .HasForeignKey(fk => fk.RoleId);
        }

        private static void RoleEntityConfigurations(DbModelBuilder builder)
        {
            builder.Entity<UserRole>()
                .HasKey(pk => pk.RoleId);
        }
    }
}