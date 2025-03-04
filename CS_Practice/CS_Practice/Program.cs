// See https://aka.ms/new-console-template for more inform

using System.Text;

internal class Program
{
	public static void Main(string[] args)
	{
	}

	/// <summary>
	/// Leetcode 387 : Firsts the uniq character.
	/// </summary>
	/// <param name="s">The s.</param>
	/// <returns></returns>
	public static int FirstUniqChar(string s)
	{
		int n = s.Length;
		if (n == 0) return -1;
		Dictionary<char, int> count = new Dictionary<char, int>();
		foreach (char c in s)
		{
			if (count.ContainsKey(c))
			{
				count[c]++;
			}
			else
			{
				count[c] = 1;
			}
		}
		for (int i = 0; i < n; i++)
		{
			if (count[s[i]] == 1)
			{
				return i;
			}
		}
		return -1;
	}

	/// <summary>
	/// Leetcode 649. Dota2 Senate ,Predicts the party victory.
	/// </summary>
	/// <param name="senate">The senate.</param>
	/// <returns></returns>
	public string PredictPartyVictory(string senate)
	{
		int n = senate.Length;
		Queue<int> radiantQueue = new Queue<int>();
		Queue<int> direQueue = new Queue<int>();

		// them vij tri vao queue
		for (int i = 0; i < n; i++)
		{
			if (senate[i] == 'R')
			{
				radiantQueue.Enqueue(i);
			}
			else
			{
				direQueue.Enqueue(i);
			}
		}

		// bo phieu
		while (radiantQueue.Count > 0 && direQueue.Count > 0)
		{
			int rIndex = radiantQueue.Dequeue();
			int dIndex = direQueue.Dequeue();

			// Người có vị trí nhỏ hơn sẽ thắng vòng này và quay lại hàng đợi với vị trí mới
			if (rIndex < dIndex)
			{
				radiantQueue.Enqueue(rIndex + n);
			}
			else
			{
				direQueue.Enqueue(dIndex + n);
			}
		}
		return radiantQueue.Count > 0 ? "Radiant" : "Dire";
	}

	/// <summary>
	/// Leetcode 1700. Number of Students Unable to Eat Lunch
	/// </summary>
	/// <param name="students">The students.</param>
	/// <param name="sandwiches">The sandwiches.</param>
	/// <returns></returns>
	public int CountStudents(int[] students, int[] sandwiches)
	{
		int count0 = 0, count1 = 0;

		foreach (int student in students)
		{
			if (student == 0) count0++;
			else count1++;
		}

		foreach (int sandwich in sandwiches)
		{
			if (sandwich == 0 && count0 > 0)
				count0--;
			else if (sandwich == 1 && count1 > 0)
				count1--;
			else
				break; // Không ai có thể ăn bánh này
		}

		// Trả về số học sinh không thể ăn
		return count0 + count1;
	}

	/// <summary>
	/// Leetcode 2073 : Times the required to buy.
	/// </summary>
	/// <param name="tickets">The tickets.</param>
	/// <param name="k">The k.</param>
	/// <returns></returns>
	public int TimeRequiredToBuy(int[] tickets, int k)
	{
		int time = 0;
		int n = tickets.Length;

		for (int i = 0; i < n; i++)
		{
			// Nếu i <= k (người này mua trước hoặc cùng lượt với người k)
			// Họ có thể mua hết số vé của mình
			if (i <= k)
			{
				time += Math.Min(tickets[i], tickets[k]);
			}
			// Nếu i > k (người này mua sau người k)
			// Chỉ tính tối đa (tickets[k] - 1) lần, vì đến lượt cuối người k sẽ rời hàng
			else
			{
				time += Math.Min(tickets[i], tickets[k] - 1);
			}
		}
		return time;
	}

	/// <summary>
	/// Leetcode 844. Backspace String Compare
	/// </summary>
	/// <param name="s">The s.</param>
	/// <param name="t">The t.</param>
	/// <returns></returns>
	public bool BackspaceCompare(string s, string t)
	{
		return ProcessString(s) == ProcessString(t);
	}

	private string ProcessString(string s)
	{
		Stack<char> stack = new Stack<char>();
		foreach (char c in s)
		{
			if (c == '#')
			{
				if (stack.Count > 0) stack.Pop();
			}
			else
			{
				stack.Push(c);
			}
		}
		return new string(stack.ToArray());
	}

	/// <summary>
	/// Leetcode 1021. Remove Outermost Parentheses
	/// </summary>
	/// <param name="s">The s.</param>
	/// <returns></returns>
	public string RemoveOuterParentheses(string s)
	{
		StringBuilder str = new StringBuilder();
		int depth = 0;
		foreach (char c in s)
		{
			if (c == ')') depth--;
			if (depth > 0) str.Append(c);
			if (c == '(') depth++;
		}
		return s.ToString();
	}
}