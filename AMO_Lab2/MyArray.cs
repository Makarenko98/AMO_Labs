using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace AMO_Lab2
{
    public class MyArray<T> : IEnumerable<T> where T : IComparable
    {
        private List<T> arr;
        public T[] SortedArray { get; set; }
        public TimeSpan Time { get; private set; }
        public int Length
        {
            get
            {
                return arr.Count;
            }
        }

        public MyArray()
        {
            arr = new List<T>();
        }

        public MyArray(T[] array)
        {
            if (array != null)
                arr = new List<T>(array);
        }

        public T this[int index]
        {
            get { return arr[index]; }
            set
            {
                if (index >= Length || index < 0)
                    throw new IndexOutOfRangeException();
                arr[index] = value;
            }
        }

        public T[] Sort()
        {
            SortedArray = new T[Length];
            arr.CopyTo(SortedArray, 0);
            GC.Collect();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            MyAlgorithm<T>.QuickSort(SortedArray, 0, SortedArray.Length - 1);
            timer.Stop();
            Time = timer.Elapsed;
            return SortedArray;
        }
        public void Add(T item)
        {
            if (arr == null)
                arr = new List<T>();
            arr.Add(item);
            SortedArray = null;
        }

        public T[] Array
        {
            get
            {
                T[] newArr = new T[Length];
                arr.CopyTo(newArr, 0);
                return newArr;
            }
            set
            {
                if (value == null)
                    return;
                arr = new List<T>(value);
                SortedArray = null;
            }
        }
        public void RemoveAt(int index)
        {
            arr.RemoveAt(index);
            SortedArray = null;
        }

        public void Clear()
        {
            arr.Clear();
            SortedArray = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)arr).GetEnumerator();
        }
    }
}