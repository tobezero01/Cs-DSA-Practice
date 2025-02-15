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