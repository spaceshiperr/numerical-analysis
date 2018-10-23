using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterpolationApp4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillDerivativeGrid();
        }

        private void FillDerivativeGrid()
        {
            Differentiation.FunctionDelegate f = ((x) => Math.Exp(3 * x));
            Differentiation.FunctionDelegate df = ((x) => 3 * f(x));
            Differentiation.FunctionDelegate d2f = ((x) => 9 * f(x));
            Differentiation.FunctionDelegate d3f = ((x) => 27 * f(x));

            var interval = new Tuple<double, double>(0, 1);
            var h = 0.1;
            var precision = 5E-06;

            var points = Differentiation.Double(interval.Item1, interval.Item2, h).ToList();
            var values = Differentiation.GetFunctionValues(interval, h, f);
            var derivatives = Differentiation.GetFunctionValues(interval, h, df);

            var rightDerivatives = Differentiation.DifferentiateRight(interval, h, f).Values.ToList();
            var rightDerivativesError = Differentiation.GetDifference(derivatives, rightDerivatives);

            var bothDerivatives = Differentiation.DifferentiateBoth(interval, h, f).Values.ToList();
            var bothDerivativesError = Differentiation.GetDifference(derivatives, bothDerivatives);

            var leftDerivatives = Differentiation.DifferentiateLeft2(interval, h, precision, f, df).Values.ToList();
            var leftDerivativesError = Differentiation.GetDifference(derivatives, leftDerivatives);
            var leftDerivativesMaxError = Differentiation.GetErrorForDifferentiateLeft2(interval, h, precision, d3f).Values.ToList();
            var expectedOptimalStep = points.Select(x => 2 * Math.Sqrt(precision / Differentiation.GetMaxAbsoluteFunction(interval, h, d2f).Value)).ToList();
            var observedOptimalStep = points.Select(x => Differentiation.GetOptimalStep(x, h, precision, f, d3f, Differentiation.DifferentiateLeft2)).ToList();

            for (int i = 0; i < points.Count; i++)
            {
                DerivativeGrid.Rows.Add(points[i], values[i], derivatives[i], 
                                        rightDerivatives[i], rightDerivativesError[i], 
                                        bothDerivatives[i], bothDerivativesError[i], 
                                        leftDerivatives[i], leftDerivativesError[i], 
                                        leftDerivativesMaxError[i], expectedOptimalStep[i],
                                        observedOptimalStep[i]);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Численное дифференцирование функции e^(3x) на [0, 1] с шагом 0.1 и точностью 5E-06");
        }
    }
}
