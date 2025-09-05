
using Microsoft.EntityFrameworkCore;
using PlatformShop.Domain.Entities;
using PlatformShop.Persistence.Configurations;
using System;
using System.Collections.Generic;


namespace PlatformShop.Persistence.Context;

public partial class ShopDbAppContext : DbContext
{
    public ShopDbAppContext()
    {
    }

    public ShopDbAppContext(DbContextOptions<ShopDbAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-RPA9Q7BD\\SQLEXPRESS04;Initial Catalog=ShopDbApp;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ShipperConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
