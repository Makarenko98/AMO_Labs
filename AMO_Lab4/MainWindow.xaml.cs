using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace AMO_Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SeriesCollection FuncSeriesCollection { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }
        private double[] iters;
        private IterationsWindow iterWindow;
        private double result;

        public MainWindow()
        {
            InitializeComponent();
            aTB.Text = "0";
            bTB.Text = "8";
            eTB.Text = "0,00001";
            itersMI.IsEnabled = false;
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ItersMenu_Click(object sender, RoutedEventArgs e)
        {
            if (iterWindow != null && iterWindow.IsActive)
            {
                iterWindow.Focus();
                return;
            }
            iterWindow = new IterationsWindow
            {
                Iterations = iters,
                TrueRes = result
            };
            iterWindow.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resTB.Text = "";
            cIterTB.Text = "";
            double a = 0, b = 8, eps = 0.0001;
            if (!Double.TryParse(aTB.Text, out a) || !Double.TryParse(bTB.Text, out b) || !Double.TryParse(eTB.Text, out eps) || a >= b)
            {
                MessageBox.Show("Некоректні дані");
                return;
            }
            result = MyAlgorithm.Newton(MyAlgorithm.Func, MyAlgorithm.dFunc, MyAlgorithm.ddFunc, a, b, eps, out iters);
            if (Double.IsNaN(result))
            {
                MessageBox.Show("Результат не збігається");
                itersMI.IsEnabled = false;
                return;
            }
            resTB.Text = Math.Round(result, eTB.Text.Length - 2).ToString();
            cIterTB.Text = iters.Length.ToString();
            itersMI.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCharts();
        }

        private void ShowCharts()
        {
            int n = 50;
            double a = -10,
                b = 15,
                h = (Math.Abs(a) + Math.Abs(b)) / n;
            double[] X = new double[n]
                , Y = new double[n];
            X[0] = a;
            Y[0] = MyAlgorithm.Func(a);
            for (int i = 1; i < n; i++)
            {
                X[i] = X[i - 1] + h;
                Y[i] = MyAlgorithm.Func(X[i]);
            }
            FuncSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Функція",
                    Values = new ChartValues<double>(Y),
                    PointGeometrySize = 5
                }
            };
            YFormatter = (x) => Math.Round(x, 4).ToString();
            Labels = new string[n];
            for (int i = 0; i < n; i++)
                Labels[i] = Math.Round(X[i], 3).ToString();
            DataContext = this;
        }
    }
}
