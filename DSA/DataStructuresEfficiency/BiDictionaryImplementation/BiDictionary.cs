namespace BiDictionaryImplementation
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, Guid> firstKeyCollection;
        private Dictionary<K2, Guid> secondKeyCollection;
        private MultiDictionary<Guid, T> values;

        public BiDictionary()
        {
            this.firstKeyCollection = new Dictionary<K1, Guid>();
            this.secondKeyCollection = new Dictionary<K2, Guid>();
            this.values = new MultiDictionary<Guid, T>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, T value)
        {
            var id = this.GenerateId();
            if (this.firstKeyCollection.ContainsKey(firstKey) && this.secondKeyCollection.ContainsKey(key2))
            {
                var id1 = this.firstKeyCollection[firstKey];
                var id2 = this.secondKeyCollection[secondKey];
                if (id1 == id2)
                {
                    id = id1;
                    this.values.Add(id, value);
                }
            }
            else
            {
                this.firstKeyCollection.Add(firstKey, id);
                this.secondKeyCollection.Add(secondKey, id);
                this.values.Add(id, value);
            }
        }

        public ICollection<T> FindByKey1(K1 firstKey)
        {
            if (this.firstKeyCollection.ContainsKey(firstKey))
            {
                var id = this.firstKeyCollection[firstKey];

                return this.values[id];
            }
            else
            {
                return null;
            }
        }

        public ICollection<T> FindByKey2(K2 secondKey)
        {
            if (this.secondKeyCollection.ContainsKey(secondKey))
            {
                var id = this.secondKeyCollection[secondKey];

                return this.values[id];
            }
            else
            {
                return null;
            }
        }

        public ICollection<T> FindByTwoKeys(K1 key1, K2 key2)
        {
            if (this.firstKeyCollection.ContainsKey(key1) && this.secondKeyCollection.ContainsKey(key2))
            {
                var id1 = this.firstKeyCollection[key1];
                var id2 = this.secondKeyCollection[key2];
                if (id1 == id2)
                {
                    return this.values[id1];
                }
            }

            return null;
        }

        private Guid GenerateId()
        {
            var guid = Guid.NewGuid();
            while (this.values.ContainsKey(guid))
            {
                guid = Guid.NewGuid();
            }

            return guid;
        }
    }
}
