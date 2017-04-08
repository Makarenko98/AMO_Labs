using System;
using System.Windows;

namespace AMO_Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinWindow linWin = null;
        private BranWindow branWin = null;
        private CyclWindow cyclWin = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LinClick(object sender, RoutedEventArgs e)
        {
            //if (linWin == null)
            linWin = new LinWindow();
            linWin.ShowDialog();
            //linWin.Focus();
        }
        private void RamClick(object sender, RoutedEventArgs e)
        {
            //if (ramWin == null)
            branWin = new BranWindow();
            branWin.ShowDialog();
            //ramWin.Focus();
        }
        private void CyclClick(object sender, RoutedEventArgs e)
        {
            //if (cyclWin == null)
            cyclWin = new CyclWindow();
            cyclWin.ShowDialog();
            //cyclWin.Focus();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
