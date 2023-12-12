﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace vetclinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetBase pets = new PetBase();
            OwnerBase owners = new OwnerBase();
            AppointmentBase appointments = new AppointmentBase();
            
            Pet cat = new Pet("пушок", 12, "кот", false);
            Pet dog = new Pet("шарик", 3, "пес", true);

            pets.AddToList(cat);
            pets.AddToList(dog);
            Appointment appointment = new Appointment(cat);
            Treatment treatment = new Treatment("hahah", 800);
            Treatment treatment1 = new Treatment("nnnn", 100);
            appointment.AddTreatment(treatment);
            appointment.AddTreatment(treatment1);
            appointments.AddToList(appointment);


            //Output.Print(pets.FindByID(1).GetInfo());

            //pets.RemoveByID(1);

            //foreach (var st in pets.GetList())
            //{
            //    Output.Print(st.GetInfo());
            //}

            Owner owner = new Owner("людмила", "гурченко", "ddd");
            cat.Owner = owner;

            //OwnerBase owners= new OwnerBase();
            owners.AddToList(owner);
            owner.AddPet(cat);

            //foreach (var st in owners.GetList())
            //{
            //    Output.Print(st.GetInfo());
            //}

            //foreach (var st in pets.GetList())
            //{
            //    Output.Print(st.GetInfo());
            //}


            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

            bool MainMenu()
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
                        AddPet();
                        return true;

                    case "2":
                        PrintPets();
                        return true;

                    case "3":
                        RemovePet();
                        return true;

                    case "4":
                        AddOwner();
                        return true;

                    case "5":
                        PrintOwners();
                        return true;

                    case "6":
                        AssignOwner();
                        return true;

                    case "7":
                        PrintOwnerPets();
                        return true;

                    case "8":
                        RemoveOwner();
                        return true;

                    case "9":
                        ScheduleAppointment();
                        return true;

                    case"10":
                        AddTreatment();
                        return true;

                    case "11":
                        CreateBill();
                        return true;

                    case "12":
                        Console.Clear();
                        return true;

                    case "13":
                        return false;

                    default:
                        return true;
                }
            }

            //добавить надписи типа "на владельца {} записаны следующие животные:

            void AddPet()
            {
                Output.Print("1 - Обычное животное  2 - Птица  3 - Рептилия");
                switch (Output.Read())
                {
                    case "1":
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
                        break;

                    case "2":
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
                        break;

                    case "3":
                        Output.Print("Введите последовательно: кличку, возраст, вид, пол (true - м, false - ж), змея ли (true - да, false - нет)");
                        try
                        {
                            Pet pet = new Bird(Output.Read(), int.Parse(Output.Read()), Output.Read(), bool.Parse(Output.Read()), bool.Parse(Output.Read()));
                            pets.AddToList(pet);

                        }
                        catch (Exception)
                        {
                            Output.Print("Неверный ввод данных");
                        }
                        break;

                    default:
                        break;

                }
            }

            void PrintPets()
            {
                foreach (Pet pt in pets.GetList())
                {
                    Output.Print(pt.GetInfo());
                }
            }

            void RemovePet()
            {
                Output.Print("Введите ID животного");
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

            void AddOwner()
            {
                Output.Print("Введите последовательно: имя, фамилию, породу, пол (true - м, false - ж)");
                Owner owner = new Owner(Output.Read(), Output.Read(), Output.Read());
                owners.AddToList(owner);
            }

            void PrintOwners()
            {
                foreach (var ow in owners.GetList())
                {
                    Output.Print(ow.GetInfo());
                }
            }

            void AssignOwner()
            {
                Output.Print("Введите ID человека");
                string ownerID = Output.Read();
                Output.Print("Введите ID животного");
                string petID = Output.Read();
                try
                {
                    int.TryParse(ownerID, out int owid);
                    int.TryParse(ownerID, out int pid);
                    owners.FindByID(owid).AddPet(pets.FindByID(pid));
                }
                catch (ArgumentException)
                {
                    Output.Print("Человека или животного с таким айди не существует");
                }
            }

            void PrintOwnerPets()
            {
                Output.Print("Введите ID человека");
                string id = Output.Read();
                try
                {
                    int.TryParse(id, out int num);
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

            void RemoveOwner()
            {
                Output.Print("Введите ID человека");
                string id = Output.Read();
                try
                {
                    int.TryParse(id, out int num);
                    foreach (Pet pet in owners.FindByID(num).GetPets())
                    {
                        owners.FindByID(num).RemovePet(pet);
                    }
                    owners.RemoveByID(num);
                }
                catch (Exception)
                {
                    Output.Print("Не найдено в списке");
                }

            }

            void ScheduleAppointment()
            {
                Output.Print("Введите ID животного");
                string id = Output.Read();
                try
                {
                    int.TryParse(id, out int number);
                    Appointment appointment = new Appointment(pets.FindByID(number));
                    appointments.AddToList(appointment);
                }
                catch (ArgumentException)
                {
                    Output.Print("Такого животного нет");
                }
                //Appointment appointment = new Appointment(Pet pet);
                //appointments.AddToList(appointment);
            }

            void AddTreatment()
            {
                Output.Print("Введите ID приема");
                string appointmentID = Output.Read();
                Output.Print("Введите название, цену процедуры");
                try
                {
                    Treatment treatment = new Treatment(Output.Read(), double.Parse(Output.Read()));
                    int.TryParse(appointmentID, out int appid);
                    appointments.FindByID(appid).AddTreatment(treatment);
                }
                catch (Exception)
                {
                    Output.Print("Неверный ввод данных");
                }
            }

            void CreateBill()
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

        struct Output
        {
            public static void Print(string info) 
            {
                Console.WriteLine(info);
            }

            public static string Read()
            {
                return Console.ReadLine();
            }
        }

        struct Bill
        {
            public double TotalCost;

            public void GenerateBill(Appointment appointment)
            {
                Pet pet = appointment.Pet;
                if (pet is Bird)
                    TotalCost += 700;
                else if (pet is Reptile)
                    TotalCost += 900;
                else if (pet is Pet)
                    TotalCost += 500;

                foreach (Treatment treatment in appointment.GetList())
                {
                    Output.Print($"{treatment.Name}: {treatment.Price}");
                    TotalCost += treatment.Price;
                }

                Output.Print("---------------------------");
                Output.Print($"Общая стоимость: {TotalCost}");
            }
        }
    }
}
