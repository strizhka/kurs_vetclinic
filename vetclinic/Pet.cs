using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Pet
    {
        public static int CountID = 0;
        private string _name;
        private int _age;
        private string _breed;
        public int PetID;

        public bool Gender { get; set; }

        public string Name
        {
            get => _name;

            init => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }



        public int Age
        {
            get => _age;

            set
            {
                if (value >= 0)
                    _age = value;
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Age), "Неверно указан возраст");
                }
            }
        }

        public Pet(string name, string lastname, int age)
        {
            Name = name;
            Age = age;
            PetID = CountID++;
        }
    }
}
