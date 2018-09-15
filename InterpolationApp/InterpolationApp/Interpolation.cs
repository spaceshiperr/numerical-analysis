using System;
using System.Collections.Generic;

namespace InterpolationApp
{
    public static class Interpolation
    {
        /// <summary>
        /// Делегат интерполируемой функции
        /// </summary>
        /// <param name="x">Вещественный аргумент функции</param>
        /// <returns>Значение функции в точке x</returns>
        public delegate double FunctionDelegate(double x);

        public delegate double NFunctionDelegate(double x, double prevN);

        /// <summary>
        /// Вычисление координат равностоящих интерполяционных узлов
        /// </summary>
        /// <param name="segment">Пара из координат начальной и конечной точек отрезка</param>
        /// <param name="step">Шаг для равностоящих узлов</param>
        /// <returns>Список вещественных узлов из отрезка segment, отстоящих друг от друга на step</returns>
        public static List<double> GetPoints(Tuple<double, double> segment, double step)
        {
            if (segment.Item1 > segment.Item2)
                throw new ArgumentException("Left coordinate of the segment must not be greater than the right!");
            else if (segment.Item2 - segment.Item1 < step)
                throw new ArgumentException("Step must be smaller than the length of the segment");

            var points = new List<double>();

            var n = Math.Round((segment.Item2 - segment.Item1) / step) + 1;

            for (int i = 0; i < n; i++)
            {
                double p = segment.Item1 + step * i;
                points.Add(p);
            }

            return points;
        }

        /// <summary>
        /// Вычисление значений функции в интерполяционных узлах
        /// </summary>
        /// <param name="function">Интерполируемая функция f: R -> R</param>
        /// <param name="points">Список узлов - параметров функции</param>
        /// <param name="precision">Точность вычисления</param>
        /// <returns>Список значений функции в узлах</returns>
        public static List<double> GetValues(FunctionDelegate function, List<double> points, double precision)
        {
            var values = new List<double>();
            points.ForEach(p => values.Add((Truncate(precision, function(p)))));
            return values;
        }

        /// <summary>
        /// Вычисление конечных разностей
        /// </summary>
        /// <param name="values">Список значений функции в узлах интерполяции</param>
        /// <param name="degree">Необходимый наивысший порядок для конечных разностей</param>
        /// <returns>Список из разностей порядков 0..degree</returns>
        public static List<List<double>> GetDeltas(List<double> values, int degree)
        {
            var deltas = new List<List<double>>();

            var deltas0 = new List<double>();
            for (int i = 0; i < values.Count - 1; i++)
            {
                deltas0.Add(values[i + 1] - values[i]);
            }
            deltas.Add(deltas0);

            if (degree < 0)
                throw new ArgumentException("Degree must be non-negative!");
            else if (degree == 0)
                return deltas;

            for (int i = 1; i < degree; i++)
            {
                var deltasI = new List<double>();
                for (int j = 0; j < deltas[i - 1].Count - 1; j++)
                {
                    deltasI.Add((deltas[i - 1][j + 1] - deltas[i - 1][j]));
                }
                deltas.Add(deltasI);
            }

            return deltas;
        }
        
        /// <summary>
        /// Генерирование списка из делегатов вспомогательных рекурсивных функций Nk(t)
        /// </summary>
        /// <param name="k">Необходимый наивысший порядок для системы функций</param>
        /// <returns>Список делегатов функций double -> double</returns>
        public static List<NFunctionDelegate> GenerateNFunctions(int k)
        {
            var NFunctions = new List<NFunctionDelegate>
            {
                (t, prevN) => 1,
                (t, prevN) => t
            };

            if (k < 0)
                throw new ArgumentException("Number k must be non-negative!");
            else if (k <= 1)
                return NFunctions;


            for (int i = 2; i <= k; i++)
            {
                NFunctions.Add((t, prevN) =>  prevN * (t - i + 1) / i);
            }
            return NFunctions;
        }

        /// <summary>
        /// Округление значений с необходимой точностью 
        /// </summary>
        /// <param name="precision">Число знаков после запятой</param>
        /// <param name="value">Округляемое значение</param>
        /// <returns>Округленное значение</returns>
        public static double Truncate(double precision, double value)
        {
            double revPrecision = 1 / precision;
            return Math.Truncate(revPrecision * value) / revPrecision;
        }

        /// <summary>
        /// Generate the formulas for recursive Nk(t) functions
        /// </summary>
        /// <param name="k">Required highest degree of the system of functions</param>
        /// <param name="t">String representation of the argument</param>
        /// <returns>Formulas for Nk(t)</returns>
        public static List<string> GenerateFormulaNFunctions(int k, string t)
        {
            var NFunctions = new List<string>();

            if (k < 0)
                throw new ArgumentException("Number k must be non-negative!");

            NFunctions.Add("1");

            if (k == 0)
                return NFunctions;

            NFunctions.Add(t);

            if (k == 1)
                return NFunctions;

            string numerator = t;
            var denominator = 1;

            for (int i = 2; i <= k; i++)
            {
                numerator += " * (" + t + (-i + 1).ToString() + ")";
                denominator *= i;
                NFunctions.Add(numerator + " / " + denominator.ToString());
            }

            return NFunctions;
        }

        public static List<double> Interpolate(double x, List<double> values, List<double> points, int k)
        {
            var approxValues = new List<double>();

            double prevP = 0;
            double prevN = 1;
            var deltas = GetDeltas(values, k);
            deltas.Insert(0, values);
            var nFunctions = GenerateNFunctions(k);

            //N for k = 2 isn't right for some reason
            for (int i = 0; i <= k; i++)
            {
                prevN = nFunctions[i](x, prevN);
                prevP = prevP + prevN * deltas[i][0];
                approxValues.Add(prevP);
            }

            return approxValues;
        }
    }
}
