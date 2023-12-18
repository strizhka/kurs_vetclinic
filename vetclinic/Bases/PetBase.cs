using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic.Bases
{
    class PetBase : Base<Pet>
    {
        public PetBase() : base() { }

        public PetBase(List<Pet> pets) : base(pets) { }

        public override Pet FindByID(int petID)
        {
            return _list.Find(pet => pet.PetID == petID) ?? throw new ArgumentException("Не найдено в списке");
        }
    }
}
