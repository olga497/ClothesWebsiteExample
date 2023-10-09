using System.Collections.Generic;
using ClothesShop.Infrastructure.Identity;
using ClothesShop.Infrastructure.Models;
using ClothesShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClothesShop;

public class ProductDBContext : IdentityDbContext<ApplicationUser>
{
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    //public virtual DbSet<Order> Orders { get; set; }
    //public virtual DbSet<User> Users { get; set; }
    //public virtual DbSet<WarehouseStock> WarehouseStockItems { get; set; }
    public string ConnectionString { get; set; }
    public ProductDBContext()
    {

    }

    public ProductDBContext(DbContextOptions<ProductDBContext> options, IConfiguration configuration) : base(options)
    {
        ConnectionString = configuration.GetConnectionString("default");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);

    }
}

