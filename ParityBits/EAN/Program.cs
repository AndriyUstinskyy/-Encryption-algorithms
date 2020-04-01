using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAN
{ 
    class Program
    {
        //static string input = "5901234123457";
        static string input = "2400000032632";
        static void Main(string[] args)
        {
            Console.WriteLine($"INPUT: {input}");
            Do();
            Console.ReadKey();
        }
        static void Do()
        {
            int Sh = 0;
            int Sch = 0;
            int cd = (int)char.GetNumericValue(input[input.Length - 1]);
            for (int i = 0; i < input.Length-1; i += 2)
            {
                Sh += (int)char.GetNumericValue(input[i]);
            }
            for (int i = 1; i < input.Length; i += 2)
            {
                Sch += (int)char.GetNumericValue(input[i]);
            }
            Console.WriteLine($"Sh = {Sh}, Sch = {Sch}, cd = {cd}");
            if ((Sh + Sch + cd) % 10 == 0)
                Console.WriteLine("CONFIRMED");
            else
                Console.WriteLine("REJECT");
        }
    }
}
