using Microsoft.EntityFrameworkCore;
using Middleware.Models;

namespace Middleware.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);
        }
    }
}