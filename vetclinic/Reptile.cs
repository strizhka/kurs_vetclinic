﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Reptile : Pet
    {
        public bool IsSnake { get; set; }
        public const double AdditionalPrice = 900;
        public Reptile(string name, int age, string breed, bool gender, bool isSnake) : base(name, age, breed, gender)
        {
            IsSnake = isSnake;
        }

        public Reptile(string name, int age, string breed, bool gender, Owner owner, bool isSnake) : base(name, age, breed, gender, owner)
        {
            IsSnake = isSnake;
        }
    }
}