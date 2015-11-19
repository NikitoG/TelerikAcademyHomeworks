namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private static Random random = new Random();  

        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var currentItem in this.Items)
            {
                if (currentItem.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            var sorter = new MergeSorter<T>();

            this.Sort(sorter);

            var left = 0;
            var right = this.Items.Count - 1;
            while (left <= right)
            {
                var middle = (left + right) / 2;
                if (this.Items[middle].CompareTo(item) == 0)
                {
                    return true;
                } 
                else if (this.Items[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var count = this.Items.Count;
            while (count > 1)
            {
                count--;
                int index = random.Next(count + 1);
                T value = this.Items[index];
                this.Items[index] = this.Items[count];
                this.Items[count] = value;
            }  
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
