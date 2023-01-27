using internet_sellings.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.db_model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public DateTime warrantry_period { get; set; }
        public string specifications { get; set; }
        public string image { get; set; }
    }
}
