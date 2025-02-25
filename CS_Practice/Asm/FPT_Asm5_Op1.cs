using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm
{
	internal class FPT_Asm5_Op1
	{
		public static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			// ================= Start Problem 1 ===================
			Console.WriteLine("============== Start Problem 1 =============");
			int[] arr = InputArray();
			Dictionary<int, int> frequency = CountFrequencies(arr);
			PrintFrequencies(frequency);
			Console.WriteLine("============== End Problem 1 =============");
			// =================== End Problem 1 ===================

			// ================= Start Problem 2 ===================
			Console.WriteLine("============== Start Problem 2 =============");
			int[] arr2 = InputArray();
			Array.Sort(arr2);
			int target = InputTarget();
			Console.WriteLine("First Index target : " + BinarySearch_ReturnFirstIndex(arr2, target));
			Console.WriteLine("============== End Problem 2 =============");
			// =================== End Problem 2 ===================
		}

		/// <summary>
		/// Binaries the first index of the search return.
		/// </summary>
		/// <param name="arr">The arr.</param>
		/// <param name="target">The target.</param>
		/// <returns>First index of target </returns>
		public static int BinarySearch_ReturnFirstIndex(int[] arr, int target)
		{
			int l = 0;
			int r = arr.Length - 1;
			while (l < r)
			{
				int mid = l + (r - l) / 2;
				if (arr[mid] == target)
				{
					while (mid > 0 && arr[mid - 1] == target)
					{
						mid--;
					}
					return mid;
				}
				else if (arr[mid] < target) l = mid + 1;
				else r = mid - 1;
			}
			return -1;
		}

		/// <summary>
		/// Inputs the target.
		/// </summary>
		/// <returns>An integer</returns>
		private static int InputTarget()
		{
			Console.WriteLine("Nhập số cần tìm :");
			int target;
			while (!int.TryParse(Console.ReadLine(), out target))
			{
				Console.WriteLine("Hãy nhập số nguyên !!!");
			}
			return target;
		}

		/// <summary>
		/// Inputs the array.
		/// </summary>
		/// <returns></returns>
		private static int[] InputArray()
		{
			Console.Write("Nhập N :");
			int n;
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
			{
				Console.WriteLine("Hãy nhập số dương !!!");
			}

			int[] arr = new int[n];

			Console.WriteLine($"Nhập {n} số nguyên :");
			for (int i = 0; i < n; i++)
			{
				while (!int.TryParse(Console.ReadLine(), out arr[i]))
				{
					Console.WriteLine("Vui lòng nhập số nguyên!!");
				}
			}
			return arr;
		}

		/// <summary>
		/// Counts the frequencies.
		/// </summary>
		/// <param name="arr">The arr.</param>
		/// <returns></returns>
		private static Dictionary<int, int> CountFrequencies(int[] arr)
		{
			Dictionary<int, int> frequency = new Dictionary<int, int>();
			foreach (int num in arr)
			{
				if (frequency.ContainsKey(num))
				{
					frequency[num]++;
				}
				else
				{
					frequency[num] = 1;
				}
			}
			return frequency;
		}

		/// <summary>
		/// Prints the frequencies.
		/// </summary>
		/// <param name="frequency">The frequency.</param>
		private static void PrintFrequencies(Dictionary<int, int> frequency)
		{
			Console.WriteLine("\nIn kết quả :");
			foreach (var item in frequency)
			{
				Console.WriteLine($"Number {item.Key}: {item.Value}");
			}
		}
	}
}