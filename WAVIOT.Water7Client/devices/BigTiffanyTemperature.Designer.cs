
namespace WAVIOT.Water7Client.devices
{
    partial class BigTiffanyTemperature
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigTiffanyTemperature));
            this.eventLogView1 = new WaviotAPI.Controls.EventLogView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboSensorType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textMessageFrequency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkRawMode = new System.Windows.Forms.CheckBox();
            this.bSendSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLogView1
            // 
            this.eventLogView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLogView1.Location = new System.Drawing.Point(13, 13);
            this.eventLogView1.Name = "eventLogView1";
            this.eventLogView1.Size = new System.Drawing.Size(459, 262);
            this.eventLogView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bSendSettings);
            this.groupBox1.Controls.Add(this.checkRawMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textMessageFrequency);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboSensorType);
            this.groupBox1.Location = new System.Drawing.Point(479, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // comboSensorType
            // 
            this.comboSensorType.FormattingEnabled = true;
            this.comboSensorType.Items.AddRange(new object[] {
            "1-Wire",
            "RTD",
            "Thermocouple"});
            this.comboSensorType.Location = new System.Drawing.Point(6, 17);
            this.comboSensorType.Name = "comboSensorType";
            this.comboSensorType.Size = new System.Drawing.Size(187, 21);
            this.comboSensorType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Частота сообщений:";
            // 
            // textMessageFrequency
            // 
            this.textMessageFrequency.Location = new System.Drawing.Point(127, 44);
            this.textMessageFrequency.Name = "textMessageFrequency";
            this.textMessageFrequency.Size = new System.Drawing.Size(67, 20);
            this.textMessageFrequency.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "RAW mode";
            // 
            // checkRawMode
            // 
            this.checkRawMode.AutoSize = true;
            this.checkRawMode.Location = new System.Drawing.Point(127, 71);
            this.checkRawMode.Name = "checkRawMode";
            this.checkRawMode.Size = new System.Drawing.Size(15, 14);
            this.checkRawMode.TabIndex = 4;
            this.checkRawMode.UseVisualStyleBackColor = true;
            // 
            // bSendSettings
            // 
            this.bSendSettings.Location = new System.Drawing.Point(9, 101);
            this.bSendSettings.Name = "bSendSettings";
            this.bSendSettings.Size = new System.Drawing.Size(184, 23);
            this.bSendSettings.TabIndex = 5;
            this.bSendSettings.Text = "Отправить настройки";
            this.bSendSettings.UseVisualStyleBackColor = true;
            this.bSendSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // BigTiffanyTemperature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 287);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.eventLogView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BigTiffanyTemperature";
            this.Text = "BigTiffanyTemperature";
            this.Load += new System.EventHandler(this.BigTiffanyTemperature_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WaviotAPI.Controls.EventLogView eventLogView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkRawMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMessageFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSensorType;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button bSendSettings;
    }
}