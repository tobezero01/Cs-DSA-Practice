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