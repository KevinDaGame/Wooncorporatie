using Company.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class WoningContext : DbContext
    {
        public DbSet<Woning> Woning { get; set; }
        public DbSet<Bewoner> Bewoner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localDB)\\MSSQLLocalDB; initial catalog = WoningDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Woning>().HasData(

                new Woning() { Naam = "Zelftevree", Id = 2 },
                new Woning() { Naam = "Boslust", Id = 3 }
                );
            modelBuilder.Entity<Bewoner>().HasData(

                new Bewoner { Naam = "Joosten", WoningId = 2, Id = 1 },
                new Bewoner { Naam = "Verschoor", WoningId = 2, Id = 2 },
                new Bewoner { Naam = "Rubens", WoningId = 3, Id = 3 },
                new Bewoner { Naam = "van Zanten", WoningId = 3, Id = 4 }
                );
        }
    }
}