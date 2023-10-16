using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waviot;
using WaviotAPI.API;

namespace WAVIOT.Water7Client
{
    public partial class BigTiffanyImrs : Form, IWater7Device
    {
        private Firmware _fw = null;
        private Water7FirmwareUpdateTask _updateTask;
        private Water7 _water7;
        private UInt64 _modemId = 0;
        public BigTiffanyImrs(Water7 water7, UInt64 modemId)
        {
            _modemId = modemId;
            _water7 = water7;
            _water7.onRollMessageEvent += MessageHandler;
            _water7.onParametersMessageEvent += ParameterMessageHandler;
            _water7.DevicesParameters["enable_inputs_reading"].onValueChangeEvent += onParameterValueChangeHander;
            _water7.DevicesParameters["rtc_irq_frequency"].onValueChangeEvent += onParameterValueChangeHander;
            _water7.DevicesParameters["message_frequency"].onValueChangeEvent += onParameterValueChangeHander;
            InitializeComponent();
            eventLogView1.AddHeader("Proto");
            eventLogView1.AddHeader("Data");
            eventLogView1.SetWidthDividers(0.2, 0.8);
        }

        private void onParameterValueChangeHander(Water7Parameter p)
        {
            Invoke((MethodInvoker)delegate
            {
                if (p.Name == "rtc_irq_frequency" && textIrqFrequency.Text != p.Value.ToString()) textIrqFrequency.Text = p.Value.ToString();
                if (p.Name == "message_frequency" && textMessageFrequency.Text != p.Value.ToString()) textMessageFrequency.Text = p.Value.ToString();
                if (p.Name == "enable_inputs_reading" && checkBoxEnablePulseScanning.Checked != p.Value > 0) checkBoxEnablePulseScanning.Checked = p.Value > 0;
            });
        }

        private void ParameterMessageHandler(Water7Parameter p)
        {
            this.textIrqFrequency.TextChanged -= this.ControlStateChanged;
            this.textMessageFrequency.TextChanged -= this.ControlStateChanged;
            this.checkBoxEnablePulseScanning.CheckedChanged -= this.ControlStateChanged;

            Invoke((MethodInvoker)delegate
            {
                if (p.Name == "rtc_irq_frequency" && textIrqFrequency.Text != p.Value.ToString()) textIrqFrequency.Text = p.Value.ToString();
                if (p.Name == "message_frequency" && textMessageFrequency.Text != p.Value.ToString()) textMessageFrequency.Text = p.Value.ToString();
                if (p.Name == "enable_inputs_reading" && checkBoxEnablePulseScanning.Checked != p.Value > 0) checkBoxEnablePulseScanning.Checked = p.Value > 0;
            });
            this.textIrqFrequency.TextChanged += this.ControlStateChanged;
            this.textMessageFrequency.TextChanged += this.ControlStateChanged;
            this.checkBoxEnablePulseScanning.CheckedChanged += this.ControlStateChanged;
        }

        private void ControlStateChanged(object sender, EventArgs e)
        {
            string parameter = "";
            string value = ((Control)sender).Text;
            switch (((Control)sender).Name)
            {
                case "textIrqFrequency":
                    parameter = "rtc_irq_frequency";
                    break;
                case "textMessageFrequency":
                    parameter = "message_frequency";
                    break;
                case "checkBoxEnablePulseScanning":
                    value = checkBoxEnablePulseScanning.Checked ? "1" : "0";
                    parameter = "enable_inputs_reading";
                    break;
            }
            try
            {
                int intValue = int.Parse(value);
                if (_water7.DevicesParameters[parameter].MaxValue >= intValue && _water7.DevicesParameters[parameter].MinValue <= intValue)
                {
                    _water7.UpdateParameter(parameter, int.Parse(value));
                    ((Control)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((Control)sender).ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                ((Control)sender).ForeColor = Color.Red;
            }
        }

        private void textHexPathClickHandler(object sender, MouseEventArgs e)
        {
            textHexPath.Text = getFilePath("hex");
        }
        private string getFilePath(string mask)
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = mask + " files (*." + mask + ")|*."+mask;
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }
            return path;
        }

        private void buttonFirmwareUpdate_Click(object sender, EventArgs e)
        {
            if (_fw == null)
            {
                try{
                    _fw = new Firmware(textHexPath.Text);
                    _fw.Load();
                    var data = _fw.GetFirmwareData(0x0800F000, 0x080177FF);
                    var task = new ImrsFirmwareLoader(_water7.GetApiInstance(), _modemId, data, 0x0800F000);
                    task.Run();
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void BigTiffanyImrs_Load(object sender, EventArgs e)
        {

        }

        public void MessageHandler(RollResponse msg)
        {
            var bytes = Tool.StringToByteArray(msg.payload);
            if(bytes[0] == 0x40 || bytes[0] == 0x42)
            {
                var response =  _water7.GetApiInstance().EncodeElectro5Packet(msg.payload);
                var list = new List<String>();
                foreach(var obis in response)
                {
                    if (list.Count == 0)
                    {
                        list.Add("EL5 "+(bytes[0] == 0x40?"INST":"PROF") );
                    }
                    else
                    {
                        list.Add("");
                    }
                    list.Add(obis.OBIS + ": " + obis.Value);
                }
                eventLogView1.Append(list.ToArray());

            }
        }

        private void bWriteSettings_Click(object sender, EventArgs e)
        {
            try
            {
                _water7.SendChangesToServer();
            }catch(Exception ex)
            {

            }
        }
    }
}
