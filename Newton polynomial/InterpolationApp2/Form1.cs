using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InterpolationApp2
{
    public partial class Form1 : Form
    {
        // input data

        private List<double> Points = new List<double> { -0.6, -0.5, -0.3, -0.2, -0.1, 0 };
        private double IntPoint = -0.4;
        private double FunctionValue = 0.8;
        private Interpolation.FunctionDelegate Function = Math.Cos;

        //private List<double> Points = new List<double> { -2, 0, 1, 3, 4, 5 };
        //private double IntPoint = 2;
        //private double FunctionValue = 10;
        //private Interpolation.FunctionDelegate Function = (x => Math.Pow(x, 3) + 2);

        private int Degree = 4;
        private double Step = 0.1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var values = Points.Select(x => Function(x)).ToList();          
            var diffList = Interpolation.GetDividedDifferences(Points, values);

            FillDiffGrid(Points, values, diffList);

            var newPoints = Interpolation.ChooseClosePoints(Points, IntPoint, Degree);
            var newValues = newPoints.Select(x => Function(x)).ToList();
            var interpolatedValues = Enumerable.Range(0, Degree).Select(x => Interpolation.Interpolate(IntPoint, newPoints, newValues, x)).ToList();
            var errors = Interpolation.GetCalculationError(FunctionValue, interpolatedValues);
            var maxModules = Enumerable.Range(0, Degree).Select(degree => Interpolation.EvaluateProductModule(newPoints, newValues, IntPoint, degree + 1, Step)).ToList();
            var errorEstimations = Enumerable.Range(0, Degree).Select(degree => Interpolation.EstimateError(newPoints, newValues, IntPoint, degree, Step)).ToList();

            FillResultGrid(newPoints, interpolatedValues, errors, maxModules, errorEstimations);
        }

        private void FillDiffGrid(List<double> points, List<double> values, List<List<double>> diffList)
        {
            Enumerable.Range(0, points.Count).ToList().ForEach(i => { diffGrid.Rows.Add(points[i], values[i]); diffGrid.Rows.Add(); });
                
            int rowStartIndex = 1;
            int columnIndex = 2;

            for (int i = columnIndex; i < diffGrid.ColumnCount; i++)
            {
                int rowIndex = rowStartIndex;
                foreach (var diff in diffList[i - 2])
                {
                    diffGrid[i, rowIndex].Value = diff;
                    rowIndex += 2;
                }

                rowStartIndex++;
            }
        }

        private void FillResultGrid(List<double> points, List<double> interpolatedValues, List<double> errors, List<double> maxModules, List<double> errorEstimations)
        {
            resultGrid.Rows.Add("Узлы");
            resultGrid.Rows.Add("P_i(x)");
            resultGrid.Rows.Add("f(x) - P_i(x)");
            resultGrid.Rows.Add("M_{i+1}");
            resultGrid.Rows.Add("R_i(x)");

            for (int i = 1; i < resultGrid.ColumnCount; i++)
            {
                resultGrid[i, 0].Value = points[i - 1];
                resultGrid[i, 1].Value = interpolatedValues[i - 1];
                resultGrid[i, 2].Value = errors[i - 1];
                resultGrid[i, 3].Value = maxModules[i - 1];
                resultGrid[i, 4].Value = errorEstimations[i - 1];
            }
        }

    }
}