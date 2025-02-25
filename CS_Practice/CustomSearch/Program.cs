internal class Program
{
	public static void Main(string[] args)
	{
	}

	public static int BinarySearch(int[] arr, int target)
	{
		int l = 0;
		int r = arr.Length - 1;
		while (l < r)
		{
			int mid = l + (r - l) / 2;
			if (arr[mid] == target) return mid;
			else if (arr[mid] < target) l = mid + 1;
			else r = mid - 1;
		}
		return -1;
	}

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

	public static int BinarySearch2(int[] arr, int l, int r, int target)
	{
		if (l < r) return -1;
		int mid = l + (l - r) / 2;
		if (arr[mid] == target) return mid;
		else if (arr[mid] < target) return BinarySearch2(arr, mid + 1, r, target);
		else return BinarySearch2(arr, l, mid - 1, target);
	}
}