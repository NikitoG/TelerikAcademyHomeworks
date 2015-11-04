namespace StackImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable
    {
        private int capacity = 4;
        private T[] items;

        public Stack()
        {
            this.items = new T[this.Capacity];
            this.Count = 0;
        }

        public int Count { get; set; }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public void Push(T item)
        {
            if (this.Count + 1 > this.capacity)
            {
                this.capacity *= 2;
                T[] currentItems = this.items;
                this.items = new T[this.capacity];

                for (int i = 0; i < currentItems.Length; i++)
                {
                    this.items[i] = currentItems[i];
                }

                this.Count = currentItems.Length;
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;

            if(this.Count < 0)
            {
                throw new InvalidOperationException("Stack is Empty!");
            }

            T currentItem = this.items[this.Count];

            return currentItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("Stack is empty!");
            }

            return this.items[this.Count - 1];
        }

        public bool IsEmpty()
        {
            return this.Count > 0 ? true : false;
        }
    }
}
