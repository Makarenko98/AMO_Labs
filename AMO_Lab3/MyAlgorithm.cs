using System;

namespace AMO_Lab3
{
    class MyAlgorithm
    {
        public static double Func(double x)
        {
            //return Math.Sin(x);
            return 1 / (0.5 + Math.Pow(x, 2));
        }

        public static double Lagrange(double x, double[] X, double[] Y)
        {
            int n = X.Length;
            double r = 0, ra, rb;
            for (int i = 0; i < n; i++)
            {
                ra = rb = 1;
                for (int j = 0; j < n; j++)
                    if (i != j)
                    {
                        ra *= x - X[j];    //(x_[i],y_[i]) - інтерполяційні вузли
                        rb *= X[i] - X[j];
                    }
                r += ra * Y[i] / rb;
            }
            return r;
        }

        public static double Lagrange_(double x, double x0, double[] Y, double h)
        {
            int n = Y.Length;
            double result = 0,
                temp = 1,
                m = (x - x0) / h;
            for (int i = 0; i < n; i++)
            {
                temp = 1;
                for (int j = 0; j < n; j++)
                    if (i != j)
                        temp *= m - j;
                result += Math.Pow(-1, n - i) * temp / FactorialInteger(i) / FactorialInteger(n - i);

            }

            return result;
        }

        private static int FactorialInteger(int a)
        {
            int result = 1;
            for (int i = 1; i <= a; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
