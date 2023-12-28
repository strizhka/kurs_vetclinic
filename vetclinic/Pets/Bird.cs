using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Bird : Pet
    {
        public bool Flying { get; init; }
        public override int Min { get => 700; }

        public Bird(string name, int age, string breed, bool gender, bool flying) : base(name, age, breed, gender)
        {
            Flying = flying;
        }

        public override string GetInfo()
        {
            return $"ID {PetID}  Владелец: {Owner?.Name ?? "Не указано"}  Кличка: {Name}  Возраст: {Age}  Вид: {Breed}  Пол: {GetGender()}  Летает: {Flying}";
        }
    }
}
