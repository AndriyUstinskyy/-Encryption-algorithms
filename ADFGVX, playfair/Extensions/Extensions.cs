using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cryptography.Extensions
{
    public static class Extensions
    {
        public static string RemoveDuplicateChars(this string myString)
        {
            string result = "";
            foreach (char value in myString)
            {
                // See if character is in the result already.
                if (result.IndexOf(value) == -1)
                {
                    // Append to the result.
                    result += value;
                }
            }
            return result;
        }

        public static char[,] PopulateMatrix(ref char[,] matrix, int size, string word, char[] characters)
        {
            matrix = new char[size, size];
            int i = 0, j = 0;
            foreach (char c in word.ToCharArray())
            {
                matrix[i, j] = c;
                if (j < size-1)
                    j++;
                else
                {
                    i++;
                    j = 0;
                }
            }
            for (int k = i; k < size; k++)
            {
                for (int q = j; q < size; q++)
                {
                    foreach (var c in characters)
                        if (!matrix.ContainsChar(c))
                        {
                            matrix[k, q] = c;
                            break;
                        }
                    j = 0;
                }
                i = 0;
            }

            return matrix;
        }
        public static char[,] PopulateSecondMatrix(ref char[,] matrix,int size,string word,string preliminaryCryptedText,char randomChosenChar)
        {
            matrix = new char[word.Length, size];
            int preliminaryCryptedTextIndex = 0;
            for (int i=0;i<matrix.GetLength(0);i++)
            {
                matrix[i, 0] = word[i];
            }
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (preliminaryCryptedTextIndex < preliminaryCryptedText.Length)
                    {
                        matrix[j, i] = preliminaryCryptedText[preliminaryCryptedTextIndex];
                        preliminaryCryptedTextIndex++;
                    }
                    else
                    {
                        matrix[j, i] = randomChosenChar;//'A';//
                    }
                }
            }
            var sortedKey = String.Concat(word.OrderBy(c => c));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var index = Array.IndexOf(sortedKey.ToArray(), matrix[i, 0]) + 1;
                matrix[i, matrix.GetLength(1) - 1] = Char.Parse(index.ToString());
            }
            Cryptography.Extensions.Extensions.Sort(matrix);
            return matrix;
        }
        public static char GetRandomCharFromArray(char[] charArray)
        {
            Random rng = new Random();
            int index = rng.Next(charArray.Length);
            return charArray[index];
        }
        public static bool ContainsChar(this char[,] matrix, char c, bool? caseSensitive = null)
        {
            foreach (var ch in matrix)
            {
                if (!(caseSensitive ?? false))
                {
                    if (char.ToUpper(c) == char.ToUpper(ch))
                        return true;
                }
                else
                {
                    if (c == ch)
                        return true;
                }
            }
            return false;
        }

        public static IEnumerable<string> SplitIntoLengths(this string input, int characterCount)
        {
            int index = 0;
            return from c in input
                   let itemIndex = index++
                   group c by itemIndex / characterCount
                   into g
                   select new string(g.ToArray());
        }
       
        public static void Sort(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = i; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, 0] > matrix[j, 0])
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            var temp = matrix[i, k];
                            matrix[i, k] = matrix[j, k];
                            matrix[j, k] = temp;
                        }
                    }
                }
            }
        }
        public static bool TextContainsOnlyAllowedChars(string text)
        {
            string allowableLetters = "ADFGVX";
            foreach (char c in text)
            {
                if (!allowableLetters.Contains(c.ToString()))
                    return false;
            }
            return true;
        }
        public static string RemoveNonLetters(this string input, bool keepSpace = false)
        {
            Regex rgx = null;
            if (keepSpace)
                rgx = new Regex("[^a-zA-Z' ]");
            else
                rgx = new Regex("[^a-zA-Z']");
            return rgx.Replace(input, "");
        }
        public static string ToWord(this char[][] input)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < input.GetLength(0); i++)
                for (int j = 0; j < input.GetLength(0); j++)
                {
                    if (char.IsLetter(input[i][j]))
                        builder.Append(input[i][j]);
                }
            return builder.ToString();
        }
        public static int GetCharLine(this char[][] input, char c)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (char.ToUpper(input[i][j]) == char.ToUpper(c))
                        return i;
            throw new Exception("Character not found in key matrix!");
        }

        public static int GetCharColumn(this char[][] input, char c)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (char.ToUpper(input[i][j]) == char.ToUpper(c))
                        return j;
            throw new Exception("Character not found in key matrix!");
        }
    }
}
