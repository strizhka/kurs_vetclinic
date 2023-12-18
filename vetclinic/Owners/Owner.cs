using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Owner
    {
        private string _name;
        private string _lastName;
        private string _email;
        private List<Pet> _pets;
        public static int CountID = 0;
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

        public string Email
        {
            get => _email;

            init => _email = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public Owner(string name, string lastname, string email)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            _pets = new List<Pet>();
            OwnerID = CountID++;
        }

        public void AddPet(Pet pet)
        {
            if (pet != null && !_pets.Contains(pet))
            {
                pet.Owner = this;
                _pets.Add(pet);
            }
        }

        public void RemovePet(Pet pet)
        {
            if (pet != null && _pets.Contains(pet))
            {
                pet.Owner = null;
            }
        }

        public IEnumerable<Pet> GetPets()
        {
            return _pets.AsReadOnly();
        }

        public string GetInfo()
        {
            return $"ID {OwnerID}  Имя: {Name}  Фамилия: {LastName}  Адрес почты: {Email}";
        }
    }
}
