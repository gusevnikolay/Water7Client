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
using WaviotAPI.Controls;

namespace WAVIOT.Water7Client.devices
{
    public partial class BigTiffanyCurrentLoop : Form, IWater7Device
    {

        private Water7 _api;
        private UInt64 _modemId;

        public BigTiffanyCurrentLoop(Water7 water7, UInt64 modemId)
        {
            InitializeComponent();
            _api = water7;
            _api.onRollMessageEvent += MessageHandler;
            _api.onParametersMessageEvent += ParameterMessageHandler;
            _api.DevicesParameters["420_max_level"].onValueChangeEvent += onParameterValueChangeHander;
            _api.DevicesParameters["420_zero_level"].onValueChangeEvent += onParameterValueChangeHander;
            _api.DevicesParameters["message_frequency"].onValueChangeEvent += onParameterValueChangeHander;
            _api.DevicesParameters["value_maximum"].onValueChangeEvent += onParameterValueChangeHander;
            _api.DevicesParameters["value_minimum"].onValueChangeEvent += onParameterValueChangeHander;
            _api.DevicesParameters["enable_converter"].onValueChangeEvent += onParameterValueChangeHander;
            _modemId = modemId;
            eventMessageView.AddHeaders("Ток");
            eventMessageView.SetWidthDividers(1.0);

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.checkBoxRawMode, "Предназначено для работы с калибратором РЗУ-420");
            toolTip1.SetToolTip(this.label7, "Предназначено для работы с калибратором РЗУ-420");
        }

        private void onParameterValueChangeHander(Water7Parameter p)
        {
            Invoke((MethodInvoker)delegate
            {
                if (p.Name == "420_max_level" && textMaxScaleValue.Text != p.Value.ToString()) textMaxScaleValue.Text = p.Value.ToString();
                if (p.Name == "420_zero_level" && textMinScaleValue.Text != p.Value.ToString()) textMinScaleValue.Text = p.Value.ToString();
                if (p.Name == "enable_converter" && checkBoxStepUp.Checked != p.Value > 0) checkBoxStepUp.Checked = p.Value > 0;
                if (p.Name == "raw_mode" && checkBoxRawMode.Checked != p.Value > 0) checkBoxRawMode.Checked = p.Value > 0;
                if (p.Name == "message_frequency" && textMessagesPerDay.Text != p.Value.ToString()) textMessagesPerDay.Text = p.Value.ToString();
                if (p.Name == "value_maximum" && textMaxCurrentValue.Text != p.Value.ToString()) textMaxCurrentValue.Text = p.Value.ToString();
                if (p.Name == "value_minimum" && textMinCurrentValue.Text != p.Value.ToString()) textMinCurrentValue.Text = p.Value.ToString();
            });
        }

        private void ParameterMessageHandler(Water7Parameter p)
        {

            this.textMessagesPerDay.TextChanged -= this.ControlStateTextChanged;
            this.checkBoxRawMode.CheckedChanged -= this.ControlStateTextChanged;
            this.checkBoxStepUp.CheckedChanged -= this.ControlStateTextChanged;
            this.textMinScaleValue.TextChanged -= this.ControlStateTextChanged;
            this.textMaxScaleValue.TextChanged -= this.ControlStateTextChanged;
            this.textMaxCurrentValue.TextChanged -= this.ControlStateTextChanged;
            this.textMinCurrentValue.TextChanged -= this.ControlStateTextChanged;

            Invoke((MethodInvoker)delegate
            {
                if (p.Name == "420_max_level" && textMaxScaleValue.Text != p.Value.ToString()) textMaxScaleValue.Text = p.Value.ToString();
                if (p.Name == "420_zero_level" && textMinScaleValue.Text != p.Value.ToString()) textMinScaleValue.Text = p.Value.ToString();
                if (p.Name == "enable_converter" && checkBoxStepUp.Checked != p.Value > 0) checkBoxStepUp.Checked = p.Value>0;
                if (p.Name == "raw_mode" && checkBoxRawMode.Checked != p.Value > 0) checkBoxRawMode.Checked = p.Value>0;
                if (p.Name == "message_frequency" && textMessagesPerDay.Text != p.Value.ToString()) textMessagesPerDay.Text = p.Value.ToString();
                if (p.Name == "value_maximum" && textMaxCurrentValue.Text != p.Value.ToString()) textMaxCurrentValue.Text = p.Value.ToString();
                if (p.Name == "value_minimum" && textMinCurrentValue.Text != p.Value.ToString()) textMinCurrentValue.Text = p.Value.ToString();
            });

            this.textMessagesPerDay.TextChanged += this.ControlStateTextChanged;
            this.checkBoxRawMode.CheckedChanged += this.ControlStateTextChanged;
            this.checkBoxStepUp.CheckedChanged += this.ControlStateTextChanged;
            this.textMinScaleValue.TextChanged += this.ControlStateTextChanged;
            this.textMaxScaleValue.TextChanged += this.ControlStateTextChanged;
            this.textMaxCurrentValue.TextChanged += this.ControlStateTextChanged;
            this.textMinCurrentValue.TextChanged += this.ControlStateTextChanged;
        }

