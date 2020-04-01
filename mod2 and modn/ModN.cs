using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure_lab_3
{
    class ModN
    {
        private static string alphabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";
        private StringBuilder gamma;
        private static string input;
        public ModN(string userInput, string gammaInput)
        {
            gamma = new StringBuilder(gammaInput);
            input = userInput;
        }
        public string Encode()
        {
            ToConsole(input, "INPUT: ");

            StringBuilder output = new StringBuilder();
            int counter = 0;
            int gammaLength = gamma.Length;
            while(input.Length != gamma.Length)
            {
                if(counter == gammaLength)
                {
                    counter = 0;
                }
                else
                {
                    gamma.Append(gamma[counter]);
                    counter++;
                }
            }
            ToConsole(gamma.ToString(), "GAMMA: ");
            for(int i = 0; i < input.Length; i++)
            {
                output.Append(alphabet[(alphabet.IndexOf(input[i]) + alphabet.IndexOf(gamma[i])) % alphabet.Length]);
            }
            ToConsole(output.ToString(), "OUTPUT: ");

            void ToConsole(string lineToConsole, string title)
            {
                Console.WriteLine(title);
                foreach (char c in lineToConsole)
                {
                    Console.Write($"{c} - {alphabet.IndexOf(c)} ");
                }
                Console.WriteLine('\n');
            }

            return output.ToString();
        }
    }
}
