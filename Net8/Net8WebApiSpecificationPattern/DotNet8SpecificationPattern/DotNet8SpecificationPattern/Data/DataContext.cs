using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet8SpecificationPattern.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8SpecificationPattern.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<DLC> DLCs { get; set; }
    }

    
}