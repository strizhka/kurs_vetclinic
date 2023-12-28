using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Owner : IRefundable
    {
        private string _name;
        private string _lastName;
        private string _email;
        private List<Pet> _pets;
        public static int CountID = 1;
        public int OwnerID;

        public string Name
        {
            get => _name;

            set => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string LastName
        {
            get => _lastName;

            set => _lastName = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string Email
        {
            get => _email;

            set
            {
                if (!string.IsNullOrEmpty(value?.Trim()))
                {
                    const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    var email = value.Trim().ToLowerInvariant();

                    if (Regex.Match(email, pattern).Success && !Regex.IsMatch(email, @"\p{IsCyrillic}"))    //соответствует ли строка email шаблону pattern и не содержит ли кириллицы
                    {
                        _email = value;
                    }
                    else
                    {
                        throw new ArgumentException("Неверно указан email.", nameof(Email));
                    }
                }
                else
                    _email = "Не  указано";
            }
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
