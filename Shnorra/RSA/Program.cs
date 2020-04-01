using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Program
    {
        static int granted = 0;
        static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                GenKeys();
            }
            Console.WriteLine("TOTAL GRANTED: " + granted);
            Console.ReadKey();
        }

        static void GenKeys()
        {
            int p = 7, q = 13;
            //int p = 3, q = 7;
            int n = p * q;
            int fn = (p - 1) * (q - 1);
            int e = 2;
            int d = 0;

            while (!IsCoprime(e, fn)) //нашли простое число (и степень)
            {
                e++;
            }

            while ((d * e) % fn != 1)
            {
                d++;
            }
            Console.WriteLine($"Private key d = {d}");

            bool IsCoprime(int a, int b)
            {
                return a == b ? a == 1 : a > b ? IsCoprime(a - b, b) : IsCoprime(b - a, a);
            }
            Console.WriteLine($"A sends e,n to B");

            Random random = new Random();
            int k = random.Next(1, n - 1);
            int r = (int)(Math.Pow(k, e) % n);
            Console.WriteLine($"B sends r = {r} to A");

            int kStroke = (int)(Math.Pow(r, d) % n);
            Console.WriteLine($"A sends k` = {kStroke} to B");

            if (k == kStroke)
            {
                Console.WriteLine("ACCESS GRANTED!");
                granted++;

            }  
            else
            {
                Console.WriteLine("ACCESS DENIED!");
            }
            
        }
    }
}
