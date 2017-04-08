using System;
using System.Collections;
using System.Collections.Generic;

namespace AMO_Lab2
{
    public class SortInfo<T> where T : IComparable
    {
        public SortInfo()
        {
            Arrays = new List<MyArray<T>>();
        }

        public SortInfo(IEnumerable<MyArray<T>> arrays)
        {
            Arrays = new List<MyArray<T>>(arrays);
        }

        private List<MyArray<T>> arrays;


        public List<MyArray<T>> Arrays
        {
            get
            {
                return arrays;
            }

            set
            {
                arrays = value;
                ChangeList?.Invoke();
            }
        }

        public MyArray<T> this[int index]
        {
            get
            {
                return Arrays[index];
            }
            set
            {
                Arrays[index] = value;
                ChangeList?.Invoke();
            }
        }

        public void SortAll()
        {
            foreach (MyArray<T> item in Arrays)
                item.Sort();
        }


        public event Action ChangeList;
    }
}


/*
public class SortInfo
{
    public SortInfo()
    {
        Arrays = new List<List<int>>();
        SortedArrays = new Dictionary<int, int[]>();
    }

    public List<List<int>> Arrays { get; set; }
    public Dictionary<int, int[]> SortedArrays { get; set; }

    public void Sort(int index)
    {

    }
    public void SortAll()
    {

    }
    private void ClearDictionary()
    {
        bool flag = false;
        foreach (KeyValuePair<int, int[]> item in SortedArrays)
        {
            flag = false;
            for (int i = 0; i < Arrays.Count; i++)
                flag = item.Key == Arrays[i].GetHashCode() || flag;
        }
    }
}
*/
