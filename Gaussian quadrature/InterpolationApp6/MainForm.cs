using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var integral = 1.32122;

            var interval = new Interval(0, 1);
            int n = 2;
            Integration.FunctionDelegate f = (x => Math.Cos(x) / Math.Pow(x, 1 / 3));

            var intByMiddleRectangles = Integration.CalculateMiddleRectanglesIntegral(interval, n, f);

            middleRectanglesLabel.Text = intByMiddleRectangles.ToString();
            integralValueLabel.Text = integral.ToString();
        }
    }
}
