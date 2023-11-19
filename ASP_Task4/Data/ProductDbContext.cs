using ASP_Task4.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASP_Task4.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
