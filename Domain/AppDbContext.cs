using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = "4F980B53-6D51-422B-9537-34425B5418F4",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = "43DA5F5E-8874-471B-BCA9-01855FA47DA4",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.ru",
                NormalizedEmail = "ADMIN@MAIL.RU",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                UserId = "43DA5F5E-8874-471B-BCA9-01855FA47DA4",
                RoleId = "4F980B53-6D51-422B-9537-34425B5418F4"
            });

            builder.Entity<TextField>().HasData(new TextField()
            {
                Id = new Guid("1D3B89B1-E834-458C-AEF4-D144E3CB8461"),
                CodeWord = "PagePhones",
                Title = "Каталог телефонов"
            });

            builder.Entity<TextField>().HasData(new TextField()
            {
                Id = new Guid("A6180EAF-9FFD-462F-B17A-EB4D77EC46FF"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

            builder.Entity<TextField>().HasData(new TextField()
            {
                Id = new Guid("CD1A8EA6-816F-4B53-B9D0-BCA8778EE256"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });
        }
    }
}
