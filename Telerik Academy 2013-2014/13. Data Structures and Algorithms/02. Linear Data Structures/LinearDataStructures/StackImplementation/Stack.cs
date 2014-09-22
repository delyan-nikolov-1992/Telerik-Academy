namespace StackImplementation
{
    using System;

    public class Stack<T>
    {
        private T[] elements;

        private int capacity;

        private int index;

        public Stack()
        {
            this.Elements = new T[this.Capacity];
            this.index = -1;
        }

        public Stack(int capacity)
        {
            this.Capacity = capacity;
            this.Elements = new T[this.Capacity];
            this.index = -1;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                this.capacity = value;
            }
        }

        public int Length
        {
            get
            {
                return this.Index + 1;
            }
        }

        protected T[] Elements
        {
            get
            {
                return this.elements;
            }

            set
            {
                this.elements = value;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }

            set
            {
                this.index = value;
            }
        }

        public void Push(T element)
        {
            if (this.Length == Capacity)
            {
                IncreaseCapacity();
            }

            Index++;
            Elements[Index] = element;
        }

        public T Pop()
        {
            if (this.Length < 1)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T element = Elements[Index];
            Elements[Index] = default(T);
            Index--;

            return element;
        }

        public T Peek()
        {
            if (this.Length < 1)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return Elements[Index];
        }

        private void IncreaseCapacity()
        {
            Capacity++;
            Capacity *= 2;
            T[] newElements = new T[Capacity];
            Array.Copy(Elements, newElements, Elements.Length);
            Elements = newElements;
        }
    }
}