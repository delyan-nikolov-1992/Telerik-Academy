namespace ImplementingHashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;
        private const double LoadFactor = 0.75;

        private int occupiedBucketsCounter;
        private int elementsCounter;

        private LinkedList<KeyValuePair<K, T>>[] buckets;

        public HashTable()
            : this(InitialCapacity)
        {
        }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("The capacity of the hash table should be a positive number.");
            }

            this.buckets = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.occupiedBucketsCounter = 0;
            this.elementsCounter = 0;
        }

        public int Count
        {
            get
            {
                return this.elementsCounter;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                ICollection<K> listOfKeys = new List<K>(this.elementsCounter);

                foreach (var pair in this)
                {
                    listOfKeys.Add(pair.Key);
                }

                return listOfKeys;
            }
        }

        public T this[K key]
        {
            get
            {
                T valueToReturn = this.Find(key);

                return valueToReturn;
            }

            set
            {
                this.Add(key, value);
            }
        }

        public void Add(K key, T value)
        {
            this.CheckAndGrow();

            var elementToAdd = new KeyValuePair<K, T>(key, value);
            int position = this.GetBucketPosition(key);

            if (this.buckets[position] == null)
            {
                this.buckets[position] = new LinkedList<KeyValuePair<K, T>>();
                this.buckets[position].AddFirst(elementToAdd);
                this.occupiedBucketsCounter++;
            }
            else
            {
                this.Remove(key);

                if (this.buckets[position].Count == 0)
                {
                    this.occupiedBucketsCounter++;
                }

                this.buckets[position].AddLast(elementToAdd);
            }

            this.elementsCounter++;
        }

        public T Find(K key)
        {
            int position = this.GetBucketPosition(key);

            if (this.buckets[position] != null && this.buckets[position].Count != 0)
            {
                foreach (var pair in this.buckets[position])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }

            return default(T);
        }

        public bool Remove(K key)
        {
            int position = this.GetBucketPosition(key);

            if (this.buckets[position] != null && this.buckets[position].Count != 0)
            {
                if (!this.Find(key).Equals(default(T)))
                {
                    var nodeToRemove = this.buckets[position].First(x => x.Key.Equals(key));
                    this.buckets[position].Remove(nodeToRemove);
                    this.elementsCounter--;

                    if (this.buckets[position].Count == 0)
                    {
                        this.occupiedBucketsCounter--;
                    }

                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.buckets = new LinkedList<KeyValuePair<K, T>>[this.buckets.Length];
            this.occupiedBucketsCounter = 0;
            this.elementsCounter = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.buckets)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var pair in this)
            {
                result.AppendFormat("({0} -> {1}) ; ", pair.Key, pair.Value);
            }

            return result.ToString().TrimEnd(new char[] { ';', ' ' });
        }

        private void CheckAndGrow()
        {
            if (this.occupiedBucketsCounter >= this.buckets.Length * LoadFactor)
            {
                var newHashTable = new HashTable<K, T>(this.buckets.Length * 2);

                foreach (var pair in this)
                {
                    newHashTable.Add(pair.Key, pair.Value);
                }

                this.buckets = newHashTable.buckets;
            }
        }

        private int GetBucketPosition(K key)
        {
            var position = Math.Abs(key.GetHashCode() % this.buckets.Length);

            return position;
        }
    }
}