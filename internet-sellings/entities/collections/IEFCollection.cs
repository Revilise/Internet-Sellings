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
        public void Search(Func<T, bool> predicate)
        {
            this.BindingList = new BindingList<T>(
                this.BindingList.Where(predicate).ToList()
            );
        }
        public void RefreshBindingList()
        {
            this.Entity.Load();

            this.BindingList = new BindingList<T>(
                this.Entity.Cast<T>().ToList()
            );
        }

        private BindingList<T> _bindingList;
    }
}
