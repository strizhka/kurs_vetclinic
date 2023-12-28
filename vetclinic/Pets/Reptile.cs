using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Reptile : Pet
    {
        public bool IsSnake { get; init; }
        public override int Min { get => 900; }
        public Reptile(string name, int age, string breed, bool gender, bool isSnake) : base(name, age, breed, gender)
        {
            IsSnake = isSnake;
        }

        public override string GetInfo()
        {
            return $"ID {PetID}  Владелец: {Owner?.Name ?? "Не указано"}  Кличка: {Name}  Возраст: {Age}  Вид: {Breed}  Пол: {GetGender()}  Змея ли: {IsSnake}";
        }
    }
}
