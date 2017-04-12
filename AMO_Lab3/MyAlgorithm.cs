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
            double result = 0, tempa, tempb;
            for (int i = 0; i < n; i++)
            {
                tempa = tempb = 1;
                for (int j = 0; j < n; j++)
                    if (i != j)
                    {
                        tempa *= x - X[j];    //(x_[i],y_[i]) - інтерполяційні вузли
                        tempb *= X[i] - X[j];
                    }
                result += tempa * Y[i] / tempb;
            }
            return result;
        }
    }
}
