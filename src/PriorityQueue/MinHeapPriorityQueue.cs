using System;
using System.Text;
using System.Collections.Generic;
using PriorityQueue;

namespace PriorityQueue 
{
    /*
     * A collection of ordered elements that provides fast
     * access to the minimum element.
     */
    public class MinHeapPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        private static int DEFAULT_CAPACITY = 10;

        private T[] elements; // array of elements
        private int size; // number of elements in the queue

        // Default Constructor:
        // Construct an empty priority queue with default capacity
        public MinHeapPriorityQueue() 
        {
            this.elements = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        // Return the number of elements in the queue
        public int Count 
        {
            get { return size; } 
        }

        // This method adds a new element into queue and restores the heap ordering.
        public void Add(T element) 
        {
            // resize if neccessary
            if (size == elements.Length - 1) 
            {
                T[] newElements = new T[2 * elements.Length];
                elements.CopyTo(newElements, 0);
                this.elements = newElements;
            }

            elements[size + 1] = element; // add as rightmost leaf
            
            // bubble up to restore the ordering
            int index = size + 1;
            bool found = false;
            while (!found && HasParent(index)) 
            {
                int parent = Parent(index);
                if (elements[index].CompareTo(elements[parent]) < 0)
                {
                    Swap(elements, index, Parent(index));
                    index = Parent(index);
                } 
                else 
                {
                    found = true; // found proper location; stop
                }
            }
            size++;
        }

        // This method clears the queue and set the queue to be empty.
        public void Clear() 
        {
            this.elements = null;
            size = 0;
        }

        // This methods returns true if there exits same element as the one passed in; otherwise, returns false.
        public bool Contains(T element) 
        {   
            for (int i = 1; i <= size; i++)
            {
                if (elements[i].CompareTo(element) == 0) return true;
            }
            return false;
        }

        // This method returns true if queue is empty; otherwise, return false.
        public bool IsEmpty() 
        {
            return size == 0;
        }

        // This method returns the root node.
        public T Peek() 
        {
            return elements[1];
        }

        // Pre: queue is not empty
        // This method removes the minimum element (root) from queue and returns the minimum element.
        public T Remove() 
        {
            T result = elements[1];
            elements[1] = elements[size];
            size--;
            int index = 1;
            bool found = false;
            while (!found && HasLeftChild(index))
            {
                int left = LeftChild(index);
                int right = RightChild(index);
                int child = left;
                if (HasRightChild(index) && (elements[right].CompareTo(elements[left]) < 0)) 
                {
                    child = right;
                }
                if (elements[child].CompareTo(elements[index]) < 0) 
                {
                    Swap(elements, index, child);
                    index = child;
                } 
                else 
                {
                    found = true;
                }
            }
            return result;
        }

        public bool Remove(T element) 
        {
            if (size == 0) return false;
            for (int i = 1; i <= size; i ++)
            {
                if (elements[i].CompareTo(element) == 0) 
                {
                    // bubble up
                    int index = i;
                    while (HasParent(index)) 
                    {
                        Swap(elements, index, Parent(index));
                        index = Parent(index);
                    }
                    // remove-min
                    this.Remove();
                    return true;
                }
            }
            return false;
        }

        override
        public string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (size > 0)
            {
                sb.Append(elements[1]);
                for (int i = 2; i <= size; i++) {
                    sb.Append(", " + elements[i]);
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        // Hepler method to obtain the index of parent of current element
        private int Parent(int index) { return index/2; }

        // Helper method to obtain the index of leftChiold of current element
        private int LeftChild(int index) { return index*2; }

        // Helper method to obtain the index of rightChild of current element
        private int RightChild(int index) { return index*2 + 1; }

        // Helper method to check if current element has parent
        // Return true if has parent; Otherise, return false
        private bool HasParent(int index) { return index > 1; }

        // Helper method to check if current element has left child
        // Return true if has left child; Otherwise, return falase
        private bool HasLeftChild(int index) {
            return LeftChild(index) <= size;
        }

        // Helper method to check is current element has right child
        // Return true if has right child; Otherwise, return false
        private bool HasRightChild(int index) {
            return RightChild(index) <= size;
        }

        // Helper method to swap two elements' values
        private void Swap(T[] a, int index1, int index2) {
            T temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }
    }
}