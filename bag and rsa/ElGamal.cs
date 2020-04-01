using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ElGamal
    {
        private static string alphabet;
        //private static string input = "ІВАСЕНКО МАКСИМ ВОЛОДИМИРОВИЧ";
        private static int alphabetLength;
        //private static string input = "ТЕКСТ ЯКИЙ ТУТ НАПИСАНО ВІН НЕ МАЄ ЖОДНОГО СЕНСУ ТА ЗМІСТОВОГО НАВАНТАЖЕННЯ";
        private static string input = "Шифр Цезаря або шифр зсуву симетричний моноалфавітний алгоритм шифрування в якому кожна буква відкритого тексту заміняється на ту що віддалена від неї в алфавіті на сталу кількість позицій".ToUpper();
        public ElGamal()
        {
            alphabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";
            alphabetLength = alphabet.Length;
        }

        public string Encode()
        {
            StringBuilder output = new StringBuilder();
            int p = 37, g = 2;
            int x = 5;
            int y = (int)(Math.Pow(g, x) % p);
            int k = 7;
            int[] massiv = new int[input.Length];
            string orderOut = "";
            string valueOut = "";
            for (int i = 0; i < input.Length; i++)
            {
                int order = alphabet.IndexOf(input[i]) + 1;
                orderOut += order + " ";
                int value = (int)((Math.Pow(y, k)*order) % p);
                valueOut += value + " ";
                massiv[i] = value;
            }
            Console.WriteLine("Order of letters: "+orderOut);
            Console.WriteLine("Encoded values: " +valueOut);
            string posOUT = "";
            for (int i = 0; i < massiv.Length; i++)
            {
                int position = (int)((massiv[i] * g) % p);
                posOUT += position + " ";
                //Console.Write(position.ToString() + " ");
                output.Append((alphabet[position-1]) + " ");
            }
            Console.WriteLine("Decoded position: " + posOUT);
            return output.ToString();
        }
    }
}
