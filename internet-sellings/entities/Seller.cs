using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Seller : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public bool PayDeliviry { get; set; }
    }
}
