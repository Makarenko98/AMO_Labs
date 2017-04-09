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
        public double A { get; set; } = 5;
        public double B { get; set; } = -5;
        public SeriesCollection FuncSeriesCollection { get; set; }
        public SeriesCollection InterpolatedFuncSeriesCollection { get; set; }
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
                h1 = (B - A) / (m - 1),
                min = double.MaxValue, max = double.MinValue;
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
                max = Y[i] > max ? Y[i] : max;
                min = Y[i] < min ? Y[i] : min;
            }
            FuncSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Функція",
                    Values = new ChartValues<double>(Y)
                }
            };
            InterpolatedFuncSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Інтерпольована функція",
                    Values = new ChartValues<double>(interpolatedY)
                }
            };

            FuncYAxis.MinValue = min;
            FuncYAxis.MaxValue = max;

            Labels = new string[n];

            for (int i = 0; i < n; i++)
            {
                Labels[i] = Math.Round(X[i], 3).ToString();
            }
            YFormatter = x => Math.Round(x, 3).ToString();


            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCharts();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            resize();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            resize();
        }

        private void resize()
        {
            FuncChart.Margin = new Thickness(0, 0, this.ActualWidth / 2 - 5, 0);
            InterpolatedFuncChart.Margin = new Thickness(this.ActualWidth / 2 + 5, 0, 0, 0);
        }
    }
}
