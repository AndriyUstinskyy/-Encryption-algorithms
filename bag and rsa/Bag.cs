using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Bag
    {
        private static string alphabet;
        //private static string input = "ІВАСЕНКО МАКСИМ ВОЛОДИМИРОВИЧ";
        private static string key;
        private static int alphabetLength;
        //private static string input = "ТЕКСТ ЯКИЙ ТУТ НАПИСАНО ВІН НЕ МАЄ ЖОДНОГО СЕНСУ ТА ЗМІСТОВОГО НАВАНТАЖЕННЯ";
        private static string input = "Устінський Андрій".ToUpper();
        public Bag()
        {
            alphabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";
            alphabetLength = alphabet.Length;
            key = "2 3 6 13 27 52 105 210";
        }

        public string Encode()
        {
            Console.WriteLine(key);
            string BinaryCodes = "";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            byte[] a = encoding.GetBytes(input);

            while (key.Length / 2 < a.Length)
            {
                key = key + ' ' + key;
            }

            var items = Array.ConvertAll(key.Split(' '), s => int.Parse(s));

            string result = "";

            for (int i = 0; i < a.Length; i++)
            {
                int temp = 0;
                string binaryCode = Convert.ToString(a[i], 2).PadLeft(8, '0');
                Console.Write(binaryCode + " ");
                for (int j = 0; j < binaryCode.Length; j++)
                {
                    if (binaryCode[j] == '1')
                    {
                        temp += items[j];
                    }
                }
                result += (temp + " ");
            }
            Console.WriteLine();
            return result;
        }
    }
}
