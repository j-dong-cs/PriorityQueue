using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue
{
    /*
        Interface PriorityQueue represents an abstract data type (ADT) for a map
        storing giving fast access to the minimum element.

        Classes implementing PriorityQueue are generally expected to provide the 
        operations below in O(1) or O(logN) average runtime, except for the Clear,
        Contains, and ToString operations, which are often O(N).
     */ 

    public interface PriorityQueue<T>
    {
        // need to implement IEnumerable<T>
        bool Add(T value);

        void Clear();

        bool Contains(T value);

        bool IsEmpty();

        T Peek();

        T Remove();

        bool Remove(T value);

        string ToString();
    }
}
