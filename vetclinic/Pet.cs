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

        public Owner Owner { get; set; }            //Способ для добавления животного в список владельца

        public string Name
        {
            get => _name;

            init => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string Breed
        {
            get => _breed;

            init => _breed = !string.IsNullOrEmpty(value) ? value : "Не указано";
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

        public Pet(string name, int age, string breed, bool gender, Owner owner)
        {
            Name = name;
            Age = age;
            Breed = breed;
            Gender = gender;
            Owner = owner;
            PetID = CountID++;
        }

        public Pet(string name, int age, string breed, bool gender)
        {
            Name = name;
            Age = age;
            Breed = breed;
            Gender = gender;
            PetID = CountID++;
        }

        public string GetGender()
        {
            if (Gender)
                return "М";
            else
                return "Ж";
        }

        public string GetInfo()
        {
            return $"ID {PetID}  Владелец: {Owner?.Name ?? "Не указано"}  Кличка: {Name}  Возраст: {Age}  Порода: {Breed}  Пол: {GetGender()}";
        }
    }
}
