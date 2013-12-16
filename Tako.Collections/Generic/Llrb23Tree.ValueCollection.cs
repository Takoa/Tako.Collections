using System;
using System.Collections.Generic;

namespace Tako.Collections.Generic
{
    public partial class Llrb23Tree<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public class ValueCollection : ICollection<TValue>
        {
            private Llrb23Tree<TKey, TValue> llrb_;
            private IEqualityComparer<TValue> equalityComparer_;

            public int Count
            {
                get
                {
                    return this.llrb_.Count;
                }
            }

            bool ICollection<TValue>.IsReadOnly
            {
                get
                {
                    return true;
                }
            }

            public ValueCollection(Llrb23Tree<TKey, TValue> llrb)
            {
                this.llrb_ = llrb;
                this.equalityComparer_ = EqualityComparer<TValue>.Default;
            }

            public void CopyTo(TValue[] array, int index)
            {
                if (array == null)
                {
                    throw new ArgumentNullException("array");
                }

                if (index < 0)
                {
                    throw new ArgumentException();
                }

                if (array.Length - index < this.Count)
                {
                    throw new ArgumentException();
                }

                if (this.llrb_.root_ != null)
                {
                    int i = index;

                    foreach (Node node in this.llrb_.root_)
                    {
                        array[i++] = node.Value;
                    }
                }
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                if (this.llrb_.root_ != null)
                {
                    foreach (Node node in this.llrb_.root_)
                    {
                        yield return node.Value;
                    }
                }
            }

            void ICollection<TValue>.Add(TValue value)
            {
                throw new NotSupportedException();
            }

            void ICollection<TValue>.Clear()
            {
                throw new NotSupportedException();
            }

            bool ICollection<TValue>.Contains(TValue value)
            {
                if (this.llrb_.root_ != null)
                {
                    if (value == null)
                    {
                        foreach (Node node in this.llrb_.root_)
                        {
                            if (node.Value == null)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        foreach (Node node in this.llrb_.root_)
                        {
                            if (this.equalityComparer_.Equals(value, node.Value))
                            {
                                return true;
                            }
                        } 
                    }
                }

                return false;
            }

            bool ICollection<TValue>.Remove(TValue value)
            {
                throw new NotSupportedException();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
