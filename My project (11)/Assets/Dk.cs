using UnityEngine;
public class Dk : MonoBehaviour
{
    public class TestList<T>
    {
        private T[] items;
        private int count;
        
        public int Count
        {
            get { return count; }
        }

        public TestList()
        {
            items = new T[4]; 
            count = 0;
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Resize();
            }

            items[count] = item;
            count++;
        }

        private void Resize()
        {
            T[] newArray = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new System.Exception("Index out of range");
            }

            return items[index];
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count)
            {
                throw new System.Exception("Index out of range");
            }

            items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new System.Exception("Index out of range");
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = default(T);
            count--;
        }
    }
    public class TestLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new System.Exception("Index out of range");
            }

            Node current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new System.Exception("Index out of range");
            }

            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
            }

            count--;
        }
    }
}