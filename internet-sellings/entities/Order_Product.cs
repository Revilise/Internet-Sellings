using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Order_Product : BaseEntity
    {
        public int Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        public int Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public Product Product { get; set; }
        public int Seller_Id { get; set; }
        [ForeignKey("Seller_Id")]
        public Seller Seller { get; set; }
        public int Count { get; set; }
    }
}
