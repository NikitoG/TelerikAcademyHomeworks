namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection);
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var middle = collection.Count / 2;
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            left = this.MergeSort(left);
            right = this.MergeSort(right);

            collection.Clear();
            return this.Merge(collection, left, right);
        }

        private IList<T> Merge(IList<T> collection, IList<T> left, IList<T> right)
        {
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0].CompareTo(right[0]) > 0)
                {
                    collection.Add(right[0]);
                    right.RemoveAt(0);
                }
                else
                {
                    collection.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                collection.Add(left[0]);
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                collection.Add(right[0]);
                right.RemoveAt(0);
            }

            return collection;
        }
    }
}
