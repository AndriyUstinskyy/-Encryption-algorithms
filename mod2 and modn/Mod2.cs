using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure_lab_3
{
    class Mod2
    {
        private static string alphabet = "АБВГДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ ";
        private static string input;
        private StringBuilder gamma;
        public Mod2(string userInput, string gammaInput)
        {
            gamma = new StringBuilder(gammaInput);
            input = userInput;
        }
        
        public string Encode()
        {
            StringBuilder output = new StringBuilder();
            Dictionary<string, string> alphabetBinary = new Dictionary<string, string>();

            for(int i = 0; i < alphabet.Length; i++)
            {
                alphabetBinary.Add(alphabet[i].ToString(), EncodeToBinary(i)); //create dictionary alphabet
            }
            ToConsole(alphabetBinary,"INPUT: ",1,input);

            int counter = 0;
            int gammaLength = gamma.Length;
            while (input.Length != gamma.Length)
            {
                    gamma.Append(gamma[counter]); // gamma length to input
                    counter++;
               
            }
            ToConsole(alphabetBinary, "GAMMA: ", 1, gamma.ToString());

            for (int i = 0; i < input.Length; i++)
            {
                string charInput = alphabetBinary[input[i].ToString()];
                string charGamma = alphabetBinary[gamma[i].ToString()];
                StringBuilder outChar = new StringBuilder();
                for (int j = 0; j < 8; j++)
                {
                    int codeXOR = (int)((char.GetNumericValue(charInput[j]) + char.GetNumericValue(charGamma[j])) % 2);
                    outChar.Append(codeXOR);
                }
                output.Append(alphabetBinary.FirstOrDefault(x => x.Value == outChar.ToString()).Key);
            }
            ToConsole(alphabetBinary, "OUTPUT: ", 1, output.ToString());

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

            void ToConsole(Dictionary<string, string> dict, string title, int mod = 0, string content = null)
            {
                Console.WriteLine(title);
                if (mod == 0)
                {
                    foreach (KeyValuePair<string, string> entry in dict)
                    {
                        Console.Write($"{entry.Key} - {entry.Value} ");
                    }
                }
                else
                {
                    foreach(char c in content)
                    {
                        //if (c == ' ') continue;
                        Console.Write($"{c} - {alphabetBinary[c.ToString()]} ");
                    }
                }
                Console.WriteLine('\n');
            }

            return output.ToString();
        }
    }
}
