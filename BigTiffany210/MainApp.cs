using Bwl.Framework;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using static BigTiffany210.LteConfig;

namespace BigTiffany210
{

    public partial class MainApp : FormAppBase
    {
        BigTiffany _device;
        Firmware _fw;
        private System.Threading.Timer timer;
        private Random _rnd = new Random();
        public MainApp()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            comboPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            textWaviotLogin.Text = Properties.Settings.Default["login"].ToString();
            textWaviotPassword.Text = Properties.Settings.Default["password"].ToString();
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
                    UpdateSelftestProgress("Загрузка обновления", currentProgress);
                }
            }
            _logger.AddMessage("Загрузка обновления завершена");
            UpdateSelftestProgress("Загрузка обновления завершена", 100);
        }

        private void bSelectHexFile_Click(object sender, EventArgs e)
        {
            try
            {
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

    

        private void bWriteApn_Click(object sender, EventArgs e)
        {
            _device.SetApnSetting(textApn.Text);
        }

        private void bPassWrite_Click(object sender, EventArgs e)
        {
            AuthInformation info = new AuthInformation();
            info.Login = textLogin.Text;
            info.Password = textPass.Text;
            _device.SetModemAuthInfo(info);
        }

        private void bWriteServer_Click(object sender, EventArgs e)
        {
            NbfiServerInformation info = new NbfiServerInformation();
            info.Port = UInt16.Parse(textPort.Text);
            info.Server = textServer.Text;
            _device.SetNbfiServerInfo(info);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioPAP.Checked == true)
            {
                _device.SetModemAuthType(AuthType.PAP);
            }
            else
            {
                _device.SetModemAuthType(AuthType.CHAP);
            }
        }

        private void bWriteNet_Click(object sender, EventArgs e)
        {
            if(radioNetAuto.Checked) _device.SetModemNetworkType(NetworkType.AUTO);
            if(radioNetGsm.Checked) _device.SetModemNetworkType(NetworkType.GSM); 
            if(radioNetLte.Checked) _device.SetModemNetworkType(NetworkType.LTE);
        }

        private void bWriteHeartbeat_Click(object sender, EventArgs e)
        {
            _device.SetNbfiHearbeatPeriodInMinutes(int.Parse(textHertbeat.Text));          
        }

        private void bSaveSettings_Click(object sender, EventArgs e)
        {
            _device.SaveCurrentSettings();
        }

        private void bResetSettings_Click(object sender, EventArgs e)
        {
            _device.RecoverDefaultSettings();
        }

        private void bWriteSim_Click(object sender, EventArgs e)
        {
            string cmd = "1";
            if (radioSIM1.Checked) _device.SetModemActiveSIM(SimCard.SIM1);
            if (radioSIM2.Checked) _device.SetModemActiveSIM(SimCard.SIM2);
        }

        private void bSelectWa1470_Click(object sender, EventArgs e)
        {
            _device.SetNbfiInterface(LteConfig.NbfiInterface.WA1470);
            bSelectWa1470.Enabled = false;
            bSelectLte.Enabled = true;
        }

        private void bSelectLte_Click(object sender, EventArgs e)
        {
            _device.SetNbfiInterface(LteConfig.NbfiInterface.LTE);
            bSelectWa1470.Enabled = true;
            bSelectLte.Enabled = false;
        }

        private void bSendViaNbfi_Click(object sender, EventArgs e)
        {
            _device.NbfiSend(textNbfiPayload.Text);
        }

        private void bOpen_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(bOpen.Text == "Закрыть")
                {
                    _device.Close();
                    bOpen.Text = "Открыть";
                }
                else
                {
                    var port = comboPorts.SelectedItem.ToString();
                    _device = new BigTiffany(port, textWaviotLogin.Text, textWaviotPassword.Text);
                    _device.onConnectEvent += onDeviceConnectEventHandler;
                    _device.onLogEvent += onLogEventHandler;
                    _device.onSerialLogEvent += onSerialLogHandler;
                    _device.Open();
                  

                    bSelftest.Enabled = true;
                    Properties.Settings.Default["login"] = textWaviotLogin.Text;
                    Properties.Settings.Default["password"] = textWaviotPassword.Text;
                    Properties.Settings.Default.Save();

                    bOpen.Text = "Закрыть";
                    _logger.AddInformation("Порт открыт");
                    bRefresh_Click(new object(), new EventArgs());
                }
                

            }
            catch (Exception ex)
            {
                _logger.AddError(ex.Message);
            }
        }

        private void UpdateSelftestProgress(string state, int progess)
        {
            this.BeginInvoke(new Action(() =>
            {
                selfTestProgress.Value = progess;
                lSelftestProgress.Text = state;
            }));
        }
        private void DeviceQuickTest()
        {

            this.BeginInvoke(new Action(() =>
            {
                bRefresh_Click(new object(), new EventArgs());
            }));
             UpdateSelftestProgress("Проверка боковой SIM", 10);
             _device.SetModemActiveSIM(SimCard.SIM1);
             this.BeginInvoke(new Action(() =>
             {
                 radioSIM1.Checked = true;
                 radioSIM2.Checked = false;
             }));
             _device.SaveCurrentSettings();
             System.Threading.Thread.Sleep(2000);
             var iccid = _device.GetModemStateString().ICCID;
             while (iccid.Length < 18)
             {
                 iccid = _device.GetModemStateString().ICCID;
                 System.Threading.Thread.Sleep(2000);
             }

             this.BeginInvoke(new Action(() =>
             {
                 liccidone.Text = iccid;
             }));
             UpdateSelftestProgress("Проверка верхней SIM", 15);
             _device.SetModemActiveSIM(SimCard.SIM2);
             _device.SaveCurrentSettings();
             this.BeginInvoke(new Action(() =>
             {
                 radioSIM1.Checked = false;
                 radioSIM2.Checked = true;
             }));
             System.Threading.Thread.Sleep(2000);
             iccid = _device.GetModemStateString().ICCID;
             while (iccid.Length < 18)
             {
                 iccid = _device.GetModemStateString().ICCID;
                 System.Threading.Thread.Sleep(2000);
             }
             this.BeginInvoke(new Action(() =>
             {
                 lDeviceIp.Text = _device.GetModemStateString().IP;
                 liccidTwo.Text = iccid;
             }));

             UpdateSelftestProgress("Проверка WA1470", 30);
            
            string payload = "";
            for (int i = 0; i < 8; i++) payload += _rnd.Next(9);
            this.BeginInvoke(new Action(() =>
            {
               textNbfiPayload.Text = payload;
            }));
            var time = BigTiffany.GetCurrentUnixTimestampMillis();
            _device.SetNbfiInterface(NbfiInterface.WA1470);
            _device.NbfiSend(payload);
            UpdateSelftestProgress("Ожидаем данные на сервере", 35);
            var id = _device.GetNbfiId();
            bool msgReceived = false;
            while (!msgReceived)
            {
                var msgs = _device.GetMessageFromServer(Convert.ToInt64(id, 16).ToString(), time-5000);
                foreach(var msg in msgs)
                {
                    if(msg.payload == payload)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            lwa1470.Text = "BS"+msg.station_id;
                            lRSSI.Text = msg.rssi.ToString();
                            msgReceived = true;
                        }));
                    }
                }
                System.Threading.Thread.Sleep(2000);
            }
            this.BeginInvoke(new Action(() =>
            {
                bRefresh.Enabled = true;
                groupBox4.Enabled = true;
                groupBox3.Enabled = true;
                groupBox2.Enabled = true;
                Fd.Enabled = false;
            }));
            UpdateSelftestProgress("Проверка завершена", 100);
            
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            var fw = _device.GetFirmwareVersion();
            var id = _device.GetNbfiId();
            var sim = _device.GetModemActiveSIM();
            var memory = _device.GetMemoryInformation();
            var modemAuth = _device.GetModemAuthInfo();
            var modemAuthType = _device.GetModemAuthType(); 
            var modemNetType = _device.GetModemNetworkType();
            var nfbiConnectionSetting = _device.GetNbfiServerInfo();
            var iface = _device.GetNbfiInterface();
            var hb = _device.GetNbfiHearbeatPeriodInMinutes();
            var simCard = _device.GetModemStateString();
            lFirmwareName.Text = fw;
            lNbfiId.Text = id;
            lMainAppStartAddress.Text = "0x" + memory.MainAppStartAddress.ToString("X8");
            lMainAppEndAddress.Text = "0x" + memory.MainAppEndAddress.ToString("X8");
            lStorageStartAddress.Text = "0x" + memory.UpdateStorageStartAddress.ToString("X8");
            lStorageEndAddress.Text = "0x" + memory.UpdateStorageEndAddress.ToString("X8");
            textApn.Text = _device.GetApnSetting();
            textLogin.Text = modemAuth.Login;
            textPass.Text = modemAuth.Password;
            textServer.Text = nfbiConnectionSetting.Server;
            textPort.Text = nfbiConnectionSetting.Port.ToString();
            radioCHAP.Checked = modemAuthType == LteConfig.AuthType.CHAP;
            radioPAP.Checked = modemAuthType == LteConfig.AuthType.PAP;

            radioNetAuto.Checked = modemNetType == LteConfig.NetworkType.AUTO;
            radioNetGsm.Checked = modemNetType == LteConfig.NetworkType.GSM;
            radioNetLte.Checked = modemNetType == LteConfig.NetworkType.LTE;

            textHertbeat.Text = hb.ToString();
            radioSIM1.Checked = sim == SimCard.SIM1;
            radioSIM2.Checked = sim == SimCard.SIM2;

            bSelectWa1470.Enabled = iface == NbfiInterface.LTE;
            bSelectLte.Enabled = iface == NbfiInterface.WA1470;
            lDeviceIp.Text = simCard.IP;
            if(sim == SimCard.SIM1)
            {
                liccidone.Text = simCard.ICCID;
            }
            else
            {
                liccidTwo.Text = simCard.ICCID;
            }

        }

        private void bSelftest_Click(object sender, EventArgs e)
        {
            bRefresh.Enabled = false;
            groupBox4.Enabled = false;
            groupBox3.Enabled = false;
            groupBox2.Enabled = false;
            Fd.Enabled = true;

            var th = new System.Threading.Thread(DeviceQuickTest);
            th.IsBackground = true;
            th.Start();
        }
    }
}
