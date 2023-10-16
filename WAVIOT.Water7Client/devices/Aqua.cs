using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaviotAPI.API;

namespace WAVIOT.Water7Client.devices
{
    public partial class Aqua : Form, IWater7Device
    {
        private Firmware _fw = null;
        private Water7FirmwareUpdateTask _updateTask;
        private Water7 _water7;
        private UInt64 _modemId = 0;
        public Aqua(Water7 water7, UInt64 modemId)
        {
            _modemId = modemId;
            _water7 = water7;
            _water7.onRollMessageEvent += MessageHandler;
            _water7.onParametersMessageEvent += ParameterMessageHandler;
          /*  _water7.DevicesParameters["enable_inputs_reading"].onValueChangeEvent += onParameterValueChangeHander;
            _water7.DevicesParameters["rtc_irq_frequency"].onValueChangeEvent += onParameterValueChangeHander;
            _water7.DevicesParameters["message_frequency"].onValueChangeEvent += onParameterValueChangeHander;*/
            InitializeComponent();
        }

        private void ParameterMessageHandler(Water7Parameter p)
        {
            Invoke((MethodInvoker)delegate
            {
                /*if (p.Name == "rtc_irq_frequency" && textIrqFrequency.Text != p.Value.ToString()) textIrqFrequency.Text = p.Value.ToString();
                if (p.Name == "message_frequency" && textMessageFrequency.Text != p.Value.ToString()) textMessageFrequency.Text = p.Value.ToString();
                if (p.Name == "enable_inputs_reading" && checkBoxEnablePulseScanning.Checked != p.Value > 0) checkBoxEnablePulseScanning.Checked = p.Value > 0;*/
            });
        }

        public void MessageHandler(RollResponse msg)
        {
            throw new NotImplementedException();
        }

        private void Aqua_Load(object sender, EventArgs e)
        {

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
                openFileDialog.Filter = mask + " files (*." + mask + ")|*." + mask;
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
                try
                {
                    _fw = new Firmware(textHexPath.Text);
                    _fw.Load();
                    var data = _fw.GetFirmwareData(0x00001000, 0x0000FFFF);
                    var task = new Waviot.AquaFirmwareLoader(_water7.GetApiInstance(), _modemId, data);
                    task.onFirmwareUpgradeEvent += UpdateEventHandler;
                    task.Run();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void UpdateEventHandler(int progess, string message)
        {
            Invoke((MethodInvoker)delegate
            {
                progressUpdateFw.Value = progess;
                labelProgress.Text = message;
            });
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
