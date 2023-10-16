using Bwl.Framework;
using System;
using System.Drawing;
using System.Windows.Forms;
using Waviot;
using WAVIOT.Water7Client.devices;
using WaviotAPI.API;

namespace WAVIOT.Water7Client
{
    public partial class MainApp : FormAppBase
    {
        int msgCounter = 0;
        private Water7 _bt;
        private SettingsEditorForm _editor = null;
        private IWater7Device _appControl = null;
        public MainApp()
        {
            InitializeComponent();
            textLogin.Text = Properties.Settings.Default["login"].ToString();
            textPassword.Text = Properties.Settings.Default["password"].ToString();
            textAddress.Text = Properties.Settings.Default["address"].ToString();

            eventLogView.AddHeaders("Data", "RSSI");
            eventLogView.SetWidthDividers(0.85, 0.15);
        }
        void CheckDriver(string firmwareName)
        {
            if (firmwareName == "BigTiffanyAN_WA_stm") _appControl = new BigTiffanyCurrentLoop(_bt, UInt64.Parse(textAddress.Text));
            if (firmwareName == "BigTiffany_IMRS_WA_stm") _appControl = new BigTiffanyImrs(_bt, UInt64.Parse(textAddress.Text));
            if (firmwareName == "BigTiffanyTM_WA_stm") _appControl = new BigTiffanyTemperature(_bt, UInt64.Parse(textAddress.Text));
            if (firmwareName == "aqua2_nvt_wa_stm") _appControl = new Aqua(_bt, UInt64.Parse(textAddress.Text));
            if (firmwareName == "aqua2set_wa_stm") _appControl = new Aqua(_bt, UInt64.Parse(textAddress.Text));
            if (_appControl != null)
            {
                _appControl.Show();
            }
        }
        private void MainApp_Load(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;
            _logger.AddInformation("WAVIOT Water7Client готов к работе");
        }
        int cursor = 0;
        private void RollMessageHandler(RollResponse msg)
        {
            _logger.AddDebug("Message from " + msg.device_id + ".  HEX: " + msg.payload + " RSSI: " + msg.rssi + " BS: " + msg.station_id);
        }

        private void bAuth_Click(object sender, EventArgs e)
        {
            if (bAuth.Text == "Отмена")
            {
                ResetForm();
            }
            else
            {
                StartForm();
            }
        }

        private void ResetForm()
        {
            bAuth.Text = "Авторизация";
            _bt.Close();
            _bt = null;
            _appControl = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            groupBox3.Enabled = false;
            groupBox1.Enabled = false;
            groupBox4.Enabled = false;

            textAddress.Enabled = true;
            textLogin.Enabled = true;
            textPassword.Enabled = true;

            downlinkDataGrid.Rows.Clear();
            eventLogView.Clear();
            gridDeviceParameters.Rows.Clear();
            gridDeviceState.Rows.Clear();
            _editor.gridMetaData.Rows.Clear();
        }

