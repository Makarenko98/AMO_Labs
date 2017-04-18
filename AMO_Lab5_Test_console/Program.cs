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
            double[][] A = new double[][]
            {
                new double[]{0,1,0,1 },
                new double[]{0,1,1,0 },
                new double[]{1,0,0,1 },
                new double[]{0,1,0,0 },
            };

            MyAlgorithm.SortRows(A, null);
            for(int i=0;i<A.Length;i++)
            {
                for(int j=0;j<A[i].Length;j++)
                    Console.Write(A[i][j]+ " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
