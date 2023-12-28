using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetclinic
{
    internal class Output
    {
        public static void Print(string info)
        {
            Console.WriteLine(info);
        }

        public static string Read()
        {
            return Console.ReadLine();
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
