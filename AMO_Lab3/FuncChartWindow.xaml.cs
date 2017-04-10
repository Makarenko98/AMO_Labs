using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows;

namespace AMO_Lab3
{
    /// <summary>
    /// Логика взаимодействия для FuncChartWindow.xaml
    /// </summary>
    public partial class FuncChartWindow : Window
    {
        //public double A { get; set; } = 0;
        //public double B { get; set; } = 2;
        //public int N { get; set; } = 5;
        //public int M { get; set; } = 50;
        public double[] X, Y, interpolatedY, arrX, arrY;

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

            Labels = new string[X.Length];

            for (int i = 0; i < X.Length; i++)
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
