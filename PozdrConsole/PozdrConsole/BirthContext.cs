using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PozdrConsole
{
    public class BirthContext : DbContext
    {
        public DbSet<Model> Models { get; set; }
       
       
        public BirthContext()
        {
          // Database.EnsureDeleted();
           Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>().HasData(new Model { Id = 0, Name = "Tom", Date = new DateTime(2022, 8, 23) });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 1, Name = "Vadim", Date = new DateTime(2022, 8, 23) });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 2, Name = "Vitalik", Date = new DateTime(2022, 8, 24) });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 3, Name = "Dima", Date = new DateTime(2022, 8, 24) });
            modelBuilder.Entity<Model>().HasData(new Model { Id = 4, Name = "Ostap", Date = new DateTime(2022, 8, 25) });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=pozdrappdb;Trusted_Connection=True;");

        }

    }
}
