using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Weights
{
    using System;

    namespace Incapsulation.Weights
    {
        public class Indexer
        {
            #region Fields

            private double[] arr;
            private int start;
            private int length;

            #endregion

            #region Fields

            public int Length
            {
                get { return length; }
            }

            #endregion

            public Indexer(double[] arr, int start = 0, int length = 0)
            {
                if (RangeIsValid(arr, start, length))
                {
                    this.arr = arr;
                    this.start = start;
                    this.length = length;
                }

                else
                {
                    throw new ArgumentException("Range is invalid.");
                }
            }

            public double this[int index]
            {
                get
                {
                    int convertedIndex = GetConvertedIndex(index);

                    if (ConvertedIndexIsValid(convertedIndex))
                    {
                        return arr[convertedIndex];
                    }

                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }

                set
                {
                    int convertedIndex = GetConvertedIndex(index);

                    if (ConvertedIndexIsValid(convertedIndex))
                    {
                        arr[convertedIndex] = value;
                    }

                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }

            private bool RangeIsValid(double[] arr, int start, int length)
            {
                if (start < 0 || length < 0) return false;
                if ((start + length) > arr.Length) return false;
                return true;
            }

            private bool ConvertedIndexIsValid(int convertedIndex)
            {
                if (convertedIndex > length || convertedIndex < start)
                {
                    return false;
                }

                return true;
            }

            private int GetConvertedIndex(int index)
            {
                return start + index;
            }
        }
    }
}
