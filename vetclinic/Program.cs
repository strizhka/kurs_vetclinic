using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            
            Pet cat = new Pet("Дуся", 12, "кошка", false);
            Pet dog = new Pet("Шарик", 3, "пес", true);
            Pet bird = new Bird("Кеша", 1, "попугай", true, true);

            pets.AddToList(cat);
            pets.AddToList(dog);
            Appointment appointment = new Appointment(cat);
            Treatment treatment = new Treatment("Анализы", 800);
            Treatment treatment1 = new Treatment("Укол", 100);
            appointment.AddTreatment(treatment);
            appointment.AddTreatment(treatment1);
            appointments.AddToList(appointment);

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
