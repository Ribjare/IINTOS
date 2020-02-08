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
        public DbSet<IINTOS.Models.Project> Project { get; set; }




    }
}
