using Bwl.Framework;
using Bwl.Hardware.SimplSerial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waviot;
using WaviotAPI.API;
using static Bwl.Hardware.SimplSerial.SimplSerialBus;

namespace BigTiffany210
{
    public partial class MainApp : FormAppBase
    {
        BigTiffany _device;
        Firmware _fw;
        public MainApp()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            _device = new BigTiffany("nikolay.gusev@spacekennel.ru", "_Gusevnikolay2205");
            _device.onConnectEvent += onDeviceConnectEventHandler;
            _device.onLogEvent += onLogEventHandler;
            _device.onSerialLogEvent += onSerialLogHandler;
            _device.Open();
        }

        private void onSerialLogHandler(string message)
        {
            _logger.AddDebug(message);
        }

        private void onLogEventHandler(string message)
        {
            _logger.AddInformation(message);

        }

        private void onDeviceConnectEventHandler(string port, string description)
        {
            _logger.AddInformation("Обнаружено [" + port + "]: " + description);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_device == null) return;
            try
            {
                lPortName.Text = _device.PortName;
                lFirmwareName.Text = _device.GetFirmwareVersion();
                lNbfiId.Text = _device.GetNbfiId();
               /* lwa1470.Text = _device.WA1470;
                lSimOne.Text = _device.SIM1;
                liccidone.Text = _device.ICCID1;
                lSimTwo.Text = _device.SIM2;
                liccidTwo.Text = _device.ICCID2;
                lRSSI.Text = _device.RSSI;
                var memory = _device.GetMemoryInformation()
                lMainAppStartAddress.Text = _device.MainAppStartAddress;
                lMainAppEndAddress.Text = _device.MainAppEndAddress;
                lStorageStartAddress.Text = _device.UpdateStorageStartAddress;
                lStorageEndAddress.Text = _device.UpdateStorageEndAddress;*/
            }catch (Exception ex) {
                _logger.AddError(ex.Message);
            }
           
        }

        private void lComPort_Click(object sender, EventArgs e)
        {

        }

        public void UploadFirmwareProcess()
        {
            var fw = new Firmware(textHexPath.Text);
            fw.Load();
            var memory = _device.GetMemoryInformation();
            var data = fw.GetFirmwareData(memory.MainAppStartAddress, memory.MainAppEndAddress);
            var cmds = FirmwareUpdateCmdSequence.Create(data, memory.MainAppStartAddress, memory.UpdateStorageStartAddress);
            int percents = 0;
            for(int i=0;i<cmds.Count;i++)
            {
                bool success = false;
                while (!success)
                {
                    try
                    {
                        _device.SendUpdateCmd(cmds[i]);
                        success = true;
                    }
                    catch (Exception ex) { 
                        if(i== cmds.Count - 1) success = true;
                    }
                }
               
                var currentProgress = i * 100 / cmds.Count;
                if(percents != currentProgress)
                {
                    _logger.AddMessage("Загрузка обновления: " + currentProgress + "%");
                    percents = currentProgress;
                }
            }
            _logger.AddMessage("Загрузка обновления завершена");
        }

        private void bSelectHexFile_Click(object sender, EventArgs e)
        {
            try
            {
                var fw = new Firmware(textHexPath.Text);
                fw.Load();
                var memory = _device.GetMemoryInformation();
                var data = fw.GetFirmwareData(memory.MainAppStartAddress, memory.MainAppEndAddress);
                var cmds = FirmwareUpdateCmdSequence.Create(data, memory.MainAppStartAddress, memory.UpdateStorageStartAddress);
                var th = new System.Threading.Thread(UploadFirmwareProcess);
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }

        private void textHexPath_MouseClick(object sender, MouseEventArgs e)
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "HEX files (*.hex)|*.hex";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }
            textHexPath.Text = path;
        }

       
        private void bReadApn_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.0=?");
                textApn.Text = resp.Replace("\"", "");
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
            
        }

        private void bWriteApn_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.0=\"" + textApn.Text + "\"");
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bPassRead_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.1=?");
                textLogin.Text = resp.Replace("\"", "").Split(',')[0];
                textPass.Text = resp.Replace("\"", "").Split(',')[1];
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bPassWrite_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.1=\"" + textLogin.Text + "\",\"" + textPass.Text + "\"");
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bReadServer_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.2=?");
                textServer.Text = resp.Replace("\"", "").Split(',')[0].Replace("\"","");
                textPort.Text = resp.Replace("\"", "").Split(',')[1];
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bWriteServer_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.2=\"" + textServer.Text + "\"," + textPort.Text);
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.3=?");
                if (resp.Contains("0")) {
                    radioPAP.Checked = true;
                    radioCHAP.Checked = false;
                }
                else
                {
                    radioPAP.Checked = false;
                    radioCHAP.Checked = true;
                }
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioPAP.Checked == true)
            {
                _device.Request("AT+USER.3=0");
            }
            else
            {
                _device.Request("AT+USER.3=1");
            }
        }

        private void bReadNet_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.4=?");
                radioNetAuto.Checked = resp.Contains("0");
                radioNetGsm.Checked = resp.Contains("1");
                radioNetLte.Checked = resp.Contains("2");

            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bWriteNet_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "0";
                if(radioNetAuto.Checked) cmd = "0";
                if(radioNetGsm.Checked) cmd = "1";
                if(radioNetLte.Checked) cmd = "2";
                var resp = _device.Request("AT+USER.4="+cmd);
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bReadHeartbeat_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.5=?");
                textHertbeat.Text = resp.ToString();

            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bWriteHeartbeat_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.5=" + textHertbeat.Text);
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.6=1" + textHertbeat.Text);
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bResetSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.6=0" + textHertbeat.Text);
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bReadSim_Click(object sender, EventArgs e)
        {
            try
            {
                var resp = _device.Request("AT+USER.7=?");
                radioSIM1.Checked = resp.Contains("0");
                radioSIM2.Checked = resp.Contains("1");

            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bWriteSim_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "1";
                if (radioSIM1.Checked) cmd = "0";
                if (radioSIM2.Checked) cmd = "1";
                var resp = _device.Request("AT+USER.7=" + cmd);
            }
            catch (Exception ex) { _logger.AddError(ex.Message); }
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _device.GetModemStateString();
        }
    }
}
