using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InterpolaionApp3
{
    public partial class Form1 : Form
    {
        // input
        private Interpolation.FunctionDelegate Function = (x => Math.Cos(x) / Math.Sin(x) - 2 * x * x);
        private Interpolation.FunctionDelegate FunctionDerivate = (x => -1 / Math.Pow(Math.Sin(x), 2) - 4 * x);
        private double Precision = 0.000001;
        private double Step = 0.1;
        private int KMax = 1000;


        public Form1()
        {
            InitializeComponent();
        }

        private void FillRootsGrid()
        {
            var intervals = Interpolation.LocateRoots(new Tuple<double, double>(0, 8), Step, 0.01, Function);
            var rootsByNewton = Interpolation.GetRootsByNewton(intervals, Precision, Function, FunctionDerivate, KMax);
            var rootsByNewton2 = Interpolation.GetRootsByNewton2(intervals, Precision, Function, FunctionDerivate, KMax);
            var rootsBySecantMethod = Interpolation.GetRootsBySecantMethod(intervals, Precision, Function, FunctionDerivate, KMax);

            for (int i = 0; i < intervals.Count; i++)
            {
                var interval = "[" + intervals[i].Item1 + "; " + intervals[i].Item2 + "]";
                RootsGrid.Rows.Add(i + 1, interval,
                                    rootsByNewton[i].Item1, rootsByNewton[i].Item2,
                                    rootsByNewton2[i].Item1, rootsByNewton2[i].Item2,
                                    rootsBySecantMethod[i].Item1, rootsBySecantMethod[i].Item2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillRootsGrid();
        }

    }
}
