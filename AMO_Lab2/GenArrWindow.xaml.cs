using System;
using System.Collections.Generic;
using System.Windows;

namespace AMO_Lab2
{
    /// <summary>
    /// Логика взаимодействия для GenArrWindow.xaml
    /// </summary>
    public partial class GenArrWindow : Window
    {
        public List<int> Arr { get; set; }
        public GenArrWindow()
        {
            InitializeComponent();
        }

        private void GenerateBut_Click(object sender, RoutedEventArgs e)
        {
            int size = 0;
            int bot = 0;
            int top = 0;
            Random random = new Random();
            if (!Int32.TryParse(SizeTB.Text, out size) || !Int32.TryParse(BotTB.Text, out bot) || !Int32.TryParse(TopTB.Text, out top) || bot > top || size < 0)
            {
                MessageBox.Show("Некоректні дані");
                return;
            }
            Arr = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                Arr.Add(random.Next(bot, top));
            }
            this.Close();
        }

        private void CancelBut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
