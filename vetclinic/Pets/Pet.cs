using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Pet : IRefundable
    {
        private string _name;
        private int _age;
        private string _breed;
        public static int CountID = 1;
        public int PetID;

        public virtual int Min { get => 500; }

        public bool IsMale { get; init; }

        public Owner Owner { get; set; }

        public string Name
        {
            get => _name;

            set => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
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

        public Pet(string name, int age, string breed, bool gender)
        {
            Name = name;
            Age = age;
            Breed = breed;
            IsMale = gender;
            PetID = CountID++;
        }

        public string GetGender()
        {
            if (IsMale)
                return "М";
            else
                return "Ж";
        }

        public virtual string GetInfo()
        {
            return $"ID {PetID}  Владелец: {Owner?.Name ?? "Не указано"}  Кличка: {Name}  Возраст: {Age}  Порода: {Breed}  Пол: {GetGender()}";
        }
    }
}
