using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    AddPet(pets);
                    return true;

                case "2":
                    PrintPets(pets);
                    return true;

                case "3":
                    PrintPets(pets);
                    RemovePet(pets);
                    return true;

                case "4":
                    AddOwner(owners);
                    return true;

                case "5":
                    PrintOwners(owners);
                    return true;

                case "6":
                    AssignOwner(owners, pets);
                    return true;

                case "7":
                    PrintOwnerPets(owners);
                    return true;

                case "8":
                    RemoveOwner(owners);
                    return true;

                case "9":
                    ScheduleAppointment(pets, appointments);
                    return true;

                case "10":
                    AddTreatment(appointments);
                    return true;

                case "11":
                    CreateBill(appointments);
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

        private static void AddPet(PetBase pets)
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

        private static void AddCommonPet(PetBase pets)
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

        private static void AddBird(PetBase pets)
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

        private static void AddReprile(PetBase pets)
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

        private static void PrintPets(PetBase pets)
        {
            foreach (Pet pt in pets.GetList())
            {
                Output.Print(pt.GetInfo());
            }
        }

        private static void RemovePet(PetBase pets)
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
                catch (ArgumentException)
                {
                    Output.Print("Не найдено в списке");
                }
            }
        }

        private static void AddOwner(OwnerBase owners)
        {
            Output.Print("Введите последовательно: имя, фамилию, адрес электронной почты");
            Owner owner = new Owner(Output.Read(), Output.Read(), Output.Read());
            owners.AddToList(owner);
        }

        private static void PrintOwners(OwnerBase owners)
        {
            foreach (Owner ow in owners.GetList())
            {
                Output.Print(ow.GetInfo());
            }
        }

        private static void AssignOwner(OwnerBase owners, PetBase pets)
        {
            PrintOwners(owners);
            Output.Print("Введите ID человека");
            string ownerID = Output.Read();
            PrintPets(pets);
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

        private static void PrintOwnerPets(OwnerBase owners)
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

        private static void RemoveOwner(OwnerBase owners)
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

        private static void ScheduleAppointment(PetBase pets, AppointmentBase appointments)
        {
            if (!pets.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного животного. Добавьте его");
                AddPet(pets);
            }

            PrintPets(pets);
            Output.Print("Введите ID животного, которого надо записать на прием");
            string id = Output.Read();
            try
            {
                int.TryParse(id, out int number);
                Appointment appointment = new Appointment(pets.FindByID(number));
                appointments.AddToList(appointment);
                Output.Print($"{pets.FindByID(number).Name} записан на прием {appointment.AppointmentDate}");
            }
            catch (ArgumentException)
            {
                Output.Print("Такого животного нет");
            }
        }

        private static void AddTreatment(AppointmentBase appointments)
        {
            if (!appointments.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного приема");
            }
            else
            {
                Output.Print("Введите ID приема, на котором провелись процедуры");
                string appointmentID = Output.Read();
                
                try
                {   
                    int.TryParse(appointmentID, out int appid);
                    Output.Print("Введите название, цену процедуры");
                    Treatment treatment = new Treatment(Output.Read(), double.Parse(Output.Read()));
                    appointments.FindByID(appid).AddTreatment(treatment);
                }
                catch (Exception)
                {
                    Output.Print("Неверный ввод данных");
                }
            }
        }

        private static void CreateBill(AppointmentBase appointments)
        {
            Output.Print("Введите ID приема");
            string appointmentID = Output.Read();
            Bill bill = new Bill();
            try
            {
                int.TryParse(appointmentID, out int num);
                bill.GenerateBill(appointments.FindByID(num));
            }
            catch (Exception)
            {
                Output.Print("Не найдено в списке");
            }
        }

    }
}

