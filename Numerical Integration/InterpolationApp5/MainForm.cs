using System;
using System.Windows.Forms;

namespace InterpolationApp5
{
    public partial class MainForm : Form
    {
        private delegate double FunctionDelegate(int x);

        private static double Factorial(int n)
        {
            double RecursiveFactorial(int count, double result)
            {
                if (count != 1) RecursiveFactorial(count - 1, result * count);
                return result;
            }

            return RecursiveFactorial(n, 1);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // function under integral sign
            Integrals.FunctionDelegate function = (x => 1 / (x * x + 5));
            // upper and lower bounds for the definite interval
            Interval interval = new Interval(0, 1);
            // expected value of the integral of the function on interval above
            double integral = Math.Atan(1 / Math.Sqrt(5)) / Math.Sqrt(5);
            // supremum of under integral function's derivative of degree k
            FunctionDelegate derivativeUpper = (k => Factorial(k) / Math.Pow(Math.Sqrt(5), k + 2));
            // desired number of segments after interval partition
            int N = 2;

            labelIntegralFunction.Text = "int of  1 / (x * x + 5) on [0, 1]";
            labelIntegral.Text = integral.ToString();

            FillDataGrid(function, interval, integral, derivativeUpper, N);
        }

        private void FillDataGrid(Integrals.FunctionDelegate function, Interval interval, double integral, FunctionDelegate derivativeUpper, int N)
        {
            var sumNLeftTriangles = Integrals.CalculateLeftRectanglesIntegral(interval, N, function);
            var sum2NLeftTriangles = Integrals.CalculateLeftRectanglesIntegral(interval, 2 * N, function);
            var sumNTrapezoid = Integrals.CalcualteTrapezoidIntegral(interval, N, function);
            var sum2NTrapezoid = Integrals.CalcualteTrapezoidIntegral(interval, 2 * N, function);
            var sumNSimpsons = Integrals.CalculateSimpsonsIntergral(interval, N, function);
            var sum2NSimpsons = Integrals.CalculateSimpsonsIntergral(interval, 2 * N, function);

            var errorLeftTriangles = Integrals.GetErrorForLeftRectangles(interval, N, derivativeUpper(Integrals.DLeftRectangles + 1));
            var errorTrapezoid = Integrals.GetErrorForTrapezoidIntegral(interval, N, derivativeUpper(Integrals.DTrapezoid + 1));
            var errorSimpsons = Integrals.GetErrorForSimpsonsIntegral(interval, N, derivativeUpper(Integrals.DSimpsons + 1));
            var error2LeftTriangles = Integrals.GetErrorForLeftRectangles(interval, 2 * N, derivativeUpper(Integrals.DLeftRectangles + 1));
            var error2Trapezoid = Integrals.GetErrorForTrapezoidIntegral(interval, 2 * N, derivativeUpper(Integrals.DTrapezoid + 1));
            var error2Simpsons = Integrals.GetErrorForSimpsonsIntegral(interval, 2 * N, derivativeUpper(Integrals.DSimpsons + 1));

            var errorMainLeftTriangles = Integrals.GetMainErrorForLeftRectangles(sum2NLeftTriangles, sumNLeftTriangles);
            var errorMainTrapezoid = Integrals.GetMainErrorForTrapezoidIntegral(sum2NTrapezoid, sumNTrapezoid);
            var errorMainSimpsons = Integrals.GetMainErrorForSimpsonsIntegral(sum2NSimpsons, sumNSimpsons);

            var iAdLeftTriangles = Integrals.GetAdjustedIntegral(sum2NLeftTriangles, errorMainLeftTriangles);
            var iAdTrapezoid = Integrals.GetAdjustedIntegral(sum2NTrapezoid, errorMainTrapezoid);
            var iAdSimpsons = Integrals.GetAdjustedIntegral(sum2NSimpsons, errorMainSimpsons);

            dataGrid.Rows.Add("Left rect", sumNLeftTriangles, integral - sumNLeftTriangles, errorLeftTriangles, 
                              sum2NLeftTriangles, integral - sum2NLeftTriangles, error2LeftTriangles, 
                              errorMainLeftTriangles, iAdLeftTriangles, integral - iAdLeftTriangles);

            dataGrid.Rows.Add("Trapezoid", sumNTrapezoid, integral - sumNTrapezoid, errorTrapezoid,
                             sum2NTrapezoid, integral - sum2NTrapezoid, error2Trapezoid,
                             errorMainTrapezoid, iAdTrapezoid, integral - iAdTrapezoid);

            dataGrid.Rows.Add("Simpson", sumNSimpsons, integral - sumNSimpsons, errorSimpsons,
                             sum2NSimpsons, integral - sum2NSimpsons, error2Simpsons,
                             errorMainSimpsons, iAdSimpsons, integral - iAdSimpsons);
        }
    }
}
