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
    public partial class BigTiffanyTemperature : Form, IWater7Device
    {
        private Firmware _fw = null;
        private Water7FirmwareUpdateTask _updateTask;
        private Water7 _water7;
        private UInt64 _modemId = 0;
        public BigTiffanyTemperature(Water7 water7, UInt64 modemId)
        {
            InitializeComponent();
            comboSensorType.SelectedIndex = comboSensorType.FindStringExact("1-Wire");
            comboSensorType.Text = "1-Wire";

            _modemId = modemId;
            _water7 = water7;
            _water7.onRollMessageEvent += MessageHandler;
            _water7.onParametersMessageEvent += ParameterMessageHandler;
            _water7.DevicesParameters["message_frequency"].onValueChangeEvent += onParameterValueChangeHander;
            _water7.DevicesParameters["sensor_type"].onValueChangeEvent += onParameterValueChangeHander;
            _water7.DevicesParameters["raw_mode"].onValueChangeEvent += onParameterValueChangeHander;
            eventLogView1.AddHeader("Data");
            eventLogView1.SetWidthDividers(1.0);

        }

        private void onParameterValueChangeHander(Water7Parameter p)
        {
            Invoke((MethodInvoker)delegate
            {
                if (p.Name == "message_frequency" && textMessageFrequency.Text != p.Value.ToString()) textMessageFrequency.Text = p.Value.ToString();
                if (p.Name == "raw_mode" && checkRawMode.Checked != p.Value > 0) checkRawMode.Checked = p.Value > 0;

                if (p.Name == "sensor_type" && comboSensorType.SelectedItem.ToString() != p.Value.ToString())
                {
                    if (p.Value == 0) comboSensorType.SelectedIndex = comboSensorType.FindStringExact("1-Wire");
                    if (p.Value == 1) comboSensorType.SelectedIndex = comboSensorType.FindStringExact("RTD");
                    if (p.Value == 2) comboSensorType.SelectedIndex = comboSensorType.FindStringExact("Thermocouple");
                }
            });
        }

        private void ParameterMessageHandler(Water7Parameter p)
        {
            this.textMessageFrequency.TextChanged -= this.ControlStateTextChanged;
            this.checkRawMode.CheckedChanged -= this.ControlStateTextChanged;
            this.comboSensorType.SelectedIndexChanged -= this.ControlStateTextChanged;

            Invoke((MethodInvoker)delegate
            {
                if (p.Name == "message_frequency" && textMessageFrequency.Text != p.Value.ToString()) textMessageFrequency.Text = p.Value.ToString();
                if (p.Name == "raw_mode" && checkRawMode.Checked != p.Value > 0) checkRawMode.Checked = p.Value > 0;
                if (p.Name == "sensor_type" && comboSensorType.SelectedItem.ToString() != p.Value.ToString())
                {
                    if (p.Value == 0) comboSensorType.SelectedIndex = comboSensorType.FindStringExact("1-Wire");
                    if (p.Value == 1) comboSensorType.SelectedIndex = comboSensorType.FindStringExact("RTD");
                    if (p.Value == 2) comboSensorType.SelectedIndex = comboSensorType.FindStringExact("Thermocouple");
                }
            });

            this.textMessageFrequency.TextChanged += this.ControlStateTextChanged;
            this.checkRawMode.CheckedChanged += this.ControlStateTextChanged;
            this.comboSensorType.SelectedIndexChanged += this.ControlStateTextChanged;
        }

        private void ControlStateTextChanged(object sender, EventArgs e)
        {
            string parameter = "";
            string value = ((Control)sender).Text;
            switch (((Control)sender).Name)
            {
                case "textMessageFrequency":
                    parameter = "message_frequency";
                    break;
                case "checkRawMode":
                    value = checkRawMode.Checked ? "1" : "0";
                    parameter = "raw_mode";
                    break;
                case "comboSensorType":
                    value = comboSensorType.SelectedIndex.ToString();
                    parameter = "sensor_type";
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

        public void MessageHandler(RollResponse msg)
        {
            var bytes = Tool.StringToByteArray(msg.payload);
            if (bytes[0] == 0x80)
            {
               Int32 currentValue = Tool.BigEndianByteArrayToInt32(bytes, 3);
                if (checkRawMode.Checked)
                {
                    eventLogView1.Append("HEX: " + currentValue.ToString("X"));
                }
                else
                {
                    eventLogView1.Append("VAL: " + currentValue * 0.001);
                }
            }
        }

        private void BigTiffanyTemperature_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _water7.SendChangesToServer();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
