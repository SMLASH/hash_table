using System;


namespace list
{
    public class List<T> : IList<T> where T : IComparable
    {
        public int Count { get; private set; } = 0;
        private Node _head;

        public bool Find(T value) => FindValue(_head, value);
        public void DeleteValue(T value) => DeleteValue(_head, value);

        public void Delete(int index)
        {
            if (Count == 1)
            {
                _head = null;
                return;
            }
            var temp = _head;
            for (var i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }

            temp.Next = temp.Next.Next;
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
                Count++;
                return;
            }
            AddElementToEnd(_head, value);
        }

        private void AddElementToEnd(Node root, T value)
        {
            if (root.Next == null)
            {
                root.Next = new Node(value);
                Count++;
                return;
            }

            AddElementToEnd(root.Next, value);
        }

        private bool FindValue(Node first, T value)
        {
            if (first.Equals(null))
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

            if (root.Value.Equals(value))
            {
                Count = 0;
                root = null;
                return;
            }

            if (root.Next.Value.Equals(value))
            {
                root.Next = root.Next.Next;
                Count--;
                return;
            }
            else
            {
                DeleteValue(root.Next, value);
            }
        }

        private Node GetNext(Node root)
        {
            return root.Next;
        }

        private class Node
        {
            public readonly T Value;

            private Node _next;
            
            public Node Next
            {
                get => _next;

                set => _next = value;

                //set => value; // ?? throw new ArgumentNullException(nameof(value));
            }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        public T this[int i] => GetValue(i);

    }
}