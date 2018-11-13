using System;
using System.Collections.Generic;

namespace InterpolationApp6
{
    /// <summary>
    /// Interval class for interpolation methods
    /// </summary>
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

    /// <summary>
    /// Integration class based on numeric analysis methods
    /// </summary>
    public static class Integration
    {
        /// <summary>
        /// Function delegate for one argument function
        /// </summary>
        /// <param name="x">Argument value</param>
        /// <returns>Function value in x</returns>
        public delegate double FunctionDelegate(double x);

        #region Constants

        // Algebraic Degree Of Accuracy For Quadratic Formulas
        public static readonly int DLeftRectangles = 0;
        public static readonly int DTrapezoid = 1;
        public static readonly int DSimpsons = 3;
        public static readonly int DRightRectangles = 1;

        // Constants for error calculation
        public static readonly double CLeftRectangles = 0.5;
        public static readonly double CTrapezoid = 1 / 12;
        public static readonly double CSimpsons = 1 / 2880;

        #endregion

        #region IntervalMethods

        /// <summary>
        /// Generates IEnumerable sequence
        /// </summary>
        /// <param name="from">Starting point</param>
        /// <param name="to">Finishing point</param>
        /// <param name="h">Step</param>
        /// <returns>IEnumerable with points</returns>
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

        /// <summary>
        /// Calculates the step for interval partition
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <returns>Step for the partition</returns>
        private static double GetStep(Interval interval, double n)
        {
            return (interval.Right - interval.Left) / n;
        }

        #endregion

        #region CalculateIntegral

        /// <summary>
        /// Calculates the integral by rectangles method
        /// </summary>
        /// <param name="interval">Interval of points for function arguments</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="h">Step calculated for interval and n</param>
        /// <param name="alpha">Parameter specific for left/right/middle rectangles method</param>
        /// <param name="f">Function delegate of under integral function</param>
        /// <returns>Calculated integral value</returns>
        public static double CalculateRectanglesIntegral(Interval interval, int n, double h, double alpha, FunctionDelegate f)
        {
            double sum = 0;
            double x;

            for (int i = 0; i < n; i++)
            {
                x = alpha + i * h;
                sum += f(x);
            }
            return h * sum;
        }

        /// <summary>
        /// Calculates the integral by left rectangles method
        /// </summary>
        /// <param name="interval">Interval of points for function arguments</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="f">Function delegate of under integral function</param>
        /// <returns>The calculated value of the integral</returns>
        public static double CalculateLeftRectanglesIntegral(Interval interval, int n, FunctionDelegate f)
        {
            double h = GetStep(interval, n);
            return CalculateRectanglesIntegral(interval, n, h, interval.Left, f);
        }

        /// <summary>
        /// Calculates the integral by right rectangles method
        /// </summary>
        /// <param name="interval">Interval of points for function arguments</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="f">Function delegate of under integral function</param>
        /// <returns>The calculated value of the integral</returns>
        public static double CalculateRightRectanglesIntegral(Interval interval, int n, FunctionDelegate f)
        {
            double h = GetStep(interval, n);
            return CalculateRectanglesIntegral(interval, n, h, interval.Left + h, f);
        }

        /// <summary>
        /// Calculates the integral by middle rectangles method
        /// </summary>
        /// <param name="interval">Interval of points for function arguments</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="f">Function delegate of under integral function</param>
        /// <returns>The calculated value of the integral</returns>
        public static double CalculateMiddleRectanglesIntegral(Interval interval, int n, FunctionDelegate f)
        {
            double h = GetStep(interval, n);
            return CalculateRectanglesIntegral(interval, n, h, interval.Left + h / 2, f);
        }

        /// <summary>
        /// Calculates the integral by trapezoid method
        /// </summary>
        /// <param name="interval">Interval of points for function arguments</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="f">Function delegate of under integral function</param>
        /// <returns>The calculated value of the integral</returns>
        public static double CalcualteTrapezoidIntegral(Interval interval, int n, FunctionDelegate f)
        {
            double h = GetStep(interval, n);
            double sum = 0;
            double x;
            
            for (int i = 1; i < n; i++)
            {
                x = interval.Left + i * h;
                sum += f(x);
            }

            sum = sum * 2 + f(interval.Left) + f(interval.Right);
            double coeff = (interval.Right - interval.Left) / 2 / n;
            return  coeff * sum;
        }

        /// <summary>
        /// Calculates the integral by Simpsons method
        /// </summary>
        /// <param name="interval">Interval of points for function arguments</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="f">Function delegate of under integral function</param>
        /// <returns>The calculated value of the integral</returns>
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

        /// <summary>
        /// Get adjusted integral value
        /// </summary>
        /// <param name="S2n">Sum for chosen method with N = 2 * n</param>
        /// <param name="Rmain">Main error</param>
        /// <returns>Adjusted integral</returns>
        public static double GetAdjustedIntegral(double S2n, double Rmain)
        {
            return S2n + Rmain;
        }

        #endregion

        #region Errors

