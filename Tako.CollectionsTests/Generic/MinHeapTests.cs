using System;
using System.Collections.Generic;
using Xunit;

namespace Tako.Collections.Generic.Tests
{
    public class MinHeapTests
    {
        private int count = 100;
        private readonly int[] testInts;
        private Random random = new Random();

        public MinHeapTests()
        {
            this.testInts = new int[this.count];

            for (int i = 0; i < this.count; i++)
            {
                this.testInts[i] = this.random.Next();
            }
        }

        [Fact()]
        public void MinHeapTest()
        {
            MinHeap<int> heap = new MinHeap<int>();

            Assert.True(heap.Count == 0);
            Assert.Throws<IndexOutOfRangeException>(() => heap[0]);
        }

        [Fact()]
        public void MinHeapTest1()
        {
            MinHeap<int> heap = new MinHeap<int>(new TestComparer());

            for (int i = 0; i < heap.Count / 2; i++)
            {
                int left = heap.GetLeft(i);
                int right = heap.GetRight(i);

                if (left != 0)
                {
                    Assert.True(left < heap[i]);
                }

                if (right != 0)
                {
                    Assert.True(right < heap[i]);
                }
            }
        }

        [Fact()]
        public void MinHeapTest2()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            for (int i = 0; i < heap.Count / 2; i++)
            {
                int left = heap.GetLeft(i);
                int right = heap.GetRight(i);

                if (left != 0)
                {
                    Assert.True(heap[i] < left);
                }

                if (right != 0)
                {
                    Assert.True(heap[i] < right);
                }
            }
        }

        [Fact()]
        public void MinHeapTest3()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, 50, true, null);

            for (int i = 0; i < heap.Count / 2; i++)
            {
                int left = heap.GetLeft(i);
                int right = heap.GetRight(i);

                if (left != 0)
                {
                    Assert.True(heap[i] < left);
                }

                if (right != 0)
                {
                    Assert.True(heap[i] < right);
                }
            }
        }

        [Fact()]
        public void GetTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            Assert.Throws<IndexOutOfRangeException>(() => heap[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => heap[this.count]);
        }

        [Fact()]
        public void LeftParent()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            Assert.Throws<IndexOutOfRangeException>(() => heap.GetParent(-1));
            Assert.Throws<IndexOutOfRangeException>(() => heap.GetParent(this.count));
        }

        [Fact()]
        public void LeftTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            Assert.Throws<IndexOutOfRangeException>(() => heap.GetLeft(-1));
            Assert.Throws<IndexOutOfRangeException>(() => heap.GetLeft(this.count));
        }

        [Fact()]
        public void RightTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            Assert.Throws<IndexOutOfRangeException>(() => heap.GetRight(-1));
            Assert.Throws<IndexOutOfRangeException>(() => heap.GetRight(this.count));
        }

        [Fact()]
        public void InsertTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            for (int i = 0; i < this.count; i++)
            {
                heap.Insert(this.random.Next());
            }

            for (int i = 0; i < heap.Count / 2; i++)
            {
                int left = heap.GetLeft(i);
                int right = heap.GetRight(i);

                if (left != 0)
                {
                    Assert.True(heap[i] < left);
                }

                if (right != 0)
                {
                    Assert.True(heap[i] < right);
                }
            }
        }

        [Fact()]
        public void ExtractMinTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);
            int[] sortedInts = new int[this.count];

            this.testInts.CopyTo(sortedInts, 0);
            Array.Sort(sortedInts);

            for (int i = 0; i < this.count; i++)
            {
                Assert.True(sortedInts[i] == heap.ExtractMin());
            }

            Assert.True(heap.ExtractMin() == 0);
        }

        [Fact()]
        public void ClearTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);

            ((ICollection<int>)heap).Clear();

            Assert.Throws<IndexOutOfRangeException>(() => heap[0]);
            Assert.True(heap.ExtractMin() == 0);
        }

        [Fact()]
        public void ContainsTest()
        {
            ICollection<int> heap = new MinHeap<int>(this.testInts, true);

            for (int i = this.count - 1; 0 <= i; i--)
            {
                Assert.True(heap.Contains(this.testInts[i]));
            }

            Assert.False(heap.Contains(-1));
        }

        [Fact()]
        public void CopyToTest()
        {
            ICollection<int> heap = new MinHeap<int>(this.testInts, true);
            int[] copy = new int[this.count];

            heap.CopyTo(copy, 0);

            for (int i = 0; i < this.count; i++)
            {
                Assert.True(copy[i] == ((MinHeap<int>)heap)[i]);
            }

            Assert.Throws<ArgumentNullException>(() => heap.CopyTo(null, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => heap.CopyTo(copy, -1));
            Assert.Throws<ArgumentException>(() => heap.CopyTo(copy, 1));
        }

        [Fact()]
        public void GetEnumeratorTest()
        {
            MinHeap<int> heap = new MinHeap<int>(this.testInts, true);
            int i = 0;

            foreach (int item in (ICollection<int>)heap)
            {
                Assert.True(item == heap[i++]);
            }
        }

        private class TestComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x < y)
                {
                    return 1;
                }
                else if (x == y)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}

