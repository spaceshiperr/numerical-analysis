using System;
using System.Windows.Forms;

namespace InterpolationApp
{
    public partial class MainForm : Form
    {
        static Interpolation interpolation;

        private static double Step = 0.1;

        private static Tuple<double, double> Segment = Tuple.Create(0.5, 1.5);

        private static int DeltaDegree = 4;

        private static double Precision = Math.Pow(10, -5);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            interpolation = new Interpolation(Math.Sin, Segment, Step, Precision, DeltaDegree);
            FillPointValueGrid();
            CorrectPointValueGridSize();
            InitPolynomialGrid();
            FillPolynomialGrid();
        }

        private void FillPointValueGrid()
        {
            for (int i = 0; i < interpolation.Points.Count; i++)
            {
                
                pointValueGrid.Rows.Add(interpolation.Points[i], interpolation.Values[i]);
                pointValueGrid.Rows.Add();
            }

            int rowStartIndex = 1;
            int columnIndex = 2;

            foreach (var deltasI in interpolation.Deltas)
            {
                int rowIndex = rowStartIndex;

                foreach (var delta in deltasI)
                {
                    pointValueGrid[columnIndex, rowIndex].Value = interpolation.TruncateValue(Precision, delta);
                    rowIndex += 2;
                }

                rowStartIndex++;
                columnIndex++;
            }
        }

        private void FillPolynomialGrid()
        {
            polynomialGrid[1, 0].Value = interpolation.Values[0];
            polynomialGrid[1, 2].Value = string.Concat(polynomialGrid[1, 0].Value, " * ", polynomialGrid[1, 1].Value);

            int k = 4;
            for (int i = 0; i < k; i++)
            {
                polynomialGrid[i + 2, 0].Value = interpolation.TruncateValue(Precision, interpolation.Deltas[i][0]);
                polynomialGrid[i + 2, 2].Value = string.Concat(polynomialGrid[i + 2, 0].Value, " * ",polynomialGrid[i + 2, 1].Value);
            }
        }

        private void CorrectPointValueGridSize()
        {
            pointValueGrid.Rows.RemoveAt(pointValueGrid.Rows.Count - 2);
        }

        private void InitPolynomialGrid()
        {
            polynomialGrid.Rows.Add("delta k y0");
            polynomialGrid.Rows.Add("Nk(t)");
            polynomialGrid.Rows.Add("Nk(t) * delta k y0");
            polynomialGrid.Rows.Add("Pk(x1)");
            polynomialGrid.Rows.Add("f(x1)-Pk(x1)");
            polynomialGrid.Rows.Add("|Rk(x1)|");

            polynomialGrid[1, 1].Value = "1";
            polynomialGrid[2, 1].Value = "t";
            polynomialGrid[3, 1].Value = "t * (t - 1) / k";
            polynomialGrid[4, 1].Value = "t * (t - 1) * (t - 2) / k ^ 3";
            polynomialGrid[5, 1].Value = "t * (t - 1) * (t - 2) * (t - 3) / k ^ 3";
        }

    }
}
