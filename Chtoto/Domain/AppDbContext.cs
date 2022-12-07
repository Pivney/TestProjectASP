using Chtoto.Domain.Enteties;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chtoto.Domain
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "ab0bce51-9a46-4587-8d2a-4147144cd415",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "cead43f6-9f36-4621-a64c-6fc607a51a73",
                UserName = "admin",
                NormalizedUserName= "ADMIN",
                Email= "my@email.com",
                NormalizedEmail= "MY@EMAIL.COM",
                EmailConfirmed= true,
                PasswordHash= new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
                SecurityStamp= String.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ab0bce51-9a46-4587-8d2a-4147144cd415",
                UserId = "cead43f6-9f36-4621-a64c-6fc607a51a73"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("a5d81dd0-e925-413d-a729-70a5177e548b"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("e148d3c0-5a47-48a4-ad14-6fb010af3880"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("2bc7ef46-f6eb-4ce7-a4bf-f681dd292ebd"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
