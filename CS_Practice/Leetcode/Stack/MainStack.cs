using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
	public class MainStack
	{
		public static void Main(string[] args)
		{
			int[] numbers = { 3, 4, -9, 0, 2, 5, 4, 3, 4, 0, -9, 7, 1 };

			for (int i = 0; i < numbers.Length; i++)
			{
				int current = numbers[i];
				bool isDuplicate = false;
				for (int j = 0; j < i; j++)
				{
					if (numbers[j] == current)
					{
						isDuplicate = true;
						break;
					}
				}
				if (!isDuplicate)
				{
					int count = 0;
					for (int k = 0; k < numbers.Length; k++)
					{
						if (numbers[k] == current)
						{
							count++;
						}
					}
					Console.WriteLine($"Số {current} xuất hiện {count} lần");
				}
			}
		}

		/// <summary>
		/// Leetcode 71. Simplify Path
		/// </summary>
		/// <param name="path">The path.</param>
		/// <returns></returns>
		public static string SimplifyPath(string path)
		{
			if (path == null) return null;
			string[] component = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			Stack<string> stack = new Stack<string>();
			foreach (string componentPath in component)
			{
				if (componentPath == "." || componentPath == "")
				{
					continue;
				}
				else if (componentPath == "..")
				{
					if (stack.Count > 0) stack.Pop();
				}
				else
				{
					stack.Push(componentPath);
				}
			}
			if (stack.Count == 0) return "/";

			StringBuilder sb = new StringBuilder();
			foreach (string componentPath in stack.Reverse())
			{
				sb.Append("/").Append(componentPath);
			}
			return sb.ToString();
		}
	}
}