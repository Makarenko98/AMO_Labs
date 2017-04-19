using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AMO_Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<List<TextBox>> TextBoxesMatrix;
        public List<List<Label>> LabelsMatrix;
        public List<TextBox> TextBoxesX;
        public List<Label> LabelsX;

        int tbWidth = 40,
                tbHeight = 20,
                lWidtdh = 40,
                lHeight = 40;

        public MainWindow()
        {
            InitializeComponent();
            TextBoxesMatrix = new List<List<TextBox>>();
            LabelsMatrix = new List<List<Label>>();
            TextBoxesX = new List<TextBox>();
            LabelsX = new List<Label>();
            AddVariable();
            AddVariable();
        }

        private void AddVarButton_Click(object sender, RoutedEventArgs e)
        {
            AddVariable();
        }
        private void RemoveVarButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveVariable();
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            double[][] A = new double[TextBoxesMatrix.Count][];
            double[] B = new double[TextBoxesMatrix.Count];
            //double temp;
            for (int i = 0; i < TextBoxesMatrix.Count; i++)
            {
                A[i] = new double[TextBoxesMatrix.Count];
                for (int j = 0; j < TextBoxesMatrix[i].Count - 1; j++)
                {
                    if (!Double.TryParse(TextBoxesMatrix[i][j].Text, out A[i][j]))
                    {
                        MessageBox.Show(String.Format("Некоректні дані A[{0}, {1}]", i, j));
                        return;
                    }
                }

                if (!Double.TryParse(TextBoxesMatrix[i][TextBoxesMatrix[i].Count - 1].Text, out B[i]))
                {
                    MessageBox.Show(String.Format("Некоректні дані B[{0}]", i));
                    return;
                }
            }
            try
            {
                double[] Roots = MyAlgorithm.Gauss(A, B);
                //for (int i = 0; i < Roots.Length; i++)
                //    if (Double.IsInfinity(Roots[i]) || Double.IsNaN(Roots[i]))
                //    {
                //        MessageBox.Show("Неможливо розв'язати");
                //        return;
                //    }
                for (int i = 0; i < Roots.Length; i++)
                    TextBoxesX[i].Text = Roots[i].ToString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int min = -5, max = 5;
            for (int i = 0; i < TextBoxesMatrix.Count; i++)
                for (int j = 0; j < TextBoxesMatrix[i].Count; j++)
                    TextBoxesMatrix[i][j].Text = random.Next(min, max).ToString();
            ClearRootsTB();
        }

        public void ClearRootsTB()
        {
            for (int i = 0; i < TextBoxesX.Count; i++)
                TextBoxesX[i].Text = "";
        }

        public void RemoveVariable()
        {
            if (TextBoxesMatrix.Count <= 2)
                return;
            for (int i = 0; i < TextBoxesMatrix.Count; i++)
            {
                MatrixGrid.Children.Remove(TextBoxesMatrix[i][TextBoxesMatrix[i].Count - 1]);
                MatrixGrid.Children.Remove(LabelsMatrix[i][LabelsMatrix[i].Count - 1]);
                TextBoxesMatrix[i].RemoveAt(TextBoxesMatrix[i].Count - 1);
                LabelsMatrix[i].RemoveAt(LabelsMatrix[i].Count - 1);
            }
            for (int i = 0; i < TextBoxesMatrix[TextBoxesMatrix.Count - 1].Count; i++)
                MatrixGrid.Children.Remove(TextBoxesMatrix[TextBoxesMatrix.Count - 1][i]);

            for (int i = 0; i < LabelsMatrix[LabelsMatrix.Count - 1].Count; i++)
                MatrixGrid.Children.Remove(LabelsMatrix[LabelsMatrix.Count - 1][i]);

            TextBoxesMatrix.RemoveAt(TextBoxesMatrix.Count - 1);
            LabelsMatrix.RemoveAt(LabelsMatrix.Count - 1);

            RootsGrid.Children.Remove(TextBoxesX[TextBoxesX.Count - 1]);
            RootsGrid.Children.Remove(LabelsX[LabelsX.Count - 1]);
            TextBoxesX.RemoveAt(TextBoxesX.Count - 1);
            LabelsX.RemoveAt(LabelsX.Count - 1);

            SetLabelsContent();
            SetTexBoxesTabIndex();
            SetGroupBoxSize(tbWidth, tbHeight, lWidtdh);

            ClearRootsTB();
        }

        public void AddVariable()
        {
            TextBox tb;
            Label label;
            List<TextBox> newRowTB = new List<TextBox>();
            List<Label> newRowL = new List<Label>();
            for (int i = 0; i <= TextBoxesMatrix.Count; i++)
            {
                tb = CreateTextBox(tbWidth, tbHeight, i * (tbWidth + lWidtdh), TextBoxesMatrix.Count * ((int)(tbHeight * 1.5)));
                newRowTB.Add(tb);
                MatrixGrid.Children.Add(tb);
                if (i != TextBoxesMatrix.Count)
                {
                    label = CreateLabel(lWidtdh, lHeight, (i + 1) * tbWidth + i * lWidtdh, TextBoxesMatrix.Count * ((int)(tbHeight * 1.5)), "");
                    newRowL.Add(label);
                    MatrixGrid.Children.Add(label);
                }
            }
            TextBoxesMatrix.Add(newRowTB);
            LabelsMatrix.Add(newRowL);
            for (int i = 0; i < TextBoxesMatrix.Count; i++)
            {
                tb = CreateTextBox(tbWidth, tbHeight, TextBoxesMatrix[i].Count * (tbWidth + lWidtdh), i * ((int)(tbHeight * 1.5)));
                TextBoxesMatrix[i].Add(tb);
                MatrixGrid.Children.Add(tb);

                label = CreateLabel(lWidtdh, lHeight, (TextBoxesMatrix[i].Count - 1) * tbWidth + (TextBoxesMatrix[i].Count - 2) * lWidtdh, i * ((int)(tbHeight * 1.5)), "");
                LabelsMatrix[i].Add(label);
                MatrixGrid.Children.Add(label);
            }

            tb = CreateTextBox(tbWidth * 2, tbHeight, lWidtdh, TextBoxesX.Count * ((int)(tbHeight * 1.5)));
            tb.IsReadOnly = true;
            TextBoxesX.Add(tb);
            RootsGrid.Children.Add(tb);
            label = CreateLabel(lWidtdh, lHeight, 0, (TextBoxesX.Count - 1) * ((int)(tbHeight * 1.5)), "x" + TextBoxesX.Count + " =");
            LabelsX.Add(label);
            RootsGrid.Children.Add(label);
            SetLabelsContent();
            SetTexBoxesTabIndex();

            SetGroupBoxSize(tbWidth, tbHeight, lWidtdh);

            ClearRootsTB();
        }

        public void SetGroupBoxSize(int tbWidth, int tbHeight, int lWidtdh)
        {
            MatrixGrB.Height = (TextBoxesMatrix.Count + 1) * ((int)(tbHeight * 1.5)) + 10;
            MatrixGrB.Width = (TextBoxesMatrix[0].Count + 1) * tbWidth + LabelsMatrix[0].Count * lWidtdh + 10;
            RootsGB.Height = MatrixGrB.Height;
            RootsGB.Margin = new Thickness() { Left = MatrixGrB.Width + MatrixGrB.Margin.Left + 10, Top = MatrixGrB.Margin.Top };
        }

        public void SetLabelsContent()
        {
            for (int i = 0; i < LabelsMatrix.Count; i++)
                for (int j = 0; j < LabelsMatrix[i].Count; j++)
                {
                    LabelsMatrix[i][j].Content = "*x" + (j + 1);
                    if (j != LabelsMatrix[i].Count - 1)
                        LabelsMatrix[i][j].Content += " +";
                    else
                        LabelsMatrix[i][j].Content += " =";
                }
        }

        public void SetTexBoxesTabIndex()
        {
            for (int i = 0; i < TextBoxesMatrix.Count; i++)
                for (int j = 0; j < TextBoxesMatrix[i].Count; j++)
                    TextBoxesMatrix[i][j].TabIndex = i * TextBoxesMatrix[i].Count + j;
        }

        public TextBox CreateTextBox(int Width, int Height, int MarginLeft, int MarginTop)
        {
            TextBox tb = new TextBox()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = Height,
                Width = Width,
                Margin = new Thickness(MarginLeft, MarginTop, 0, 0)
            };
            return tb;
        }

        public Label CreateLabel(int Width, int Height, int MarginLeft, int MarginTop, string content)
        {
            Label label = new Label
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = Height,
                Width = Width,
                Margin = new Thickness(MarginLeft, MarginTop, 0, 0),
                Content = content
            };
            return label;
        }
    }
}
