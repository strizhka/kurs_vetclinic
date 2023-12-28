using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetclinic.Bases;

namespace vetclinic.Managers
{
    internal class PetsManager
    {
        public static void AddPet(PetBase pets)
        {
            Output.Print("1 - Обычное животное  2 - Птица  3 - Рептилия");
            switch (Output.Read())
            {
                case "1":
                    AddCommonPet(pets);
                    break;

                case "2":
                    AddBird(pets);
                    break;

                case "3":
                    AddReprile(pets);
                    break;

                default:
                    break;

            }
        }

        public static void AddCommonPet(PetBase pets)
        {
            Output.Print("Введите последовательно: кличку, возраст, породу, пол (true - м, false - ж)");
            try
            {
                Pet pet = new Pet(Output.Read(), int.Parse(Output.Read()), Output.Read(), bool.Parse(Output.Read()));
                pets.AddToList(pet);

            }
            catch (Exception)
            {
                Output.Print("Неверный ввод данных");
            }
        }

        public static void AddBird(PetBase pets)
        {
            Output.Print("Введите последовательно: кличку, возраст, вид, пол (true - м, false - ж), способен ли летать (true - да, false - нет)");
            try
            {
                Pet pet = new Bird(Output.Read(), int.Parse(Output.Read()), Output.Read(), bool.Parse(Output.Read()), bool.Parse(Output.Read()));
                pets.AddToList(pet);

            }
            catch (Exception)
            {
                Output.Print("Неверный ввод данных");
            }
        }

        public static void AddReprile(PetBase pets)
        {
            Output.Print("Введите последовательно: кличку, возраст, вид, пол (true - м, false - ж), змея ли (true - да, false - нет)");
            try
            {
                Pet pet = new Reptile(Output.Read(), int.Parse(Output.Read()), Output.Read(), bool.Parse(Output.Read()), bool.Parse(Output.Read()));
                pets.AddToList(pet);

            }
            catch (Exception)
            {
                Output.Print("Неверный ввод данных");
            }
        }

        public static void PrintPets(PetBase pets)
        {
            if (!pets.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного животного");
            }
            else
            {
                foreach (Pet pt in pets.GetList())
                {
                    Output.Print(pt.GetInfo());
                }
            }
        }

        public static void RemovePet(PetBase pets)
        {
            if (!pets.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного животного");
            }
            else
            {
                Output.Print("Введите ID животного для удаления");
                string id = Output.Read();
                try
                {
                    int.TryParse(id, out int number);
                    pets.RemoveByID(number);
                }
                catch (Exception)
                {
                    Output.Print("Не найдено в списке");
                }
            }
        }
    }
}
