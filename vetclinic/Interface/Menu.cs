using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetclinic.Bases;
using vetclinic.Managers;

namespace vetclinic
{
    internal class Menu
    {
        public static bool MainMenu(PetBase pets, OwnerBase owners, AppointmentBase appointments)
        {
            Output.Print("\nЧто нужно сделать?\n" +
                "1 - Добавить животное\n" +
                "2 - Посмотреть список животных\n" +
                "3 - Удалить животное из списка\n" +
                "4 - Добавить владельца\n" +
                "5 - Посмотреть список владельцев\n" +
                "6 - Назначить животному владельца\n" +
                "7 - Посмотреть всех животных владельца\n" +
                "8 - Удалить владельца из списка\n" +
                "9 - Назначить прием\n" +
                "10 - Добавить процедуру в прием\n" +
                "11 - Рассчитать итоговую стоимость приема\n" +
                "12 - Очистить консоль\n" +
                "13 - Выход из приложения");

            switch (Output.Read())
            {
                case "1":
                    PetsManager.AddPet(pets);
                    return true;

                case "2":
                    PetsManager.PrintPets(pets);
                    return true;

                case "3":
                    PetsManager.PrintPets(pets);
                    PetsManager.RemovePet(pets);
                    return true;

                case "4":
                    OwnerManager.AddOwner(owners);
                    return true;

                case "5":
                    OwnerManager.PrintOwners(owners);
                    return true;

                case "6":
                    OwnerManager.AssignOwner(owners, pets);
                    return true;

                case "7":
                    OwnerManager.PrintOwnerPets(owners);
                    return true;

                case "8":
                    OwnerManager.RemoveOwner(owners);
                    return true;

                case "9":
                    AppointmentManager.ScheduleAppointment(pets, appointments);
                    return true;

                case "10":
                    AppointmentManager.AddTreatment(appointments);
                    return true;

                case "11":
                    Bill.PrintBill(appointments);
                    return true;

                case "12":
                    Output.Clear();
                    return true;

                case "13":
                    return false;

                default:
                    return true;
            }
        }
    }
}

