using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class FixedSizeList<T>
    {
        private readonly int _capacity;
        private readonly List<T> _list;

        public int Count { get; private set; }

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            _capacity = capacity;
            _list = new List<T>(capacity);
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count >= _capacity)
            {
                Console.WriteLine("Error: The list is full. Cannot add another item.");
                return;
            }

            _list.Add(item);
            Count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index out of range.");

            return _list[index];
        }

    }
}
