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
using LiveCharts;
using LiveCharts.Wpf;

namespace AMO_Lab4
{
    /// <summary>
    /// Логика взаимодействия для IterationsWindow.xaml
    /// </summary>
    public partial class IterationsWindow : Window
    {
        public double[] Iterations { get; set; }
        public double TrueRes { get; set; }
        public SeriesCollection IterationsSeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public IterationsWindow()
        {
            InitializeComponent();
        }

        private void ShowCharts()
        {
            double[] res = new double[Iterations.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = TrueRes;
            IterationsSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Корінь рівняння",
                    Values = new ChartValues<double>(Iterations)
                },
                new LineSeries
                {
                    Title = "Проміні результати",
                    Values = new ChartValues<double>(res)
                }
            };
            YFormatter = (x) => x.ToString();
            Labels = new string[Iterations.Length];
            for (int i = 0; i < Labels.Length; i++)
                Labels[i] = i.ToString();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCharts();
        }
    }
}
