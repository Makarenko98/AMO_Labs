using System;
using System.Windows;
using System.Xml.XPath;
using Microsoft.Win32;

namespace AMO_Lab1
{
    /// <summary>
    /// Логика взаимодействия для LinWindow.xaml
    /// </summary>
    public partial class LinWindow : Window
    {
        public LinWindow()
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
                double a = Double.Parse(aTextBox.Text);
                double c = Double.Parse(cTextBox.Text);
                double result = MyAlgorithms.Linear(a, c);
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
                    foreach (var item in navigator.Select("Data/Lin/a"))
                        aTextBox.Text = item.ToString();
                    foreach (var item in navigator.Select("Data/Lin/c"))
                        cTextBox.Text = item.ToString();
                }
                catch { MessageBox.Show("Некоректний файл"); }
            }
        }
    }
}
