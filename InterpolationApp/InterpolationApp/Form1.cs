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

        private static int DeltaDegree = 4;

        private static double Precision = Math.Pow(10, -5);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            interpolation = new Interpolation(Math.Sin, Segment, Step, Precision, DeltaDegree);
            fillPointValueGrid();
            correctPointValueGridSize();
        }

        private void fillPointValueGrid()
        {
            for (int i = 0; i < interpolation.Points.Count; i++)
            {
                
                pointValueGrid.Rows.Add(interpolation.Points[i], interpolation.Values[i]);
                pointValueGrid.Rows.Add();
            }

            int rowStartIndex = 1;
            int columnIndex = 2;

            foreach (var deltasI in interpolation.Deltas)
            {
                int rowIndex = rowStartIndex;

                foreach (var delta in deltasI)
                {
                    double revPrecision = 1 / Precision;
                    double value = Math.Truncate(revPrecision * delta) / revPrecision;
                    pointValueGrid[columnIndex, rowIndex].Value = value;
                    rowIndex += 2;
                }

                rowStartIndex++;
                columnIndex++;
            }
        }

        private void correctPointValueGridSize()
        {
            pointValueGrid.Rows.RemoveAt(pointValueGrid.Rows.Count - 2);
        }
    }
}
