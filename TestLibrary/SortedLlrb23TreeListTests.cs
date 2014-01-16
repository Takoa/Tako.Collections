using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tako.Collections.Generic;
using Xunit;

namespace TestLibrary
{
    public class SortedLlrb23TreeListTests
    {
        private int count_ = 100;
        private Random random = new Random();
        private int[] testInts_;
        private SortedSet<int> sortedSet = new SortedSet<int>();

        public SortedLlrb23TreeListTests()
        {
            this.testInts_ = new int[this.count_];

            for (int i = 0; i < this.count_; i++)
            {
                this.testInts_[i] = this.random.Next();
                this.sortedSet.Add(this.testInts_[i]);
            }
        }

        [Fact]
        public void AddTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();
            int i = 0;

            foreach (int item in this.sortedSet)
            {
                Assert.Equal(item, tree[i++]);
            }

            Assert.Throws<ArgumentException>(() => tree.Add(testInts_[0]));
        }

        [Fact]
        public void ContainsTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();

            foreach (int item in this.sortedSet)
            {
                Assert.Equal(true, tree.Contains(item));
            }

            Assert.Equal(false, tree.Contains(-1));
        }

        [Fact]
        public void IndexOfTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();
            int i = 0;

            foreach (int item in this.sortedSet)
            {
                Assert.Equal(i++, tree.IndexOf(item));
            }

            Assert.InRange(tree.IndexOf(-1), int.MinValue, -1);
        }

        [Fact]
        public void ClearTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();

            tree.Clear();

            Assert.Equal(0, tree.Count);

            foreach (int item in this.sortedSet)
            {
                Assert.Equal(false, tree.Contains(item));
            }
        }

        [Fact]
        public void RemoveAtTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();
            int i = 0;

            for (int j = 0; j < this.count_ / 2; j++)
            {
                tree.RemoveAt(j);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => tree.RemoveAt(tree.Count));
            Assert.Equal(this.count_ / 2, tree.Count);

            foreach (int item in this.sortedSet)
            {
                if (i % 2 != 0)
                {
                    Assert.Equal(item, tree[(i - 1) / 2]);
                }

                i++;
            }
        }

        [Fact]
        public void RemoveTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();
            int i = 0;

            foreach (int item in this.sortedSet)
            {
                if (i % 2 == 0)
                {
                    tree.Remove(item);
                }

                i++;
            }

            Assert.Throws<ArgumentException>(() => tree.Remove(-1));
            Assert.Equal(this.count_ / 2, tree.Count);

            i = 0;
            foreach (int item in this.sortedSet)
            {
                if (i % 2 != 0)
                {
                    Assert.Equal(item, tree[(i - 1) / 2]);
                }

                i++;
            }
        }

        [Fact]
        public void CopyToTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();
            int[] values = new int[this.count_];
            int i = 0;

            tree.CopyTo(values, 0);

            foreach (int item in this.sortedSet)
            {
                Assert.Equal(item, values[i++]);
            }
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            SortedLlrb23TreeList<int> tree = this.InitializeTree();
            IEnumerator<int> sortedSetEnumerator = this.sortedSet.GetEnumerator();
            IEnumerator<int> treeEnumerator = tree.GetEnumerator();

            while (sortedSetEnumerator.MoveNext())
            {
                treeEnumerator.MoveNext();

                Assert.Equal(sortedSetEnumerator.Current, treeEnumerator.Current);
            }
        }

        [Fact]
        public void InsertTest()
        {
            IList<int> tree = this.InitializeTree();

            Assert.Throws<NotSupportedException>(() => tree.Insert(0, 0));
        }

        [Fact]
        public void SetTest()
        {
            IList<int> tree = this.InitializeTree();

            Assert.Throws<NotSupportedException>(() => tree[0] = 0);
        }

        private SortedLlrb23TreeList<int> InitializeTree()
        {
            SortedLlrb23TreeList<int> tree = new SortedLlrb23TreeList<int>();

            for (int i = 0; i < this.count_; i++)
            {
                tree.Add(this.testInts_[i]);
            }

            return tree;
        }
    }
}
