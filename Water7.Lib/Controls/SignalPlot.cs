using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaviotAPI.Controls
{
    public partial class SignalPlot : Form
    {
        private int _size = 100;
        private Dictionary<string, List<int>> _signals = new Dictionary<string, List<int>>();
        private bool isAcMode = false;
        public SignalPlot(int size)
        {
            _size = size;
            InitializeComponent();
        }

        public void AddSignal(string name)
        {
            _signals.Add(name, new List<int>());
            chart1.Series.Add(name);
            chart1.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        public void Append(string name, int value)
        {
            if (_signals[name].Count > _size) _signals[name].RemoveAt(0);
            _signals[name].Add(value);
        }

        public void Reload()
        {
            Invoke((MethodInvoker)delegate
            {
                foreach (var pair in _signals)
                {
                    chart1.Series[pair.Key].Points.Clear();
                    var min = 0;
                    if (isAcMode == true) min = pair.Value.Min();
                    foreach (var value in pair.Value)
                    {
                        chart1.Series[pair.Key].Points.Add(value - min);
                    }
                }
                chart1.Update();
            });
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            isAcMode = !isAcMode;
            Reload();
        }

        private void SignalPlot_Load(object sender, EventArgs e)
        {

        }
    }
}
