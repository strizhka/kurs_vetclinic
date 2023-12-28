using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vetclinic.Bases;

namespace vetclinic.Managers
{
    internal class BillsManager
    {
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
    }
}
