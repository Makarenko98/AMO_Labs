using System;

namespace AMO_Lab2
{
    public class MyAlgorithm<T> where T : IComparable
    {
        public static void QuickSort(T[] a, int l, int r)
        {
            if (a.Length == 0 || l > r)
                return;
            T temp;
            T x = a[l + (r - l) / 2];

            int i = l;
            int j = r;

            while (i <= j)
            {
                while (a[i].CompareTo(x) < 0) i++;
                while (a[j].CompareTo(x) > 0) j--;
                if (i <= j)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(a, i, r);

            if (l < j)
                QuickSort(a, l, j);
        }
    }
}
