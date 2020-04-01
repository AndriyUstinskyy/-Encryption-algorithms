using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeigeFiatShamir
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

		public static int n, p, q, r, b;
		public static double v, vFinal, z, y;
		public static double VRev, s, VRevFinal;
		public static List<double> list = new List<double>();
		public static List<double> listRev = new List<double>();
		public static List<double> closedKeys = new List<double>();
		public static double[] distinctiveList;
		public static double[] distinctiveListRev;


		public static int modInverse(int a, int m)
		{
			a = a % m;
			for (int x = 1; x < m; x++)
				if ((a * x) % m == 1)
					return x;
			return 0;
		}
		public static void A1(int p, int q)
		{
			Console.WriteLine("p= " + p);
			Console.WriteLine("q= " + q);
			n = p * q;
			for (int i = 1; i <= n; i++)
			{
				v = Math.Pow(i, 2) % n;
				VRev = modInverse(Convert.ToInt32(v), n);
				if (VRev != 0)
				{
					list.Add(v);
					listRev.Add(VRev);
					distinctiveList = list.Distinct<double>().ToArray<double>();
					distinctiveListRev = listRev.Distinct<double>().ToArray<double>();
				}
			}
			//Array.Sort(distinctiveListRev);
			Console.WriteLine("открытые ключи");
			for (int i = 0; i < distinctiveList.Length; i++)
			{
				Console.WriteLine(distinctiveList[i]);
			}
			Console.WriteLine(new string('*', 15));

			Console.WriteLine("обратные значения");
			for (int i = 0; i < distinctiveListRev.Length; i++)
			{
				Console.WriteLine(distinctiveListRev[i]);
			}
			Console.WriteLine(new string('*', 15));


			// choose V and Vrev среди получившихся
			int position = new Random().Next(list.Count);
			vFinal = list[position];
			VRevFinal = listRev[position];
			for (int i = 0; i < distinctiveListRev.Length; i++)
			{
				s = (Math.Sqrt(n * i + VRevFinal));
				if (s % 1 == 0)
				{
					closedKeys.Add(s);
				}

			}
			s = closedKeys.Min();
			Console.WriteLine("закрытый ключ s: " + s);
			Console.WriteLine("открытые ключи v = {0}, n = {1}, v' = {2} ", vFinal, n, VRevFinal);
			Console.WriteLine(new string('*', 15));

			r = alphabet['З'];
			Console.WriteLine("r= "+ r);
			z = Math.Pow(r, 2) % n;

			B1(z);
			Console.WriteLine(z);
		}
		public static void B1(double z)
		{
			var rnd = new Random();
			var vals = new int[] { 0, 1 };
			int b = vals[rnd.Next(vals.Length)];
			Console.WriteLine("случайный бит " + b);
			A2(b);
		}
		public static void A2(int b)
		{
			if (b == 0)
			{
				B2(r);
			}
			else
			{
				y = (r * s) % n;
				z = (Math.Pow(y, 2) * vFinal) % n;
				Console.WriteLine("При букве З результат z = " + z);
			}
		}
		public static void B2(int r)
		{
			if (z == Math.Pow(r, 2) % n)
			{
				Console.WriteLine("При букве З результат z = " + z);
			}
		}

		static void Main(string[] args)
		{
			A1(3, 7);
			Console.ReadKey();

		}
	}
}
