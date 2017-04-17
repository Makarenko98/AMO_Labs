using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;

//TODO: realize in Array and SortInfo INotifyPropertyChanged - no

namespace AMO_Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SortInfo<int> sortInfo = new SortInfo<int>();

        public MainWindow()
        {
            InitializeComponent();
            CountLabel.Content = "Кількість елементів: " + 0;
            MassInfoGB.IsEnabled = false;
            ShowGraphBut.IsEnabled = false;
            sortInfo.ChangeList += SortInfo_ChangeList;
        }

        private void SortInfo_ChangeList()
        {
            MassInfoGB.IsEnabled = sortInfo.Arrays.Count != 0;
        }

        private void ArrayChange()
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            ArrListBox.ItemsSource = sortInfo.Arrays[ArrNumberCB.SelectedIndex].Array;
            SortedArrListBox.ItemsSource = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray;
            CountLabel.Content = "Кількість елементів: " + sortInfo.Arrays[ArrNumberCB.SelectedIndex].Length;
            TimeLabel.Content = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray != null ? "Час сортування:\n\t" + sortInfo.Arrays[ArrNumberCB.SelectedIndex].Time.TotalMilliseconds + "мс" : "";
        }

        public void ShowGenerateWindow(object sender, RoutedEventArgs e)
        {
            GenerateWindow gw = new GenerateWindow();
            gw.ShowDialog();
            if (gw.Arrays == null)
                return;
            foreach (int[] row in gw.Arrays)
                sortInfo.Arrays.Add(new MyArray<int>(row));
            ChangeArrNumberCB();
            SortInfo_ChangeList();
        }

        public void ChangeArrNumberCB()
        {
            ArrNumberCB.Items.Clear();
            for (int i = 0; i < sortInfo.Arrays.Count; i++)
                ArrNumberCB.Items.Add(i + 1);
            ArrNumberCB.SelectedIndex = 0;
        }

        public void OpenFile(object sender, RoutedEventArgs e)
        {
            sortInfo.Arrays.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<int> lst = new List<int>();
            openFileDialog.Filter = "TXT (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader(openFileDialog.FileName);
                    string file = reader.ReadToEnd();
                    string[] arrStr = file.Split(' ', '\n');
                    int a;
                    foreach (string elem in arrStr)
                    {
                        if (Int32.TryParse(elem, out a))
                            lst.Add(a);
                        //else
                        //{
                        //    MessageBox.Show("Файл містить некоректні дані");
                        //    return;
                        //}

                    }
                    sortInfo.Arrays.Add(new MyArray<int>(lst.ToArray()));
                    ArrNumberCB.Items.Add(sortInfo.Arrays.Count);
                    ArrayChange();
                }
                catch { MessageBox.Show("Некоректний файл"); }
                finally
                {
                    reader?.Close();
                }
            }
        }

        void AddItem(int item)
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            sortInfo.Arrays[ArrNumberCB.SelectedIndex].Add(item);
            ArrayChange();
        }

        public void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ElementTextBox.Text.Length == 0)
                return;
            int a;
            if (Int32.TryParse(ElementTextBox.Text, out a))
            {
                AddItem(a);
                ElementTextBox.Text = "";
            }
            else
                MessageBox.Show("Некоректні дані");
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            sortInfo.Arrays[ArrNumberCB.SelectedIndex].RemoveAt(ArrListBox.SelectedIndex);
            ArrayChange();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            sortInfo.Arrays[ArrNumberCB.SelectedIndex].Clear();
            ArrayChange();
        }

        private void ElementTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                AddButton_Click(sender, e);
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            sortInfo.Arrays[ArrNumberCB.SelectedIndex].Sort();
            SortedArrListBox.ItemsSource = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray;
            TimeLabel.Content = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray != null ? "Час сортування:\n\t" + sortInfo.Arrays[ArrNumberCB.SelectedIndex].Time.TotalMilliseconds + "мс" : "";
        }

        private void ArrNumberCB_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            ArrListBox.ItemsSource = sortInfo.Arrays[ArrNumberCB.SelectedIndex].Array;
            SortedArrListBox.ItemsSource = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray;
            CountLabel.Content = "Кількість елементів: " + sortInfo.Arrays[ArrNumberCB.SelectedIndex].Length;
            TimeLabel.Content = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray != null ? "Час сортування:\n\t" + sortInfo.Arrays[ArrNumberCB.SelectedIndex].Time.TotalMilliseconds + "мс" : "";
            MassInfoGB.IsEnabled = sortInfo.Arrays.Count != 0;
        }

        private void ShowGraphBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChartsWindow cw = new ChartsWindow();
                cw.sortInfo = sortInfo;
                cw.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неможливо завантажити бібліотеку LiveCharts");
            }
        }

        private void GenerateArrClick(object sender, RoutedEventArgs e)
        {
            GenArrWindow gaw = new GenArrWindow();
            gaw.ShowDialog();
            if (gaw.Arr == null)
                return;
            sortInfo.Arrays.Add(new MyArray<int>(gaw.Arr.ToArray()));
            ArrayChange();
            ArrNumberCB.Items.Add(sortInfo.Arrays.Count);
        }
        private void CreateEmptyArrClick(object sender, RoutedEventArgs e)
        {
            sortInfo.Arrays.Add(new MyArray<int>());
            ArrNumberCB.Items.Add(sortInfo.Arrays.Count);
        }
        private void RemoveArray(object sender, RoutedEventArgs e)
        {
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            sortInfo.Arrays.RemoveAt(ArrNumberCB.SelectedIndex);
            ArrNumberCB.Items.RemoveAt(ArrNumberCB.Items.Count - 1);
            ArrNumberCB_SelectionChanged(sender, e);
            //ArrNumberCB.SelectedIndex = ArrNumberCB.SelectedIndex == 0 ? 1; ArrNumberCB.SelectedIndex - 1;
        }

        private void SortAllBut_Click(object sender, RoutedEventArgs e)
        {
            if (sortInfo.Arrays.Count == 0)
                return;
            sortInfo.SortAll();
            if (ArrNumberCB.SelectedIndex < 0)
                return;
            SortedArrListBox.ItemsSource = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray;
            TimeLabel.Content = sortInfo.Arrays[ArrNumberCB.SelectedIndex].SortedArray != null ? "Час сортування:\n\t " + sortInfo.Arrays[ArrNumberCB.SelectedIndex].Time.TotalMilliseconds + "мс" : "";
            ShowGraphBut.IsEnabled = true;
        }

        private void ClearAllBut_Click(object sender, RoutedEventArgs e)
        {
            sortInfo.Arrays.Clear();
            ArrNumberCB.Items.Clear();
            SortInfo_ChangeList();
            ArrListBox.ItemsSource = null;
            SortedArrListBox.ItemsSource = null;
            CountLabel.Content = "";
        }
    }
}
