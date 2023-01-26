using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Delivery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        public DateTime Devivery_dt { get; set; }
        public string Address { get; set; }
        public string Deliver_FullName { get; set; }
    }
}
