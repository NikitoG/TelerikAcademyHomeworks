namespace LinkedListImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable
    {
        public LinkedList()
        {
            this.FirstElement = null;
        }

        public LinkedItem<T> FirstElement { get; set; }

        public void AddFirst(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new LinkedItem<T>(value);
            }
            else
            {
                LinkedItem<T> newItem = new LinkedItem<T>(value);
                newItem.NextItem = this.FirstElement;
                this.FirstElement = newItem;
            }
        }

        public void AddLast(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new LinkedItem<T>(value);
            }
            else
            {
                LinkedItem<T> newItem = this.FirstElement;
                while (newItem.NextItem != null)
                {
                    newItem = newItem.NextItem;
                }

                newItem.NextItem = new LinkedItem<T>(value);
            }
        }

        public void RemoveFirst()
        {
            this.FirstElement = this.FirstElement.NextItem;
        }

        public void RemoveLast()
        {
            LinkedItem<T> newItem = this.FirstElement;
            while (newItem.NextItem.NextItem != null)
            {
                newItem = newItem.NextItem;
            }

            newItem.NextItem = null;
        }

        public int Count()
        {
            int counter = 1;
            LinkedItem<T> newItem = this.FirstElement;

            while (newItem.NextItem != null)
            {
                newItem = newItem.NextItem;
                counter++;
            }

            return counter;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedItem<T> newItem = this.FirstElement;

            while (newItem != null)
            {
                yield return newItem.Value;
                newItem = newItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
