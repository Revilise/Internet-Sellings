using internet_sellings.classes;
using internet_sellings.entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace internet_sellings.windows
{
    /// <summary>
    /// Логика взаимодействия для DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {
        EntityController EntityController;
        ApplicationContext db;
        public DeliveryWindow()
        {
            InitializeComponent();
            db = ApplicationContext.GetInstance();
            EntityController = (EntityController)this.DataContext;
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

            if ((bool)checkBox.IsChecked) EntityController.Deliveries.Where(x => x.Delivered);
        }

        private void SaveCurrantRowToPdf_Click(object sender, RoutedEventArgs e)
        {
            Delivery delivery = (Delivery)dvg.SelectedItem;

            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream($"delivery-{delivery.Id}.pdf", FileMode.Create));
            doc.Open();

            string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
            paragraph.Add(
                $"Delivery identificator: {delivery.Id} \n" +
                $"Order_id: {delivery.Order_Id} \n" +
                $"Delivery to: {delivery.Delivery_dt} \n" +
                $"Address to: {delivery.Address} \n" +
                $"Deliverer fullname: {delivery.Deliver_FullName} \n" +
                $"Client fullname: {delivery.Order.Client_Fullname} \n" +
                $"Client phone: {delivery.Order.Client_Phone} \n\n\n"
            );

            doc.Add(paragraph);

            PdfPTable table = new PdfPTable(3);

            table.AddCell(new Phrase("№", font));
            table.AddCell(new Phrase("Product name", font));
            table.AddCell(new Phrase("Count", font));

            List<Order_Product> op = (new EntityController()).OrderProducts.BindingList.Where(x => x.Order_Id == delivery.Order_Id).ToList();
            int row = 0;
            foreach (var obj in op)
            {
                table.AddCell(new Phrase(row.ToString(), font));
                table.AddCell(new Phrase(obj.Product.Name, font));
                table.AddCell(new Phrase(obj.Count.ToString(), font));
                row++;
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show($"Заказ №{delivery.Order_Id} сохранен в pdf");
        }
    }
}
