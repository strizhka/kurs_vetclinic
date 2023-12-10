using System;
using System.Collections.Generic;

namespace vetclinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet cat = new Pet("", 12, "", false);
            Pet dog = new Pet("nwdad", 3, "", true);
            PetBase pets = new PetBase();
            pets.AddToList(cat);
            pets.AddToList(dog);

            Console.WriteLine(pets.FindByID(1).GetInfo());

            pets.RemoveByID(1);

            foreach (var st in pets.GetList())
            {
                Console.WriteLine(st.GetInfo());
            }
        }
    }
}
