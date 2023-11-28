using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrudDotNet8.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
    }
}