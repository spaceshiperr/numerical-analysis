
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationApp4
{
    static class Differentiation
    {
        public delegate double FunctionDelegate(double x);

        public static IEnumerable<double> Double(double from, double to, double step)
        {
            if (step <= 0.0) step = (step == 0.0) ? 1.0 : -step;

            if (from <= to)
            {
                for (double d = from; d <= to; d += step) yield return d;
            }
            else
            {
                for (double d = from; d >= to; d -= step) yield return d;
            }
        }

        public static Dictionary<double, double> DifferentiateRight(Tuple<double, double> interval, double step, FunctionDelegate function)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, step).ToList().ForEach(x => derivatives.Add(x, (function(x + step) - function(x)) / step));

            return derivatives;
        }

        public static Dictionary<double, double> DifferentiateBoth(Tuple<double, double> interval, double step, FunctionDelegate function)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, step).ToList().ForEach(x => derivatives.Add(x, (function(x + step) - function(x - step)) / 2 / step));

            return derivatives;
        }

        public static List<double> GetDifference(List<double> expected, List<double> observed)
        {
            return expected.Zip(observed, (x, y) => x - y).ToList();
        }

        public static List<double> GetFunctionValues(Tuple<double, double> interval, double step,FunctionDelegate function)
        {
            return Double(interval.Item1, interval.Item2, step).Select(x => function(x)).ToList();
        }

        // for DifferentiateLeft
        public static double GetOptimalStep(double x, double step, FunctionDelegate function, FunctionDelegate functionDerivative)
        {
            double prevDiff = functionDerivative(x) - DifferentiateLeft(x, step, function, functionDerivative);
            double diff = 0;
            while (diff < prevDiff)
            {
                step /= 2;
                prevDiff = diff;
                diff = functionDerivative(x) - DifferentiateLeft(x, step, function, functionDerivative);
            }
            return step * 2;
        }

        public static double DifferentiateLeft(double x, double step, FunctionDelegate function, FunctionDelegate functionDerivative)
        {
            return (function(x) - function(x - step)) / step + step / 2 * function(x + step / 2);
        }

        public static Dictionary<double, double> DifferentiateLeft(Tuple<double, double> interval, double step, FunctionDelegate function, FunctionDelegate functionDerivative)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, step).ToList().ForEach(x => derivatives.Add(x, DifferentiateLeft(x, GetOptimalStep(x, step, function, functionDerivative), function, functionDerivative)));

            return derivatives;
        }
    }
}
