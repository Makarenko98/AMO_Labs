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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AMO_Lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<List<TextBox>> TextBoxesMatrix;
        public List<List<Label>> LabelsX;
        public MainWindow()
        {
            InitializeComponent();
            TextBoxesMatrix = new List<List<TextBox>>();
            LabelsX = new List<List<Label>>();
            AddVariable();
            AddVariable();
            AddVariable();
            AddVariable();
        }
        //size
        public void AddVariable()
        {
            int tbWidth = 40,
                tbHeight = 20,
                lWidtdh = 40,
                lHeight = 40;
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
            LabelsX.Add(newRowL);
            for (int i = 0; i < TextBoxesMatrix.Count; i++)
            {
                tb = CreateTextBox(tbWidth, tbHeight, TextBoxesMatrix[i].Count * (tbWidth + lWidtdh), i * ((int)(tbHeight * 1.5)));
                TextBoxesMatrix[i].Add(tb);
                MatrixGrid.Children.Add(tb);

                label = CreateLabel(lWidtdh, lHeight, (TextBoxesMatrix[i].Count - 1) * tbWidth + (TextBoxesMatrix[i].Count - 2) * lWidtdh, i * ((int)(tbHeight * 1.5)), "");
                LabelsX[i].Add(label);
                MatrixGrid.Children.Add(label);
            }
            for (int i = 0; i < LabelsX.Count; i++)
                for (int j = 0; j < LabelsX[i].Count; j++)
                {
                    LabelsX[i][j].Content = "*x" + (j + 1);
                    if (j != LabelsX[i].Count - 1)
                        LabelsX[i][j].Content += " +";
                    else
                        LabelsX[i][j].Content += " =";
                }
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
