using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Bird : Pet
    {
        public bool Flying { get; set; }
        public override int Min { get { return 700; } }
        public Bird(string name, int age, string breed, bool gender, bool flying) : base(name, age, breed, gender)
        {
            Flying = flying;
        }
    }
}
