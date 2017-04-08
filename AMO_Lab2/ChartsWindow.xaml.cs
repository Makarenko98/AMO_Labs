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

namespace AMO_Lab2
{
    /// <summary>
    /// Логика взаимодействия для ChartsWindow.xaml
    /// </summary>
    public partial class ChartsWindow : Window
    {
        public SortInfo<int> sortInfo;

        public SeriesCollection TimeSeriesCollection { get; set; }
        public SeriesCollection ComplexitySeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YTimeFormatter { get; set; }
        public Func<int, string> XFormatter { get; set; }

        public ChartsWindow()
        {
            InitializeComponent();
        }

        public void ShowCharts()
        {
            if (sortInfo == null)
            {
                MessageBox.Show("Помилка, немає даних");
                return;
            }
            //Getting data
            SortedDictionary<int, MyArray<int>> infos = new SortedDictionary<int, MyArray<int>>();
            foreach (MyArray<int> item in sortInfo.Arrays)
                if (!infos.ContainsKey(item.Length))
                    infos.Add(item.Length, item);
            double[] times = new double[infos.Count];
            double[] complexity = new double[infos.Count];

            for (int i = 0; i < infos.Count; i++)
            {
                times[i] = infos.Values.ElementAt(i).Time.TotalMilliseconds;
                complexity[i] = infos.Keys.ElementAt(i) * Math.Log10(infos.Keys.ElementAt(i));
            }
            //Drawing charts
            TimeSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Час",
                    Values = new ChartValues<double> (times)
                }
            };
            ComplexitySeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Теоретична складність",
                    Values = new ChartValues<double> (complexity)
                }
            };

            Labels = new string[infos.Count];

            for (int i = 0; i < Labels.Length; i++)
            {
                Labels[i] = infos.Keys.ElementAt(i).ToString();
            }

            YTimeFormatter = value => value.ToString() + "мс";

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
            ComplexityChart.Margin = new Thickness(this.ActualWidth / 2 + 5, 0, 0, 0);
            TimeChart.Margin = new Thickness(0, 0, this.ActualWidth / 2 - 5, 0);
        }
    }
}
