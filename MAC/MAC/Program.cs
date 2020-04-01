using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAC
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            string input = "Ustinskyy Andriy";
            Console.WriteLine($"INPUT : {input}");
            Do(input);
            Console.ReadKey();
        }
        static void Do(string input)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(input);
            List<string> converted = new List<string>();
            StringBuilder convertedString = new StringBuilder();
            Random random = new Random();
            foreach (byte b in bytes)
            {
                string temp = EncodeToBinary64(b + random.Next(880000000,2000000000));
                converted.Add(temp);
                convertedString.Append(temp);
            }
            Console.WriteLine($"CONVERTED STRING IS: {convertedString.ToString()}");

            DESCryptoServiceProvider serviceProvider = new DESCryptoServiceProvider();
            string synchroKey = EncodeToBinary64(random.Next(900000000,1000000000));
            Console.WriteLine($"SYNCHRO KEY: {synchroKey}");

            foreach(string s in converted)
            {
                string sXOR = XOR(s, synchroKey);
                byte[] cipherText;

                byte[] key;

                byte[] initializationVector;

                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    key = des.Key;
                    initializationVector = des.IV;

                    ICryptoTransform encryptor = des.CreateEncryptor();

                    using (MemoryStream encryptMemoryStream = new MemoryStream())
                    {

                        using (CryptoStream encryptCryptoStream = new CryptoStream(encryptMemoryStream,
                        encryptor, CryptoStreamMode.Write))
                        {

                            using (StreamWriter swEncrypt = new StreamWriter(encryptCryptoStream))
                            {
                                swEncrypt.Write(sXOR);
                            }

                            cipherText = encryptMemoryStream.ToArray();
                        }
                    }
                }
                int tempSum = 0;
                foreach(byte z in cipherText)
                {
                    tempSum += z;
                }
                synchroKey = EncodeToBinary64(tempSum);

            }
            
            Console.WriteLine("MAC-code: {0}", synchroKey);

            string EncodeToBinary64(int value)
            {
                StringBuilder result = new StringBuilder(new string('0', 64));
                int st = 63;
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
                        result[63 - st] = '1';
                        st--;
                    }
                }
                return result.ToString();
            }

            string XOR(string a, string b)
            {
                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < 64; i++)
                {
                    if (a[i] == b[i])
                    {
                        temp.Append(0);
                    }
                    else
                    {
                        temp.Append(1);
                    }
                }
                return temp.ToString();
            }

            void DumpBytes(string title, byte[] bytes2)
            {
                Console.Write(title);
                foreach (byte b in bytes2)
                {
                    Console.Write("{0:X} ", b);
                }
                Console.WriteLine();
            }
        }
    }
}
