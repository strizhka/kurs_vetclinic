using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class DoctorBase : Base<Doctor>
    {
        public DoctorBase() { }

        public DoctorBase(List<Doctor> doctors) : base(doctors) { }

        public override Doctor FindByID(int doctorID)
        {
            return _list.Find(doctor => doctor.DoctorID == doctorID);
        }

    }
}
