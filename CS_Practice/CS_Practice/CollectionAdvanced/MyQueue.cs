using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice.CollectionAdvanced
{
	public class MyQueue<T>
	{
		private T[] array;     // Mảng lưu trữ các phần tử
		private int head;      // Vị trí của phần tử đầu hàng đợi
		private int tail;      // Vị trí chèn phần tử mới
		private int count;     // Số lượng phần tử hiện có

		// Khởi tạo hàng đợi với kích thước ban đầu (mặc định là 4)
		public MyQueue(int capacity = 4)
		{
			array = new T[capacity];
			head = 0;
			tail = 0;
			count = 0;
		}

		// Thuộc tính trả về số lượng phần tử trong hàng đợi
		public int Count => count;

		// Thuộc tính cho biết kích thước mảng hiện tại
		private int Capacity => array.Length;

		// Phương thức mở rộng mảng khi cần (gấp đôi kích thước)
		private void EnsureCapacity()
		{
			if (count == Capacity)
			{
				int newCapacity = Capacity * 2;
				T[] newArray = new T[newCapacity];

				// Copy các phần tử từ head đến tail theo thứ tự
				if (head < tail)
				{
					Array.Copy(array, head, newArray, 0, count);
				}
				else
				{
					// Copy hai đoạn: từ head đến cuối mảng, sau đó từ đầu mảng đến tail
					int firstPartLength = Capacity - head;
					Array.Copy(array, head, newArray, 0, firstPartLength);
					Array.Copy(array, 0, newArray, firstPartLength, tail);
				}

				array = newArray;
				head = 0;
				tail = count;
			}
		}

		// Thêm phần tử vào cuối hàng đợi
		public void Enqueue(T item)
		{
			EnsureCapacity();
			array[tail] = item;
			tail = (tail + 1) % Capacity;
			count++;
		}

		// Lấy và xoá phần tử ở đầu hàng đợi
		public T Dequeue()
		{
			if (count == 0)
				throw new InvalidOperationException("Hàng đợi rỗng.");

			T removedItem = array[head];
			array[head] = default(T);  // Hỗ trợ giải phóng bộ nhớ
			head = (head + 1) % Capacity;
			count--;
			return removedItem;
		}

		// Lấy phần tử ở đầu hàng đợi mà không xoá nó
		public T Peek()
		{
			if (count == 0)
				throw new InvalidOperationException("Hàng đợi rỗng.");

			return array[head];
		}

		// Kiểm tra xem hàng đợi có chứa phần tử item hay không
		public bool Contains(T item)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < count; i++)
			{
				int index = (head + i) % Capacity;
				if (comparer.Equals(array[index], item))
					return true;
			}
			return false;
		}

		// Xoá toàn bộ phần tử trong hàng đợi
		public void Clear()
		{
			// Xoá sạch các phần tử trong mảng
			if (head < tail)
			{
				Array.Clear(array, head, count);
			}
			else
			{
				Array.Clear(array, head, Capacity - head);
				Array.Clear(array, 0, tail);
			}
			head = 0;
			tail = 0;
			count = 0;
		}

		// Hiển thị nội dung hàng đợi dưới dạng chuỗi
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[");
			for (int i = 0; i < count; i++)
			{
				if (i > 0)
					sb.Append(", ");
				int index = (head + i) % Capacity;
				sb.Append(array[index]);
			}
			sb.Append("]");
			return sb.ToString();
		}
	}
}