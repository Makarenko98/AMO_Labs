using System;
using System.Windows;
using System.Xml.XPath;
using Microsoft.Win32;

namespace AMO_Lab1
{
    /// <summary>
    /// Логика взаимодействия для RamWindow.xaml
    /// </summary>
    public partial class BranWindow : Window
    {
        public BranWindow()
        {
            InitializeComponent();
        }
        public void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Calc(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = Double.Parse(xTextBox.Text);
                double b = Double.Parse(bTextBox.Text);
                double c = Double.Parse(cTextBox.Text);
                double k = Double.Parse(kTextBox.Text);
                double result = MyAlgorithms.Branched(x, b, c, k);
                ResTextBox.Text = result.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Некоректні Дані", "Помилка"); }
        }

        public void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    XPathNavigator navigator = new XPathDocument(openFileDialog.FileName).CreateNavigator();
                    foreach (var item in navigator.Select("Data/Bran/x"))
                        xTextBox.Text = item.ToString();
                    foreach (var item in navigator.Select("Data/Bran/b"))
                        bTextBox.Text = item.ToString();
                    foreach (var item in navigator.Select("Data/Bran/c"))
                        cTextBox.Text = item.ToString();
                    foreach (var item in navigator.Select("Data/Bran/k"))
                        kTextBox.Text = item.ToString();
                }
                catch { MessageBox.Show("Некоректний файл"); }
            }
        }
    }
}
