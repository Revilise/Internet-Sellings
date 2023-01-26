using internet_sellings.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Database db;
        public BindingList<TabItem> TabViews { get; set; }
        public BindingList<User> Users { get; set; }
        public BindingList<Role> Roles { get; set; }
        public AdminWindow()
        {
            InitializeComponent();
            db = Database.GetInstance();
            this.DataContext = this;

            Users = new BindingList<User>(db.Users.ToList());
            //Roles = new BindingList<Role>(db.Roles.ToArray());

            TabViews = new BindingList<TabItem>
            {
                new TabItem {
                    Header = "Пользователи",
                    Content = Users
                },
                //new TabItem
                //{
                //    Header = "Роли",
                //    Content = Roles
                //}
            };
        }

        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
