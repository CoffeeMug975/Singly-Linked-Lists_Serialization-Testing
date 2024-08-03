using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OO2_Assignment3_Group4
{
    [Serializable]
    public class SLL<T> : ILinkedListADT<T>
    {
        private Node<T> head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }

        public void Prepend(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void Append(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (index == 0)
            {
                RemoveAtStart();
                return;
            }

            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            count--;
        }

        public void RemoveAtStart()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }
            head = head.Next;
            count--;
        }

        public void RemoveAtEnd()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node<T> current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            count--;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (index == 0)
            {
                Prepend(item);
                return;
            }

            Node<T> newNode = new Node<T>(item);
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }

        public void Replace(int index, T item)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = item;
        }

        public T GetItemAtIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int GetIndexOfItem(T item)
        {
            Node<T> current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(item))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1; // Item not found
        }

        public bool CheckListForItem(T item)
        {
            return GetIndexOfItem(item) != -1;

        }

        public void ClearList()
        {
            head = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Reverse()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        // Serialization method
        public byte[] Serialize()
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL<T>));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                return ms.ToArray();
            }
        }

        // Deserialization method
        public static SLL<T> Deserialize(byte[] data)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL<T>));
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (SLL<T>)serializer.ReadObject(ms);
            }
        }
    }
}
