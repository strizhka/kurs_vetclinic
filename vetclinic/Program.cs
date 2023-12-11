using System;
using System.Collections.Generic;

namespace vetclinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pet cat = new Pet("", 12, "", false, null);
            
            Pet dog = new Pet("nwdad", 3, "", true);
            PetBase pets = new PetBase();
            pets.AddToList(cat);
            pets.AddToList(dog);

            Output.Print(pets.FindByID(1).GetInfo());

            pets.RemoveByID(1);

            foreach (var st in pets.GetList())
            {
                Output.Print(st.GetInfo());
            }

            Owner owner = new Owner("sdfv", "sdfvghehe", "ddd");
            cat.Owner = owner;

            OwnerBase owners= new OwnerBase();
            owners.AddToList(owner);

            foreach (var st in owners.GetList())
            {
                Output.Print(st.GetInfo());
            }

            foreach (var st in pets.GetList())
            {
                Output.Print(st.GetInfo());
            }

        }

        struct Output
        {
            public static void Print(string info) 
            {
                Console.WriteLine(info);
            }
        }
    }
}
