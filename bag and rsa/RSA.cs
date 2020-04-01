using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class RSA
    {
        private static string alphabet;
        //private static string input = "ІВАСЕНКО МАКСИМ ВОЛОДИМИРОВИЧ";
        private static int alphabetLength;
        //private static string input = "ТЕКСТ ЯКИЙ ТУТ НАПИСАНО ВІН НЕ МАЄ ЖОДНОГО СЕНСУ ТА ЗМІСТОВОГО НАВАНТАЖЕННЯ";
        private static string input = "Шифр Цезаря або шифр зсуву симетричний моноалфавітний алгоритм шифрування в якому кожна буква відкритого тексту заміняється на ту що віддалена від неї в алфавіті на сталу кількість позицій".ToUpper();
        public RSA()
        {
            alphabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";
            alphabetLength = alphabet.Length;
        }

        public string Encode()
        {
            StringBuilder output = new StringBuilder();
            int p = 7, q = 13;
            int n = p * q;
            int fn = (p - 1) * (q - 1);
            int e = 2;
            int[] massiv = new int[input.Length];

            while (!IsCoprime(e, fn)) //нашли простое число (и степень)
            {
                e++;
            }
            string orderOut = "";
            string valueOut = "";
            for (int i = 0; i < input.Length; i++)
            {
                int order = alphabet.IndexOf(input[i]) + 1;
                orderOut += order + " ";
                int value = (int)(Math.Pow(order, e) % n);
                valueOut += value + " ";
                massiv[i] = value;
                output.Append(value.ToString() + " ");
            }
            Console.WriteLine("Order of letters: " + orderOut);
            Console.WriteLine("Encoded letters: " + valueOut);
            // decode
            int x = 1;
            while ((x*e)%fn != 1)
            {
                x++;
            }
            string posOUT = "";
            Console.Write("Decoded position: ");
            for(int i = 0; i < massiv.Length; i++)
            {
                int position = (int)(Math.Pow(massiv[i], x) % n);
                posOUT += position + " ";
                //Console.Write(position);
                Console.Write((alphabet.IndexOf(input[i]) + 1) + " "); //!!!!!!!!!!!!!!
            }
            Console.WriteLine();
            foreach(char c in input)
            {
                Console.Write(c.ToString() + " ");
            }
            //Console.WriteLine('\n'+input);
            return output.ToString();

            bool IsCoprime(int a, int b)
            {
                return a == b ? a == 1 : a > b ? IsCoprime(a - b, b) : IsCoprime(b - a, a);
            }
        }
    }
}
