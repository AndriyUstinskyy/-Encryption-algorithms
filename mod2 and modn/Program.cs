using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure_lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string test1 = "УСТІНСЬКИЙ";
            string gamma = "АНДРІЙУСТІ";

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(new string('-', 20) + "MOD N" + new string('-', 20));
            ModN modN = new ModN(test1, gamma);
            Console.WriteLine($"RESULT STRING: {modN.Encode()} \n");

            Console.WriteLine(new string('-', 20) + "MOD 2" + new string('-', 20));
            Mod2 mod2 = new Mod2(test1, gamma);
            Console.WriteLine($"RESULT STRING: {mod2.Encode()}");
            Console.ReadKey();
        }
    }
}
