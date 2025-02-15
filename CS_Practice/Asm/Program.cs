using System;
using System.Collections.Generic;

internal class CustomStack<T>
{
	private T[] stack;
	private int top;
	private int capacity;

	public CustomStack(int size)
	{
		stack = new T[size];
		capacity = size;
		top = -1;
	}

	public void Push(T item)
	{
		if (IsFull())
		{
			Console.WriteLine("Stack overflow!");
			return;
		}
		stack[++top] = item;
	}

	public T Pop()
	{
		if (IsEmpty())
		{
			Console.WriteLine("Stack underflow!");
			return default(T); // Trả về giá trị mặc định của kiểu dữ liệu T
		}
		return stack[top--];
	}

	public T Peek()
	{
		if (IsEmpty()) return default(T);
		return stack[top];
	}

	public bool IsEmpty()
	{
		return top == -1;
	}

	public bool IsFull()
	{
		return top == capacity - 1;
	}
}

internal class CustomQueue<T>
{
	private T[] queue;
	private int front, rear, capacity, size;

	public CustomQueue(int capacity)
	{
		this.capacity = capacity;
		queue = new T[capacity];
		front = 0;
		rear = -1;
		size = 0;
	}

	public void Enqueue(T item)
	{
		if (IsFull())
		{
			Console.WriteLine("Queue overflow!");
			return;
		}
		rear = (rear + 1) % capacity;
		queue[rear] = item;
		size++;
	}

	public T Dequeue()
	{
		if (IsEmpty())
		{
			Console.WriteLine("Queue underflow!");
			return default(T);
		}
		T item = queue[front];
		front = (front + 1) % capacity;
		size--;
		return item;
	}

	public T Peek()
	{
		if (IsEmpty()) return default(T);
		return queue[front];
	}

	public bool IsEmpty()
	{
		return size == 0;
	}

	public bool IsFull()
	{
		return size == capacity;
	}

	public int Size()
	{
		return size;
	}
}

internal class Program
{
	private static void Main(string[] args)
	{
		Problem1(); Console.WriteLine();
		Problem2("FSOFT ACADEMY"); Console.WriteLine();
		Problem3(); Console.WriteLine();
		Problem4(10); Console.WriteLine();
		Problem5(5);
	}

	/// <summary>
	/// Stack operations
	/// </summary>
	private static void Problem1()
	{
		string operations = "EAS*Y*QUE***ST***IO*N***";
		CustomStack<char> stack = new CustomStack<char>(operations.Length);
		Console.Write("Problem 1 Output: ");
		foreach (char c in operations)
		{
			if (c == '*')
			{
				Console.Write(stack.Pop() + " ");
			}
			else
			{
				stack.Push(c);
			}
		}
	}

	/// <summary>
	/// Reverse a string using Stack
	/// </summary>
	/// <param name="input">The input.</param>
	private static void Problem2(string input)
	{
		CustomStack<char> stack = new CustomStack<char>(input.Length);
		foreach (char c in input) stack.Push(c);

		Console.Write("Problem 2 Output: ");
		while (!stack.IsEmpty()) Console.Write(stack.Pop());
	}

	/// <summary>
	/// Queue operations
	/// </summary>
	private static void Problem3()
	{
		string operations = "EAS*Y*QUE***ST***IO*N***";
		CustomQueue<char> queue = new CustomQueue<char>(operations.Length);
		Console.Write("Problem 3 Output: ");
		foreach (char c in operations)
		{
			if (c == '*')
			{
				if (queue.Size() > 0)
				{
					Console.Write(queue.Dequeue() + " ");
				}
			}
			else
			{
				queue.Enqueue(c);
			}
		}
	}

	/// <summary>
	/// Fibonaccis the specified n.
	/// </summary>
	/// <param name="n">The n.</param>
	/// <returns>Fibo nth</returns>
	private static int Fibonacci(int n)
	{
		if (n == 0) return 0;
		if (n == 1) return 1;
		return Fibonacci(n - 1) + Fibonacci(n - 2);
	}

	private static void Problem4(int n)
	{
		Console.Write("Problem 4 Output: " + n + " numbers: ");
		for (int i = 0; i < n; i++)
		{
			Console.Write(Fibonacci(i) + " ");
		}
	}

	/// <summary>
	/// Factorials the specified n.
	/// </summary>
	/// <param name="n">The n.</param>
	/// <returns>Factorials nth</returns>
	private static int Factorial(int n)
	{
		if (n == 0 || n == 1) return 1;
		return n * Factorial(n - 1);
	}

	private static void Problem5(int n)
	{
		Console.WriteLine("Problem 5 Output: " + n + " is: " + Factorial(n));
	}
}