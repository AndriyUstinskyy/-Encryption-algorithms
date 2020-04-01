using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    class Program

    {
        static void Main(string[] args)
        {
            
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("A generates keys");
                GenKeys gk = new GenKeys();
                int publicKey = gk.Generate();
                Console.WriteLine($"Public key is {publicKey}");
                gk.Authintification();
                Console.Write($" - {i} ");
            }
            
            Console.ReadKey();
        }
    }
}
