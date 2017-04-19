using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new double[]{1,2,3,4 },
                new double[]{4,1,2,3 },
                new double[]{5,1,2,5 },
                new double[]{1,3,3,2 },
            };

            double[] B = new double[] { 1, 2, 3, 4 };

            double[] result = MyAlgorithm.Gauss(A, B);
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                    Console.Write(A[i][j] + " ");
                Console.Write("| " + B[i] + " | " + result[i]);
                Console.WriteLine();
            }
        }
    }
}
