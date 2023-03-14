using Microsoft.EntityFrameworkCore;
using Productos_wpf.Models;
using System.Collections.Generic;

namespace Productos_wpf.DataContext
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
             new Product {
                 Id=1000,
                 Category="Muebles",
                 Description="Bonito escritorio",
                 Name="Escritorio de madera",
                 Price=100m
             },
             new Product
             {
                Id=1001,
                 Category="Computo",
                 Description="laptop hp 2323",
                 Name="laptop hp 12 gb ram",
                 Price=400m
             }
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
