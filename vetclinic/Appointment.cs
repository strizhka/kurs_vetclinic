using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Appointment
    {
        public static int CountID = 0;
        public int AppointmentID;
        public DateTime AppointmentDate { get; set; }

        public Appointment(DateTime appointmentDate) 
        {
            AppointmentDate = appointmentDate;
        }
    }
}
