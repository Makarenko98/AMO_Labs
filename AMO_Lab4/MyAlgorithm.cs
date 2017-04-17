using System;
using System.Collections.Generic;

namespace AMO_Lab4
{
    public class MyAlgorithm
    {
        public static double Func(double x)
        {
            return 10 * Math.Atan(5 - x) - 1;
        }
        public static double dFunc(double x)
        {
            return -10 / (Math.Pow(5 - x, 2) + 1);
        }
        public static double ddFunc(double x)
        {
            return 20 * (x - 5) / Math.Pow(Math.Pow(x, 2) - 10 * x + 26, 2);
        }

        public static double Newton(Func<double, double> f, Func<double, double> df, Func<double, double> ddf, double a, double b, double eps, out double[] iters)
        {
            iters = null;
            List<double> itersList = new List<double>(20);
            if (Func(a) * Func(b) >= 0)
                return Double.NaN;
            double xn = Func(a) * ddf(a) > 0 ? b : a;
            double x1 = (a + b) / 2;
            double x0 = xn;
            itersList.Add(x1);
            while (Math.Abs(x0 - x1) > eps)
            {
                x0 = x1;
                x1 = x1 - f(x1) / df(x1);
                itersList.Add(x1);
            }
            iters = itersList.ToArray();
            return x1;
        }
    }
}
