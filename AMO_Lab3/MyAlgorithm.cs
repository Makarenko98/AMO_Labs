using System;

namespace AMO_Lab3
{
    class MyAlgorithm
    {
        public static double Func(double x)
        {
            return 1 / (0.5 + Math.Pow(x, 2));
        }

        public static double LagrangeEvenly(double x, double[] X, double[] Y)
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
    }
}
