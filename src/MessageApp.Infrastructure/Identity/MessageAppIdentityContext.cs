using MessageApp.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Infrastructure.Identity
{
    public class MessageAppIdentityContext:IdentityDbContext<User,Role,int>
    {

        public MessageAppIdentityContext( DbContextOptions<MessageAppIdentityContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users", "dbo");
            modelBuilder.Entity<Role>().ToTable("Roles", "dbo");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UsersClaims", "dbo");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UsersRoles", "dbo");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UsersLogins", "dbo");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RolesClaims", "dbo");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UsersTokens", "dbo");
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                UserName = "JoelFerreira",
                Id = 1,
                NormalizedUserName = "JOELFERREIRA",
                EmailConfirmed = true,
                PhoneNumber = "+351960180464",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = "J141996@HOTMAIL.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "jJ963679933"),
                Email = "j141996@hotmail.com",

            });
            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = 1,
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            });
            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "User",
                NormalizedName = "USER",
                Id = 2,
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1,

            });
        }
    }
}
