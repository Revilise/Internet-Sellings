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
    public class ApplicationContext : DbContext
    {
        static private ApplicationContext Instance;
        private ApplicationContext() : base(ConfigurationManager.ConnectionStrings["db_connection"].ConnectionString) { }
        static public ApplicationContext GetInstance()
        {
            if (Instance == null) Instance = new ApplicationContext();

            return Instance;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}
