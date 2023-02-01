using internet_sellings.classes;
using internet_sellings.entities;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace internet_sellings
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = ApplicationContext.GetInstance();
            db.Users.Load();
            db.Roles.Load();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrantUser user = CurrantUser.AuthUser(
                    (User)contaier.DataContext
                );

                if (user == null) throw new Exception("Неверный логин или пароль");

                Role role = db.Roles.First(r => r.Id == user.Role_Id);
                Window window = WindowFabric.CreateWindow(role.Name);
                window.Owner = this;
                window.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
