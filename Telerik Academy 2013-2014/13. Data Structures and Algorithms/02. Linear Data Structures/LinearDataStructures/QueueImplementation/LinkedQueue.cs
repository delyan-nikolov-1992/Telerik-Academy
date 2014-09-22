namespace QueueImplementation
{
    using System;
    using System.Collections.Generic;

    public class LinkedQueue<T>
    {
        private Node<T> head;

        private Node<T> tail;

        private int count;

        public LinkedQueue()
        {
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = this.head;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = this.tail.Next;
            }

            this.count++;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            T result = this.head.Data;
            this.head = this.head.Next;

            return result;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.head.Data;
        }
    }
}