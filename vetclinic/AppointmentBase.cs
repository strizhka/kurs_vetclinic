using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class AppointmentBase : Base<Appointment>
    {
        public AppointmentBase() { }

        public AppointmentBase(List<Appointment> appointments) : base(appointments) { }

        public override Appointment FindByID(int appointmentID)
        {
            return _list.Find(appointment => appointment.AppointmentID == appointmentID) ?? throw new ArgumentException("Не найдено в списке");
        }
    }
}
