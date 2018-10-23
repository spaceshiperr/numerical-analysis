using System;
using System.Collections.Generic;
using System.Linq;

namespace InterpolationApp4
{
    static class Differentiation
    {
        #region SinglePointDifferentiation

        /// <summary>
        /// Дифференцирование вправо в точке с погрешностью O(h)
        /// </summary>
        /// <param name="x">Значение точки</param>
        /// <param name="h">Шаг</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <returns>Значение прозводной функции в точке</returns>
        public static double DifferentiateRight(double x, double h, FunctionDelegate f)
        {
            return (f(x + h) - f(x)) / h;
        }

        /// <summary>
        /// Дифференцирование в обе стороны для интервала с погрешностью O(h^2)
        /// </summary>
        /// <param name="x">Значение точки</param>
        /// <param name="h">Шаг</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <returns>Значение прозводной функции в точке</returns>
        public static double DifferentiateBoth(double x, double h, FunctionDelegate f)
        {
            return (f(x + h) - f(x - h)) / 2 / h;
        }

        /// <summary>
        /// Дифференцирование влево с использованием второй производной
        /// </summary>
        /// <param name="x">Значение аргумента функции</param>
        /// <param name="h">Шаг</param>
        /// <param name="f">Делегат дифференциремой функции</param>
        /// <param name="d2f">Делегат производной второго порядка функции f</param>
        /// <returns>Значение производной в точке</returns>
        public static double DifferentiateLeft(double x, double h, double precision, FunctionDelegate f, FunctionDelegate d2f)
        {
            var xi = GetMaxAbsoluteFunction(new Tuple<double, double>(x, x + h), precision, d2f).Key;
            return (f(x) - f(x - h)) / h + h / 2 * d2f(xi);
        }

        /// <summary>
        /// Дифференцирование влево с использованием третьей производной
        /// </summary>
        /// <param name="x">Значение аргумента функции</param>
        /// <param name="h">Шаг для разбиения интервала</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <param name="d3f">Делегат производной третьего порядка функции f</param>
        /// <returns>Значение производной в точке</returns>
            
        public static double DifferentiateLeft2(double x, double h, double precision, FunctionDelegate f, FunctionDelegate d3f)
        {
            var xi = GetMaxAbsoluteFunction(new Tuple<double, double>(x, x + 2 * h), precision, d3f).Key;
            return (-3 * f(x) + 4 * f(x + h) - f(x + 2 * h)) / 2 / h + h * h * d3f(xi) / 3;
        }

        #endregion

        #region IntervalDifferentiation

        /// <summary>
        /// Дифференцирование вправо для интервала с погрешностью O(h)
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг для разбиения интервала</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <returns>Словарь из точек и значения производной в точке для всего интервала</returns>
        public static Dictionary<double, double> DifferentiateRight(Tuple<double, double> interval, double h, FunctionDelegate f)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, h).ToList().ForEach(x => derivatives.Add(x, DifferentiateRight(x, h, f)));

