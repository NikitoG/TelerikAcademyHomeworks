namespace HashSetImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using HashTableImplementation;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> elements;

        public HashedSet()
        {
            this.elements = new HashTable<int, T>();
        }

        public int Count
        {
            get { return this.elements.Count; }
        }

        public void Add(T item)
        {
            if (!this.elements.ContainsKey(item.GetHashCode()))
            {
                this.elements.Add(item.GetHashCode(), item);
            }
        }

        public bool Contains(T item)
        {
            return this.elements.Find(item.GetHashCode(), out item);
        }

        public bool Remove(T item)
        {
            return this.elements.Remove(item.GetHashCode());
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public HashedSet<T> UnionWith(IEnumerable<T> otherSet)
        {
            var result = new HashedSet<T>();
            foreach (var item in this)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            foreach (var item in otherSet)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public HashedSet<T> IntersectWith(IEnumerable<T> otherSet)
        {
            var result = new HashedSet<T>();

            foreach (var item in this)
            {
                if (otherSet.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.elements)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
