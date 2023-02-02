using internet_sellings.entities;
using internet_sellings.entities.collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace internet_sellings.classes
{
    public class EntityController
    {
        ApplicationContext db;
        private static EntityController _instance;
        static public EntityController Instance { 
            get
            {
                if (_instance == null) _instance = new EntityController();
                return _instance;
            }
        }
        public EntityController()
        {
            db = ApplicationContext.GetInstance();

            Deliveries = new DeliveryCollection(db.Deliveries);
            Users = new UserCollection(db.Users);
            Roles = new RoleCollection(db.Roles);
            Orders = new OrderCollection(db.Orders);
            OrderProducts = new OrderProductCollection(db.Order_Products);
            Sellers = new SellerCollection(db.Sellers);
            Products = new ProductCollection(db.Products);
        }
        public UserCollection Users { get; private set; }
        public RoleCollection Roles { get; private set; }
        public OrderCollection Orders { get; private set; }
        public OrderProductCollection OrderProducts { get; private set; }
        public SellerCollection Sellers { get; private set; }
        public ProductCollection Products { get; private set; }
        public DeliveryCollection Deliveries { get; private set; }
    }
}
