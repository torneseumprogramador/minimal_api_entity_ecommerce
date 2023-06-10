using Exercio.WebApi.Minimal.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exercio.WebApi.Minimal.Ecommerce.Contexts;

public class EcommerceDatabaseContext : DbContext
{
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<OrderProductModel> OrderProducts { get; set; }

    public EcommerceDatabaseContext(DbContextOptions<EcommerceDatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerModel>()
            .Property(customer => customer.RegisterDate).HasDefaultValueSql("datetime('now', 'localtime', 'start of day')")
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        modelBuilder.Entity<OrderModel>()
            .Property(order => order.OrderDate).HasDefaultValueSql("datetime('now', 'localtime', 'start of day')")
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
    }
}