using internet_sellings.classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities.collections
{
    public class ProductCollection : EFCollection<Product>
    {
        public ProductCollection(DbSet<Product> set) : base(set)
        {
            this.BindingList = set.Local.ToBindingList();
            this.BindingList.ListChanged += CollectionChanged;
        }

        public new string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropetryChanged("Search");
                this.Where(
                    x => x.Name.IndexOf(_search) > -1 || x.Producer.IndexOf(_search) > -1 || x.Image.IndexOf(_search) > -1
                );
            }
        }
    }
}
