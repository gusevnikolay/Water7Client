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
    public partial class EventLogView : UserControl
    {

        private Timer _timer; 
        public Color OddRowColor = Color.FromArgb(227, 238, 255);
        public Color EvenRowColor = Color.FromArgb(255, 229, 158);
        private List<double> _widthDivider = null;
        public EventLogDirection Direction = EventLogDirection.Forward;
        UInt32 _counter = 0;
        UInt32 _id = 0;
        public enum EventLogDirection
        {
            Forward,
            Reverse
        }
        public EventLogView()
        {
            InitializeComponent();
            dataGrid.Columns.Add(new DataGridViewColumn() { HeaderText = "ID", CellTemplate = new DataGridViewTextBoxCell() });
            dataGrid.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGrid.Columns.Add(new DataGridViewColumn() { HeaderText = "Time", CellTemplate = new DataGridViewTextBoxCell() });

            dataGrid.AllowUserToAddRows = false;
            dataGrid.RowHeadersVisible = false;
            dataGrid.Location = new Point(0, 0);
            dataGrid.Width = Width;
            dataGrid.Height = Height;
            dataGrid.Margin = new Padding(0, 0, 0, 0);
            dataGrid.Dock = DockStyle.Fill;
        }

        private void TuneWidthOfColumns()
        {
            try
            {
                int sum = 0;
                Graphics g = this.CreateGraphics();
                float maxWidthOfIdColumn = 0;
                float maxWidthOfTimeColumt = 0;
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    var idValue = row.Cells[0].Value.ToString();
                    var timeValue = row.Cells[row.Cells.Count - 1].Value.ToString();
                    float currentIdWidth = g.MeasureString(idValue, dataGrid.Font).Width;
                    float currentTimeWidth = g.MeasureString(timeValue, dataGrid.Font).Width;
                    if (maxWidthOfIdColumn < currentIdWidth) maxWidthOfIdColumn = currentIdWidth;
                    if (maxWidthOfTimeColumt < currentTimeWidth) maxWidthOfTimeColumt = currentTimeWidth;
                }
                int idWidth = (int)(maxWidthOfIdColumn + 5);
                if (idWidth < 25) idWidth = 25;
                int timeWidth = (int)(maxWidthOfTimeColumt + 20);
                if (timeWidth < 35) timeWidth = 35;

                int difference = dataGrid.Width - idWidth - timeWidth;
                if (_widthDivider != null)
                {
                    dataGrid.Columns[0].Width = idWidth;
                    dataGrid.Columns[dataGrid.Columns.Count - 1].Width = timeWidth;
                    sum += (idWidth + timeWidth);
                    for (int i = 1; i < dataGrid.Columns.Count - 2; i++)
                    {
                        dataGrid.Columns[i].Width = (int)(difference * _widthDivider[i - 1]);
                        sum += dataGrid.Columns[i].Width;
                    }
                    dataGrid.Columns[dataGrid.Columns.Count - 2].Width = (dataGrid.Width - sum - 3);
                }
            }
            catch(Exception ex)
            {

            }         
        }
        public void SetWidthDividers(params double[] widthPercentages)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
            _widthDivider = new List<double>();
            _widthDivider.AddRange(widthPercentages);
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += (sender, e) => ResizeFinished();
            _timer.Start();
        }
        private void ResizeEventHandler(object sender, EventArgs e)
        {
            if (_timer != null)
            {
            }
        }
        private void ResizeFinished()
        {
            TuneWidthOfColumns();
        }
        public void AddHeaders(params string[] headers)
        {
            foreach (var header in headers)
            {
                AddHeader(header);
            }
        }
        public void AddHeader(string header)
        {
            dataGrid.Columns.Add(new DataGridViewColumn() { HeaderText = header, CellTemplate = new DataGridViewTextBoxCell() });
            var last = dataGrid.Columns[dataGrid.Columns.Count - 1].HeaderText;
            var penultimate = dataGrid.Columns[dataGrid.Columns.Count - 2].HeaderText;
            dataGrid.Columns[dataGrid.Columns.Count - 1].HeaderText = penultimate;
            dataGrid.Columns[dataGrid.Columns.Count - 2].HeaderText = last;
        }
        public void Append(Color color, params object[] list)
        {
            List<string> values = new List<string>();
            int lineItemsCount = dataGrid.Columns.Count - 2;
            int lines = (int)Math.Ceiling(list.Length * 1.0 / (dataGrid.Columns.Count - 2));
            for (int index=0; index < lines; index++)
            {
                values.Clear();
                if (index == 0) values.Add(_id++.ToString()); else values.Add("");
                for(int i = 0; i < dataGrid.Columns.Count - 2; i++)
                {
                    values.Add(list[lineItemsCount * index + i].ToString());
                }
                if (index == 0) values.Add(DateTime.Now.ToString()); else values.Add("");

                if (Direction == EventLogDirection.Forward)
                {
                    dataGrid.Invoke((MethodInvoker)delegate
                    {
                        var scrollPosition = dataGrid.FirstDisplayedScrollingRowIndex;
                        dataGrid.Rows.Insert(index, values.ToArray());
                        dataGrid.Rows[index].DefaultCellStyle.BackColor = color;
                        if (scrollPosition > 0) dataGrid.FirstDisplayedScrollingRowIndex = scrollPosition + 1;
                    });
                }
                if (Direction == EventLogDirection.Reverse)
                {
                    dataGrid.Invoke((MethodInvoker)delegate
                    {
                        dataGrid.Rows.Add(values.ToArray());
                        dataGrid.Rows[dataGrid.Rows.Count - 1].DefaultCellStyle.BackColor = color;
                        int position = dataGrid.RowCount - dataGrid.DisplayedRowCount(true);
                        dataGrid.FirstDisplayedScrollingRowIndex = position;
                    });
                }
            }
        }

        public void Append(params object[] list)
        {
            _counter++;
            Append(_counter % 2 == 0 ? OddRowColor : EvenRowColor, list);
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Clear()
        {
            dataGrid.Invoke((MethodInvoker)delegate
            {
                dataGrid.Rows.Clear();
            });
        }
    }
}
