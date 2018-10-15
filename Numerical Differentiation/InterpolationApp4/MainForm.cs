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
            Differentiation.FunctionDelegate function = ((x) => Math.Exp(3 * x));
            Differentiation.FunctionDelegate functionFirstDerivative = ((x) => 3 * Math.Exp(3 * x));
            Differentiation.FunctionDelegate functionSecondDerivative = ((x) => 9 * Math.Exp(3 * x));

            var interval = new Tuple<double, double>(0, 1);
            var step = 0.1;

            var points = Differentiation.Double(interval.Item1, interval.Item2, step).ToList();
            var values = Differentiation.GetFunctionValues(interval, step, function);
            var derivatives = Differentiation.GetFunctionValues(interval, step, functionFirstDerivative);

            var rightDerivatives = Differentiation.DifferentiateRight(interval, step, function);
            var rightDerivativesError = Differentiation.GetDifference(derivatives, rightDerivatives.Values.ToList());

            var bothDerivatives = Differentiation.DifferentiateBoth(interval, step, function);
            var bothDerivativesError = Differentiation.GetDifference(derivatives, bothDerivatives.Values.ToList());

            var leftDerivatives = Differentiation.DifferentiateLeft(interval, step, function, functionFirstDerivative);
            var leftDerivativesError = Differentiation.GetDifference(derivatives, leftDerivatives.Values.ToList());

            for (int i = 0; i < points.Count; i++)
            {
                DerivativeGrid.Rows.Add(points[i], values[i], derivatives[i], 
                                        rightDerivatives.Values.ToList()[i], rightDerivativesError[i], 
                                        bothDerivatives.Values.ToList()[i], bothDerivativesError[i], 
                                        leftDerivatives.Values.ToList()[i], leftDerivativesError[i]);
            }
        }
    }
}
