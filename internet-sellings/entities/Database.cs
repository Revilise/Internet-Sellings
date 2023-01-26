using internet_sellings.db_model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Database : DbContext
    {
        static private Database Instance;
        private Database() : base(ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString) { }
        static public Database GetInstance()
        {
            if (Instance == null) Instance = new Database();

            return Instance;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //{
            //    modelBuilder.Entity<User>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //    modelBuilder.Entity<Role>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //    modelBuilder.Entity<Seller>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //    modelBuilder.Entity<Product>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //    modelBuilder.Entity<Order>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //    modelBuilder.Entity<Order_Product>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //    modelBuilder.Entity<Delivery>()
            //       .Property(f => f.Id)
            //       .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //}

        }
    }
}
