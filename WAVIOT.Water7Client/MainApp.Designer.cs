
namespace WAVIOT.Water7Client
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
            this.downlinkDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eventLogView = new WaviotAPI.Controls.EventLogView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkAutoSettingRequest = new System.Windows.Forms.CheckBox();
            this.textHardwareType = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bAuth = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bUpdateDeviceInfo = new System.Windows.Forms.Button();
            this.gridDeviceState = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSendParametersToDevice = new System.Windows.Forms.Button();
            this.bSettingRequestAll = new System.Windows.Forms.Button();
            this.bAllParameters = new System.Windows.Forms.Button();
            this.gridDeviceParameters = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSettingRequestPrimary = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.downlinkDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceParameters)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // logWriter
            // 
            this.logWriter.Location = new System.Drawing.Point(9, 453);
            this.logWriter.Size = new System.Drawing.Size(1074, 164);
            // 
            // downlinkDataGrid
            // 
            this.downlinkDataGrid.AllowUserToAddRows = false;
            this.downlinkDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downlinkDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.downlinkDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.downlinkDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.STATUS});
            this.downlinkDataGrid.Location = new System.Drawing.Point(6, 258);
            this.downlinkDataGrid.Name = "downlinkDataGrid";
            this.downlinkDataGrid.RowHeadersVisible = false;
            this.downlinkDataGrid.Size = new System.Drawing.Size(475, 158);
            this.downlinkDataGrid.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 49.56658F;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 81.21828F;
            this.dataGridViewTextBoxColumn2.HeaderText = "ModemID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 136.6939F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Payload";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 132.5213F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // STATUS
            // 
            this.STATUS.HeaderText = "Status";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eventLogView);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.downlinkDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(595, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 423);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // eventLogView
            // 
            this.eventLogView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLogView.Location = new System.Drawing.Point(6, 42);
            this.eventLogView.Name = "eventLogView";
            this.eventLogView.Size = new System.Drawing.Size(474, 179);
            this.eventLogView.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(153, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Downlink messages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(153, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Uplink messages";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkAutoSettingRequest);
            this.groupBox2.Controls.Add(this.textHardwareType);
            this.groupBox2.Controls.Add(this.textAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.bAuth);
            this.groupBox2.Controls.Add(this.textPassword);
            this.groupBox2.Controls.Add(this.textLogin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 95);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Авторизация";
            // 
            // checkAutoSettingRequest
            // 
            this.checkAutoSettingRequest.AutoSize = true;
            this.checkAutoSettingRequest.Location = new System.Drawing.Point(477, 15);
            this.checkAutoSettingRequest.Name = "checkAutoSettingRequest";
            this.checkAutoSettingRequest.Size = new System.Drawing.Size(89, 17);
            this.checkAutoSettingRequest.TabIndex = 9;
            this.checkAutoSettingRequest.Text = "Автозапрос ";
            this.checkAutoSettingRequest.UseVisualStyleBackColor = true;
            // 
            // textHardwareType
            // 
            this.textHardwareType.Enabled = false;
            this.textHardwareType.Location = new System.Drawing.Point(385, 35);
            this.textHardwareType.Name = "textHardwareType";
            this.textHardwareType.Size = new System.Drawing.Size(181, 20);
            this.textHardwareType.TabIndex = 8;
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(385, 13);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(75, 20);
            this.textAddress.TabIndex = 7;
            this.textAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "hw_type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Адрес устройства";
            // 
            // bAuth
            // 
            this.bAuth.Location = new System.Drawing.Point(10, 61);
            this.bAuth.Name = "bAuth";
            this.bAuth.Size = new System.Drawing.Size(557, 23);
            this.bAuth.TabIndex = 4;
            this.bAuth.Text = "Авторизация";
            this.bAuth.UseVisualStyleBackColor = true;
            this.bAuth.Click += new System.EventHandler(this.bAuth_Click);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(58, 35);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(181, 20);
            this.textPassword.TabIndex = 3;
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(58, 13);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(181, 20);
            this.textLogin.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Логин";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bUpdateDeviceInfo);
            this.groupBox3.Controls.Add(this.gridDeviceState);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 316);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NB-Fi";
            // 
            // bUpdateDeviceInfo
            // 
            this.bUpdateDeviceInfo.Location = new System.Drawing.Point(9, 19);
            this.bUpdateDeviceInfo.Name = "bUpdateDeviceInfo";
            this.bUpdateDeviceInfo.Size = new System.Drawing.Size(155, 48);
            this.bUpdateDeviceInfo.TabIndex = 9;
            this.bUpdateDeviceInfo.Text = "Обновить";
            this.bUpdateDeviceInfo.UseVisualStyleBackColor = true;
            this.bUpdateDeviceInfo.Click += new System.EventHandler(this.bUpdateDeviceInfo_Click);
            // 
            // gridDeviceState
            // 
            this.gridDeviceState.AllowUserToAddRows = false;
            this.gridDeviceState.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDeviceState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDeviceState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.gridDeviceState.Location = new System.Drawing.Point(9, 74);
            this.gridDeviceState.Name = "gridDeviceState";
            this.gridDeviceState.RowHeadersVisible = false;
            this.gridDeviceState.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridDeviceState.Size = new System.Drawing.Size(156, 235);
            this.gridDeviceState.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.FillWeight = 71.03544F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Параметр";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 59.74942F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // bSendParametersToDevice
            // 
            this.bSendParametersToDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSendParametersToDevice.ForeColor = System.Drawing.Color.Black;
            this.bSendParametersToDevice.Location = new System.Drawing.Point(138, 19);
            this.bSendParametersToDevice.Name = "bSendParametersToDevice";
            this.bSendParametersToDevice.Size = new System.Drawing.Size(123, 48);
            this.bSendParametersToDevice.TabIndex = 11;
            this.bSendParametersToDevice.Text = "Записать параметры";
            this.bSendParametersToDevice.UseVisualStyleBackColor = true;
            this.bSendParametersToDevice.Click += new System.EventHandler(this.bSendParametersToDevice_Click);
            // 
            // bSettingRequestAll
            // 
            this.bSettingRequestAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSettingRequestAll.ForeColor = System.Drawing.Color.Black;
            this.bSettingRequestAll.Location = new System.Drawing.Point(6, 19);
            this.bSettingRequestAll.Name = "bSettingRequestAll";
            this.bSettingRequestAll.Size = new System.Drawing.Size(126, 23);
            this.bSettingRequestAll.TabIndex = 10;
            this.bSettingRequestAll.Text = "Запросить все";
            this.bSettingRequestAll.UseVisualStyleBackColor = true;
            this.bSettingRequestAll.Click += new System.EventHandler(this.bSettingRequestAll_Click);
            // 
            // bAllParameters
            // 
            this.bAllParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bAllParameters.ForeColor = System.Drawing.Color.Black;
            this.bAllParameters.Location = new System.Drawing.Point(267, 19);
            this.bAllParameters.Name = "bAllParameters";
            this.bAllParameters.Size = new System.Drawing.Size(123, 48);
            this.bAllParameters.TabIndex = 9;
            this.bAllParameters.Text = "Все параметры";
            this.bAllParameters.UseVisualStyleBackColor = true;
            this.bAllParameters.Click += new System.EventHandler(this.bAllParameters_Click);
            // 
            // gridDeviceParameters
            // 
            this.gridDeviceParameters.AllowUserToAddRows = false;
            this.gridDeviceParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDeviceParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDeviceParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.gridDeviceParameters.Location = new System.Drawing.Point(6, 75);
            this.gridDeviceParameters.Name = "gridDeviceParameters";
            this.gridDeviceParameters.RowHeadersVisible = false;
            this.gridDeviceParameters.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.gridDeviceParameters.Size = new System.Drawing.Size(384, 235);
            this.gridDeviceParameters.TabIndex = 6;
            this.gridDeviceParameters.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDeviceParameters_CellContentClick);
            this.gridDeviceParameters.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDeviceParameters_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 79.66589F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Параметр";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 51.11896F;
            this.dataGridViewTextBoxColumn6.HeaderText = "Значение";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // bSettingRequestPrimary
            // 
            this.bSettingRequestPrimary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bSettingRequestPrimary.ForeColor = System.Drawing.Color.Black;
            this.bSettingRequestPrimary.Location = new System.Drawing.Point(6, 44);
            this.bSettingRequestPrimary.Name = "bSettingRequestPrimary";
            this.bSettingRequestPrimary.Size = new System.Drawing.Size(126, 23);
            this.bSettingRequestPrimary.TabIndex = 4;
            this.bSettingRequestPrimary.Text = "Запросить основные";
            this.bSettingRequestPrimary.UseVisualStyleBackColor = true;
            this.bSettingRequestPrimary.Click += new System.EventHandler(this.bSettingRequest_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gridDeviceParameters);
            this.groupBox4.Controls.Add(this.bSettingRequestPrimary);
            this.groupBox4.Controls.Add(this.bSendParametersToDevice);
            this.groupBox4.Controls.Add(this.bSettingRequestAll);
            this.groupBox4.Controls.Add(this.bAllParameters);
            this.groupBox4.Location = new System.Drawing.Point(193, 134);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 316);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры Water7";
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 626);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainApp";
            this.Text = "Water7Client";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.Controls.SetChildIndex(this.logWriter, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.downlinkDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeviceParameters)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView downlinkDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bAuth;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bSettingRequestPrimary;
        private System.Windows.Forms.DataGridView gridDeviceParameters;
        private System.Windows.Forms.DataGridView gridDeviceState;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.TextBox textHardwareType;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button bAllParameters;
        private System.Windows.Forms.Button bSettingRequestAll;
        private System.Windows.Forms.Button bSendParametersToDevice;
        private System.Windows.Forms.Button bUpdateDeviceInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private WaviotAPI.Controls.EventLogView eventLogView;
        private System.Windows.Forms.CheckBox checkAutoSettingRequest;
    }
}

