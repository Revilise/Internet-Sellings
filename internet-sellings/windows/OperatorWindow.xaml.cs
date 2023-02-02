using internet_sellings.classes;
using internet_sellings.entities;
using System;
using System.Windows;
using System.Windows.Controls;

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
            Owner.Show();
            CurrantUser.GetInstance().IsLogged(true);
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
            
            if ((bool)checkBox.IsChecked)
            {
                EntityController.Deliveries.Where(x => x.Delivered && (bool)checkBox.IsChecked);
                return;
            }

            EntityController.Deliveries.RefreshBindingList();
        }
    }
}
