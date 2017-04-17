using System;
using System.Windows;

namespace AMO_Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FuncChartWindow funcChartsWindow;
        AccuracyChartWindow accChartWindow;
        //public double A = 0;
        //public double B = 2;
        //public int N = 5;
        //public int M = 50;

        double[] X, Y, interpolatedY, arrX, arrY, interpolatedArrY;

        public MainWindow()
        {
            InitializeComponent();
            aTB.Text = "0";
            bTB.Text = "2";
            nTB.Text = "10";
            mTB.Text = "10";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FuncCahrtsMenu_Click(object sender, RoutedEventArgs e)
        {
            if (funcChartsWindow != null && funcChartsWindow.IsLoaded)
            {
                funcChartsWindow.Activate();
                return;
            }
            funcChartsWindow = new FuncChartWindow
            {
                X = this.X,
                Y = this.Y,
                arrX = this.arrX,
                arrY = this.arrY,
                interpolatedY = this.interpolatedY
            };
            funcChartsWindow.Show();
        }

        private void AccuracyCharMenu_Click(object sender, RoutedEventArgs e)
        {
            if (accChartWindow != null && accChartWindow.IsLoaded)
            {
                accChartWindow.Activate();
                return;
            }
            accChartWindow = new AccuracyChartWindow
            {
                X = this.X,
                Y = this.Y,
                interpolatedY = this.interpolatedY
            };
            accChartWindow.Show();
        }

        private void GenArrs(double A, double B, int N, int M)
        {
            if (B < A)
                MessageBox.Show("Icnorrect data");
            double h = (B - A) / (M - 1),
                h1 = (B - A) / (N - 1);
            X = new double[M];
            Y = new double[M];
            interpolatedY = new double[M];
            interpolatedArrY = new double[N];
            arrX = new double[N];
            arrY = new double[N];
            for (int i = 0; i < N; i++)
            {
                arrX[i] = A + i * h1;
                arrY[i] = MyAlgorithm.Func(arrX[i]);
            }
            for (int i = 0; i < N; i++)
                interpolatedArrY[i] = MyAlgorithm.Lagrange(arrX[i], arrX, arrY);
            for (int i = 0; i < M; i++)
            {
                X[i] = A + i * h;
                Y[i] = MyAlgorithm.Func(X[i]);
                interpolatedY[i] = MyAlgorithm.Lagrange(X[i], arrX, arrY);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            double A = 0;
            double B = 2;
            int N = 10;
            int M = N ;

            if (!Double.TryParse(aTB.Text, out A) || !Double.TryParse(bTB.Text, out B) || !Int32.TryParse(nTB.Text, out N) || !Int32.TryParse(mTB.Text, out M) || A > B || N < 1 || M < 1)
            {
                MessageBox.Show("Некоректні дані");
                return;
            }
            GenArrs(A, B, N, M);
            if (funcChartsWindow != null && funcChartsWindow.IsLoaded)
                funcChartsWindow.UpdateValues(X, Y, interpolatedY, arrX, arrY);
            if (accChartWindow != null && accChartWindow.IsLoaded)
                accChartWindow.UpdateValues(X, Y, interpolatedY);
            ChartsMI.IsEnabled = true;
        }
    }
}
