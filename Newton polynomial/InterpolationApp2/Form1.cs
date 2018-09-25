using MathNet.Numerics.Interpolation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InterpolationApp2
{
    public partial class Form1 : Form
    {
        //private List<double> points = new List<double>{ -0.6, -0.5, -0.3, -0.2, -0.1, 0 };
        //private double intPoint = -0.4;
        //private double functionValue = 0.8;
        //private FunctionDelegate function = Math.Cos;

        private List<double> Points = new List<double> { -2, 0, 1, 3, 4, 5 };
        private double IntPoint = 2;
        private double FunctionValue = 10;
        private FunctionDelegate Function = (x => Math.Pow(x, 3) + 2);
        private int Degree = 4;

        private delegate double FunctionDelegate(double x);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var values = Points.Select(x => Function(x)).ToList();           

            var diffList = GetDividedDifferences(Points, values);

            FillDiffGrid(Points, values, diffList);
            var newPoints = ChooseClosePoints(Points, IntPoint, Degree);
            var newValues = newPoints.Select(x => Function(x)).ToList();

            var interpolatedValues = new List<double>();
            for (int i = 0; i < Degree; i++)
            {
                var value = Interpolate(IntPoint, newPoints, newValues, i);
                interpolatedValues.Add(value);
            }

            var errors = GetCalculationError(FunctionValue, interpolatedValues);

            FillResultGrid(newPoints, interpolatedValues, errors);

            var res = Differentiation(newPoints, newValues, IntPoint, 2);
        }

        private void FillDiffGrid(List<double> points, List<double> values, List<List<double>> diffList)
        {
            for (int i = 0; i < points.Count; i++)
            {
                diffGrid.Rows.Add(points[i], values[i]);
                diffGrid.Rows.Add();
            }
                
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

        private void FillResultGrid(List<double> points, List<double> interpolatedValues, List<double> errors)
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

            }
        }

        private List<List<double>> GetDividedDifferences(List<double> points, List<double> values)
        {
            var diffs = new List<List<double>>();

            var diffs1 = new List<double>();
            for (int i = 1; i < points.Count; i++)
            {
                var diff = (values[i] - values[i - 1]) / (points[i] - points[i - 1]);
                diffs1.Add(diff);
            }

            diffs.Add(diffs1);

            int diffNumber = points.Count / 2 - 1;
            
            for (int i = 0; i <= diffNumber; i++)
            {
                int beginPoint = 0;
                int endPoint = i + 2;
                var diffsN = new List<double>();

                for (int j = 1; j < diffs[diffs.Count - 1].Count; j++)
                {
                    var diff = (diffs[diffs.Count - 1][j] - diffs[diffs.Count - 1][j - 1]) / (points[endPoint] - points[beginPoint]);
                    diffsN.Add(diff);
                    beginPoint++;
                    endPoint++;
                }

                diffs.Add(diffsN);
            }

            return diffs;
        }

        private List<double> ChooseClosePoints(List<double> points, double intPoint, int count)
        {
            var newPoints = new List<double>();
            
            for (int i = 0; i < count; i++)
            {
                var distances = new List<double>();
                points.ForEach(x => distances.Add(Math.Abs(x - intPoint)));
                var minDistanceIndex = distances.IndexOf(distances.Min());

                newPoints.Add(points[minDistanceIndex]);
                points.Remove(points[minDistanceIndex]);
            }

            return newPoints;
        }

        private List<double> GetCalculationError(double value, List<double> calculatedValues)
        {
            return calculatedValues.Select(calcValue => value - calcValue).ToList();
        }

        private double Interpolate(double intPoint, List<double> points, List<double> values, int degree)
        {
            if (degree == 0)
                return values[0];

            var result = values[0];
            var diffs = GetDividedDifferences(points, values);

            for (int i = 0; i < degree; i++)
            {
                double product = 1;
                for (int j = 0; j <= i; j++)
                {
                    product *= intPoint - points[j];
                }

                result += diffs[i][0] * product;
            }

            return result;
        }

        private double Differentiation(List<double> points, List<double> values, double diffPoint, int degree)
        {
            double recDifferentiation (List<double> newValues, int newDegree)
            {
                if (newDegree == 0)
                {
                    return CubicSpline.InterpolateNatural(points, newValues).Differentiate(diffPoint);
                }
                else
                {
                    var cs = CubicSpline.InterpolateNatural(points, newValues);
                    newValues = points.Select(point => cs.Differentiate(point)).ToList();
                    return recDifferentiation(newValues, newDegree - 1);
                }
            }

            return recDifferentiation(values, degree);
        }

        //найти Mi+1 как максимум производной и погрешность
    }
}