namespace BigTiffany210
{
    partial class MainApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textWaviotPassword = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textWaviotLogin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.labelport = new System.Windows.Forms.Label();
            this.lFirmwareName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bSendViaNbfi = new System.Windows.Forms.Button();
            this.textNbfiPayload = new System.Windows.Forms.TextBox();
            this.bSelectLte = new System.Windows.Forms.Button();
            this.bSelectWa1470 = new System.Windows.Forms.Button();
            this.lDeviceIp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lRSSI = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.liccidTwo = new System.Windows.Forms.Label();
            this.liccidone = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lwa1470 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lNbfiId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lStorageEndAddress = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lStorageStartAddress = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lMainAppEndAddress = new System.Windows.Forms.Label();
            this.bSelectHexFile = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lMainAppStartAddress = new System.Windows.Forms.Label();
            this.textHexPath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioSIM1 = new System.Windows.Forms.RadioButton();
            this.radioSIM2 = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.bWriteSim = new System.Windows.Forms.Button();
            this.bResetSettings = new System.Windows.Forms.Button();
            this.bSaveSettings = new System.Windows.Forms.Button();
            this.bWriteHeartbeat = new System.Windows.Forms.Button();
            this.textHertbeat = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioNetLte = new System.Windows.Forms.RadioButton();
            this.radioNetAuto = new System.Windows.Forms.RadioButton();
            this.radioNetGsm = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.bWriteNet = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioPAP = new System.Windows.Forms.RadioButton();
            this.radioCHAP = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.bWriteServer = new System.Windows.Forms.Button();
            this.textServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.TextBox();
            this.bPassWrite = new System.Windows.Forms.Button();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.bWriteApn = new System.Windows.Forms.Button();
            this.textApn = new System.Windows.Forms.TextBox();
            this.PA = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Fd = new System.Windows.Forms.GroupBox();
            this.selfTestProgress = new System.Windows.Forms.ProgressBar();
            this.lSelftestProgress = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.bSelftest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.Fd.SuspendLayout();
            this.SuspendLayout();
            // 
            // logWriter
            // 
            this.logWriter.Location = new System.Drawing.Point(2, 509);
            this.logWriter.Size = new System.Drawing.Size(799, 126);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSelftest);
            this.groupBox1.Controls.Add(this.textWaviotPassword);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textWaviotLogin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bRefresh);
            this.groupBox1.Controls.Add(this.bOpen);
            this.groupBox1.Controls.Add(this.comboPorts);
            this.groupBox1.Controls.Add(this.labelport);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 146);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "USB Connection";
            // 
            // textWaviotPassword
            // 
            this.textWaviotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWaviotPassword.Location = new System.Drawing.Point(96, 82);
            this.textWaviotPassword.Name = "textWaviotPassword";
            this.textWaviotPassword.PasswordChar = '*';
            this.textWaviotPassword.Size = new System.Drawing.Size(266, 22);
            this.textWaviotPassword.TabIndex = 41;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(6, 85);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 16);
            this.label19.TabIndex = 40;
            this.label19.Text = "Пароль:";
            // 
            // textWaviotLogin
            // 
            this.textWaviotLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textWaviotLogin.Location = new System.Drawing.Point(96, 54);
            this.textWaviotLogin.Name = "textWaviotLogin";
            this.textWaviotLogin.Size = new System.Drawing.Size(266, 22);
            this.textWaviotLogin.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Логин:";
            // 
            // bRefresh
            // 
            this.bRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRefresh.Location = new System.Drawing.Point(210, 110);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(73, 30);
            this.bRefresh.TabIndex = 9;
            this.bRefresh.Text = "Обновить";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // bOpen
            // 
            this.bOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOpen.Location = new System.Drawing.Point(96, 110);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(108, 30);
            this.bOpen.TabIndex = 8;
            this.bOpen.Text = "Открыть";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click_1);
            // 
            // comboPorts
            // 
            this.comboPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(96, 21);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(266, 24);
            this.comboPorts.TabIndex = 7;
            // 
            // labelport
            // 
            this.labelport.AutoSize = true;
            this.labelport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelport.Location = new System.Drawing.Point(6, 26);
            this.labelport.Name = "labelport";
            this.labelport.Size = new System.Drawing.Size(84, 16);
            this.labelport.TabIndex = 3;
            this.labelport.Text = "COM-порт:";
            // 
            // lFirmwareName
            // 
            this.lFirmwareName.AutoSize = true;
            this.lFirmwareName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lFirmwareName.Location = new System.Drawing.Point(110, 27);
            this.lFirmwareName.Name = "lFirmwareName";
            this.lFirmwareName.Size = new System.Drawing.Size(12, 16);
            this.lFirmwareName.TabIndex = 6;
            this.lFirmwareName.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Устройство:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bSendViaNbfi);
            this.groupBox2.Controls.Add(this.textNbfiPayload);
            this.groupBox2.Controls.Add(this.bSelectLte);
            this.groupBox2.Controls.Add(this.bSelectWa1470);
            this.groupBox2.Controls.Add(this.lDeviceIp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lRSSI);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.liccidTwo);
            this.groupBox2.Controls.Add(this.liccidone);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lwa1470);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lNbfiId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(404, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 134);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Беспроводные интерфейсы";
            // 
            // bSendViaNbfi
            // 
            this.bSendViaNbfi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSendViaNbfi.Location = new System.Drawing.Point(304, 49);
            this.bSendViaNbfi.Name = "bSendViaNbfi";
            this.bSendViaNbfi.Size = new System.Drawing.Size(75, 23);
            this.bSendViaNbfi.TabIndex = 22;
            this.bSendViaNbfi.Text = "SEND";
            this.bSendViaNbfi.UseVisualStyleBackColor = true;
            this.bSendViaNbfi.Click += new System.EventHandler(this.bSendViaNbfi_Click);
            // 
            // textNbfiPayload
            // 
            this.textNbfiPayload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textNbfiPayload.Location = new System.Drawing.Point(223, 50);
            this.textNbfiPayload.Name = "textNbfiPayload";
            this.textNbfiPayload.Size = new System.Drawing.Size(75, 22);
            this.textNbfiPayload.TabIndex = 21;
            // 
            // bSelectLte
            // 
            this.bSelectLte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSelectLte.Location = new System.Drawing.Point(304, 24);
            this.bSelectLte.Name = "bSelectLte";
            this.bSelectLte.Size = new System.Drawing.Size(75, 23);
            this.bSelectLte.TabIndex = 20;
            this.bSelectLte.Text = "LTE";
            this.bSelectLte.UseVisualStyleBackColor = true;
            this.bSelectLte.Click += new System.EventHandler(this.bSelectLte_Click);
            // 
            // bSelectWa1470
            // 
            this.bSelectWa1470.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSelectWa1470.Location = new System.Drawing.Point(223, 25);
            this.bSelectWa1470.Name = "bSelectWa1470";
            this.bSelectWa1470.Size = new System.Drawing.Size(75, 23);
            this.bSelectWa1470.TabIndex = 19;
            this.bSelectWa1470.Text = "WA1470";
            this.bSelectWa1470.UseVisualStyleBackColor = true;
            this.bSelectWa1470.Click += new System.EventHandler(this.bSelectWa1470_Click);
            // 
            // lDeviceIp
            // 
            this.lDeviceIp.AutoSize = true;
            this.lDeviceIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDeviceIp.Location = new System.Drawing.Point(82, 75);
            this.lDeviceIp.Name = "lDeviceIp";
            this.lDeviceIp.Size = new System.Drawing.Size(12, 16);
            this.lDeviceIp.TabIndex = 18;
            this.lDeviceIp.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "IP:";
            // 
            // lRSSI
            // 
            this.lRSSI.AutoSize = true;
            this.lRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lRSSI.Location = new System.Drawing.Point(82, 59);
            this.lRSSI.Name = "lRSSI";
            this.lRSSI.Size = new System.Drawing.Size(12, 16);
            this.lRSSI.TabIndex = 16;
            this.lRSSI.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "RSSI:";
            // 
            // liccidTwo
            // 
            this.liccidTwo.AutoSize = true;
            this.liccidTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.liccidTwo.Location = new System.Drawing.Point(82, 107);
            this.liccidTwo.Name = "liccidTwo";
            this.liccidTwo.Size = new System.Drawing.Size(12, 16);
            this.liccidTwo.TabIndex = 14;
            this.liccidTwo.Text = "-";
            // 
            // liccidone
            // 
            this.liccidone.AutoSize = true;
            this.liccidone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.liccidone.Location = new System.Drawing.Point(82, 91);
            this.liccidone.Name = "liccidone";
            this.liccidone.Size = new System.Drawing.Size(12, 16);
            this.liccidone.TabIndex = 12;
            this.liccidone.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "ICCID 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ICCID 1:";
            // 
            // lwa1470
            // 
            this.lwa1470.AutoSize = true;
            this.lwa1470.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lwa1470.Location = new System.Drawing.Point(82, 43);
            this.lwa1470.Name = "lwa1470";
            this.lwa1470.Size = new System.Drawing.Size(12, 16);
            this.lwa1470.TabIndex = 6;
            this.lwa1470.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "WA1470:";
            // 
            // lNbfiId
            // 
            this.lNbfiId.AutoSize = true;
            this.lNbfiId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lNbfiId.Location = new System.Drawing.Point(82, 27);
            this.lNbfiId.Name = "lNbfiId";
            this.lNbfiId.Size = new System.Drawing.Size(12, 16);
            this.lNbfiId.TabIndex = 4;
            this.lNbfiId.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "ID:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lStorageEndAddress);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lStorageStartAddress);
            this.groupBox3.Controls.Add(this.lFirmwareName);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lMainAppEndAddress);
            this.groupBox3.Controls.Add(this.bSelectHexFile);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lMainAppStartAddress);
            this.groupBox3.Controls.Add(this.textHexPath);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(13, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(384, 225);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Карта памяти";
            // 
            // lStorageEndAddress
            // 
            this.lStorageEndAddress.AutoSize = true;
            this.lStorageEndAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStorageEndAddress.Location = new System.Drawing.Point(252, 124);
            this.lStorageEndAddress.Name = "lStorageEndAddress";
            this.lStorageEndAddress.Size = new System.Drawing.Size(12, 16);
            this.lStorageEndAddress.TabIndex = 14;
            this.lStorageEndAddress.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(6, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(216, 16);
            this.label14.TabIndex = 13;
            this.label14.Text = "Конечный адрес хранилища:";
            // 
            // lStorageStartAddress
            // 
            this.lStorageStartAddress.AutoSize = true;
            this.lStorageStartAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lStorageStartAddress.Location = new System.Drawing.Point(252, 102);
            this.lStorageStartAddress.Name = "lStorageStartAddress";
            this.lStorageStartAddress.Size = new System.Drawing.Size(12, 16);
            this.lStorageStartAddress.TabIndex = 12;
            this.lStorageStartAddress.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(6, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(226, 16);
            this.label16.TabIndex = 11;
            this.label16.Text = "Начальный адрес хранилища:";
            // 
            // lMainAppEndAddress
            // 
            this.lMainAppEndAddress.AutoSize = true;
            this.lMainAppEndAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMainAppEndAddress.Location = new System.Drawing.Point(252, 80);
            this.lMainAppEndAddress.Name = "lMainAppEndAddress";
            this.lMainAppEndAddress.Size = new System.Drawing.Size(12, 16);
            this.lMainAppEndAddress.TabIndex = 10;
            this.lMainAppEndAddress.Text = "-";
            // 
            // bSelectHexFile
            // 
            this.bSelectHexFile.Location = new System.Drawing.Point(6, 188);
            this.bSelectHexFile.Name = "bSelectHexFile";
            this.bSelectHexFile.Size = new System.Drawing.Size(373, 28);
            this.bSelectHexFile.TabIndex = 1;
            this.bSelectHexFile.Text = "Обновить";
            this.bSelectHexFile.UseVisualStyleBackColor = true;
            this.bSelectHexFile.Click += new System.EventHandler(this.bSelectHexFile_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(6, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(226, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Конечный адрес приложения:";
            // 
            // lMainAppStartAddress
            // 
            this.lMainAppStartAddress.AutoSize = true;
            this.lMainAppStartAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMainAppStartAddress.Location = new System.Drawing.Point(252, 58);
            this.lMainAppStartAddress.Name = "lMainAppStartAddress";
            this.lMainAppStartAddress.Size = new System.Drawing.Size(12, 16);
            this.lMainAppStartAddress.TabIndex = 8;
            this.lMainAppStartAddress.Text = "-";
            // 
            // textHexPath
            // 
            this.textHexPath.Location = new System.Drawing.Point(6, 159);
            this.textHexPath.Name = "textHexPath";
            this.textHexPath.ReadOnly = true;
            this.textHexPath.Size = new System.Drawing.Size(373, 26);
            this.textHexPath.TabIndex = 0;
            this.textHexPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textHexPath_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(6, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(236, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Начальный адрес приложения:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.bWriteSim);
            this.groupBox4.Controls.Add(this.bResetSettings);
            this.groupBox4.Controls.Add(this.bSaveSettings);
            this.groupBox4.Controls.Add(this.bWriteHeartbeat);
            this.groupBox4.Controls.Add(this.textHertbeat);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.bWriteNet);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.textPort);
            this.groupBox4.Controls.Add(this.bWriteServer);
            this.groupBox4.Controls.Add(this.textServer);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textPass);
            this.groupBox4.Controls.Add(this.bPassWrite);
            this.groupBox4.Controls.Add(this.textLogin);
            this.groupBox4.Controls.Add(this.bWriteApn);
            this.groupBox4.Controls.Add(this.textApn);
            this.groupBox4.Controls.Add(this.PA);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(404, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 343);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Настройка модема";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioSIM1);
            this.groupBox7.Controls.Add(this.radioSIM2);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.Location = new System.Drawing.Point(118, 257);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(211, 51);
            this.groupBox7.TabIndex = 38;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "TYPE";
            // 
            // radioSIM1
            // 
            this.radioSIM1.AutoSize = true;
            this.radioSIM1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioSIM1.Location = new System.Drawing.Point(21, 18);
            this.radioSIM1.Name = "radioSIM1";
            this.radioSIM1.Size = new System.Drawing.Size(50, 17);
            this.radioSIM1.TabIndex = 26;
            this.radioSIM1.TabStop = true;
            this.radioSIM1.Text = "SIM1";
            this.radioSIM1.UseVisualStyleBackColor = true;
            // 
            // radioSIM2
            // 
            this.radioSIM2.AutoSize = true;
            this.radioSIM2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioSIM2.Location = new System.Drawing.Point(150, 17);
            this.radioSIM2.Name = "radioSIM2";
            this.radioSIM2.Size = new System.Drawing.Size(50, 17);
            this.radioSIM2.TabIndex = 23;
            this.radioSIM2.TabStop = true;
            this.radioSIM2.Text = "SIM2";
            this.radioSIM2.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(6, 277);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 16);
            this.label18.TabIndex = 35;
            this.label18.Text = "SIM CARD:";
            // 
            // bWriteSim
            // 
            this.bWriteSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bWriteSim.Location = new System.Drawing.Point(335, 262);
            this.bWriteSim.Name = "bWriteSim";
            this.bWriteSim.Size = new System.Drawing.Size(40, 46);
            this.bWriteSim.TabIndex = 37;
            this.bWriteSim.Text = "W";
            this.bWriteSim.UseVisualStyleBackColor = true;
            this.bWriteSim.Click += new System.EventHandler(this.bWriteSim_Click);
            // 
            // bResetSettings
            // 
            this.bResetSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bResetSettings.Location = new System.Drawing.Point(198, 314);
            this.bResetSettings.Name = "bResetSettings";
            this.bResetSettings.Size = new System.Drawing.Size(177, 23);
            this.bResetSettings.TabIndex = 34;
            this.bResetSettings.Text = "RESET TO DEFAULT";
            this.bResetSettings.UseVisualStyleBackColor = true;
            this.bResetSettings.Click += new System.EventHandler(this.bResetSettings_Click);
            // 
            // bSaveSettings
            // 
            this.bSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSaveSettings.Location = new System.Drawing.Point(6, 314);
            this.bSaveSettings.Name = "bSaveSettings";
            this.bSaveSettings.Size = new System.Drawing.Size(177, 23);
            this.bSaveSettings.TabIndex = 33;
            this.bSaveSettings.Text = "SAVE SETTINGS";
            this.bSaveSettings.UseVisualStyleBackColor = true;
            this.bSaveSettings.Click += new System.EventHandler(this.bSaveSettings_Click);
            // 
            // bWriteHeartbeat
            // 
            this.bWriteHeartbeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bWriteHeartbeat.Location = new System.Drawing.Point(335, 225);
            this.bWriteHeartbeat.Name = "bWriteHeartbeat";
            this.bWriteHeartbeat.Size = new System.Drawing.Size(40, 23);
            this.bWriteHeartbeat.TabIndex = 32;
            this.bWriteHeartbeat.Text = "W";
            this.bWriteHeartbeat.UseVisualStyleBackColor = true;
            this.bWriteHeartbeat.Click += new System.EventHandler(this.bWriteHeartbeat_Click);
            // 
            // textHertbeat
            // 
            this.textHertbeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textHertbeat.Location = new System.Drawing.Point(118, 225);
            this.textHertbeat.Name = "textHertbeat";
            this.textHertbeat.Size = new System.Drawing.Size(211, 22);
            this.textHertbeat.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(6, 228);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 16);
            this.label17.TabIndex = 29;
            this.label17.Text = "HEARTBEAT:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioNetLte);
            this.groupBox6.Controls.Add(this.radioNetAuto);
            this.groupBox6.Controls.Add(this.radioNetGsm);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(118, 168);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 51);
            this.groupBox6.TabIndex = 28;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "TYPE";
            // 
            // radioNetLte
            // 
            this.radioNetLte.AutoSize = true;
            this.radioNetLte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioNetLte.Location = new System.Drawing.Point(150, 20);
            this.radioNetLte.Name = "radioNetLte";
            this.radioNetLte.Size = new System.Drawing.Size(45, 17);
            this.radioNetLte.TabIndex = 27;
            this.radioNetLte.TabStop = true;
            this.radioNetLte.Text = "LTE";
            this.radioNetLte.UseVisualStyleBackColor = true;
            // 
            // radioNetAuto
            // 
            this.radioNetAuto.AutoSize = true;
            this.radioNetAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioNetAuto.Location = new System.Drawing.Point(21, 20);
            this.radioNetAuto.Name = "radioNetAuto";
            this.radioNetAuto.Size = new System.Drawing.Size(55, 17);
            this.radioNetAuto.TabIndex = 26;
            this.radioNetAuto.TabStop = true;
            this.radioNetAuto.Text = "AUTO";
            this.radioNetAuto.UseVisualStyleBackColor = true;
            // 
            // radioNetGsm
            // 
            this.radioNetGsm.AutoSize = true;
            this.radioNetGsm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioNetGsm.Location = new System.Drawing.Point(86, 20);
            this.radioNetGsm.Name = "radioNetGsm";
            this.radioNetGsm.Size = new System.Drawing.Size(49, 17);
            this.radioNetGsm.TabIndex = 23;
            this.radioNetGsm.TabStop = true;
            this.radioNetGsm.Text = "GSM";
            this.radioNetGsm.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(7, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "NETWORK:";
            // 
            // bWriteNet
            // 
            this.bWriteNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bWriteNet.Location = new System.Drawing.Point(336, 173);
            this.bWriteNet.Name = "bWriteNet";
            this.bWriteNet.Size = new System.Drawing.Size(40, 46);
            this.bWriteNet.TabIndex = 27;
            this.bWriteNet.Text = "W";
            this.bWriteNet.UseVisualStyleBackColor = true;
            this.bWriteNet.Click += new System.EventHandler(this.bWriteNet_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioPAP);
            this.groupBox5.Controls.Add(this.radioCHAP);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(118, 110);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(211, 51);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TYPE";
            // 
            // radioPAP
            // 
            this.radioPAP.AutoSize = true;
            this.radioPAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioPAP.Location = new System.Drawing.Point(21, 19);
            this.radioPAP.Name = "radioPAP";
            this.radioPAP.Size = new System.Drawing.Size(46, 17);
            this.radioPAP.TabIndex = 26;
            this.radioPAP.TabStop = true;
            this.radioPAP.Text = "PAP";
            this.radioPAP.UseVisualStyleBackColor = true;
            // 
            // radioCHAP
            // 
            this.radioCHAP.AutoSize = true;
            this.radioCHAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioCHAP.Location = new System.Drawing.Point(150, 19);
            this.radioCHAP.Name = "radioCHAP";
            this.radioCHAP.Size = new System.Drawing.Size(54, 17);
            this.radioCHAP.TabIndex = 23;
            this.radioCHAP.TabStop = true;
            this.radioCHAP.Text = "CHAP";
            this.radioCHAP.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(335, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 46);
            this.button1.TabIndex = 22;
            this.button1.Text = "W";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(6, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "AUTH TYPE:";
            // 
            // textPort
            // 
            this.textPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPort.Location = new System.Drawing.Point(282, 82);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(47, 22);
            this.textPort.TabIndex = 18;
            // 
            // bWriteServer
            // 
            this.bWriteServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bWriteServer.Location = new System.Drawing.Point(335, 82);
            this.bWriteServer.Name = "bWriteServer";
            this.bWriteServer.Size = new System.Drawing.Size(40, 23);
            this.bWriteServer.TabIndex = 17;
            this.bWriteServer.Text = "W";
            this.bWriteServer.UseVisualStyleBackColor = true;
            this.bWriteServer.Click += new System.EventHandler(this.bWriteServer_Click);
            // 
            // textServer
            // 
            this.textServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textServer.Location = new System.Drawing.Point(118, 82);
            this.textServer.Name = "textServer";
            this.textServer.Size = new System.Drawing.Size(158, 22);
            this.textServer.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(6, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "NBFI SERVER:";
            // 
            // textPass
            // 
            this.textPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPass.Location = new System.Drawing.Point(236, 51);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(93, 22);
            this.textPass.TabIndex = 13;
            // 
            // bPassWrite
            // 
            this.bPassWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bPassWrite.Location = new System.Drawing.Point(335, 51);
            this.bPassWrite.Name = "bPassWrite";
            this.bPassWrite.Size = new System.Drawing.Size(40, 23);
            this.bPassWrite.TabIndex = 12;
            this.bPassWrite.Text = "W";
            this.bPassWrite.UseVisualStyleBackColor = true;
            this.bPassWrite.Click += new System.EventHandler(this.bPassWrite_Click);
            // 
            // textLogin
            // 
            this.textLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogin.Location = new System.Drawing.Point(118, 51);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(112, 22);
            this.textLogin.TabIndex = 10;
            // 
            // bWriteApn
            // 
            this.bWriteApn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bWriteApn.Location = new System.Drawing.Point(335, 23);
            this.bWriteApn.Name = "bWriteApn";
            this.bWriteApn.Size = new System.Drawing.Size(40, 23);
            this.bWriteApn.TabIndex = 9;
            this.bWriteApn.Text = "W";
            this.bWriteApn.UseVisualStyleBackColor = true;
            this.bWriteApn.Click += new System.EventHandler(this.bWriteApn_Click);
            // 
            // textApn
            // 
            this.textApn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textApn.Location = new System.Drawing.Point(118, 23);
            this.textApn.Name = "textApn";
            this.textApn.Size = new System.Drawing.Size(211, 22);
            this.textApn.TabIndex = 7;
            // 
            // PA
            // 
            this.PA.AutoSize = true;
            this.PA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PA.Location = new System.Drawing.Point(6, 54);
            this.PA.Name = "PA";
            this.PA.Size = new System.Drawing.Size(101, 16);
            this.PA.TabIndex = 5;
            this.PA.Text = "LOGIN/PASS:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(6, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "APN:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Fd
            // 
            this.Fd.Controls.Add(this.label21);
            this.Fd.Controls.Add(this.lSelftestProgress);
            this.Fd.Controls.Add(this.selfTestProgress);
            this.Fd.Location = new System.Drawing.Point(13, 179);
            this.Fd.Name = "Fd";
            this.Fd.Size = new System.Drawing.Size(384, 100);
            this.Fd.TabIndex = 8;
            this.Fd.TabStop = false;
            this.Fd.Text = "Автотест";
            // 
            // selfTestProgress
            // 
            this.selfTestProgress.Location = new System.Drawing.Point(9, 44);
            this.selfTestProgress.Name = "selfTestProgress";
            this.selfTestProgress.Size = new System.Drawing.Size(369, 23);
            this.selfTestProgress.Step = 1;
            this.selfTestProgress.TabIndex = 39;
            // 
            // lSelftestProgress
            // 
            this.lSelftestProgress.AutoSize = true;
            this.lSelftestProgress.Location = new System.Drawing.Point(6, 70);
            this.lSelftestProgress.Name = "lSelftestProgress";
            this.lSelftestProgress.Size = new System.Drawing.Size(42, 13);
            this.lSelftestProgress.TabIndex = 40;
            this.lSelftestProgress.Text = "Готово";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(6, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(151, 16);
            this.label21.TabIndex = 41;
            this.label21.Text = "Проверка устройства";
            // 
            // bSelftest
            // 
            this.bSelftest.Enabled = false;
            this.bSelftest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSelftest.Location = new System.Drawing.Point(289, 110);
            this.bSelftest.Name = "bSelftest";
            this.bSelftest.Size = new System.Drawing.Size(73, 30);
            this.bSelftest.TabIndex = 42;
            this.bSelftest.Text = "Автотест";
            this.bSelftest.UseVisualStyleBackColor = true;
            this.bSelftest.Click += new System.EventHandler(this.bSelftest_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 652);
            this.Controls.Add(this.Fd);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainApp";
            this.Text = "BT210 Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.logWriter, 0);
            this.Controls.SetChildIndex(this.Fd, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.Fd.ResumeLayout(false);
            this.Fd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lFirmwareName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lNbfiId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lwa1470;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label liccidTwo;
        private System.Windows.Forms.Label liccidone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lRSSI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textHexPath;
        private System.Windows.Forms.Button bSelectHexFile;
        private System.Windows.Forms.Label lStorageEndAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lStorageStartAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lMainAppEndAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lMainAppStartAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bWriteApn;
        private System.Windows.Forms.TextBox textApn;
        private System.Windows.Forms.Label PA;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button bPassWrite;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Button bWriteServer;
        private System.Windows.Forms.TextBox textServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioPAP;
        private System.Windows.Forms.RadioButton radioCHAP;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioNetLte;
        private System.Windows.Forms.RadioButton radioNetAuto;
        private System.Windows.Forms.RadioButton radioNetGsm;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bWriteNet;
        private System.Windows.Forms.Button bWriteHeartbeat;
        private System.Windows.Forms.TextBox textHertbeat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bResetSettings;
        private System.Windows.Forms.Button bSaveSettings;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioSIM1;
        private System.Windows.Forms.RadioButton radioSIM2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button bWriteSim;
        private System.Windows.Forms.Label lDeviceIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bSelectLte;
        private System.Windows.Forms.Button bSelectWa1470;
        private System.Windows.Forms.Button bSendViaNbfi;
        private System.Windows.Forms.TextBox textNbfiPayload;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.TextBox textWaviotPassword;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textWaviotLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox Fd;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lSelftestProgress;
        private System.Windows.Forms.ProgressBar selfTestProgress;
        private System.Windows.Forms.Button bSelftest;
    }
}

