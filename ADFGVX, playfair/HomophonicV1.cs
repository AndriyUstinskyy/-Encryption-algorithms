using Cryptography.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class HomophonicV1
    {
        private Dictionary<int, string> keyValuePairs = new Dictionary<int, string>
        {
            { 0,"E" }, { 6,"E" }, { 13,"E" }, { 32,"E" }, { 52,"E" }, { 53,"E" }, { 71,"E" }, { 72,"E" }, { 83,"E" }, { 93,"E" }, { 94,"E" },
            { 14,"T" }, { 16,"T" }, { 30,"T" }, { 31,"T" }, { 43,"T" }, { 58,"T" }, { 73,"T" }, { 79,"T" }, { 84,"T" },
            { 11,"O" }, { 15,"O" }, { 25,"O" }, { 41,"O" }, { 42,"O" }, { 57,"O" }, { 78,"O" }, { 85,"O" },
            { 3,"I" }, { 10,"I" }, { 34,"I" }, { 35,"I" }, { 54,"I" }, { 56,"I" }, { 77,"I" }, { 86,"I" },
            { 18,"A" }, { 19,"A" }, { 20,"A" }, { 36,"A" }, { 55,"A" }, { 62,"A" }, { 76,"A" }, { 87,"A" },
            { 2,"N" }, { 37,"N" }, { 38,"N" }, { 59,"N" }, { 61,"N" }, { 69,"N" }, { 70,"N" },
            { 9,"R" }, { 26,"R" }, { 39,"R" }, { 60,"R" }, { 75,"R" }, { 88,"R" },
            { 17,"L" }, { 28,"L" }, { 63,"L" }, { 74,"L" }, { 89,"L" },
            { 4,"H" }, { 8,"H" }, { 27,"H" }, { 64,"H" },
            { 5,"D" }, { 29,"D" }, { 66,"D" },
            { 7,"U" }, { 22,"U" }, { 91,"U" },
            { 23,"C" }, { 40,"C" }, { 92,"C" }, { 44,"C" },
            { 33,"M" }, { 51,"M" }, { 80,"M" },
            { 12,"P" }, { 50,"P" },
            { 49,"Y" }, { 68,"Y" },
            { 45,"F" },
            { 1,"G" }, { 96,"G" },
            { 81,"W" }, { 98,"W" },
            { 48,"B" }, { 97,"B" },
            { 99,"V" },
            { 67,"K" },
            { 47,"X" },
            { 95,"J" },
            { 90,"Q" },
            { 46,"Z" },
            { 24, "S"}
        };

        public HomophonicV1()
        {

        }

        public string Decrypt(string sentence)
        {
            List<string> result = new List<string>();
            sentence = sentence.TrimStart().TrimEnd();
            string[] words = sentence.Split(' ');
            foreach (var word in words)
            {
                string wordResult = "";
                if (word.Length % 2 != 0)
                    throw new Exception("Format incorect");
                List<string> split = word.SplitIntoLengths(2).ToList();
                foreach (var str in split)
                {
                    int key = int.Parse(str);
                    wordResult += keyValuePairs[key];
                }
                result.Add(wordResult);
            }
            return string.Join(" ", result);
        }

        public string Encrypt(string sentence)
        {
            List<string> result = new List<string>();
            sentence = sentence.TrimStart().TrimEnd();
            string[] words = sentence.Split(' ');
            foreach (var word in words)
            {
                string wordResult = "";
                foreach (var c in word)
                {
                    var validNumbers = keyValuePairs.Where(kv => kv.Value.ToString() == c.ToString().ToUpper()).ToList();
                    var random = new Random();
                    int randomInt = random.Next(validNumbers.Count);

                    if (validNumbers[randomInt].Key < 10)
                        wordResult += "0" + validNumbers[randomInt].Key;
                    else
                        wordResult += validNumbers[randomInt].Key;

                }
                result.Add(wordResult);
            }
            return string.Join(" ", result);
        }
    }
}
