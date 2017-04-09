using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AMO_Lab3
{
    /// <summary>
    /// Логика взаимодействия для FuncChartWindow.xaml
    /// </summary>
    public partial class FuncChartWindow : Window
    {
        public double A { get; set; } = 0;
        public double B { get; set; } = 2;
        public SeriesCollection FuncSeriesCollection { get; set; }
        LineSeries FuncLS;
        LineSeries InterpolatedFuncLS;
        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }

        public FuncChartWindow()
        {
            InitializeComponent();
        }

        private void ShowCharts()
        {
            if (B < A)
                MessageBox.Show("Icnorrect data");
            int n = 50;
            int m = 10;
            double h = (B - A) / (n - 1),
                h1 = (B - A) / (m - 1);
            double[] X = new double[n],
                Y = new double[n],
                interpolatedY = new double[n],
                arrX = new double[m],
                arrY = new double[m];
            for (int i = 0; i < m; i++)
            {
                arrX[i] = A + i * h1;
                arrY[i] = MyAlgorithm.Func(arrX[i]);
            }
            for (int i = 0; i < n; i++)
            {
                X[i] = A + i * h;
                Y[i] = MyAlgorithm.Func(X[i]);
                interpolatedY[i] = MyAlgorithm.Lagrange(X[i], arrX, arrY);
            }

            FuncLS = new LineSeries
            {
                Title = "Функція",
                Values = new ChartValues<double>(Y),
                StrokeThickness = 5
            };
            InterpolatedFuncLS = new LineSeries
            {
                Title = "Інтерпольована функція",
                Values = new ChartValues<double>(interpolatedY)
            };

            FuncSeriesCollection = new SeriesCollection
            {
                FuncLS,
                InterpolatedFuncLS
            };

            Labels = new string[n];

            for (int i = 0; i < n; i++)
            {
                Labels[i] = Math.Round(X[i], 3).ToString();
            }
            YFormatter = x => Math.Round(x, 3).ToString();

            ChartFuncCB.IsChecked = true;
            ChartInterpolatedFuncCB.IsChecked = true;
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCharts();
        }

        private void ChartFuncCB_Checked(object sender, RoutedEventArgs e)
        {
            FuncLS.Visibility = Visibility.Visible;
        }

        private void ChartFuncCB_Unchecked(object sender, RoutedEventArgs e)
        {
            FuncLS.Visibility = Visibility.Hidden;
        }

        private void ChartInterpolatedFuncCB_Checked(object sender, RoutedEventArgs e)
        {
            FuncLS.StrokeThickness = 5;
            InterpolatedFuncLS.Visibility = Visibility.Visible;
        }

        private void ChartInterpolatedFuncCB_Unchecked(object sender, RoutedEventArgs e)
        {
            FuncLS.StrokeThickness = 2;
            InterpolatedFuncLS.Visibility = Visibility.Hidden;
        }
    }
}
