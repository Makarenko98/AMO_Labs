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

        public MainWindow()
        {
            InitializeComponent();
            //Test();
        }

        public void Test()
        {
            double[] X = new double[10];
            double[] Y = new double[10];
            double a = -4, b = 4;
            double d = (b - a) / 10;
            for (int i = 0; i < 10; i++)
            {
                X[i] = a + d * i;
                Y[i] = Math.Sin(X[i]);
            }
            MessageBox.Show(MyAlgorithm.Lagrange(1, X, Y).ToString());
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
            funcChartsWindow = new FuncChartWindow();
            funcChartsWindow.A = 0;
            funcChartsWindow.B = 2;
            funcChartsWindow.Show();
        }

        private void AccuracyCharMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
