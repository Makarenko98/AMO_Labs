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

        public MainWindow()
        {
            InitializeComponent();
            aTB.Text = "0";
            bTB.Text = "8";
            eTB.Text = "0,00001";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a = 0, b = 6, eps = 0.0001;
            if (!Double.TryParse(aTB.Text, out a) || !Double.TryParse(bTB.Text, out b) || !Double.TryParse(eTB.Text, out eps) || a >= b)
            {
                MessageBox.Show("Некоректні дані");
                return;
            }
            resTB.Text =  MyAlgorithm.Newton(MyAlgorithm.Func, MyAlgorithm.dFunc, MyAlgorithm.ddFunc, a, b, eps).ToString().Substring(0, eTB.Text.Length);
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
                    Values = new ChartValues<double>(Y)
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
