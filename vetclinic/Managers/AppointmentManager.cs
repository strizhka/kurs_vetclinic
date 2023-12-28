using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetclinic.Bases;

namespace vetclinic.Managers
{
    internal class AppointmentManager
    {
        public static void PrintAppointments(AppointmentBase appointments)
        {
            foreach (Appointment app in appointments.GetList())
            {
                Output.Print(app.GetInfo());
            }
        }

        public static void ScheduleAppointment(PetBase pets, AppointmentBase appointments)
        {
            if (!pets.GetList().Any())
            {
                Output.Print("В базе еще нет ни одного животного. Добавьте его");
                PetsManager.AddPet(pets);
            }

            PetsManager.PrintPets(pets);
            Output.Print("Введите ID животного, которого надо записать на прием");
            string id = Output.Read();
            try
            {
                int.TryParse(id, out int number);
                Appointment appointment = new Appointment(pets.FindByID(number));
                appointments.AddToList(appointment);
                Output.Print($"{pets.FindByID(number).Name} записан на прием {appointment.AppointmentDate}");
            }
            catch (Exception)
            {
                Output.Print("Такого животного нет");
            }
        }

        public static void AddTreatment(AppointmentBase appointments)
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
    }
}
