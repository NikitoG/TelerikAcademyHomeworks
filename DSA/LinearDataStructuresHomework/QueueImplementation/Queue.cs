namespace QueueImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IEnumerable
    {
        private LinkedList<T> items;

        public Queue()
        {
            this.items = new LinkedList<T>();
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public void Enqueue(T value)
        {
            this.items.AddLast(value);
        }

        public T Dequeue()
        {
            if (this.items.Count == 0)
            {
                throw new ArgumentNullException("Queue is empty!");
            }

            T value = this.items.First.Value;
            this.items.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if (this.items.Count == 0)
            {
                throw new ArgumentNullException("Queue is empty!");
            }

            T value = this.items.First.Value;

            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
