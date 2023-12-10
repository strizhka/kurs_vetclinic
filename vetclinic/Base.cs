using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    public abstract class Base<T> where T : class
    {
        protected List<T> _list;

        public Base()
        {
            _list = new List<T>();
        }

        public Base(List<T> pets)
        {
            _list = pets;
        }

        public void AddToList(T pet)
        {
            if (!_list.Contains(pet) && pet != null)
                _list.Add(pet);
            else
                throw new ArgumentException("В списке уже есть это животное!");
        }

        public void RemoveByID(int petID)
        {
            if (_list.Contains(FindByID(petID)))
                _list.Remove(FindByID(petID));
            else
                throw new ArgumentException("Такого животного нет в базе!");
        }

        public abstract T FindByID(int ID);

        public IEnumerable<T> GetList()
        {
            return _list.AsReadOnly();
        }
    }
}
