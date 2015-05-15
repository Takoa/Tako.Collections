using System;
using System.Collections.Generic;

namespace Tako.Collections.Generic
{
    public class MinHeap<T> : Heap<T>
    {
        private const int defaultCount = 10;

        public MinHeap()
            : base(null, MinHeap<T>.defaultCount, false, null)
        {
        }

        public MinHeap(IComparer<T> comparer)
            : base(null, MinHeap<T>.defaultCount, false, comparer)
        {
        }

        public MinHeap(T[] array, bool copies)
            : base(array, array.Length, copies, null)
        {
        }

        public MinHeap(T[] array, int size, bool copies, IComparer<T> comparer)
            : base(array, size, copies, comparer)
        {
        }

        protected override bool SatisfiesProperty(T item1, T item2)
        {
            return this.Comparer.Compare(item1, item2) < 0;
        }
    }
}
