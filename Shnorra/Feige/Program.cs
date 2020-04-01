using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feige
{
    class Program
    {
        static int denied = 0;
        static void Main(string[] args)
        {
            for(int i = 0;i < 5;i++)
            {
                GenKeys();
            }
            Console.WriteLine("TOTAL DENIED: " + denied); // must be 0 (only for check)
            Console.ReadKey();
        }

        static void GenKeys()
        {
            int p = 5, q = 7;
            int n = p * q;
            List<int> vFull = new List<int>();
            for(int i = 0; i < n; i++)
            {
                int temp = i + 1;
                vFull.Add((temp * temp) % n);
            }
            vFull = vFull.Distinct().ToList();

            List<int> vRevert = new List<int>();
            for(int i = 0; i < vFull.Count - 1; i++)
            {
                if(IsCoprime(vFull[i], n)) 
                {
                    vRevert.Add(vFull[i]);
                }
            }
            Random random = new Random();
            int v = vRevert[random.Next(0, vRevert.Count)];
            int vRev = 0;
            while((v*vRev) % n != 1)
            {
                vRev++;
            }

            int s = 0;
            while((s*s) % n != vRev)
            {
                s++;
            }

            bool IsCoprime(int a, int b)
            {
                return a == b ? a == 1 : a > b ? IsCoprime(a - b, b) : IsCoprime(b - a, a);
            }

            Console.WriteLine($"Public keys are: v = {v}, n = {n}");
            Console.WriteLine("Somebody sends private key s to A");

            int r = random.Next(1, n - 1);
            int z = (r * r) % n;
            Console.WriteLine($"A sends z = {z} to B");

            int randomBit = random.Next(0,2);
            Console.WriteLine($"B sends randomBit = {randomBit} to A");

            int y = 0;
            switch(randomBit)
            {
                case 0:
                    Console.WriteLine($"A sends B r = {r}");
                    if (z == (r * r) % n)
                    {
                        Console.WriteLine("ACCESS GRANTED! SW-1");
                    }
                    else
                    {
                        Console.WriteLine("ACCESS DENIED! SW-1");
                        denied++;
                    }
                    break;
                case 1:
                    y = (r * s) % n;
                    Console.WriteLine($"A sends B y = {y}");
                    if(z == (y*y*v) % n)
                    {
                        Console.WriteLine($"ACCESS GRANTED! SW-2");
                    }
                    else
                    {
                        Console.WriteLine("ACCESS DENIED! SW-2");
                        denied++;
                    }
                    break;
                default:
                    Console.WriteLine("Something went wrong!");
                    break;
            }

        }
    }
}
