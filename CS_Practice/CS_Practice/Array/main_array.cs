using CS_Practice.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice.Array
{
	internal class main_array
	{

		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			int[] arr = { 5, 1, 4, 2, 8 }; // Mảng chưa sắp xếp

			Console.WriteLine("Mảng ban đầu:");
			PrintArray(arr);

			bubble.BubbleSort(arr); // Gọi phương thức Bubble Sort để sắp xếp mảng

			Console.WriteLine("\nMảng sau khi sắp xếp:");
			PrintArray(arr); // In ra mảng đã sắp xếp
		}

		static void PrintArray(int[] arr)
		{
			foreach (int item in arr)
			{
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}
	}
}
