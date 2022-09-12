using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace InventoryManagerment.Models.EF
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
            : base("name=InventoryDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SupplyDetail> SupplyDetails {get;set;}
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<ImportDetail> ImportDetails { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<ExportDetail> ExportDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<RefundDetail> RefundDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .Property(e => e.Price)
            .HasPrecision(18, 0);
            modelBuilder.Entity<SupplyDetail>()
            .Property(e => e.Price)
            .HasPrecision(18, 0);
            modelBuilder.Entity<ImportDetail>().Property(e => e.ImportPrice).HasPrecision(18, 0);
            modelBuilder.Entity<ExportDetail>().Property(e => e.Price).HasPrecision(18, 0);
            modelBuilder.Entity<RefundDetail>().Property(e => e.Price).HasPrecision(18, 0);
        }
    }
}