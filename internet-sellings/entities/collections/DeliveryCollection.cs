using internet_sellings.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities.collections
{
    public class DeliveryCollection : EFCollection<Delivery>
    {
        public DeliveryCollection(DbSet<Delivery> set) : base(set)
        {
            this.BindingList = set.Local.ToBindingList();
            this.BindingList.ListChanged += CollectionChanged;
        }
    }
}
