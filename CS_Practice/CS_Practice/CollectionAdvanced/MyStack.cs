using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Practice.CollectionAdvanced
{
	public class MyStack<T>
	{
		private T[] items;    // Mảng lưu trữ các phần tử của stack
		private int count;    // Số lượng phần tử hiện có trong stack

		// Khởi tạo stack với kích thước mảng ban đầu (mặc định là 4)
		public MyStack(int capacity = 4)
		{
			items = new T[capacity];
			count = 0;
		}

		// Thuộc tính trả về số lượng phần tử hiện có trong stack
		public int Count => count;

		// Thuộc tính cho biết kích thước mảng hiện tại
		private int Capacity => items.Length;

		// Phương thức đảm bảo mảng có đủ dung lượng, nếu không sẽ mở rộng (gấp đôi kích thước)
		private void EnsureCapacity()
		{
			if (count == Capacity)
			{
				int newCapacity = Capacity * 2;
				T[] newItems = new T[newCapacity];
				Array.Copy(items, newItems, count);
				items = newItems;
			}
		}

		// Thêm phần tử vào đỉnh stack
		public void Push(T item)
		{
			EnsureCapacity();
			items[count] = item;
			count++;
		}

		// Lấy và xoá phần tử ở đỉnh stack
		public T Pop()
		{
			if (count == 0)
				throw new InvalidOperationException("Stack rỗng.");
			count--;
			T item = items[count];
			items[count] = default(T); // Hỗ trợ giải phóng bộ nhớ
			return item;
		}

		// Lấy phần tử ở đỉnh stack mà không xoá nó
		public T Peek()
		{
			if (count == 0)
				throw new InvalidOperationException("Stack rỗng.");
			return items[count - 1];
		}

		// Kiểm tra sự tồn tại của phần tử trong stack
		public bool Contains(T item)
		{
			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < count; i++)
			{
				if (comparer.Equals(items[i], item))
					return true;
			}
			return false;
		}

		// Xoá toàn bộ phần tử trong stack
		public void Clear()
		{
			for (int i = 0; i < count; i++)
			{
				items[i] = default(T);
			}
			count = 0;
		}

		// Hiển thị nội dung của stack dưới dạng chuỗi (phần tử ở đỉnh sẽ hiển thị đầu tiên)
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("[");
			for (int i = count - 1; i >= 0; i--)
			{
				if (i < count - 1)
					sb.Append(", ");
				sb.Append(items[i]);
			}
			sb.Append("]");
			return sb.ToString();
		}
	}
}