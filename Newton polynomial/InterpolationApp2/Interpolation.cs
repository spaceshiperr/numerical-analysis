using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Interpolation;

namespace InterpolationApp2
{
    public static class Interpolation
    {
        public delegate double FunctionDelegate(double x);

        public static List<List<double>> GetDividedDifferences(List<double> points, List<double> values)
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

        public static List<double> ChooseClosePoints(List<double> points, double intPoint, int count)
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

        public static List<double> GetCalculationError(double value, List<double> calculatedValues)
        {
            return calculatedValues.Select(calcValue => value - calcValue).ToList();
        }

        public static double Interpolate(double intPoint, List<double> points, List<double> values, int degree)
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


        public static double Differentiate(List<double> points, List<double> values, double diffPoint, int degree)
        {
            double recDifferentiation(List<double> newValues, int newDegree)
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

        public static double EvaluateProductModule(List<double> points, List<double> values, double intPoint, int degree, double step)
        {
            var a = points.Concat(new List<double> { intPoint }).Min();
            var b = points.Concat(new List<double> { intPoint }).Max();

            var derivates = new List<double>();

            for (double i = a; i < b; i += step)
            {
                var derivative = Differentiate(points, values, i, degree);
                derivates.Add(Math.Abs(derivative));
            }

            return derivates.Max();
        }

        public static double EstimateError(List<double> points, List<double> values, double intPoint, int degree, double step)
        {
            var maxModule = EvaluateProductModule(points, values, intPoint, degree + 1, step);
            var product = Math.Abs(points.Select(x => intPoint - x).Aggregate((acc, x) => acc * x));
            var factorial = Enumerable.Range(1, degree + 1).Aggregate((i, r) => r * i);

            return maxModule * product / factorial;
        }

    }
}
