using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetclinic.Bases;

namespace vetclinic.Managers
{
    internal class OwnerManager
    {
        public static void AddOwner(OwnerBase owners)
        {
            Output.Print("Введите последовательно: имя, фамилию, адрес электронной почты");
            Owner owner = new Owner(Output.Read(), Output.Read(), Output.Read());
            owners.AddToList(owner);
        }

        public static void PrintOwners(OwnerBase owners)
        {
            foreach (Owner ow in owners.GetList())
            {
                Output.Print(ow.GetInfo());
            }
        }

        public static void AssignOwner(OwnerBase owners, PetBase pets)
        {
            PrintOwners(owners);
            Output.Print("Введите ID человека");
            string ownerID = Output.Read();
            PetsManager.PrintPets(pets);
            Output.Print("Введите ID животного");
            string petID = Output.Read();
            try
            {
                int.TryParse(ownerID, out int owid);
                int.TryParse(petID, out int pid);
                owners.FindByID(owid)?.AddPet(pets.FindByID(pid));
            }
            catch (ArgumentException)
            {
                Output.Print("Человека или животного с таким айди не существует");
            }
        }

        public static void PrintOwnerPets(OwnerBase owners)
        {
            if (!owners.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного владельца");
            }
            else
            {
                PrintOwners(owners);
                Output.Print("Введите ID человека, чьих животных хотите посмотреть");
                string id = Output.Read();
                try
                {
                    int.TryParse(id, out int num);
                    Output.Print($"На владельца {owners.FindByID(num).Name} записаны следующие животные:");
                    foreach (Pet pet in owners.FindByID(num).GetPets())
                    {
                        Output.Print(pet.GetInfo());
                    }
                }
                catch (Exception)
                {
                    Output.Print("Список пуст или не существует");
                }
            }
        }

        public static void RemoveOwner(OwnerBase owners)
        {
            if (!owners.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного владельца");
            }
            else
            {
                PrintOwners(owners);
                Output.Print("Введите ID человека для удаления");
                string id = Output.Read();
                try
                {
                    int.TryParse(id, out int num);
                    foreach (Pet pet in owners.FindByID(num).GetPets())
                    {
                        owners.FindByID(num).RemovePet(pet);
                    }
                    owners.RemoveByID(num);
                    Output.Print("Владелец удален из базы. У животных, пренадлежавших ему, больше не указан владелец");
                }
                catch (Exception)
                {
                    Output.Print("Не найдено в списке");
                }
            }
        }
    }
}
