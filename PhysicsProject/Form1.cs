using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace PhysicsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Name = "Distribution";
            chart1.ChartAreas[0].AxisX.Title = "r";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.Title = "4πr^2(R_nl(r))^2";
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int l = Convert.ToInt32(textBox2.Text);
            ElectronDistribution.R eDistribution = ElectronDistribution.GetElectronDistribution(n, l);

            chart1.Series[0].Points.Clear();

            double x, y;
            double a = Convert.ToDouble(textBox4.Text, CultureInfo.InvariantCulture);
            double b = Convert.ToDouble(textBox3.Text, CultureInfo.InvariantCulture);
            double N = Convert.ToDouble(textBox5.Text, CultureInfo.InvariantCulture);
            
            double maxY = eDistribution(a);
            chart1.Series[0].Points.AddXY(a, maxY);
            for (int i = 1; i <= N; i++)
            {
                x = a + (double)(b - a) / N * i;
                y = eDistribution(x);
                if (maxY < y)
                {
                    maxY = y;
                }
                chart1.Series[0].Points.AddXY(x, y);
            }
            chart1.ChartAreas[0].AxisX.IntervalOffset = 0.1;
            chart1.ChartAreas[0].AxisX.Interval = (b - a) / 10;
            chart1.ChartAreas[0].AxisY.Interval = (maxY - 0) / 15;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 1.1 * b;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1.1 * maxY;
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            double mouseX = chart1.ChartAreas[0].AxisX.PixelPositionToValue(MousePosition.X - this.Location.X - 20); // 22 Y axis label width
            double dx = Math.Abs(mouseX - chart1.Series[0].Points[0].XValue);
            System.Windows.Forms.DataVisualization.Charting.DataPoint closestPoint = chart1.Series[0].Points[0];
            foreach (var point in chart1.Series[0].Points)
            {
                if (dx >= Math.Abs(mouseX - point.XValue))
                {
                    closestPoint = point;
                    dx = Math.Abs(mouseX - point.XValue);
                }
                else
                {
                    break;
                }
            }
            
            if (Math.Abs((chart1.ChartAreas[0].AxisY.ValueToPixelPosition(closestPoint.YValues[0]) + chart1.Margin.Bottom + 40) - (MousePosition.Y - this.Location.Y) ) <= 15)
            {
                closestPoint.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                closestPoint.MarkerColor = Color.Red;
                closestPoint.MarkerSize = 5;
                closestPoint.Label = $"{{{closestPoint.XValue}; {closestPoint.YValues[0]}}}";
            }
        }
    }
}
