using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace AMO_Lab2
{
    /// <summary>
    /// Логика взаимодействия для GenerateWindow.xaml
    /// </summary>
    public partial class GenerateWindow : Window
    {
        private TextBox[] sizeTBs = new TextBox[10];
        private int bot = 10000;
        private int top = 2000000;
        public GenerateWindow()
        {
            InitializeComponent();
            sizeTBs[0] = Size1TB;
            sizeTBs[1] = Size2TB;
            sizeTBs[2] = Size3TB;
            sizeTBs[3] = Size4TB;
            sizeTBs[4] = Size5TB;
            sizeTBs[5] = Size6TB;
            sizeTBs[6] = Size7TB;
            sizeTBs[7] = Size8TB;
            sizeTBs[8] = Size9TB;
            sizeTBs[9] = Size10TB;
        }
        public int[][] Arrays { get; set; }

        private void RandomSizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
                sizeTBs[i].Text = random.Next(bot, top).ToString();
        }

        private void GenerateBut_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Arrays = new int[10][];
            int size = 0;
            for (int i = 0; i < 10; i++)
            {
                if (!Int32.TryParse(sizeTBs[i].Text, out size) || size < 0 || size > Int32.MaxValue / 2)
                {
                    MessageBox.Show("Некоректні дані");
                    return;
                }
                Arrays[i] = new int[size];
                for (int j = 0; j < size; j++)
                    Arrays[i][j] = random.Next(0, size * 2);
            }
            //ToFiles();
            this.Close();
        }

        private void ToFiles()
        {
            StreamWriter writer;
            for (int i = 0; i < Arrays.Length; i++)
            {
                writer = new StreamWriter("files/f" + (i + 1) + ".txt", false);
                for (int j = 0; j < Arrays[i].Length; j++)
                    writer.Write(Arrays[i][j] + " ");
            }
        }

        private void CancelBut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
