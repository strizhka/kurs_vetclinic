using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic.Bases
{
    public abstract class Base<T> where T : class       //шаблон подо все базы (животные, люди, приемы)
    {
        protected List<T> _list;

        public Base()
        {
            _list = new List<T>();
        }

        public Base(List<T> list)
        {
            _list = list;
        }

        public void AddToList(T item)
        {
            if (!_list.Contains(item) && item != null)
                _list.Add(item);
            else
                throw new ArgumentException("Уже имеется в списке");
        }

        public void RemoveByID(int ID)
        {
            if (_list.Contains(FindByID(ID)))
                _list.Remove(FindByID(ID));
            else
                throw new ArgumentException();
        }

        public abstract T FindByID(int ID);

        public IEnumerable<T> GetList()
        {
            return _list.AsReadOnly();
        }
    }
}
