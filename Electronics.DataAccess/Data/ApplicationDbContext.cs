using Electronics.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Headphone> Headphones { get; set; }
        
    }
}
