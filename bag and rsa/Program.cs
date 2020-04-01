using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RSA rsa = new RSA();
            rsa.Encode();
            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
            Bag bag = new Bag();
            Console.WriteLine(bag.Encode());
            Console.WriteLine(new String('-', 50));
            ElGamal elg = new ElGamal();
            Console.WriteLine(elg.Encode());

             Console.ReadLine();

        }
    }
}
