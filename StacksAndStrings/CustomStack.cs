using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndStrings
{
    /// <summary>
    /// A generic stack implementation using T[]. 
    /// 
    /// This class is not thread-safe.
    /// </summary>
    /// <typeparam name="T">the type of items stored on the stack</typeparam>
    public class CustomStack<T> : ICustomStack<T>
    {
        private const float ExpandPct = 10f;

        private T[] items;
        private int itemCount = 0;

        /// <summary>
        /// Returns true if the stack is full requiring expansion to push more items.
        /// </summary>
        private bool IsFull
        {
            get
            {
                return itemCount == items.Length;
            }
        }

        /// <summary>
        /// Expand the item array by a given percentage of the current size.
        /// </summary>
        private void Expand()
        {
            var size = items.Count();

            var newSize = size + (int)(size * ExpandPct / 100);
            var expandedItems = new T[newSize];

            Array.Copy(items, expandedItems, size);

            items = expandedItems;
        }

        /// <summary>
        /// Returns true if the stack contains zero items.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return itemCount == 0;
            }
        }

        /// <summary>
        /// Returns the number of items in the stack.
        /// </summary>
        public int Size
        {
            get
            {
                return itemCount;
            }
        }

        /// <summary>
        /// Sets the initial stack size to 100.
        /// </summary>
        public CustomStack()
        {
            items = new T[100];
        }

        /// <summary>
        /// Removes the last item added to the stack.
        /// </summary>
        /// <returns>the removed item</returns>
        public T Pop()
        {
            if (itemCount == 0)
                throw new InvalidOperationException("The CustomStack is empty.");

            var item = items[itemCount - 1];
            itemCount--;

            return item;
        }

        /// <summary>
        /// Add a new item to the top of the stack.
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (IsFull)
                Expand();

            items[itemCount] = item;
            itemCount++;
        }
    }
}
