using System;
using System.Collections.Generic;
using Tako.Collections.Generic;
using Xunit;

namespace TestLibrary
{
    public class Llrb23TreeTests
    {
        private int count_ = 100;
        private string[] testStrings_;

        public Llrb23TreeTests()
        {
            this.testStrings_ = new string[this.count_];

            for (int i = 0; i < this.count_; i++)
            {
                testStrings_[i] = "Test String " + i;
            }
        }

        [Fact]
        public void AddTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            Assert.Equal(this.count_, tree.Count);

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(this.testStrings_[i], tree[i]);
            }

            Assert.Throws<ArgumentException>(() => tree.Add(0, this.testStrings_[0]));
        }

        [Fact]
        public void RemoveTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i += 2)
            {
                tree.Remove(i);
            }

            Assert.Equal(this.count_ / 2, tree.Count);

            for (int i = 0; i < this.count_; i += 2)
            {
                Assert.Throws<KeyNotFoundException>(() => tree[i]);
            }

            for (int i = 1; i < this.count_ / 2; i += 2)
            {
                Assert.Equal(this.testStrings_[i], tree[i]);
            }
        }

        [Fact]
        public void ContainsKeyTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(true, tree.ContainsKey(i));
            }

            Assert.Equal(false, tree.ContainsKey(this.count_));
        }

        [Fact]
        public void ClearTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            tree.Clear();

            Assert.Equal(0, tree.Count);

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Throws<KeyNotFoundException>(() => tree[i]);
            }
        }

        [Fact]
        public void TryGetValueTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            string value;

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(true, tree.TryGetValue(i, out value));
                Assert.Equal(this.testStrings_[i], value);
            }

            Assert.Equal(false, tree.TryGetValue(this.count_, out value));
            Assert.Equal(null, value);
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            int i = 0;

            foreach (KeyValuePair<int, string> value in tree)
            {
                Assert.Equal(i, value.Key);
                Assert.Equal(this.testStrings_[i], value.Value);
                i++;
            }
        }

        [Fact]
        public void KeysTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            int i = 0;

            foreach (int value in tree.Keys)
            {
                Assert.Equal(i++, value);
            }
        }

        [Fact]
        public void ValuesTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            int i = 0;

            foreach (string value in tree.Values)
            {
                Assert.Equal(this.testStrings_[i], value);
                i++;
            }
        }

        [Fact]
        public void SetTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            string changed = "Changed";

            for (int i = 0; i < this.count_; i++)
            {
                tree[i] = changed;
                Assert.Equal(changed, tree[i]);
            }
        }

        private Llrb23Tree<int, string> InitializeTree()
        {
            Llrb23Tree<int, string> tree = new Llrb23Tree<int, string>();

            for (int i = 0; i < this.count_; i++)
            {
                tree.Add(i, this.testStrings_[i]);
            }

            return tree;
        }
    }
}
