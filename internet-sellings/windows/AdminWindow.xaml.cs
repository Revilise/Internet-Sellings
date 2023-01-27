using internet_sellings.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace internet_sellings.windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ApplicationContext db;
        public BindingList<User> Users { get; set; }
        public BindingList<Role> Roles { get; set; }
        public BindingList<Order> Orders { get; set; }
        public BindingList<Delivery> Deliveries { get; set; }
        public BindingList<Order_Product> Order_Products { get; set; }
        public AdminWindow()
        {
            InitializeComponent();
            db = ApplicationContext.GetInstance();
            this.DataContext = this;

            Users = new BindingList<User>();
            Roles = new BindingList<Role>();
            Orders = new BindingList<Order>();
            Deliveries = new BindingList<Delivery>();
            Order_Products = new BindingList<Order_Product>();
        }
        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TabControl tc = ((TabControl)sender);
                TabItem item = (TabItem)tc.SelectedItem;

                switch (item.Uid)
                {
                    case "users_tabitem":
                        db.Users.Load();
                        Users = db.Users.Local.ToBindingList();
                        dvg_1.ItemsSource = Users;
                        break;
                    case "roles_tabitem":
                        db.Roles.Load();
                        Roles = db.Roles.Local.ToBindingList();
                        dvg_2.ItemsSource = Roles;
                        break;
                    case "orders_tabitem":
                        db.Orders.Load();
                        Orders = db.Orders.Local.ToBindingList();
                        dvg_3.ItemsSource = Orders;
                        break;
                    case "deliveries_tabitem":
                        db.Deliveries.Load();
                        Deliveries = db.Deliveries.Local.ToBindingList();
                        dvg_4.ItemsSource = Deliveries;
                        break;
                    case "order_products_tabitem":
                        db.Order_Products.Load();
                        Order_Products = db.Order_Products.Local.ToBindingList();
                        dvg_5.ItemsSource = Order_Products;
                        break;
                    default: throw new Exception("Unexpected selected item: " + item.Uid);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Измененения сохранены");
            }
            catch (Exception ex)
            {
                RollBack();
                MessageBox.Show(ex.Message);
            }
        }
        public void RollBack()
        {
            var changedEntries = db.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
