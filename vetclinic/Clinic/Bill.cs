using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetclinic.Bases;

namespace vetclinic
{
    internal class Bill
    {
        public double TotalCost { get; set; }

        public void GenerateBill(Appointment appointment)
        {
            PrintAppointmentDetails(appointment);
            CountTotalCost(appointment);
            PrintTotalCost();
        }

        public static void PrintBill(AppointmentBase appointments)
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

        private void PrintAppointmentDetails(Appointment appointment)
        {
            Output.Print($"Цена осмотра {appointment.Pet.Breed}: {appointment.Pet.Min}");
            foreach (Treatment treatment in appointment.GetList())
            {
                Output.Print($"{treatment.Name}: {treatment.Price}");
            }
        }

        private void CountTotalCost(Appointment appointment)
        {
            TotalCost += appointment.Pet.Min;
            foreach (Treatment treatment in appointment.GetList())
            {
                TotalCost += treatment.Price;
            }
        }

        private void PrintTotalCost()
        {
            Output.Print($"Общая стоимость: {TotalCost}");
        }
    }
}
