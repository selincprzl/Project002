using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public DbSet<Samurai> Samurai { get; set; }

        public DbSet<War> War { get; set; }
        public DbSet <Clan> Clan { get; set; }
        public DbSet <Weapon> Weapon { get; set; }
        public DbSet<Horse> Horse { get; set; }

        public DbSet<Clothing> Clothing { get; set; }

        public DbSet<Armour> Armour { get; set; }

        public DbSet<Rank> Rank { get; set; }

        public DbSet<TimePeriod> TimePeriod { get; set; }

        public DbSet<Admin> Admin { get; set; }

    }

}
