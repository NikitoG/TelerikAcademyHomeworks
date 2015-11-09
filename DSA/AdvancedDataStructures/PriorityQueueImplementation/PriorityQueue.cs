namespace PriorityQueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> queue;

        public PriorityQueue()
        {
            this.queue = new List<T>();
        }

        public int Count
        {
            get { return this.queue.Count; }
        }

        public void Enqueue(T element)
        {
            var index = this.Count;
            this.queue.Add(element);

            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (!(this.queue[index].CompareTo(this.queue[parentIndex]) > 0))
                {
                    break;
                }

                T oldValue = queue[index];
                queue[index] = queue[parentIndex];
                queue[parentIndex] = oldValue;
                index = parentIndex;
            }
        }

        public T Dequeue()
        {
            var index = this.Count - 1;
            var result = this.queue[0];
            this.queue[0] = this.queue[index];
            this.queue.RemoveAt(index);

            MaxHeapify(0);

            return result;
        }

        private void MaxHeapify(int index)
        {
            var left = 2 * index;
            var right = 2 * index + 1;
            var largest = index;

            if (left < this.Count && this.queue[left].CompareTo(this.queue[largest]) > 0)
            {
                largest = left;
            }

            if (right < this.Count && this.queue[right].CompareTo(this.queue[largest]) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                var oldValue = this.queue[index];
                this.queue[index] = this.queue[largest];
                this.queue[largest] = oldValue;

                MaxHeapify(largest);
            }
        }
    }
}
