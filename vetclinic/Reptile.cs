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
        public override int Min { get { return 900; } }
        public Reptile(string name, int age, string breed, bool gender, bool isSnake) : base(name, age, breed, gender)
        {
            IsSnake = isSnake;
        }
    }
}
