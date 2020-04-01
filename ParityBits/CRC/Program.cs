using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 40;
            Console.WriteLine("INPUT NUMBER {0}", x);
            string input = EncodeToBinary(x);
            string Px = input + "0000";
            string Gx = "10011";
            Console.WriteLine($"Px = {Px}, Gx = {Gx}");
            (string quotientR, string restR) = Divide(Px, Gx);

            Console.WriteLine($"Input with control sum: {input + " " + restR}");

            // VALIDATE

            (string quotientV, string restV) = Divide(input+restR, Gx);
            if (restV == "0000")
                Console.WriteLine("CONFIRMED!");
            else
                Console.WriteLine("REJECT");

            Console.ReadKey();

            (string a, string b) Divide(string p, string g)
            {
                string temp = p.Substring(0, g.Length);
                string rest = "";
                string quotient = "";
                for (int i = 0; i < g.Length; i++)
                {
                    rest = "";
                    if (temp[0] == '1')
                    {     
                        g = Gx;
                        for(int j = 0; j < g.Length; j++)
                        {
                            rest += ((int)char.GetNumericValue(temp[j]) + (int)char.GetNumericValue(g[j])) % 2;
                        }

                        quotient += "1";
                    }
                    else
                    {
                        g = "00000"; // ONLY FOR 5 ELEMENTS

                        for (int j = 0; j < g.Length; j++)
                        {
                            rest += ((int)char.GetNumericValue(temp[j]) + (int)char.GetNumericValue(g[j])) % 2;
                        }

                        quotient += "0";
                    }
                    
                    if(g.Length + i < p.Length)
                    {
                        temp = rest.Substring(1, g.Length - 1) + p[g.Length + i];
                    }
                    else
                    {
                        temp = rest.Substring(1, g.Length - 1);
                    }
                }
                rest = rest.Substring(1, rest.Length - 1);
                Console.WriteLine($"QOUTIENT: {quotient}");
                Console.WriteLine($"REST: {rest}");
                return (quotient, rest);
            }

            string EncodeToBinary(int value)
            {
                StringBuilder result = new StringBuilder("00000");
                int st = 4;
                while (value != 0)
                {
                    if ((int)(value / Math.Pow(2, st)) <= 0)
                    {
                        st--;
                        continue;
                    }
                    else
                    {
                        value %= (int)Math.Pow(2, st);
                        result[4 - st] = '1';
                        st--;
                    }
                }
                return result.ToString();
            }
        }
    }
}
