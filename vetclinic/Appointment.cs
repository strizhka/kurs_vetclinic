using System;
using System.Collections;
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
        private List<Treatment> _treatments;
        public Pet Pet { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(DateTime appointmentDate, Pet pet) 
        {
            AppointmentDate = appointmentDate;
            Pet = pet;
            AppointmentID = CountID++;
        }

        public void AddTreatment(Treatment treatment) 
        {
            if (treatment != null) 
            { 
                _treatments.Add(treatment);
            }
        }
        public IEnumerable<Treatment> GetList()
        {
            return _treatments.AsReadOnly();
        }
    }
}
