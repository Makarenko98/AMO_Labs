using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.XPath;
using Microsoft.Win32;

namespace AMO_Lab1
{
    /// <summary>
    /// Логика взаимодействия для CyclWindow.xaml
    /// </summary>
    public partial class CyclWindow : Window
    {
        public CyclWindow()
        {
            InitializeComponent();
            Console.WriteLine(MyAlgorithms.Cyclic(new double[] { 2.5, 6.3, 8 }));
        }
        public void CloseWindow(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                AddItem();
        }

        public void AddItemClick(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        public void ClearList(object sender, RoutedEventArgs e)
        {
            aListBox.Items.Clear();
        }

        private void AddItem()
        {
            double a;
            if (Double.TryParse(aTextBox.Text, out a))
                aListBox.Items.Add(a);
            else
                MessageBox.Show("Некоректні дані");
            aTextBox.Text = "";
        }
        public void RemoveItem(object sender, RoutedEventArgs e)
        {
            aListBox.Items.Remove(aListBox.SelectedItem);
        }
        public void Calc(object sender, RoutedEventArgs e)
        {
            if (aListBox.Items.IsEmpty)
            {
                MessageBox.Show("Додайте число");
                return;
            }
            var a = aListBox.Items.Cast<double>();
            ResTextBox.Text = MyAlgorithms.Cyclic(a.ToArray<double>()).ToString();
        }

        public void OpenFile(object sender, RoutedEventArgs e)
        {
            double a;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    XPathNavigator navigator = new XPathDocument(openFileDialog.FileName).CreateNavigator();
                    foreach (var item in navigator.Select("Data/Cycl/a"))
                    {
                        if (Double.TryParse(item.ToString(), out a))
                            aListBox.Items.Add(a);
                    }
                }
                catch { MessageBox.Show("Некоректний файл"); }
            }
        }

    }
}
