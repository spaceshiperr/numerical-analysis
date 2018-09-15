using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterpolationApp
{
    public partial class MainForm : Form
    {
        // Input data
        private static double Step = 0.1;
        private static Tuple<double, double> Segment = Tuple.Create(0.5, 1.5);
        private static int DeltaDegree = 4;
        private static double Precision = Math.Pow(10, -5);
        private static Interpolation.FunctionDelegate Function = Math.Sin;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var points = Interpolation.GetPoints(Segment, Step);
            var values = Interpolation.GetValues(Function, points, Precision);
            var deltas = Interpolation.GetDeltas(values, DeltaDegree);

            FillPointValueGrid(points, values, deltas);
            CorrectPointValueGridSize();
            InitPolynomialGrid();
            FillPolynomialGrid(values, deltas);
        }

        private void FillPointValueGrid(List<double> points, List<double> values, List<List<double>> deltas)
        {
            for (int i = 0; i < points.Count; i++)
            {
                
                pointValueGrid.Rows.Add(points[i], values[i]);
                pointValueGrid.Rows.Add();
            }

            int rowStartIndex = 1;
            int columnIndex = 2;

            foreach (var deltasI in deltas)
            {
                int rowIndex = rowStartIndex;

                foreach (var delta in deltasI)
                {
                    pointValueGrid[columnIndex, rowIndex].Value = Interpolation.Truncate(Precision, delta);
                    rowIndex += 2;
                }

                rowStartIndex++;
                columnIndex++;
            }
        }

        private void FillPolynomialGrid(List<double> values, List<List<double>> deltas)
        {
            polynomialGrid[1, 0].Value = values[0];
            polynomialGrid[1, 2].Value = string.Concat(polynomialGrid[1, 0].Value, " * ", polynomialGrid[1, 1].Value);

            int k = 4;
            for (int i = 0; i < k; i++)
            {
                polynomialGrid[i + 2, 0].Value = Interpolation.Truncate(Precision, deltas[i][0]);
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

            var formulas = Interpolation.GenerateFormulaNFunctions(DeltaDegree, "t");
            for (int i = 1; i < polynomialGrid.ColumnCount; i++)
            {
                polynomialGrid[i, 1].Value = formulas[i - 1];
            }
        }

    }
}
