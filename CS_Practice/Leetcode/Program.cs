//internal class Program
//{
//	public static void Main(string[] args)
//	{
//	}

//	public static int[] TwoSum(int[] numbers, int target)
//	{
//		int left = 0;
//		int right = numbers.Length - 1;
//		while (left < right)
//		{
//			int sum = numbers[left] + numbers[right];
//			if (sum == target) break;
//			if (sum < target) left++;
//			if (sum > target) right--;
//		}
//		return new int[] { left + 1, right + 1 };
//	}
//}