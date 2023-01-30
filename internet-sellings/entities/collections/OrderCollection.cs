﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities.collections
{
    public class OrderCollection : EFCollection<Order>
    {
        public OrderCollection(DbSet<Order> set) : base(set) => this.BindingList = set.Local.ToBindingList();
    }
}