        private void StartForm()
        {
            var login = textLogin.Text;
            var password = textPassword.Text;
            var address = ulong.Parse(textAddress.Text);
            var hardwarePlatform = textHardwareType.Text;
            Properties.Settings.Default["login"] = login;
            Properties.Settings.Default["password"] = password;
            Properties.Settings.Default["address"] = address;
            Properties.Settings.Default.Save();
            _bt = new Water7(login, password, address.ToString());
            try
            {
                _editor = new SettingsEditorForm();
                _editor.gridMetaData.CellEndEdit += new DataGridViewCellEventHandler(this.gridOfEditor_CellEndEdit);
                _logger.AddMessage("Попытка авторизации");
                _bt.onRollMessageEvent += RollMessageHandler;
                _bt.onDeviceMessageEvent += DeviceMessageHandler;
                _bt.onDownlinkMessageEvent += DownlinkMessageHandler;
                //_bt.onParametersMessageEvent += ParameterMessageHandler;
                _bt.onDeviceInfoEvent += DeviceInfoMessageHandler;
                _bt.onLogMessageEvent += onLogMessageHandler;
                _bt.onNewParametersMessageEvent += ParameterMessageHandler;
                _bt.Run();
                textHardwareType.Text = _bt.HardwareType;
                _logger.AddMessage("Авторизация прошла успешно");
                DeviceInfoMessageHandler(_bt.GetDeviceInfo());
                _logger.AddMessage("NB-Fi параметры обновлены");
                groupBox3.Enabled = true;
                groupBox1.Enabled = true;
                groupBox4.Enabled = true;

                textAddress.Enabled = false;
                textLogin.Enabled = false;
                textPassword.Enabled = false;
                CheckDriver(_bt.HardwareType);
                if (checkAutoSettingRequest.Checked)
                {
                    _bt.SendParameterGetRequest(false);
                }
                bAuth.Text = "Отмена";
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }
        private void OnNewParameterMessageHandler(Water7Parameter p)
        {
            throw new NotImplementedException();
        }

        private void DeviceMessageHandler(DeviceMessage msg)
        {
            eventLogView.Append(msg.Description, msg.RSSI, "HEX: "+Tool.ByteArrayToString(msg.Payload), "");
        }

        private void onLogMessageHandler(string msg)
        {
            _logger.AddDebug(msg);
        }

        private void DeviceInfoMessageHandler(DeviceInfo deviceInfo)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                textHardwareType.Text = deviceInfo.hw_type;
                gridDeviceState.Rows.Clear();
                gridDeviceState.Rows.Add(new string[] { "modem_id", deviceInfo.modem_id.ToString() });
                gridDeviceState.Rows.Add(new string[] { "dl_mode", deviceInfo.dl_mode.ToString() });
                gridDeviceState.Rows.Add(new string[] { "nbfi_ver", deviceInfo.nbfi_ver.ToString() });
                gridDeviceState.Rows.Add(new string[] { "pin", deviceInfo.pin.ToString() });
                gridDeviceState.Rows.Add(new string[] { "protocol", deviceInfo.protocol.ToString() });
                gridDeviceState.Rows.Add(new string[] { "dl_base_freq", deviceInfo.dl_base_freq.ToString() });
                gridDeviceState.Rows.Add(new string[] { "ul_base_freq", deviceInfo.ul_base_freq.ToString() });
                gridDeviceState.Rows.Add(new string[] { "dl_messages_per_ack", deviceInfo.dl_messages_per_ack.ToString() });
            });
        }

        public void UpdateValues(Water7Parameter p)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                bool parameterExists = false;
                Color parameterState = Color.Red;
                if (p.State == Water7Parameter.StateFlag.Undefined) parameterState = Color.FromArgb(186, 186, 186);
                if (p.State == Water7Parameter.StateFlag.ModifiedByUser) parameterState = Color.FromArgb(255, 226, 145);
                if (p.State == Water7Parameter.StateFlag.SynchronizedWithServer) parameterState = Color.FromArgb(173, 255, 211);
                if (p.State == Water7Parameter.StateFlag.SentToServer) parameterState = Color.FromArgb(148, 169, 255);
                if (p.State == Water7Parameter.StateFlag.WaitingDeviceResponse) parameterState = Color.FromArgb(109, 156, 121);
                foreach (DataGridViewRow row in gridDeviceParameters.Rows)
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
                    if (p.IsPrimary)
                    {
                        gridDeviceParameters.Rows.Insert(gridDeviceParameters.Rows.Count, new string[] {
                        p.Name, p.Value.ToString()});
                        gridDeviceParameters.Rows[gridDeviceParameters.Rows.Count - 1].DefaultCellStyle.BackColor = parameterState;
                        gridDeviceParameters.Rows[gridDeviceParameters.Rows.Count - 1].Cells[1].ReadOnly = p.IsReadOnly;
                    }
                }
            });
        }

        private void ParameterMessageHandler(Water7Parameter parameter)
        {
            _editor.UpdateValues(parameter);
            UpdateValues(parameter);
            parameter.onValueChangeEvent += UpdateValues;
            parameter.onValueChangeEvent += _editor.UpdateValues;
        }


        private void DownlinkMessageHandler(DownlinkMessage[] msgs)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                downlinkDataGrid.Rows.Clear();
                int iteration = 0;
                foreach (var msg in msgs)
                {
                    int rowId = downlinkDataGrid.Rows.Add();
                    DataGridViewRow row = downlinkDataGrid.Rows[rowId];
                    row.Cells[0].Value = iteration++;
                    row.Cells[1].Value = msg.modem_id;
                    row.Cells[2].Value = "HEX: " + msg.payload;
                    if (msg.status == 1) row.Cells[4].Value = "Queued";
                    if (msg.status == 2) row.Cells[4].Value = "In process";
                    if (msg.status == 4) row.Cells[4].Value = "Delivered";
                    if (msg.status == 5) row.Cells[4].Value = "Lost";
                    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    origin = origin.AddSeconds(msg.posted_time);
                    row.Cells[3].Value = origin.ToString();
                    var color = Color.FromArgb(123, 159, 209);
                    if (msg.status == 2) color = Color.FromArgb(195, 216, 217);
                    if (msg.status == 4) color = Color.FromArgb(50, 191, 111);
                    if (msg.status == 5) color = Color.FromArgb(209, 123, 123);
                    row.DefaultCellStyle.BackColor = color;
                }
            });
        }

        private void bSettingRequest_Click(object sender, EventArgs e)
        {
            try
            {
                _bt.SendParameterGetRequest(true);
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }

        private void bAllParameters_Click(object sender, EventArgs e)
        {
            if (_editor != null)
            {
                _editor.WindowState = FormWindowState.Minimized;
                _editor.Show();
                _editor.WindowState = FormWindowState.Normal;

            }
            if (_appControl!=null) _appControl.Show();
        }

        private void bSendParametersToDevice_Click(object sender, EventArgs e)
        {
            try
            {
                _bt.SendChangesToServer();
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }

        private void bSettingRequestAll_Click(object sender, EventArgs e)
        {
            try
            {
                _bt.SendParameterGetRequest(false);
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }

        private void gridOfEditor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string parameter = _editor.gridMetaData.Rows[e.RowIndex].Cells[0].Value.ToString().Split(',')[0];
                string value = _editor.gridMetaData.Rows[e.RowIndex].Cells[1].Value.ToString();
                _bt.UpdateParameter(parameter, int.Parse(value));
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }
        private void gridDeviceParameters_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string parameter = gridDeviceParameters.Rows[e.RowIndex].Cells[0].Value.ToString().Split(',')[0];
                string value = gridDeviceParameters.Rows[e.RowIndex].Cells[1].Value.ToString();
                _bt.UpdateParameter(parameter, int.Parse(value));
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }

        }

        private void bUpdateDeviceInfo_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceInfoMessageHandler(_bt.GetDeviceInfo());
                _logger.AddMessage("NB-Fi параметры обновлены");
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }


        }

        private void gridDeviceParameters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}