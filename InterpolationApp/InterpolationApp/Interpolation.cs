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
        public List<double> Points { get; set; }

        /// <summary>
        /// Список значений функции в узлах интерполяции
        /// </summary>
        public List<double> Values { get; set; }

        /// <summary>
        /// Шаг для узлов интерполяции
        /// </summary>
        public double Step { get; set; }

        /// <summary>
        /// Отрезок, из которого берутся равностоящие значения узлов с шагом Step
        /// </summary>
        public Tuple<double, double> Segment { get; set; }

        /// <summary>
        /// Точность вычисления значений функции
        /// </summary>
        public double Precision { get; set; }

        /// <summary>
        /// Наивысший порядок для конечных разностей дельта
        /// </summary>
        public int DeltaDegree { get; set; }

        /// <summary>
        /// Делегат интерполируемой функции
        /// </summary>
        /// <param name="x">Вещественный аргумент функции</param>
        /// <returns></returns>
        public delegate double FunctionDelegate(double x);

        /// <summary>
        /// Списки конечных разностей порядка до DeltaDegree
        /// </summary>
        public List<List<double>> Deltas { get; set; }

        /// <summary>
        /// Интерполируемая функция
        /// </summary>
        public FunctionDelegate Function;

        public FunctionDelegate NFunction;

        public Interpolation(FunctionDelegate function, 
                             Tuple<double, double> segment, 
                             double step, 
                             double precision, 
                             int deltaDegree)
        {
            Function = function;
            Segment = segment;
            Step = step;
            Precision = precision;
            DeltaDegree = deltaDegree;

            GeneratePoints();
            GenerateValues();
            GenerateDeltas();
        }


        private void GeneratePoints()
        {
            Points = new List<double>();

            var n = Math.Round((Segment.Item2 - Segment.Item1) / Step) + 1;

            for (int i = 0; i < n; i++)
            {
                double p = Segment.Item1 + Step * i;
                Points.Add(p);
            }
        }

        private void GenerateValues()
        {
            Values = new List<double>();

            foreach (double p in Points)
            {
                Values.Add(TruncateValue(Precision, Function(p)));
            }
        }

        private void GenerateDeltas()
        {
            Deltas = new List<List<double>>();

            var deltas0 = new List<double>();
            for (int i = 0; i < Values.Count - 1; i++)
            {
                deltas0.Add(Values[i + 1] - Values[i]);
            }
            Deltas.Add(deltas0);

            for (int i = 1; i < DeltaDegree; i++)
            {
                var deltasI = new List<double>();
                for (int j = 0; j < Deltas[i - 1].Count - 1; j++)
                {
                    deltasI.Add((Deltas[i - 1][j + 1] - Deltas[i - 1][j]));
                }
                Deltas.Add(deltasI);
            }
        }
        
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

        public double TruncateValue(double precision, double value)
        {
            double revPrecision = 1 / Precision;
            return Math.Truncate(revPrecision * value) / revPrecision;
        }
    }
}
