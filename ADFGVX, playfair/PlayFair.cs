using Cryptography.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cryptography
{
    public class PlayFair
    {
        char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'y', 'x', 'z' };
        char[][] keyMatrix;
        private string key;
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
                GenerateKeyMatrix();
            }
        }
        public PlayFair()
        {

        }
        public PlayFair(string key)
        {
            Key = key;
            GenerateKeyMatrix();
        }

        private void GenerateKeyMatrix()
        {
            keyMatrix = new char[5][];
            for (int it = 0; it < 5; it++)
            {
                keyMatrix[it] = new char[5];
            }
            if (key == null)
                throw new Exception("No key assigned.");
            string tempKey = Key.RemoveNonLetters().ToUpper().RemoveDuplicateChars().Replace("J", "");

            int i = 0, j = 0;
            foreach (char c in tempKey.ToCharArray())
            {
                keyMatrix[i][j] = c;
                if (j < 4)
                    j++;
                else
                {
                    i++;
                    j = 0;
                }
            }
            while (i < 5)
            {
                if (j == 5)
                    j = 0;
                while (j < 5)
                {
                    char x = alphabet.Where(l => !(keyMatrix.ToWord().Contains(char.ToUpper(l)))).FirstOrDefault();
                    keyMatrix[i][j] = char.ToUpper(x);
                    j++;
                }
                i++;
            }
        }
        private string InsertBetweenDoubleLetters(string input, char newChar)
        {
            bool modified = false;

            StringBuilder stringBuilder = new StringBuilder();
            var pairs = input.SplitIntoLengths(2);
            foreach (var pair in pairs)
            {
                //the check for modified makes sure the string is rechecked for pairs after every change
                if (pair.Distinct().Count() == 1 && modified == false)
                {
                    modified = true;
                    stringBuilder.Append(pair[0]);
                    stringBuilder.Append(newChar);
                    if (pair.Length > 1)
                        stringBuilder.Append(pair[1]);
                }
                else
                    stringBuilder.Append(pair);
            }
            if (HasPairsOfSameLetter(stringBuilder.ToString().SplitIntoLengths(2)))
            {
                return InsertBetweenDoubleLetters(stringBuilder.ToString(), char.ToUpper(newChar) == 'X' ? 'Z' : 'X');
            }
            else
                return stringBuilder.ToString();
        }

        private bool HasPairsOfSameLetter(IEnumerable<string> inputList)
        {
            foreach (var letterGroup in inputList)
            {
                if (letterGroup.Length > 1)
                    if (char.ToUpper(letterGroup[0]) == char.ToUpper(letterGroup[1]))
                        return true;
            }
            return false;
        }
        public string Encrypt(string text)
        {
            text = text.RemoveNonLetters().ToUpper().Replace("J", "I");
            text = InsertBetweenDoubleLetters(text, 'X');
            if (text.Length % 2 != 0)
                text += "Z";
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var pair in text.SplitIntoLengths(2))
            {
                //if on different lines and columns
                int line0 = keyMatrix.GetCharLine(pair[0]);
                int line1 = keyMatrix.GetCharLine(pair[1]);
                int column0 = keyMatrix.GetCharColumn(pair[0]);
                int column1 = keyMatrix.GetCharColumn(pair[1]);
                if (line0 != line1 && column0 != column1)
                {
                    stringBuilder.Append(keyMatrix[line0][column1]);
                    stringBuilder.Append(keyMatrix[line1][column0]);
                }
                //if on same line 
                else if (line0 == line1)
                {
                    if (column0 == 4)
                        stringBuilder.Append(keyMatrix[line0][0]);
                    else
                        stringBuilder.Append(keyMatrix[line0][column0 + 1]);

                    if (column1 == 4)
                        stringBuilder.Append(keyMatrix[line0][0]);
                    else
                        stringBuilder.Append(keyMatrix[line0][column1 + 1]);
                }
                //if on same column
                else if (column0 == column1)
                {
                    if (line0 == 4)
                        stringBuilder.Append(keyMatrix[0][column0]);
                    else
                        stringBuilder.Append(keyMatrix[line0 + 1][column0]);

                    if (line1 == 4)
                        stringBuilder.Append(keyMatrix[0][column1]);
                    else
                        stringBuilder.Append(keyMatrix[line1 + 1][column1]);
                }

            }
            return stringBuilder.ToString();
        }
        public string Decrypt(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var pair in text.SplitIntoLengths(2))
            {
                int line0 = keyMatrix.GetCharLine(pair[0]);
                int line1 = keyMatrix.GetCharLine(pair[1]);
                int column0 = keyMatrix.GetCharColumn(pair[0]);
                int column1 = keyMatrix.GetCharColumn(pair[1]);
                //if on different lines and columns
                if (line0 != line1 && column0 != column1)
                {
                    stringBuilder.Append(keyMatrix[line0][column1]);
                    stringBuilder.Append(keyMatrix[line1][column0]);
                }
                //if on same line 
                else if (line0 == line1)
                {
                    if (column0 == 0)
                        stringBuilder.Append(keyMatrix[line0][4]);
                    else
                        stringBuilder.Append(keyMatrix[line0][column0 - 1]);

                    if (column1 == 0)
                        stringBuilder.Append(keyMatrix[line0][4]);
                    else
                        stringBuilder.Append(keyMatrix[line0][column1 - 1]);
                }
                //if on same column
                else if (column0 == column1)
                {
                    if (line0 == 0)
                        stringBuilder.Append(keyMatrix[4][column0]);
                    else
                        stringBuilder.Append(keyMatrix[line0 - 1][column0]);

                    if (line1 == 0)
                        stringBuilder.Append(keyMatrix[4][column1]);
                    else
                        stringBuilder.Append(keyMatrix[line1 - 1][column1]);
                }

            }
            return stringBuilder.ToString();
        }
        

    }
}
