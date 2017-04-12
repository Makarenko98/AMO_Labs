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
    /// Логика взаимодействия для AccuracyChartWindow.xaml
    /// </summary>
    public partial class AccuracyChartWindow : Window
    {
        public double[] X, Y, interpolatedY;
        public SeriesCollection AccSeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public AccuracyChartWindow()
        {
            InitializeComponent();
        }

        public void ShowCharts()
        {
            double[] acc = new double[X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                acc[i] = Math.Abs(Y[i] - interpolatedY[i]);
            }
            AccSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Похибка",
                    Values = new ChartValues<double>(acc)
                }
            };

            Labels = new string[X.Length];

            for (int i = 0; i < X.Length; i++)
            {
                Labels[i] = Math.Round(X[i], 3).ToString();
            }

            YFormatter = x => Math.Round(x, 5).ToString();

            DataContext = this;
        }

        public void UpdateValues(double[] X, double[] Y, double[] interpolatedY)
        {
            this.X = X;
            this.Y = Y;
            this.interpolatedY = interpolatedY;
            DataContext = null;
            ShowCharts();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCharts();
        }
    }
}
