using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography
{
    class ADFGVX
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        private string key1Crypto;
        private string key2Cripto;
        private char[,] keyMatrix1;
        private char[,] keyMatrix2;
        private char[] characters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't','u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private Dictionary<char, string> key1Dictionary;
        private Dictionary<string, char> reverseKey1Dictionary;
        private Dictionary<int, char> dictionary = new Dictionary<int, char>
        {
            {0,'A' }, {1, 'D'}, {2, 'F'}, {3, 'G'}, {4, 'V'}, {5, 'X'}
        };
        private string preliminaryCryptedText;
        private char randomChosenChar;
        private static char[] charArray = { 'A', 'D', 'F', 'G', 'V', 'X' };


        public ADFGVX(string key1, string key2)
        {
            Key1 = key1;
            Key2 = key2;
            key1Crypto = Cryptography.Extensions.Extensions.RemoveDuplicateChars(Key1);
            key2Cripto = Cryptography.Extensions.Extensions.RemoveDuplicateChars(Key2);
            GenerateaKey1Matrix();
            GenerateDictionaryForKey1Matrix();
            GenerateReverseDictionaryForKey1Matrix();
            randomChosenChar = Cryptography.Extensions.Extensions.GetRandomCharFromArray(charArray);
        }
        private void GenerateaKey1Matrix()
        {
            keyMatrix1 = Extensions.Extensions.PopulateMatrix(ref keyMatrix1, 6, key1Crypto, characters);
            PrintMatrix(keyMatrix1);
        }
        private void GenerateKey2Matrix()
        {

        }
        private void GenerateDictionaryForKey1Matrix()
        {
            key1Dictionary = new Dictionary<char, string>();
            for (int i = 0; i < keyMatrix1.GetLength(0); i++)
                for (int j = 0; j < keyMatrix1.GetLength(0); j++)
                {
                    key1Dictionary.Add(char.ToUpper(keyMatrix1[i, j]), dictionary[i].ToString().ToUpper() + dictionary[j].ToString().ToUpper());
                }
        }
        private void GenerateReverseDictionaryForKey1Matrix()
        {
            reverseKey1Dictionary = new Dictionary<string, char>();
            for (int i = 0; i < keyMatrix1.GetLength(0); i++)
            {
                for (int j = 0; j < keyMatrix1.GetLength(0); j++)
                {
                    reverseKey1Dictionary.Add(dictionary[i].ToString().ToUpper() + dictionary[j].ToString().ToUpper(), char.ToUpper(keyMatrix1[i, j]));
                }
            }
        }
        public string Encrypt(string message)
        {
            string result = "";
            preliminaryCryptedText = EncryptPreliminary(message);
            keyMatrix2 = Extensions.Extensions.PopulateSecondMatrix(ref keyMatrix2, 7, Key2, preliminaryCryptedText, randomChosenChar);
            PrintMatrix(keyMatrix2);
            for (int i = 0; i < keyMatrix2.GetLength(0); i++)
                for (int j = 1; j < keyMatrix2.GetLength(1) - 1; j++)
                    result += keyMatrix2[i, j];
            return result;
        }

        private string EncryptPreliminary(string message)
        {
            string result = "";
            foreach (char c in message)
            {
                result += key1Dictionary[char.ToUpper(c)];
            }
            return result;
        }
        public string Decrypt(string message)
        {
            string result = "";
            preliminaryCryptedText = DecryptPreliminary(message);
            var addedchars = preliminaryCryptedText.Length % 2;
            var encryptedSize = (preliminaryCryptedText.Length / 2) * 2;
            for (int i = 0; i < encryptedSize; i += 2)
            {
                string cryptedPair = preliminaryCryptedText[i].ToString() + preliminaryCryptedText[i + 1].ToString();
                result += reverseKey1Dictionary[cryptedPair].ToString();
            }
            return result;
        }
        private string DecryptPreliminary(string message)
        {
            string result = "";
            Dictionary<char, int> unsortedKey2CharSizeDictionary = new Dictionary<char, int>();
            Dictionary<char, int> sortedKey2CharSizeDictionary = new Dictionary<char, int>();
            Dictionary<char, List<char>> sortedKey2Dictionary = new Dictionary<char, List<char>>();
            Dictionary<char, List<char>> unsortedKey2Dictionary = new Dictionary<char, List<char>>();
            int messageLength = message.Length;
            int extraSize = messageLength % Key2.Length;
            foreach (char character in Key2)
            {
                unsortedKey2CharSizeDictionary.Add(character, (messageLength - extraSize) / Key2.Length);
            }
            for (int x = 0; x < extraSize; x++)
            {
                unsortedKey2CharSizeDictionary[unsortedKey2CharSizeDictionary.Keys.ToArray()[x]]++;
            }

            List<char> key2Temp = Key2.ToList();
            key2Temp.Sort();
            foreach (char key in key2Temp)
            {
                sortedKey2CharSizeDictionary.Add(key, unsortedKey2CharSizeDictionary[key]);
            }
            for (int i = 0; i < Key2.Length; i++)
            {
                sortedKey2Dictionary.Add(key2Temp[i], new List<char>());
                unsortedKey2Dictionary.Add(Key2.ToList()[i], new List<char>());
            }
            int messageIndex = 0;
            foreach (char key in sortedKey2CharSizeDictionary.Keys)
            {
                for (int i = 0; i < sortedKey2CharSizeDictionary[key]; i++)
                {
                    sortedKey2Dictionary[key].Add(message[messageIndex]);
                    messageIndex++;
                }
            }
            foreach (char key in sortedKey2Dictionary.Keys)
            {
                if (sortedKey2Dictionary[key].Count < Key2.Length)
                {
                    sortedKey2Dictionary[key].Add(randomChosenChar);//random selected character a,d,f,g,v,x
                }
            }
            foreach (char key in sortedKey2CharSizeDictionary.Keys)
            {
                unsortedKey2Dictionary[key] = sortedKey2Dictionary[key];
            }
            messageIndex = 0;
            while (true)
            {
                try
                {
                    foreach (char key in unsortedKey2Dictionary.Keys)
                    {
                        result += unsortedKey2Dictionary[key][messageIndex];
                    }
                }
                catch (Exception ex)
                {
                    break;
                }
                messageIndex++;
            }
            return result;
        }
        private void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
