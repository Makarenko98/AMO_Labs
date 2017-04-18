using System;
using System.Collections.Generic;

namespace AMO_Lab5
{
    public class MyAlgorithm
    {
        public static double[] Gauss(double[][] A, double[] B)
        {
            SortRows(A, B);
            double[] result = new double[B.Length];
            return result;
        }

        public static void SortRows(double[][] A, double[] B)
        {
            double[] temp;
            double temp1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i][i] == 0)
                {
                    for (int j = 0; j < A.Length; j++)
                        if (A[j][i] != 0)
                        {
                            temp = A[i];
                            A[i] = A[j];
                            A[j] = temp;
                            temp1 = B[i];
                            B[i] = B[j];
                            B[j] = temp1;
                        }
                    if (A[i][i] == 0)
                        throw new ArgumentException("Некоректна матриця");
                }
            }
        }


        //public static void SortRows(double[][] A, double[] B)
        //{
        //    double[] temp;
        //    List<int>[] index = new List<int>[A.Length];
        //    for (int i = 0; i < index.Length; i++)
        //        index[i] = new List<int>();
        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        for (int j = 0; j < A.Length; j++)
        //            if (A[i][j] != 0)
        //                index[j].Add(i);
        //    }
        //    for (int i = 0; i < index.Length; i++)
        //    {
        //        if (index[i].Count == 0)
        //            throw new ArgumentException("Некоректна матриця");
        //        if (A[i][i] != 0)
        //            continue;
        //        for (int j = 0; j < index[i].Count; j++)
        //        {
        //            if (index[i][j] != i && (A[i][index[i][j]] != 0 || j == index[i].Count - 1))
        //            {
        //                //TODO: index error
        //                temp = A[index[i][j]];
        //                A[index[i][j]] = A[i];
        //                A[i] = temp;
        //                for (int i1 = 0; i1 < index.Length; i1++)
        //                    for (int j1 = 0; j1 < index[i1].Count; j1++)
        //                        if (index[i1][j1] == index[i][j] && i1 != i && j1 != j)
        //                            index[i1][j1] = i;
        //                index[i][j] = i;
        //            }
        //        }
        //    }
        //}
    }
}
