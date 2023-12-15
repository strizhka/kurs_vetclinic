using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Reptile : Pet
    {
        public bool IsSnake { get; set; }
        public new int Min = 900;
        public Reptile(string name, int age, string breed, bool gender, bool isSnake) : base(name, age, breed, gender)
        {
            IsSnake = isSnake;
        }
    }
}
