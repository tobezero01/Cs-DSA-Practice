using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice.CollectionAdvanced
{
	public class MyLinkedList<T>
	{
		private T[] items;      // mảng lưu trữ các phần tử
		private int head;       // vị trí của phần tử đầu tiên trong mảng vòng
		private int count;      // số lượng phần tử hiện có

		// Khởi tạo với kích thước ban đầu (mặc định là 4)
		public MyLinkedList(int capacity = 4)
		{
			items = new T[capacity];
			head = 0;
			count = 0;
		}

		// Thuộc tính đếm số phần tử
		public int Count => count;

		// Thuộc tính cho biết kích thước mảng hiện tại
		private int Capacity => items.Length;

		// Kiểm tra và mở rộng mảng nếu cần (gấp đôi kích thước)
		private void EnsureCapacity()
		{
			if (count == Capacity)
			{
				int newCapacity = Capacity * 2;
				T[] newArray = new T[newCapacity];
				// Copy các phần tử theo thứ tự từ head
				for (int i = 0; i < count; i++)
				{
					newArray[i] = this[i];
				}
				items = newArray;
				head = 0;
			}
		}

		// Indexer cho phép truy xuất phần tử theo vị trí (0-indexed)
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= count)
					throw new ArgumentOutOfRangeException(nameof(index));
				int realIndex = (head + index) % Capacity;
				return items[realIndex];
			}
			set
			{
				if (index < 0 || index >= count)
					throw new ArgumentOutOfRangeException(nameof(index));
				int realIndex = (head + index) % Capacity;
				items[realIndex] = value;
			}
		}

		// Thêm phần tử vào cuối danh sách
		public void AddLast(T item)
		{
			EnsureCapacity();
			int tailIndex = (head + count) % Capacity; // vị trí chèn mới ở cuối
			items[tailIndex] = item;
			count++;
		}

		// Thêm phần tử vào đầu danh sách
		public void AddFirst(T item)
		{
			EnsureCapacity();
			// Giảm head đi 1 (với vòng tròn)
			head = (head - 1 + Capacity) % Capacity;
			items[head] = item;
			count++;
		}

		// Xoá và trả về phần tử đầu tiên
		public T RemoveFirst()
		{
			if (count == 0)
				throw new InvalidOperationException("Danh sách rỗng.");
			T removedItem = items[head];
			items[head] = default(T); // hỗ trợ dọn dẹp bộ nhớ
			head = (head + 1) % Capacity;
			count--;
			return removedItem;
		}

		// Xoá và trả về phần tử cuối cùng
		public T RemoveLast()
		{
			if (count == 0)
				throw new InvalidOperationException("Danh sách rỗng.");
			int tailIndex = (head + count - 1) % Capacity;
			T removedItem = items[tailIndex];
			items[tailIndex] = default(T);
			count--;
			return removedItem;
		}

		// Kiểm tra xem danh sách có chứa phần tử nào không
		public bool Contains(T item)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < count; i++)
			{
				if (comparer.Equals(this[i], item))
					return true;
			}
			return false;
		}

		// Trả về chỉ số của phần tử đầu tiên khớp với item (nếu không có thì trả về -1)
		public int IndexOf(T item)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < count; i++)
			{
				if (comparer.Equals(this[i], item))
					return i;
			}
			return -1;
		}

		// Chèn phần tử vào vị trí bất kỳ (0-indexed)
		public void InsertAt(int index, T item)
		{
			if (index < 0 || index > count)
				throw new ArgumentOutOfRangeException(nameof(index));
			// Nếu chèn vào đầu hoặc cuối thì sử dụng các hàm có sẵn
			if (index == 0)
			{
				AddFirst(item);
				return;
			}
			else if (index == count)
			{
				AddLast(item);
				return;
			}

			EnsureCapacity();

			// Tìm vị trí thực trong mảng
			int realIndex = (head + index) % Capacity;

			// Dịch chuyển các phần tử bên phải (từ cuối mảng về realIndex)
			for (int i = count - 1; i >= index; i--)
			{
				int current = (head + i) % Capacity;
				int next = (current + 1) % Capacity;
				items[next] = items[current];
			}
			items[realIndex] = item;
			count++;
		}

		// Xoá phần tử tại vị trí cho trước
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= count)
				throw new ArgumentOutOfRangeException(nameof(index));

			int realIndex = (head + index) % Capacity;
			// Dịch chuyển các phần tử bên trái để lấp khoảng trống
			for (int i = index; i < count - 1; i++)
			{
				int current = (head + i) % Capacity;
				int next = (head + i + 1) % Capacity;
				items[current] = items[next];
			}
			int tailIndex = (head + count - 1) % Capacity;
			items[tailIndex] = default(T);
			count--;
		}

		// Xoá toàn bộ phần tử trong danh sách
		public void Clear()
		{
			for (int i = 0; i < count; i++)
			{
				items[(head + i) % Capacity] = default(T);
			}
			head = 0;
			count = 0;
		}

		// Phương thức hiển thị nội dung danh sách dưới dạng chuỗi
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[");
			for (int i = 0; i < count; i++)
			{
				if (i > 0)
					sb.Append(", ");
				sb.Append(this[i]);
			}
			sb.Append("]");
			return sb.ToString();
		}
	}
}