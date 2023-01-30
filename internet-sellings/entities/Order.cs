using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Created_dt { get; set; } = DateTime.Now;
        public string Client_Fullname { get; set; }
        public string Client_Phone { get; set; }
        public bool Accepted { get; set; }
    }
}
