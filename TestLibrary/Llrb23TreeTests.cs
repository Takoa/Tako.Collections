using System;
using System.Collections.Generic;
using Tako.Collections.Generic;
using Xunit;

namespace TestLibrary
{
    public class Llrb23TreeTests
    {
        private Random random = new Random();
        private int count_ = 100;
        private SortedDictionary<int, string> dictionary = new SortedDictionary<int, string>();
        private int[] testInts_;
        private string[] testStrings_;

        public Llrb23TreeTests()
        {
            this.testInts_ = new int[this.count_];
            this.testStrings_ = new string[this.count_];

            for (int i = 0; i < this.count_; i++)
            {
                this.testInts_[i] = this.random.Next();
                this.testStrings_[i] = "Test String " + this.testInts_[i];
                this.dictionary.Add(this.testInts_[i], this.testStrings_[i]);
            }
        }

        [Fact]
        public void AddTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            Assert.Equal(this.count_, tree.Count);

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(this.testStrings_[i], tree[this.testInts_[i]]);
            }

            Assert.Throws<ArgumentException>(() => tree.Add(this.testInts_[0], this.testStrings_[0]));
        }

        [Fact]
        public void RemoveTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i += 2)
            {
                tree.Remove(this.testInts_[i]);
            }

            Assert.Equal(this.count_ / 2, tree.Count);

            for (int i = 0; i < this.count_; i += 2)
            {
                Assert.Throws<KeyNotFoundException>(() => tree[this.testInts_[i]]);
            }

            for (int i = 1; i < this.count_ / 2; i += 2)
            {
                Assert.Equal(this.testStrings_[i], tree[this.testInts_[i]]);
            }
        }

        [Fact]
        public void ContainsKeyTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(true, tree.ContainsKey(this.testInts_[i]));
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
                Assert.Throws<KeyNotFoundException>(() => tree[this.testInts_[i]]);
            }
        }

        [Fact]
        public void TryGetValueTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            string value;

            for (int i = 0; i < this.count_; i++)
            {
                Assert.Equal(true, tree.TryGetValue(this.testInts_[i], out value));
                Assert.Equal(this.testStrings_[i], value);
            }

            Assert.Equal(false, tree.TryGetValue(-1, out value));
            Assert.Equal(null, value);
        }

        [Fact]
        public void GetEnumeratorTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            IEnumerator<KeyValuePair<int, string>> dictionaryEnumerator = this.dictionary.GetEnumerator();
            IEnumerator<KeyValuePair<int, string>> llrbEnumerator = tree.GetEnumerator();

            while (dictionaryEnumerator.MoveNext())
            {
                llrbEnumerator.MoveNext();

                Assert.Equal(dictionaryEnumerator.Current, llrbEnumerator.Current);
            }
        }

        [Fact]
        public void KeysTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            IEnumerator<int> dictionaryKeysEnumerator = this.dictionary.Keys.GetEnumerator();
            IEnumerator<int> treeKeysEnumerator = tree.Keys.GetEnumerator();

            while (dictionaryKeysEnumerator.MoveNext() && treeKeysEnumerator.MoveNext())
            {
                Assert.Equal(dictionaryKeysEnumerator.Current, treeKeysEnumerator.Current);
            }
        }

        [Fact]
        public void ValuesTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            IEnumerator<string> dictionaryKeysEnumerator = this.dictionary.Values.GetEnumerator();
            IEnumerator<string> treeKeysEnumerator = tree.Values.GetEnumerator();

            while (dictionaryKeysEnumerator.MoveNext() && treeKeysEnumerator.MoveNext())
            {
                Assert.Equal(dictionaryKeysEnumerator.Current, treeKeysEnumerator.Current);
            }
        }

        [Fact]
        public void SetTest()
        {
            Llrb23Tree<int, string> tree = this.InitializeTree();
            string changed = "Changed";

            for (int i = 0; i < this.count_; i++)
            {
                tree[this.testInts_[i]] = changed;
                Assert.Equal(changed, tree[this.testInts_[i]]);
            }
        }

        private Llrb23Tree<int, string> InitializeTree()
        {
            Llrb23Tree<int, string> tree = new Llrb23Tree<int, string>();

            for (int i = 0; i < this.count_; i++)
            {
                tree.Add(this.testInts_[i], this.testStrings_[i]);
            }

            return tree;
        }
    }
}
