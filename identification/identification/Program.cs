using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
	class Program
	{
		public static Dictionary<char, int> alphabet = new Dictionary<char, int>
		{
					{ 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 }, { 'Е', 6 }, { 'Ё', 7 },
			        { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 }, { 'Й', 11 }, { 'К', 12 }, { 'Л', 13 },
					{ 'М', 14 }, { 'Н', 15 }, { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 }, { 'У', 21 },
					{ 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 }, { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 }, { 'Ы', 29 },
					{ 'Ь', 30 }, { 'Э', 31 }, { 'Ю', 32 }, { 'Я', 33 }
		};

		public static bool IsCoprime(int a, int b)
		{
			return a == b
				   ? a == 1
				   : a > b
						? IsCoprime(a - b, b)
						: IsCoprime(b - a, a);
		}

		static int p, q, n, fi, e, d, k;
		static double r, kDot;

		public static int NOD(int a, int b)
		{
			if (a == b)
				return a;
			else
				if (a > b)
				return NOD(a - b, b);
			else
				return NOD(b - a, a);
		}

		public static void A(int p1, int q1)
		{
			List<int> list = new List<int>();

			p = p1;
			q = q1;
			n = p * q;
			fi = (p - 1) * (q - 1);
			e = 0;
			d = 0;

			for (int i = 2; i < fi; i++)
			{
				if (NOD(i, fi) == 1)
				{
					e = i;
					
					break;
				}
			}

			var x = fi;
			var s = 1;
			var e1 = fi - 10;

			for (int i = s; i < e1 + 1; i++)
			{
				if (IsCoprime(x, i))
				{
					list.Add(i);
				}
			}
			d = list[new Random().Next(list.Count)];
			B(e, n);
		}

		public static void B(int e1, int n1)
		{
			// e, n - open keys
			k = alphabet['П'];
			r = alphabet['П'];
			//k = 23;
			//r = 4;

			// по теории
			//Random rand = new Random();
			//k = rand.Next(1, n - 1);
			//r = Math.Pow(k, e) % n;
			Aagain();
		}

		public static void Aagain()
		{
			kDot = Math.Pow(r, d) % n;
			Proverka();
		}

		public static bool Proverka()
		{

			if (k != 0 && kDot != 0 && p != 0 && q != 0 && n != 0 && fi != 0)
			{

				Console.WriteLine("два простых числа");
				Console.WriteLine("p = " + p);
				Console.WriteLine("q = " + q);

				Console.WriteLine("функция Эйлера");
				Console.WriteLine("fi = " + fi);
				Console.WriteLine("**************");

				Console.WriteLine("открытый ключ");
				Console.WriteLine("e = " + e + " n = " + n);
		
				Console.WriteLine("закрытый ключ");
				Console.WriteLine("d = " + d);

				Console.WriteLine("**************");
				Console.WriteLine("вычисление k и k`");
				Console.WriteLine("k = " + k);
				Console.WriteLine("k' = " + kDot);

				if (k == kDot)
				{
					Console.WriteLine("Аутентификация подтверждена, k and k` равны");
					return true;
				}
				else
				{
					Console.WriteLine("Аутентификация не подтверждена,  k and k` НЕ равны");
					return false;
				}
			}

			return false;

		}
		static void Main(string[] args)
		{
			bool i = true;
			while (i)
			{
				//поменять на 13
				A(3, 7);
				Console.ReadKey();
			}
		}
	}
}
