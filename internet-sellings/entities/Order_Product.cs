using internet_sellings.db_model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Order_Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        [ForeignKey("Seller_Id")]
        public Seller Seller { get; set; }
        public int Count { get; set; }
    }
}
