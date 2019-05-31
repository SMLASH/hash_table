using System;

//TODO: System.Collections.Generic;
// where T : IComparable

namespace List
{
    public class List<T> : IList<T> where T : IComparable
    {
        private Node _head;

        public bool Find(T value) => FindValue(_head, value);
        
        public void Delete(T value) => DeleteValue(_head, value);
        
        public void Delete(int index)
        {
            var head = _head;
            for (var i = 0; i < index - 1; i++)
            {
                head = GetNext(head);
            }
            
            head.Next = head.Next.Next;
        }

        public void Add(T value, int index)
        {
            throw new NotImplementedException();
        }

        public T GetValue(int index)
        {
            var currentNode = _head;
            for (var i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }
        
        
//        public void AddToBegin(T value)
//        {
//            var newNode = new Node(value);
//            newNode.Next = _head;
//            _head = newNode;
//        }

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node(value);
                return;
            }
            AddElementToEnd(_head, value);
        }
        
        public void AddByIndex(T value, int index)
        {
            throw new NotImplementedException();
        }

        private void AddElementToEnd(Node head, T value)
        {
            if (head.Next == null)
            {
                head.Next = new Node(value);
                return;
            }

            AddElementToEnd(head.Next, value);
        }

        private bool FindValue(Node first, T value)
        {
            if (first?.Next == null)
            {
                return false;
            }
            return first.Value.Equals(value) || FindValue(first.Next, value);
        }
        

        private void DeleteValue(Node root, T value)
        {
            if (FindValue(root, value) == false)
            {
                throw new ArgumentException("No such value in this list");
            }

            if (root.Next.Value.Equals(value))
            {
                root.Next = root.Next.Next;
            }
            else
            {
                DeleteValue(root.Next, value);
            }
        }

        private Node GetNext(Node head)
        {
            return head.Next;
        }
        
        private class Node
        {
            public readonly T Value;

            public Node Next
            {
                get
                {
                    if (Next == null)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return Next;
                }
                
                set => Next = value ?? throw new ArgumentNullException(nameof(value));
            }
            public Node(T value)
            {
                this.Value = value;
            }
        }

        public T this[int i] => GetValue(i);
    }
}