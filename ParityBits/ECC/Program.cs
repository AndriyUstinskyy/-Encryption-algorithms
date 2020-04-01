using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "10010010111";
            List<string> xr = new List<string>();
            foreach(char s in input)
            {
                xr.Add(s.ToString());
            }
            string positions = "1248";
            for(int i = 0; i < 4; i++)
            {
                xr.Insert((int)char.GetNumericValue(positions[i]) - 1, "0");
            }

            int[,] n = new int[4, 15];
            for(int i = 0; i < 15; i++)
            {
                string temp = EncodeToBinary(i + 1);
                char[] charArray = temp.ToCharArray();
                Array.Reverse(charArray);
                string tempNew = new string(charArray);
                for (int j = 0; j < 4; j++)
                {
                    n[j, i] = (int)char.GetNumericValue(tempNew[j]);
                }
            }

            // FIND r
            string rAll = "";
            for(int i = 0; i < 4; i++)
            {
                int sum = 0;
                for(int j = 0; j < 15; j++)
                {
                    sum += Convert.ToInt32(xr[j]) * n[i, j];
                }
                rAll += sum % 2 == 0 ? 0 : 1;
            }

            // INSERT r
            for (int i = 0; i < 4; i++)
            {
                xr[(int)char.GetNumericValue(positions[i]) - 1] =  rAll[i].ToString();
            }

            // FIND s
            string sAll = "";
            for (int i = 0; i < 4; i++)
            {
                int sum = 0;
                for (int j = 0; j < 15; j++)
                {
                    sum += Convert.ToInt32(xr[j]) * n[i, j];
                }
                sAll += sum % 2 == 0 ? 0 : 1;
            }

            // FIND pb
            int tempPB = 0;
            for(int i = 0; i < xr.Count; i++)
            {
                tempPB += Convert.ToInt32(xr[i]);
            }
            int pb = tempPB % 2;

            Console.WriteLine($"INPUT WITH PARITY BIT: {input + " " + rAll + pb}");
            Console.ReadKey();

            string EncodeToBinary(int value)
            {
                StringBuilder result = new StringBuilder("0000");
                int st = 3;
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
                        result[3 - st] = '1';
                        st--;
                    }
                }
                return result.ToString();
            }
        }
    }
}
