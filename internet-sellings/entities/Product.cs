using internet_sellings.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public DateTime Warrantry_period { get; set; }
        public string Specifications { get; set; }
        public string Image { get; set; }
    }
}
