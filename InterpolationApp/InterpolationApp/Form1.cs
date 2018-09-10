using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterpolationApp
{
    public partial class MainForm : Form
    {
        static Interpolation interpolation;

        private static double Step = 0.1;

        private static Tuple<double, double> Segment = Tuple.Create(0.5, 1.5);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            interpolation = new Interpolation(Math.Sin, Segment, Step);
            fillPointValueGrid();
        }

        private void fillPointValueGrid()
        {
            for (int i = 0; i < interpolation.Points.Count; i++)
            {
                pointValueGrid.Rows.Add(interpolation.Points[i], interpolation.Values[i]);
            }
        }
    }
}
