using System;
using System.Collections.Generic;
using System.Linq;

namespace InterpolationApp5
{
    public class Interval
    {
        public Interval(double left, double right)
        {
            Left = left;
            Right = right;
        }

        public double Left { get; set; }
        public double Right { get; set; }
    }

    public static class Integrals
    {
        public delegate double FunctionDelegate(double x);

        // Algebraic Degree Of Accuracy For Quadratic Formula
        private static readonly int ADALeftRectangles = 0;
        private static readonly int ADATrapezoid = 1;
        private static readonly int ADASimpsons = 3;

        // Constant for error calculation
        private static readonly double CLeftRectangles = 0.5;
        private static readonly double CTrapezoid = 1 / 12;
        private static readonly double CSimpsons = 1 / 2880;


        public static IEnumerable<double> Double(double from, double to, double h)
        {
            if (h <= 0.0) h = (h == 0.0) ? 1.0 : -h;

            if (from <= to)
            {
                for (double d = from; d <= to; d += h) yield return d;
            }
            else
            {
                for (double d = from; d >= to; d -= h) yield return d;
            }
        }

        private static double GetStep(Interval interval, double n)
        {
            return (interval.Right - interval.Left) / n;
        }

        public static double CalculateLeftRectanglesIntegral(Interval interval, int n, FunctionDelegate f)
        {
            double h = GetStep(interval, n);
            double sum = 0;
            double x;

            for (int i = 0; i < n; i++)
            {
                x = interval.Left + i * h;
                sum += f(x);
            }
            return h * sum;
        }

        public static double CalcualteTrapezoidIntegral(Interval interval, int n, FunctionDelegate f)
        {
            double h = GetStep(interval, n);
            double sum = 0;
            double x;
            
            for (int i = 1; i < n - 1; i++)
            {
                x = interval.Left + i * h;
                sum += f(x);
            }

            sum = sum * 2 + f(interval.Left) + f(interval.Right);
            double coeff = (interval.Right - interval.Left) / 2 / n;
            return  coeff * sum;
        }

        public static double CalculateSimpsonsIntergral(Interval interval, int n, FunctionDelegate f)
        {
            n *= 2;
            double h = GetStep(interval, n);
            double sum = 0;
            double x;

            for (int i = 1; i < n; i++)
            {
                x = interval.Left + i * h;
                if (i % 2 == 0)
                {
                    sum += 2 * f(x);
                }
                else
                {
                    sum += 4 * f(x);
                }
            }

            sum += f(interval.Left) + f(interval.Right);
            double coeff = (interval.Right - interval.Left) / 3 / n;
            return coeff * sum;
        }

        public static double GetError(double c, Interval interval, int n, int d, FunctionDelegate df)
        {
            var maxDf = GetMaxFunctionValue(interval, n, df);
            return c * Math.Pow(interval.Right - interval.Left, d + 2) / Math.Pow(n, d + 1) * maxDf;
        }

        public static double GetErrorForLeftRectangles(Interval interval, int n, FunctionDelegate df)
        {
            return GetError(CLeftRectangles, interval, n, ADALeftRectangles, df);
        }

        public static double GetErrorForTrapezoidIntegral(Interval interval, int n, FunctionDelegate df)
        {
            return GetError(CTrapezoid, interval, n, ADATrapezoid, df);
        }

        public static double GetErrorForSimpsonsIntegral(Interval interval, int n, FunctionDelegate df)
        {
            return GetError(CSimpsons, interval, n, ADASimpsons, df);
        }

        private static double GetMaxFunctionValue(Interval interval, int n, FunctionDelegate f)
        {
            return Double(interval.Left, interval.Right, (interval.Right - interval.Left) / n).Select(x => Math.Abs(f(x))).Max();
        }

        public static double GetMainError(double S2n, double Sn, int d)
        {
            return (S2n - Sn) / (Math.Pow(2, d + 1) - 1);
        }

        public static double GetMainErrorForLeftRectangles(double S2n, double Sn)
        {
            return GetMainError(S2n, Sn, ADALeftRectangles);
        }

        public static double GetMainErrorForTrapezoidIntegral(double S2n, double Sn)
        {
            return GetMainError(S2n, Sn, ADATrapezoid);
        }

        public static double GetMainErrorForSimpsonsIntegral(double S2n, double Sn)
        {
            return GetMainError(S2n, Sn, ADASimpsons);
        }

        public static double GetMainErrorForLeftRectangles(Interval interval, int n, FunctionDelegate f)
        {
            var Sn = CalculateLeftRectanglesIntegral(interval, n, f);
            var S2n = CalculateLeftRectanglesIntegral(interval, 2 * n, f);
            return GetMainErrorForLeftRectangles(S2n, Sn);
        }

        public static double GetMainErrorForTrapezoidIntegral(Interval interval, int n, FunctionDelegate f)
        {
            var Sn = CalcualteTrapezoidIntegral(interval, n, f);
            var S2n = CalcualteTrapezoidIntegral(interval, 2 * n, f);
            return GetMainErrorForTrapezoidIntegral(S2n, Sn);
        }

        public static double GetMainErrorForSimpsonsIntegral(Interval interval, int n, FunctionDelegate f)
        {
            var Sn = CalculateSimpsonsIntergral(interval, n, f);
            var S2n = CalculateSimpsonsIntergral(interval, 2 * n, f);
            return GetMainErrorForSimpsonsIntegral(S2n, Sn);
        }

        public static double GetAdjustedIntegral(double S2n, double Rmain)
        {
            return S2n + Rmain;
        }
    }
}
