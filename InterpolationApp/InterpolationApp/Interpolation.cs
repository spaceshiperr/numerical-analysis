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
        public ArrayList Points { get; set; }

        /// <summary>
        /// Список значений функции в узлах интерполяции
        /// </summary>
        public ArrayList Values { get; set; }

        /// <summary>
        /// Шаг для узлов интерполяции
        /// </summary>
        public double Step { get; set; }

        /// <summary>
        /// Отрезок, из которого берутся равностоящие значения узлов с шагом Step
        /// </summary>
        public Tuple<double, double> Segment { get; set; }

        /// <summary>
        /// Делегат интерполируемой функции
        /// </summary>
        /// <param name="x">Вещественный аргумент функции</param>
        /// <returns></returns>
        public delegate double FunctionDelegate(double x);

        /// <summary>
        /// Интерполируемая функция
        /// </summary>
        public FunctionDelegate Function;

        public Interpolation(FunctionDelegate function, 
                             Tuple<double, double> segment, 
                             double step)
        {
            Function = function;
            Segment = segment;
            Step = step;

            GeneratePoints();
            GenerateValues();
        }


        private void GeneratePoints()
        {
            Points = new ArrayList();

            double lastPoint = Segment.Item1;

            while (lastPoint <= Segment.Item2)
            {
                Points.Add(lastPoint);
                lastPoint += Step;
            }
        }

        private void GenerateValues()
        {
            Values = new ArrayList();

            foreach (double p in Points)
            {
                Values.Add(Function(p));
            }
        }

    }
}
