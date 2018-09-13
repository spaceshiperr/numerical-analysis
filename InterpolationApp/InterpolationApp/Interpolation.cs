using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace InterpolationApp
{
    public class Interpolation
    {
        /// <summary>
        /// Список узлов интерполяции
        /// </summary>
        //public List<double> Points { get; set; }

        /// <summary>
        /// Список значений функции в узлах интерполяции
        /// </summary>
        //public List<double> Values { get; set; }

        /// <summary>
        /// Шаг для узлов интерполяции
        /// </summary>
        //public double Step { get; set; }

        /// <summary>
        /// Отрезок, из которого берутся равностоящие значения узлов с шагом Step
        /// </summary>
        //public Tuple<double, double> Segment { get; set; }

        /// <summary>
        /// Точность вычисления значений функции
        /// </summary>
        //public double Precision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public int DeltaDegree { get; set; }

        /// <summary>
        /// Делегат интерполируемой функции
        /// </summary>
        /// <param name="x">Вещественный аргумент функции</param>
        /// <returns></returns>
        public delegate double FunctionDelegate(double x);

        /// <summary>
        /// Списки конечных разностей порядка до DeltaDegree
        /// </summary>
        //public List<List<double>> Deltas { get; set; }

        /// <summary>
        /// Интерполируемая функция
        /// </summary>
        //public FunctionDelegate Function;

        public Interpolation(FunctionDelegate function, 
                             Tuple<double, double> segment, 
                             double step, 
                             double precision, 
                             int deltaDegree)
        {
            //Function = function;
            //Segment = segment;
            //Step = step;
            //Precision = precision;
            //DeltaDegree = deltaDegree;

            //GeneratePoints();
            //GenerateValues();
            //GenerateDeltas();
        }

        /// <summary>
        /// Вычисление координат равностоящих интерполяционных узлов
        /// </summary>
        /// <param name="segment">Пара из координат начальной и конечной точек отрезка</param>
        /// <param name="step">Шаг для равностоящих узлов</param>
        /// <returns>Список вещественных узлов из отрезка segment, отстоящих друг от друга на step</returns>
        private List<double> GetPoints(Tuple<double, double> segment, double step)
        {
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
        private List<double> GetValues(FunctionDelegate function, List<double> points, double precision)
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
        private List<List<double>> GetDeltas(List<double> values, int degree)
        {
            var deltas = new List<List<double>>();

            var deltas0 = new List<double>();
            for (int i = 0; i < values.Count - 1; i++)
            {
                deltas0.Add(values[i + 1] - values[i]);
            }
            deltas.Add(deltas0);

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
        private List<FunctionDelegate> GenerateNFunctions(int k)
        {
            var NFunctions = new List<FunctionDelegate>
            {
                t => 1,
                t => t
            };

            for (int i = 2; i <= k; i++)
            {
                NFunctions.Add(t => NFunctions[NFunctions.Count - 1](t) * (t - i + 1) / k);
            }
            return NFunctions;
        }

        /// <summary>
        /// Округление значений с необходимой точностью 
        /// </summary>
        /// <param name="precision">Число знаков после запятой</param>
        /// <param name="value">Округляемое значение</param>
        /// <returns>Округленное значение</returns>
        public double Truncate(double precision, double value)
        {
            double revPrecision = 1 / precision;
            return Math.Truncate(revPrecision * value) / revPrecision;
        }

        //public double Interpolate(double x, int n)
        //{
        //    var NFunctions = GenerateNFunctions(n);

        //}
    }
}
