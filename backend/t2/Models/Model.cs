using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace t2.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelDb")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.mgrid);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.unitprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.unitprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.discount)
                .HasPrecision(4, 3);

            modelBuilder.Entity<Order>()
                .Property(e => e.freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipper>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Shipper)
                .WillCascadeOnDelete(false);
        }
    }
}
