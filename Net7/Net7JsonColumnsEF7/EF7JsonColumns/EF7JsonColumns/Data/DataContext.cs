using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF7JsonColumns.Models;
using Microsoft.EntityFrameworkCore;

namespace EF7JsonColumns.Data
{
    public class DataContext : DbContext
    {
public DataContext()
{
    
}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=JsonColumnsDb;Trusted_Connection=true;TrustServerCertificate=true");
            // optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=JsonColumnsDb;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().OwnsOne(sh => sh.HeroDetail, navigationsBuilder => {
                navigationsBuilder.ToJson();
                // navigationsBuilder.ToTable("HeroDetails");
            } );


        }

        public DbSet<SuperHero> SuperHeros { get; set; }

    }
}