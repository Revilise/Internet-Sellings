using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internet_sellings.entities.collections
{
    public abstract class EFCollection<T> : INotifyPropertyChanged
    {
        public DbSet Entity;
        public EFCollection(DbSet set)
        {
            this.Entity = set;
            this.Entity.Load();
        }
        public BindingList<T> BindingList {
            get => _bindingList;
            set
            {
                _bindingList = value;
                OnPropetryChanged("BindingList");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropetryChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private BindingList<T> _bindingList;
    }
}
