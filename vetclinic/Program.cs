using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using vetclinic.Bases;

namespace vetclinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PetBase pets = new PetBase();
            OwnerBase owners = new OwnerBase();
            AppointmentBase appointments = new AppointmentBase();
            
            Pet cat = new Pet("Дуся", 12, "кошка", false);
            Pet dog = new Pet("Шарик", 3, "пес", true);
            Pet bird = new Bird("Кеша", 1, "попугай", true, true);

            pets.AddToList(cat);
            pets.AddToList(dog);
            pets.AddToList(bird);

            Appointment appointment = new Appointment(cat);
            Appointment appointment1 = new Appointment(bird);

            Treatment treatment = new Treatment("Анализ А", 800);
            Treatment treatment1 = new Treatment("Анализ Б", 1000);
            Treatment treatment2 = new Treatment("Обрезка когтей", 300);
            Treatment treatment3 = new Treatment("Анализ В", 950);
            Treatment treatment4 = new Treatment("Обработка от паразитов", 800);
            Treatment treatment5 = new Treatment("Оформление вет паспорта", 100);

            appointment.AddTreatment(treatment);
            appointment.AddTreatment(treatment2);
            appointment1.AddTreatment(treatment3);
            appointment.AddTreatment(treatment4);

            appointment1.AddTreatment(treatment1);
            appointment1.AddTreatment(treatment3);
            appointment1.AddTreatment(treatment5);

            appointments.AddToList(appointment);
            appointments.AddToList(appointment1);

            Owner owner = new Owner("Людмила", "Сушкина", "Email");
            owners.AddToList(owner);
            owner.AddPet(cat);

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu.MainMenu(pets, owners, appointments);
            }
        }
    }
}
