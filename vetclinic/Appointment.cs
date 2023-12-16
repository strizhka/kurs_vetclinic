using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Appointment      //класс для приемов
    {
        public static int CountID = 0;
        public int AppointmentID;
        private List<Treatment> treatments;     //список проводимых на приеме процедур
        public Pet Pet { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(Pet pet) 
        {
            AppointmentDate = DateTime.Now;
            Pet = pet;                              //привязка к конкретному животному
            treatments = new List<Treatment>();
            AppointmentID = CountID++;
        }

        public void AddTreatment(Treatment treatment) 
        {
            if (treatment != null) 
            { 
                treatments.Add(treatment);
            }
        }

        public IEnumerable<Treatment> GetList()
        {
            return treatments.AsReadOnly();
        }
    }
}
