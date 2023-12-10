using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Owner
    {
        public static int CountID = 0;
        private string _name;
        private string _lastName;
        private string _adress;
        //private List<Pet> _pets;
        public int OwnerID;

        public string Name
        {
            get => _name;

            init => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string LastName
        {
            get => _lastName;

            init => _lastName = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string Adress
        {
            get => _adress;

            init => _adress = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public Owner(string name, string lastname, string adress)
        {
            Name = name;
            LastName = lastname;
            Adress = adress;
            OwnerID = CountID++;
        }

        public string GetInfo()
        {
            return $"ID {OwnerID}  Имя: {Name}  Фамилия: {LastName}  Адрес: {Adress}";
        }
    }
}
