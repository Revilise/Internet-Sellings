using internet_sellings.classes;
using internet_sellings.entities;
using System;
using System.Windows;

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

        private void Refresh(object sender, RoutedEventArgs e)
        {
          
        }

    }
}
