using internet_sellings.classes;
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
    /// Логика взаимодействия для OperatorWindow.xaml
    /// </summary>
    public partial class OperatorWindow : Window
    {
        private ApplicationContext db;
        private EntityController EntityController { get; set; }
        public OperatorWindow()
        {
            InitializeComponent();
            db = ApplicationContext.GetInstance();
            this.EntityController = (EntityController)this.DataContext;
        }

        private void Logout_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            BindingList<Delivery> d = new BindingList<Delivery>(
                db.Deliveries.Where(x => x.Delivered && (bool)checkBox.IsChecked).ToList()
            );

            EntityController.Deliveries.BindingList = (bool)checkBox.IsChecked ? d : db.Deliveries.Local.ToBindingList();
        }
    }
}
