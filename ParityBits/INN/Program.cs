using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INN
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "1181111110";
            string input = "3803300254";
            Console.WriteLine($"INPUT {input}");
            if(((2* (int)char.GetNumericValue(input[0]) + 4 * (int)char.GetNumericValue(input[1]) + 10 * (int)char.GetNumericValue(input[2])
                + 3 * (int)char.GetNumericValue(input[3]) + 5 * (int)char.GetNumericValue(input[4]) + 9 * (int)char.GetNumericValue(input[5])
                + 4 * (int)char.GetNumericValue(input[6]) + 8 * (int)char.GetNumericValue(input[8])
                + 6 * (int)char.GetNumericValue(input[7])) % 11) % 10 == (int)char.GetNumericValue(input[9]))
            {
                Console.WriteLine("CONFIRMED");
            }
            else
            {
                Console.WriteLine("REJECT");
            }
            Console.ReadKey();
        }
    }
}
