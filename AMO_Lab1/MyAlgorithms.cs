using System;

namespace AMO_Lab1
{
    public class MyAlgorithms
    {
        public static double Linear(double a, double c)
        {
            return (Math.Pow(a, 2) - Math.Pow(c, 2)) / 7 + Factorial(a) / (Factorial(c) * Factorial(a - c));
        }

        public static double Branched(double x, double b, double c, double k)
        {
            if (x > 0)
                return k * Math.Pow(x, 2) + c * x + b;
            else
                return b * Math.Pow(x, 2) + c * x + k;
        }

        public static double Cyclic(double[] a)
        {
            double result = 0;
            double c = 1;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                    c *= a[j];
                result += c + Math.Pow(a[i], 2);
                c = 1;
            }
            return result;

            //double result = 1;
            //for (int j = 0; j < a.Length; j++)
            //    result *= a[j];
            //result *= a.Length;
            //for (int i = 0; i < a.Length; i++)
            //    result += Math.Pow(a[i], 2);
            //return result;
        }

        private static double Factorial(double a)
        {
            if (a < 0)
                throw new ArgumentException("Факторіал від від'ємного числа " + a.ToString());
            return Math.Exp(Math.Log(FactorialInteger((int)a)) + (a - (int)a) * Math.Log(a + 1));
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
