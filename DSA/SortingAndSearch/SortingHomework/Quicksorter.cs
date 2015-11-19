namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = this.Partition(collection, left, right);

                this.QuickSort(collection, left, pivotIndex - 1);

                this.QuickSort(collection, pivotIndex + 1, right);
            }
        }

        private int Partition(IList<T> collection, int left, int right)
        {
            var pivotValue = collection[right];
            var storeIndex = left - 1;
            for (int i = left; i < right; i++)
            {
                if (collection[i].CompareTo(pivotValue) <= 0)
                {
                    storeIndex++;
                    this.Swap(collection, i, storeIndex);
                }
            }

            this.Swap(collection, storeIndex + 1, right);

            return storeIndex + 1;
        }

        private void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            var oldValue = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = oldValue;
        }
    }
}
