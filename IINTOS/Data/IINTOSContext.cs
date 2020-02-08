using System;
using System.Collections.Generic;
using System.Text;
using IINTOS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IINTOS.Data
{
    public class IINTOSContext : IdentityDbContext<User>
    {
        public IINTOSContext(DbContextOptions<IINTOSContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<School>().HasMany(p => p.Professors).WithOne(u => u.School);
            builder.Entity<School>().HasOne(p => p.Coordinator).WithOne(u => u.SchoolCoordination);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        //Add here our models
        public DbSet<Models.Language> Language { get; set; }
        public DbSet<Models.Nationality> Nationality { get; set; }
        public DbSet<Models.Newsletter> Newsletter { get; set; }
        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.School> School { get; set; }
        public DbSet<Models.Events> Events { get; set; }
        public DbSet<Models.City> City { get; set; }
        public DbSet<Models.Country> Country { get; set; }
        public DbSet<Models.State> State { get; set; }




    }
}
