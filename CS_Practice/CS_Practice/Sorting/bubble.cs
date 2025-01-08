using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice.Sorting
{
	public class bubble
	{
		public static void BubbleSort(int[] arr)
		{
			int n = arr.Length;
			for (int i = 0; i < n - 1; i++) // Lặp qua các phần tử mảng
			{
				for (int j = 0; j < n - i - 1; j++) // So sánh từng cặp phần tử liền kề
				{
					if (arr[j] > arr[j + 1]) // Nếu phần tử trước lớn hơn phần tử sau, đổi chỗ chúng
					{
						// Hoán đổi arr[j] và arr[j + 1]
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}


		static void Main(string[] args)
		{
			
		}
	}
}
