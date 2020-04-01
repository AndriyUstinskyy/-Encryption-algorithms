using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace md5me
{
	class Program
	{
		static string FreeTest()
		{
			byte[] hash = Encoding.ASCII.GetBytes("сегодня утром туманно");
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] hashenc = md5.ComputeHash(hash);
			string result = "";
			foreach (var b in hashenc)
			{
				result += b.ToString("x2");
			}
			Console.WriteLine(result);
			return result;
			
		}

		static void Main(string[] args)
		{
			FreeTest();
			Console.ReadKey();
		}
	}
}