            return derivatives;
        }

        /// <summary>
        /// Дифференцирование в обе стороны для интервала с погрешностью O(h^2)
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг для разбиения интервала</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <returns>Словарь из точек и значения производной в точке для всего интервала</returns>
        public static Dictionary<double, double> DifferentiateBoth(Tuple<double, double> interval, double h, FunctionDelegate f)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, h).ToList().ForEach(x => derivatives.Add(x, DifferentiateBoth(x, h, f)));

            return derivatives;
        }
        
        /// <summary>
        /// Дифференцирование влево для интервала с использованием второй производной с оптимальным шагом
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг для разбиения интервала</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <param name="d2f">Делегат производной второго порядка функции f</param>
        /// <returns>Словарь из точек и значения производной в точке для всего интервала</returns>
        public static Dictionary<double, double> DifferentiateLeft(Tuple<double, double> interval, double h, double precision, FunctionDelegate f, FunctionDelegate d2f)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, h).ToList().ForEach(x => derivatives.Add(x, DifferentiateLeft(x, GetOptimalStep(x, h, precision, f, d2f, DifferentiateLeft), precision, f, d2f)));

            return derivatives;
        }

        /// <summary>
        /// Дифференцирование влево для интервала с использованием третьей производной с оптимальным шагом
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг разбиения интервала</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <param name="d3f">Делегат производной третьего порядка функции f</param>
        /// <returns>Словарь из точек и значения производной в точке для всего интервала</returns>
        public static Dictionary<double, double> DifferentiateLeft2(Tuple<double, double> interval, double h, double precision, FunctionDelegate f, FunctionDelegate d3f)
        {
            var derivatives = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, h).ToList().ForEach(x => derivatives.Add(x, DifferentiateLeft2(x, GetOptimalStep(x, h, precision, f, d3f, DifferentiateLeft2), precision, f, d3f)));

            return derivatives;
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Делегат дифференцируемой функции одной переменной
        /// </summary>
        /// <param name="x">Вещественный аргумент</param>
        /// <returns>Значение функции в точке x</returns>
        public delegate double FunctionDelegate(double x);

        /// <summary>
        /// Делегат метода дифференцирования
        /// </summary>
        /// <param name="x">Точка дифференцирования</param>
        /// <param name="h">Точность</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <param name="df">Производная f некоторого порядка</param>
        /// <returns>Значение первой производной в точке x</returns>
        public delegate double DifferentiateDelegate(double x, double h, double precision, FunctionDelegate f, FunctionDelegate df = null);

        #endregion

        #region AdditionalMethods

        /// <summary>
        /// Генерация упорядоченной структуры по границам и шагу
        /// </summary>
        /// <param name="from">Нижняя граница</param>
        /// <param name="to">Вержняя граница</param>
        /// <param name="h">Шаг</param>
        /// <returns>Упорядоченная структура вещественных чисел</returns>
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
        /// Вычисление значений функции в точках интервала
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг для интервала</param>
        /// <param name="f">Делегат функции</param>
        /// <returns>Список значений функции в точках интервала</returns>
        public static List<double> GetFunctionValues(Tuple<double, double> interval, double h, FunctionDelegate f)
        {
            return Double(interval.Item1, interval.Item2, h).Select(x => f(x)).ToList();
        }

        /// <summary>
        /// Поиск максимального значения функции на интервале
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг разбиения интервала</param>
        /// <param name="f">Делегат функции</param>
        /// <returns>Пару из точки и значения функции точке</returns>
        public static KeyValuePair<double, double> GetMaxAbsoluteFunction(Tuple<double, double> interval, double h, FunctionDelegate f)
        {
            return Double(interval.Item1, interval.Item2, h).Select(x => new KeyValuePair<double, double>(x, Math.Abs(f(x)))).OrderByDescending(pair => pair.Value).First();
        }

        /// <summary>
        /// Разность между векторами ожидаемых и полученных значений
        /// </summary>
        /// <param name="expected">Список ожидаемых вещественных значений</param>
        /// <param name="observed">Список полученных вещественных значений</param>
        /// <returns>Список из разности значений</returns>
        public static List<double> GetDifference(List<double> expected, List<double> observed)
        {
            return expected.Zip(observed, (x, y) => x - y).ToList();
        }

        /// <summary>
        /// Вычисление оптимального шага для вычисления производных
        /// </summary>
        /// <param name="x">Значение аргумента функции</param>
        /// <param name="h">Начальное значение шага</param>
        /// <param name="f">Делегат дифференцируемой функции</param>
        /// <param name="df">Делегат прозводной функции некоторого порядка</param>
        /// <param name="differentiate">Делегат выбранного метода дифференцирования</param>
        /// <returns>Значение оптимального шага для минимальной погрешности</returns>
        public static double GetOptimalStep(double x, double h, double precision, FunctionDelegate f, FunctionDelegate df, DifferentiateDelegate differentiate)
        {
            double prevDiff = df(x) - differentiate(x, h, precision, f, df);
            double diff = prevDiff;
            while (diff <= prevDiff)
            {
                h /= 2;
                prevDiff = diff;
                diff = df(x) - differentiate(x, h, precision, f, df);
            }
            return h * 2;
        }

        /// <summary>
        /// Вычисление максимальной погрешности для метода DifferentiateLeft2 в точке
        /// </summary>
        /// <param name="x">Значение аргумента функции</param>
        /// <param name="h">Шаг</param>
        /// <param name="precision">Точность epsilon</param>
        /// <param name="d3f">Делегат производной третьего порядка функции f</param>
        /// <returns>Значение максимальной погрешности в точке</returns>
        public static double GetErrorForDifferentiateLeft2(double x, double h, double precision, FunctionDelegate d3f)
        {
            var maxD3f = GetMaxAbsoluteFunction(new Tuple<double, double>(x, x + 2 * h), precision, d3f).Value;
            return 8 * precision / 2 / h + h * h * maxD3f / 3;
        }

        /// <summary>
        /// Вычисление максимальной погрешности для метода DifferentiateLeft2 в точке
        /// </summary>
        /// <param name="interval">Интервал точек</param>
        /// <param name="h">Шаг разбиения интервала</param>
        /// <param name="precision">Точность epsilon</param>
        /// <param name="d3f">Делегат производной третьего порядка функции f</param>
        /// <returns>Словарь из точки и значения максимальной погрешности в точке</returns>
        public static Dictionary<double, double> GetErrorForDifferentiateLeft2(Tuple<double, double> interval, double h, double precision, FunctionDelegate d3f)
        {
            var errors = new Dictionary<double, double>();

            Double(interval.Item1, interval.Item2, h).ToList().ForEach(x => errors.Add(x, GetErrorForDifferentiateLeft2(x, h, precision, d3f)));

            return errors;
        }

        #endregion
    }
}
