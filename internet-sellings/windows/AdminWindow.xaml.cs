using internet_sellings.classes;
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
        public AdminWindow()
        {
            InitializeComponent();
            db = ApplicationContext.GetInstance();
        }
        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Owner.Show();
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
                db.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            this.DataContext = new EntityController();
        }
    }
}
