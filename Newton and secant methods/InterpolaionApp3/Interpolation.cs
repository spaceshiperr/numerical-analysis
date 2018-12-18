using System;
using System.Collections.Generic;
using System.Linq;

namespace InterpolaionApp3
{
    public static class Interpolation
    {
        public delegate double FunctionDelegate(double x);

        public static List<Tuple<double, int>> GetRootsBySecantMethod(List<Tuple<double, double>> intervals,
                                                                double precision,
                                                                FunctionDelegate function,
                                                                FunctionDelegate functionDerivate,
                                                                int KMax)
        {
            return intervals.Select(interval => GetRootBySecantMethod(interval.Item1 + (interval.Item2 - interval.Item1) / 4,
                                                                        interval.Item1 + (interval.Item2 - interval.Item1) / 2,
                                                                        precision,
                                                                        function,
                                                                        functionDerivate,
                                                                        KMax)).ToList();
        }

        public static List<Tuple<double, int>> GetRootsByNewton(List<Tuple<double, double>> intervals,
                                                          double precision,
                                                          FunctionDelegate function,
                                                          FunctionDelegate functionDerivate,
                                                          int KMax)
        {
            return intervals.Select(interval => GetRootByNewton(interval.Item1 + (interval.Item2 - interval.Item1) / 2, precision, function, functionDerivate, KMax)).ToList();
        }

        public static List<Tuple<double, int>> GetRootsByNewton2(List<Tuple<double, double>> intervals,
                                                           double precision,
                                                           FunctionDelegate function,
                                                           FunctionDelegate functionDerivate,
                                                           int KMax)
        {
            return intervals.Select(interval => GetRootByNewton2(interval.Item1 + (interval.Item2 - interval.Item1) / 2, precision, function, functionDerivate, KMax)).ToList();
        }


        public static Tuple<double, int> GetRootBySecantMethod(double x0, double x1, double precision, FunctionDelegate function, FunctionDelegate functionDerivate, int KMax)
        {
            double x = 0;
            int count = 0;

            while (Math.Abs(x1 - x0) > precision && count < KMax)
            {
                x = x1 - function(x1) * (x1 - x0) / (function(x1) - function(x0));
                x0 = x1;
                x1 = x;
                count++;
            }
            return new Tuple<double, int>(x, count);
        }

        public static Tuple<double, int> GetRootByNewton(double x, double precision, FunctionDelegate function, FunctionDelegate functionDerivate, int KMax)
        {
            double prevX = 0;
            int count = 0;

            while (Math.Abs(x - prevX) > precision && count < KMax)
            {
                prevX = x;
                x -= function(x) / functionDerivate(x);
                count++;
            }

            return new Tuple<double, int>(x, count);
        }

        public static Tuple<double, int> GetRootByNewton2(double x, double precision, FunctionDelegate function, FunctionDelegate functionDerivate, int KMax)
        {
            double x0 = x;
            double prevX = 0;
            int count = 0;

            while (Math.Abs(x - prevX) > precision && count < KMax)
            {
                prevX = x;
                x -= function(x) / functionDerivate(x0);
                count++;
            }

            return new Tuple<double, int>(x, count);
        }

        public static List<Tuple<double, double>> LocateRoots(Tuple<double, double> interval, double precision, double step, FunctionDelegate function)
        {
            var roots = new List<Tuple<double, double>>();
            var count = Math.Round((interval.Item2 - interval.Item1) / step);

            for (int i = 0; i < count - 1; i++)
            {
                var a = interval.Item1 + i * step;
                var b = interval.Item1 + (i + 1) * step;

                if (function(a) * function(b) < 0)
                {
                    roots.Add(LocateRoot(new Tuple<double, double>(a, b), precision, function));
                }
            }
            return roots;
        }

        public static Tuple<double, double> LocateRoot(Tuple<double, double> interval, double precision, FunctionDelegate function)
        {
            var a = interval.Item1;
            var b = interval.Item2;
            double c = 0;

            while (Math.Abs(b - a) > precision)
            {
                c = (a + b) / 2;

                if (function(a) * function(c) < 0)
                {
                    b = c;
                }
                else if (function(c) * function(b) < 0)
                {
                    a = c;
                }
            }
            return new Tuple<double, double>(a, b);
        }
    }
}
