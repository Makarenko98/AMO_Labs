using System;
using AMO_Lab5;

namespace AMO_Lab5_Test_console
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSort();
            Console.ReadKey();
        }
        static void TestSort()
        {
            double[][] A = new double[][]
            {
                new double[]{4,-4,4,2 },
                new double[]{2,2,2,-3 },
                new double[]{-3,2,-3,1 },
                new double[]{-1,-2,2,4 },
            };

            double[] B = new double[] { -5, -2, 0, 4 };
            try
            {
                double[] result = MyAlgorithm.Gauss(A, B);
                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < A[i].Length; j++)
                        Console.Write(A[i][j] + " ");
                    Console.Write("| " + B[i] + " | " + result[i]);
                    Console.WriteLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
