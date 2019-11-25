using System;
using System.Text;
using Xunit;
using PriorityQueue;

namespace PriorityQueueTests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void TestEmptyPQ()
        {
            var emptyHeap = new MinHeapPriorityQueue<int>();
            int[] values = new int[] { 0 , 1, 2, -10, 100 };
            foreach (int n in values)
            {
                bool result = emptyHeap.Contains(n);
                Console.WriteLine($"Check if pq = {emptyHeap.ToString()} Contains {n}?: {result}");
                Assert.False(result);
            }
        }

        [Fact]
        public void TestIntMinPQ()
        {
            var heap = new MinHeapPriorityQueue<int>();
            int[] values = new int[] { 9, 33, 8, -3, 49, 72, 24, 15, 0, 1, 10, 40 };
            foreach (int n in values) 
            {
                heap.Add(n);
                Console.WriteLine($"After adding {n}: pq = {heap.ToString()}, size = {heap.Count}");
            }
            Assert.Equal("[-3, 0, 9, 8, 1, 40, 24, 33, 15, 49, 10, 72]", heap.ToString());
            Assert.Equal(12, heap.Count);

            foreach (int n in values)
            {
                bool result = heap.Contains(n);
                Console.WriteLine($"Check if pq = {heap.ToString()} Contains {n} ?: {result}");
                Assert.True(result);
            }

            for (int i = 0; i < 5; i++)
            {
                int removed = heap.Remove();
                bool result = heap.Contains(removed);
                Console.WriteLine($"After removing min element {removed}: pq = {heap.ToString()}, Contains {removed}?: {result}");
                Assert.False(result);
            }
            Assert.Equal("[10, 15, 24, 33, 49, 40, 72]", heap.ToString());

            int[] needToRemove = new int[] { 15, 0, 15, -3, 40};
            foreach (int n in needToRemove)
            {
                bool result = heap.Remove(n);
                Console.WriteLine($"After removing element {n}: pq = {heap.ToString()}, successfully ?: {result}");
            }

            heap.Clear();
            Console.WriteLine($"After Clear pq = {heap.ToString()}");
            Assert.Equal("[]", heap.ToString());
            Assert.True(heap.IsEmpty());
        }
    }
}
