using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WAVIOT.Water7Client
{
    public partial class SettingsEditorForm : Form
    {
        public SettingsEditorForm()
        {
            InitializeComponent();
        }

        public void UpdateControls(Water7Parameter p)
        {
            bool parameterExists = false;
            Color parameterState = Color.Red;
            if (p.State == Water7Parameter.StateFlag.Undefined) parameterState = Color.FromArgb(186, 186, 186);
            if (p.State == Water7Parameter.StateFlag.ModifiedByUser) parameterState = Color.FromArgb(255, 226, 145);
            if (p.State == Water7Parameter.StateFlag.SynchronizedWithServer) parameterState = Color.FromArgb(173, 255, 211);
            if (p.State == Water7Parameter.StateFlag.SentToServer) parameterState = Color.FromArgb(148, 169, 255);
            if (p.State == Water7Parameter.StateFlag.WaitingDeviceResponse) parameterState = Color.FromArgb(109, 156, 121);
            foreach (DataGridViewRow row in gridMetaData.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(p.Name))
                {
                    parameterExists = true;
                    var rowIndex = row.Index;
                    row.Cells[1].Value = p.Value;
                    row.DefaultCellStyle.BackColor = parameterState;
                    break;
                }
            }
            if (!parameterExists)
            {
                if (p.IsReadOnly && p.Type == MetaParameter.MetaType.Parameter)
                {
                    gridMetaData.Rows.Insert(gridMetaData.Rows.Count, new string[] {
                        p.Name, p.Value.ToString(), p.Unit, p.MinValue.ToString(), p.MaxValue.ToString(), p.Description
                    });
                    gridMetaData.Rows[gridMetaData.Rows.Count - 1].DefaultCellStyle.BackColor = parameterState;
                    gridMetaData.Rows[gridMetaData.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Gray;
                    gridMetaData.Rows[gridMetaData.Rows.Count - 1].Cells[1].ReadOnly = true;
                }
                else
                {
                    gridMetaData.Rows.Insert(0, new string[] {
                        p.Name, p.Value.ToString(), p.Unit, p.MinValue.ToString(), p.MaxValue.ToString(), p.Description
                    });
                    gridMetaData.Rows[0].DefaultCellStyle.BackColor = parameterState;
                }
            }
        }
        public void UpdateValues(Water7Parameter p)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    UpdateControls(p);
                });
            }
            else
            {
                UpdateControls(p);
            }
        }

        private void SettingsEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void FormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
