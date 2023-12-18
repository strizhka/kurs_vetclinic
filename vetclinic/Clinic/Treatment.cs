using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Treatment
    {
        private string _name;
        private double _price;
        public static int CountID = 0;
        public int TreatmentID;

        public string Name
        {
            get => _name;

            init => _name = !string.IsNullOrEmpty(value) ? value : "Не указано";
        }

        public double Price
        {
            get => _price;

            set
            {
                if (value >= 0)
                    _price = value;
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Price), "Неверно указана стоимость");
                }
            }
        }

        public Treatment(string name, double price)
        {
            Name = name;
            Price = price;
            TreatmentID = CountID++;
        }

        public string GetInfo()
        {
            return $"ID {TreatmentID}  Название: {Name}  Стоимость: {Price}";
        }
    }
}