        public void MessageHandler(RollResponse msg)
        {
            var bytes = Tool.StringToByteArray(msg.payload);
            if (bytes[0] == 0x80)
            {
                Int32 currentValue = Tool.BigEndianByteArrayToInt32(bytes, 3);
                var raw = (UInt16)(currentValue >> 16);
                var aref = (UInt16)(currentValue & 0xFFFF);
                //

                if (checkBoxRawMode.Checked)
                {
                    var shuntValue = _api.GetParameterValue("shunt_correction");
                    var curr = Math.Round(raw / (shuntValue * 0.001 * aref)* 1224000);
                    var deviation = curr % 100;
                    if (deviation > 50) deviation = 100 - deviation;
                    var accuracy = Math.Round(deviation * 100.0 / 16000, 2);
                    string firstLine = String.Format("SIGNAL: {0,-14} REF: {1,-10}", raw, aref);
                    string secondLine;
                    if (shuntValue > 30000 && shuntValue < 70000)
                    {
                        secondLine = String.Format("I: {0,-10} DEV: {1,-5} ACC: {2}%", curr, deviation, accuracy).Replace(",", ".");
                    }
                    else
                    {
                        secondLine = "Cопротивления шунта пока не получено";
                    }
                    eventMessageView.Append(firstLine, secondLine);
                }
                else
                {
                    var deviation = currentValue % 100;
                    if (deviation > 50) deviation = 100 - deviation;
                    var accuracy = Math.Round(deviation * 100.0 / 16000, 2);
                    eventMessageView.Append(currentValue * 0.001 + "mA ["+ accuracy +"%]");
                }


            }
            else if (bytes[0] == 0x20)
            {
                UInt16 eventType = (UInt16)(bytes[1] << 8 | bytes[2]);
                UInt16 payload = (UInt16)(bytes[3] << 8 | bytes[4]);
                switch (eventType)
                {
                    case 0:
                        eventMessageView.Append(Color.OrangeRed, "Перезагрузка устройства #" + payload);
                        break;
                    case 1:
                        eventMessageView.Append(Color.OrangeRed, "Проверка связи. Принят PING пакет");
                        break;
                    case 2:
                        eventMessageView.Append(Color.OrangeRed, "Значение тока ниже порога");
                        break;
                    case 3:
                        if (payload == 0)
                        {
                            eventMessageView.Append(Color.OrangeRed, "Значение тока находится в рабочем диапазоне измерения");
                        }
                        if (payload == 1)
                        {
                            eventMessageView.Append(Color.OrangeRed, "Значение тока вышло за нижние пределы измерения");
                        }
                        if (payload == 2)
                        {
                            eventMessageView.Append(Color.OrangeRed, "Значение тока вышло за верхние пределы измерения");
                        }
                        break;
                    case 4:
                        eventMessageView.Append(Color.OrangeRed,  "Ошибка напряжения повышающего DC/DC");
                        break;
                    case 5:
                        eventMessageView.Append(Color.OrangeRed, "Ионистор не зарядился в установленное время");
                        break;
                }
            }
        }

        private void BigTiffanyCurrentLoop_Load(object sender, EventArgs e)
        {
        }

        private void ControlStateTextChanged(object sender, EventArgs e)
        {
            string parameter = "";
            string value = ((Control)sender).Text;
            switch (((Control)sender).Name)
            {
                case "textMaxScaleValue":
                    parameter = "420_max_level";
                    break;
                case "textMinScaleValue":
                    parameter = "420_zero_level";
                    break;
                case "textMessagesPerDay":
                    parameter = "message_frequency";
                    break;
                case "textMaxCurrentValue":
                    parameter = "value_maximum";
                    break;
                case "textMinCurrentValue":
                    parameter = "value_minimum";
                    break;
                case "checkBoxStepUp":
                    value = checkBoxStepUp.Checked ? "1" : "0";
                    parameter = "enable_converter";
                    break;
                case "checkBoxRawMode":
                    value = checkBoxRawMode.Checked ? "1" : "0";
                    parameter = "raw_mode";
                    break;
            }
            try
            {
                int intValue = int.Parse(value);
                if (_api.DevicesParameters[parameter].MaxValue>= intValue && _api.DevicesParameters[parameter].MinValue<= intValue)
                {
                    _api.UpdateParameter(parameter, int.Parse(value));
                    ((Control)sender).ForeColor = Color.Black;
                }
                else
                {
                    ((Control)sender).ForeColor = Color.Red;
                }
            }
            catch(Exception ex)
            {
                ((Control)sender).ForeColor = Color.Red;
            }
        }

        private void bSettingsWrite_Click(object sender, EventArgs e)
        {
            try
            {
                _api.SendChangesToServer();
            }
            catch (Exception ex)
            {
            }
        }

        private void FormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
