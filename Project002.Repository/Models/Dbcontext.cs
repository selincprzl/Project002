using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project002.Repository.Models;

namespace Project002.Repository.Models
{
    public class Dbcontext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Constructor with DbContextOptions parameter
        public Dbcontext(DbContextOptions<Dbcontext> options) : base(options)
        {
            // DbSet is "a" Table
            // Add DbSet properties here to represent database tables
        }


        // Represents the tables in the database
        public DbSet<Samurai> Samurai { get; set; }

        public DbSet<War> War { get; set; }
        public DbSet<Clan> Clan { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Horse> Horse { get; set; }

        public DbSet<Armour> Armour { get; set; }

        public DbSet<FrontPage> FrontPage { get; set; }

    }

}