using System;
using System.Collections.Generic;
using PriorityQueue;

namespace PriorityQueue {
    /*
     * A collection of ordered elements that provides fast
     * access to the minimum element.
     */
    public class HeapPriorityQueue<T> : PriorityQueue<T>
    {
        private static int DEFAULT_CAPACITY = 10;

        private T[] elements; // array of elements
        private int size; // number of elements in the queue

        // Default Constructor:
        // Construct an empty priority queue with default capacity
        public HeapPriorityQueue() {
            this.elements = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        // Return the number of elements in the queue
        public int Count 
        {
            get { return size; } 
        }

        public bool Add(T value) {
            return true;
        }

        public void Clear() {

        }

        public bool Contains(T value) {
            return true;
        }

        public bool IsEmpty() {
            return true;
        }

        public T Peek() {
            return default(T);
        }

        public T Remove() {
            return default(T);
        }

        public bool Remove(T value) {
            return true;
        }

        override
        public string ToString() {
            return "";
        }

        // Hepler method to obtain the index of parent of current element
        private int parent(int index) { return index/2; }

        // Helper method to obtain the index of leftChiold of current element
        private int leftChild(int index) { return index*2; }

        // Helper method to obtain the index of rightChild of current element
        private int rightChild(int index) { return index*2 + 1; }

        // Helper method to check if current element has parent
        // Return true if has parent; Otherise, return false
        private bool hasParent(int index) { return index > 1; }

        // Helper method to check if current element has left child
        // Return true if has left child; Otherwise, return falase
        private bool hasLeftChild(int index) {
        return leftChild(index) <= size;
        }

        // Helper method to check is current element has right child
        // Return true if has right child; Otherwise, return false
        private bool hasRightChild(int index) {
            return rightChild(index) <= size;
        }

        // Helper method to swap two elements' values
        private void swap(T[] a, int index1, int index2) {
            T temp = a[index1];
            a[index1] = a[index2];
            a[index2] = temp;
        }
    }
}