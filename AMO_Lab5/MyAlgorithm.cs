using System;

namespace AMO_Lab5
{
    public class MyAlgorithm
    {
        public static double[] Gauss(double[][] A, double[] B)
        {
            int n = A.Length;
            double M;
            double[] result = new double[B.Length];
            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    SortRows(A, B);

                    M = A[i][k] / A[k][k];
                    for (int j = k; j < n; j++)
                        //обичслення A[i][j]
                        A[i][j] = A[i][j] - M * A[k][j];
                    //обчислення B[i]
                    B[i] = B[i] - M * B[k];
                }
            }

            result[B.Length - 1] = B[B.Length - 1] / A[B.Length - 1][B.Length - 1];
            double s = 0;
            for (int i = B.Length - 2; i >= 0; i--)
            {
                s = 0;
                for (int j = i + 1; j < B.Length; j++)
                    s += A[i][j] * result[j];
                result[i] = (B[i] - s) / A[i][i];
            }

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
                        if (A[j][i] != 0 && !(A[i][j] == 0 && j < i))
                        {
                            temp = A[i];
                            A[i] = A[j];
                            A[j] = temp;
                            temp1 = B[i];
                            B[i] = B[j];
                            B[j] = temp1;
                            break;
                        }
                    if (A[i][i] == 0)
                        throw new ArgumentException("Некоректна матриця");
                }
            }
        }
    }
}
