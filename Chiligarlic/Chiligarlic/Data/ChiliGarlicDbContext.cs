using Chiligarlic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiligarlic.Data
{
    public class ChiliGarlicDbContext : DbContext
    {

        public ChiliGarlicDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