        /// <summary>
        /// Get Rn error for chosen method
        /// </summary>
        /// <param name="c">Constant specific for the chosen method</param>
        /// <param name="interval">Interval of points for function's argument</param>
        /// <param name="n">Number of segments the interval is partitioned</param>
        /// <param name="d">Algebraic degree of accuracy specific for the method</param>
        /// <param name="maxDf">Function maximum on the given interval of absolute values of under integral sign function derivative with degree of (d + 1)</param>
        /// <returns>Calculated error for the chosen method</returns>
        public static double GetError(double c, Interval interval, int n, int d, double maxDf)
        {
            return c * Math.Pow(interval.Right - interval.Left, d + 2) / Math.Pow(n, d + 1) * maxDf;
        }

        /// <summary>
        /// Get Rn error for left rectangles method
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments after interval partition</param>
        /// <param name="maxDf">Function maximum on the given interval of absolute values of under integral sign function derivative with degree of 1</param>
        /// <returns>Calculated error</returns>
        public static double GetErrorForLeftRectangles(Interval interval, int n, double maxDf)
        {
            return GetError(CLeftRectangles, interval, n, DLeftRectangles, maxDf);
        }

        /// <summary>
        /// Get Rn error for trapezoid method
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments after interval partition</param>
        /// <param name="maxDf">Function maximum on the given interval of absolute values of under integral sign function derivative with degree of 2</param>
        /// <returns>Calculated error</returns>
        public static double GetErrorForTrapezoidIntegral(Interval interval, int n, double maxDf)
        {
            return GetError(CTrapezoid, interval, n, DTrapezoid, maxDf);
        }

        /// <summary>
        /// Get Rn error for Simpsons method
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments after interval partition</param>
        /// <param name="maxDf">Function maximum on the given interval of absolute values of under integral sign function derivative with degree of 4</param>
        /// <returns>Calculated error</returns>
        public static double GetErrorForSimpsonsIntegral(Interval interval, int n, double maxDf)
        {
            return GetError(CSimpsons, interval, n, DSimpsons, maxDf);
        }

        /// <summary>
        /// Get Rmain for chosen method
        /// </summary>
        /// <param name="S2n">Calculated sum by this method for N = 2 * n</param>
        /// <param name="Sn">Calculated sum by this method for N = n</param>
        /// <param name="d">Algebraic degree of accuracy specific for the method</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainError(double S2n, double Sn, int d)
        {
            return (S2n - Sn) / (Math.Pow(2, d + 1) - 1);
        }

        /// <summary>
        /// Get Rmain for left rectangles method
        /// </summary>
        /// <param name="S2n">Calculated sum for N = 2 * n</param>
        /// <param name="Sn">Calculated sum for N = n</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainErrorForLeftRectangles(double S2n, double Sn)
        {
            return GetMainError(S2n, Sn, DLeftRectangles);
        }

        /// <summary>
        /// Get Rmain for trapezoid method
        /// </summary>
        /// <param name="S2n">Calculated sum for N = 2 * n</param>
        /// <param name="Sn">Calculated sum for N = n</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainErrorForTrapezoidIntegral(double S2n, double Sn)
        {
            return GetMainError(S2n, Sn, DTrapezoid);
        }

        /// <summary>
        /// Get Rmain for Simpsons method
        /// </summary>
        /// <param name="S2n">Calculated sum for N = 2 * n</param>
        /// <param name="Sn">Calculated sum for N = n</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainErrorForSimpsonsIntegral(double S2n, double Sn)
        {
            return GetMainError(S2n, Sn, DSimpsons);
        }

        /// <summary>
        /// Get Rmain for left rectangles method
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments after interval partition</param>
        /// <param name="f">Function delegate of under integral sign function</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainErrorForLeftRectangles(Interval interval, int n, FunctionDelegate f)
        {
            var Sn = CalculateLeftRectanglesIntegral(interval, n, f);
            var S2n = CalculateLeftRectanglesIntegral(interval, 2 * n, f);
            return GetMainErrorForLeftRectangles(S2n, Sn);
        }

        /// <summary>
        /// Get Rmain for trapezoid method
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments after interval partition</param>
        /// <param name="f">Function delegate of under integral sign function</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainErrorForTrapezoidIntegral(Interval interval, int n, FunctionDelegate f)
        {
            var Sn = CalcualteTrapezoidIntegral(interval, n, f);
            var S2n = CalcualteTrapezoidIntegral(interval, 2 * n, f);
            return GetMainErrorForTrapezoidIntegral(S2n, Sn);
        }

        /// <summary>
        /// Get Rmain for Simpsons method
        /// </summary>
        /// <param name="interval">Interval of points</param>
        /// <param name="n">Number of segments after interval partition</param>
        /// <param name="f">Function delegate of under integral sign function</param>
        /// <returns>Calculated main error</returns>
        public static double GetMainErrorForSimpsonsIntegral(Interval interval, int n, FunctionDelegate f)
        {
            var Sn = CalculateSimpsonsIntergral(interval, n, f);
            var S2n = CalculateSimpsonsIntergral(interval, 2 * n, f);
            return GetMainErrorForSimpsonsIntegral(S2n, Sn);
        }

        #endregion
    }
}
