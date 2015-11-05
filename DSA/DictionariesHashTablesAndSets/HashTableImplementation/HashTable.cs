namespace HashTableImplementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Helpers;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int DefaultCapacity = 16;
        private const double CapacityResizing = 0.75;

        private LinkedList<KeyValuePair<K, T>>[] elements;
        private ICollection<K> keys;
        private int count;

        public HashTable()
        {
            this.Clear();
        }

        public int Count { get; private set; }

        public ICollection<K> Keys
        {
            get
            {
                return this.keys;
            }
        }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        public T this[K key]
        {
            get
            {
                T result = default(T);
                var isExist = this.Find(key, out result);
                if (isExist)
                {
                    return result;
                }

                throw new KeyNotFoundException("The given key was not present in the hash table.");
            }

            set
            {
                this.Add(key, value);
            }
        }

        public void Add(K key, T value)
        {
            if (this.Keys.Contains(key))
            {
                throw new ArgumentException("An item with the same key already been addded.");
            }

            this.Keys.Add(key);

            if (this.Count >= this.elements.Length * CapacityResizing)
            {
                this.ResizeTable();
            }

            var index = this.GetHashCode(key);
            if (this.elements[index] == null)
            {
                this.elements[index] = new LinkedList<KeyValuePair<K, T>>();
            }

            var newPair = new KeyValuePair<K, T>(key, value);
            this.elements[index].AddLast(newPair);
            this.Count++;
        }

        public bool Find(K key, out T value)
        {
            if (!this.ContainsKey(key))
            {
                value = default(T);
                return false;
            }

            var index = this.GetHashCode(key);
            var collesionItems = this.elements[index];
            foreach (var pair in collesionItems)
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }

            value = default(T);
            return false;
        }

        public bool ContainsKey(K key)
        {
            return this.Keys.Contains(key);
        }
        
        public bool Remove(K key)
        {
            if (!this.ContainsKey(key))
            {
                return false;
            }

            this.Keys.Remove(key);
            var index = this.GetHashCode(key);
            var pairToRemove = this.elements[index].First(p => p.Key.Equals(key));
            this.Count--;

            return this.elements[index].Remove(pairToRemove);
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[DefaultCapacity];
            this.keys = new HashSet<K>();
            this.Count = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var collesionItems in this.elements)
            {
                if (collesionItems == null)
                {
                    continue;
                }

                foreach (var pair in collesionItems)
                {
                    yield return pair;
                }
            }
        }

        public IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetHashCode(K key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }

        private void ResizeTable()
        {
            var lenght = this.elements.Length * 2;
            var oldTable = Copy.DeepClone(this.elements);

            this.keys = new HashSet<K>();
            this.elements = new LinkedList<KeyValuePair<K, T>>[lenght];
            this.Count = 0;

            foreach (var item in oldTable)
            {
                if (item != null)
                {
                    foreach (var pair in item)
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}
