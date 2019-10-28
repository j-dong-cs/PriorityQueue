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
        // Default Constructor
        public HeapPriorityQueue() {

        }
        public int Count { get; set; }

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
    }
}