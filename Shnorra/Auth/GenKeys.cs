using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Auth
{
    class GenKeys
    {
        static int g;
        static int y;
        static int p;
        static int q;
        static int x;
        static int denied = 0;
        public GenKeys()
        {
            k = 13;
            g = default;
            y = default;
            p = 23;
            q = 11;
            x = default;
        }
        public int Generate()
        {
            Random random = new Random();
            if ((p - 1) % q != 0)
                throw new ArgumentException("Try to change p and q!");
            x = random.Next(1,q-1);

            List<int> gArray = new List<int>();

            for(int i = 0; gArray.Count != 3; i++)
            {
                if(Math.Pow(g,q) % p == 1)
                {
                    gArray.Add(g);
                }
                g++;
            }
            
            g = gArray[random.Next(0, gArray.Count)];
            
            List<int> yArray = new List<int>();

            for (int i = 0; yArray.Count != 3; i++)
            {
                if((Math.Pow(g, x)*y) % p == 1)
                {
                    yArray.Add(y);
                }
                y++;
            }

            y = yArray[random.Next(0, yArray.Count)];
            return y;
        }
        public void Authintification()
        {
            Random random = new Random();
            int k = random.Next(1,q-1);
            int r = (int)(Math.Pow(g, k) % p);
            Console.WriteLine($"A sends to B r = {r}");

            int e = random.Next(0, (int)(Math.Pow(2, 3) - 1));
            Console.WriteLine($"B sends to A e = {e}");

            int s = (k + x * e) % q;
            Console.WriteLine($"A sends to B s = {s}");

            if(r == ((Math.Pow(g,s) * Math.Pow(y,e)) % p))
            {
                Console.WriteLine("OK! ACCESS GRANTED!");
            }
            else
            {
                Console.WriteLine("ACCESS DENIED!");
                denied++;
            }
            Console.WriteLine("DENIED TOTAL: " + denied);
        }
    }
}
