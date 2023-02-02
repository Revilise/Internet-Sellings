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
    public abstract class EFCollection<T> : INotifyPropertyChanged where T : BaseEntity
    {
        public DbSet Entity;
        public EFCollection(DbSet set)
        {
            this.Entity = set;
            this.Entity.Load();
        }     
        public void Load()
        {
            this.Entity.Load();
        }
        public String Search {
            get => _search; 
            set {
                _search = value;
                OnPropetryChanged("Search");
            }
        }
        public BindingList<T> BindingList {
            get => _bindingList;
            set
            {
                _bindingList = value;
                OnPropetryChanged("BindingList");
            }
        }
        public void CollectionChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    this.BindingList[e.NewIndex].Id = this.Entity.Local.Count + 1;
                    break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropetryChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        /// <summary>
        /// Поиск значений в BindingList по предикату. Изменяет текущий BindingList в соответствии с условием predicate
        /// </summary>
        /// <param name="predicate">Условие фильтрации</param>
        public void Where(Func<T, bool> predicate)
        {
            this.BindingList = new BindingList<T>(
                this.Entity.Cast<T>().Where(predicate).ToList()
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
        protected string _search;
    }
}
