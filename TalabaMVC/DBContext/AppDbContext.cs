using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalabaMVC.Models;

namespace TalabaMVC.DBContext
{
    public class AppDbContext : IdentityDbContext<ApiUser, Role, int>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Talaba> Talabalar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
        public class RoleConfiguration : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );
            }
        }

        public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
        {
            public void Configure(EntityTypeBuilder<ApiUser> builder)
            {
                var hasher = new PasswordHasher<ApiUser>();
                builder.HasData(
                    new ApiUser
                    {
                        Id = 1,
                        FirstName = "Mansur",
                        LastName = "Xamrayev",
                        UserName = "Khmansur",
                        NormalizedUserName = "KHMANSUR",
                        PasswordHash = hasher.HashPassword(null, "Khmansur8#")
                    },
                    new ApiUser
                    {
                        Id = 2,
                        FirstName = "Aziz",
                        LastName = "A'zamjonov",
                        UserName = "Aziz",
                        NormalizedUserName = "AZIZ",
                        PasswordHash = hasher.HashPassword(null, "Aziz4577#")
                    }

                );
            }
        }

        public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
        {
            public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
            {
                var hasher = new PasswordHasher<ApiUser>();
                builder.HasData(
                    new IdentityUserRole<int>
                    {
                        UserId = 1,
                        RoleId = 1
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 2,
                        RoleId = 2
                    }

                );
            }
        }
    }
}
