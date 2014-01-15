using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tako.Collections.Generic;
using Xunit;

namespace TestLibrary
{
    public class Llrb23TreeListTests
    {
        private Random random = new Random();
        private int count_ = 100;
        private string[] testStrings_;

        public Llrb23TreeListTests()
        {
            this.testStrings_ = new string[this.count_];

            for (int i = 0; i < this.count_; i++)
            {
                this.testStrings_[i] = "Test String " + this.random.Next();
            }
        }

        [Fact]
        public void AddTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();

            Assert.Equal(this.count_, tree.Count);

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(this.testStrings_[i], tree[i]);
            }
        }

        [Fact] void InsertTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();
            string inserted = "Inserted String";

            for (int i = 0; i < this.count_; i++)
            {
                tree.Insert(i * 2, inserted);
            }

            for (int i = 0; i < this.count_; i++)
            {
                int j = i * 2;

                Assert.Equal(inserted, tree[j]);
                Assert.Equal(this.testStrings_[i], tree[j + 1]);
            }
        }

        [Fact]
        public void ContainsTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(true, tree.Contains(this.testStrings_[i]));
            }

            Assert.Equal(false, tree.Contains("Not Contained String"));
        }

        [Fact]
        void IndexOfTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(i, tree.IndexOf(this.testStrings_[i]));
            }
        }

        [Fact]
        public void RemoveAtTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_ / 2; i++)
            {
                tree.RemoveAt(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => tree.RemoveAt(tree.Count));
            Assert.Equal(this.count_ / 2, tree.Count);

            for (int i = 0; i < this.count_ / 2; i++)
            {
                Assert.Equal(this.testStrings_[i * 2 + 1], tree[i]);
            }
        }

        [Fact]
        public void RemoveTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i += 2)
            {
                tree.Remove(this.testStrings_[i]);
            }

            Assert.Throws<ArgumentException>(() => tree.Remove(this.testStrings_[0]));
            Assert.Equal(this.count_ / 2, tree.Count);

            for (int i = 0; i < this.count_ / 2; i++)
            {
                Assert.Equal(this.testStrings_[i * 2 + 1], tree[i]);
            }
        }

        [Fact]
        public void CopyToTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();
            string[] values = new string[this.count_];

            tree.CopyTo(values, 0);

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(this.testStrings_[i], values[i]);
            }
        }

        [Fact]
        public void ClearTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();

            tree.Clear();

            Assert.Equal(0, tree.Count);

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => tree[i]);
            }
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();
            int i = 0;

            foreach (string value in tree)
            {
                Assert.Equal(this.testStrings_[i], value);
                i++;
            }
        }

        [Fact]
        public void SetTest()
        {
            Llrb23TreeList<string> tree = this.InitializeTree();
            string changed = "Changed";

            for (int i = 0; i < this.count_; i++)
            {
                tree[i] = changed;
                Assert.Equal(changed, tree[i]);
            }
        }

        private Llrb23TreeList<string> InitializeTree()
        {
            Llrb23TreeList<string> tree = new Llrb23TreeList<string>();

            for (int i = 0; i < this.count_; i++)
            {
                tree.Add(this.testStrings_[i]);
            }

            return tree;
        }
    }
}
