using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Doctor
    {
        public static int CountID = 0;
        private string _name;
        private string _lastName;
        private string _specialisation;
        public int DoctorID;

        public string Name
        {
            get => _name;

            init => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string LastName
        {
            get => _lastName;

            init => _lastName = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public string Specialisation
        {
            get => _specialisation;

            init => _specialisation = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public Doctor(string name, string lastname, string specialisation)
        {
            Name = name;
            LastName = lastname;
            Specialisation = specialisation;
            DoctorID = CountID++;
        }

        public string GetInfo()
        {
            return $"ID {DoctorID}  Имя: {Name}  Фамилия: {LastName}  Специализация: {Specialisation}";
        }
    }
}
