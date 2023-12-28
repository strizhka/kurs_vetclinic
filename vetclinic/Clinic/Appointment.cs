using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace vetclinic
{
    internal class Appointment : IRefundable     //класс для приемов
    {
        private List<Treatment> _treatments;     //список проводимых на приеме процедур
        public static int CountID = 1;
        public int AppointmentID;
        public Pet Pet { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(Pet pet) 
        {
            AppointmentDate = DateTime.Now;
            Pet = pet;                              //привязка к конкретному животному
            _treatments = new List<Treatment>();
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

        public string GetInfo()
        {
            return $"ID {AppointmentID}  Животное: {Pet.Breed} {Pet.Name}  Время и дата приема: {AppointmentDate}";
        }
    }
}
