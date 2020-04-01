using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParityBits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Ivasenko Maksym";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(input);
            string[] binary = new string[bytes.Length];
            StringBuilder evenResult = new StringBuilder();

            for(int i = 0; i < bytes.Length; i++)
            {
                binary[i] = EncodeToBinary(bytes[i]);
            }

            Console.WriteLine($"Letter\t\t Bytes\t\t Even\t\t Odd");

            for(int i = 0; i < binary.Length; i++)
            {
                Console.WriteLine($"{input[i]}\t\t {binary[i]}\t {Even(binary[i], i)}\t\t {1-Even(binary[i], i)}");
                evenResult.Append(binary[i]).Append(Even(binary[i], i));
            }

            Console.WriteLine("Input string: {0}",evenResult.ToString());

            // VALIDATE 
            string inputValidate = evenResult.ToString();
            List<string> inputToArray = new List<string>();
            for(int i = 0; i < inputValidate.Length; i+=9)
            {
                string temp = inputValidate.Substring(i, 9);
                inputToArray.Add(temp);
            }
            foreach(string s in inputToArray)
            {
                string temp = s.Substring(0,8);
                int r = temp.Where(a => a.ToString() != "0").Count();
                if (r % 2 != 0)
                {
                    if (s[8].ToString() == "1")
                        Console.WriteLine("CONFIRMED");
                    else
                        Console.WriteLine("REJECT");
                }
                else
                {
                    if (s[8].ToString() == "0")
                        Console.WriteLine("CONFIRMED");
                    else
                        Console.WriteLine("REJECT");
                }
            }

            Console.ReadKey();

            int Even(string s, int i)
            {
                int r = s.Where(a => a.ToString() != "0").Count();
                if (r % 2 != 0)
                    return 1;
                else
                    return 0;
            }

            string EncodeToBinary(int value)
            {
                StringBuilder result = new StringBuilder("00000000");
                int st = 7;
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
                        result[7 - st] = '1';
                        st--;
                    }
                }
                return result.ToString();
            }

        }
    }
}
