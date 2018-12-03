using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterpolationApp6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // int of cos(x)/(x^(1/3)) on [0,1]

            var intValue = 1.32122;

            var interval = new Interval(0, 1);
            int n = 2;
            Integration.FunctionDelegate phi = (x => Math.Cos(x) / Math.Pow(x, 1 / 3));

            var intByMiddleRectangles = Integration.CalculateMiddleRectanglesIntegral(interval, n, phi);

            var Ak = new List<double> { 1.74682, 0.881834, 0.371351 };
            var points = new List<double> { 0.037857, 0.41241, 0.86224 };
            Integration.FunctionDelegate f = (x => Math.Cos(x) * Math.Pow(x, 1 / 3));

            var intByGaussType = Integration.CalculateInterpolationIntegral(points, Ak, f);
            var intByGauss = Integration.CalculateGaussianIntegral(f);

            var interpolatedInt = Integration.CalculateInterpolationIntegral(new List<double> { 0.25, 0.75 }, new List<double> { 3, 0 }, f);

            FillIntGridView(intValue, intByMiddleRectangles, interpolatedInt, intByGauss, intByGaussType);
        }

        private void FillIntGridView(double intValue, double intByMiddleRectangles, double interpolatedInt, double intByGauss, double intByGaussType)
        {
            intGridView.Rows.Add("Exact", intValue, 0);
            intGridView.Rows.Add("Middle rect", intByMiddleRectangles, intValue - intByMiddleRectangles);
            intGridView.Rows.Add("Interpolation formula", interpolatedInt, intValue - interpolatedInt);
            intGridView.Rows.Add("Gauss formula", intByGauss, intValue - intByGauss);
            intGridView.Rows.Add("Gauss type formula", intByGaussType, intValue - intByGaussType);
        }
    }
}
