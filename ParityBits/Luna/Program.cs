using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luna
{
    class Program
    {
        static string input = "354190023896443";
        static void Main(string[] args)
        {
            Console.WriteLine($"INPUT: {input}");
            int choose = input.Length % 2 == 0 ? 0 : 1;
            Do(choose);
            Console.ReadKey();
        }
        static void Do(int choose)
        {
            int Sh = 0;
            int Sch = 0;
            int cd = (int)char.GetNumericValue(input[input.Length - 1]);
            for (int i = choose; i < input.Length; i += 2)
            {
                int temp = ((int)char.GetNumericValue(input[i]) * 2) % 9;
                Sh += temp;
            }
            for (int i = 1 - choose; i < input.Length - 1; i += 2)
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
