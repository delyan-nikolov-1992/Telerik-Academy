namespace ImplementingHashSet
{
    using System.Collections.Generic;

    using ImplementingHashTable;
    using System.Collections;

    public class HashSet<T> : IEnumerable<T>
    {
        private HashTable<int, T> elements;

        public HashSet()
        {
            this.elements = new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element)
        {
            this.elements.Add(element.GetHashCode(), element);
        }

        public T Find(T element)
        {
            return this.elements.Find(element.GetHashCode());
        }

        public bool Remove(T element)
        {
            return this.elements.Remove(element.GetHashCode());
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public HashSet<T> UnionWith(HashSet<T> other)
        {
            HashSet<T> resultSet = new HashSet<T>();

            foreach (var element in this)
            {
                resultSet.Add(element);
            }

            foreach (var element in other)
            {
                resultSet.Add(element);
            }

            return resultSet;
        }

        public HashSet<T> IntersectWith(HashSet<T> other)
        {
            HashSet<T> resultSet = new HashSet<T>();

            foreach (var element in this)
            {
                foreach (var otherElement in other)
                {
                    if (element.Equals(otherElement))
                    {
                        resultSet.Add(element);
                    }
                }
            }

            return resultSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.elements)
            {
                yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}