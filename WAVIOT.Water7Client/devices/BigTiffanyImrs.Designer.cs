
using System;

namespace WAVIOT.Water7Client
{
    partial class BigTiffanyImrs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigTiffanyImrs));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFirmwareUpdate = new System.Windows.Forms.Button();
            this.textHexPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eventLogView1 = new WaviotAPI.Controls.EventLogView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxEnablePulseScanning = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textIrqFrequency = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMessageFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bWriteSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonFirmwareUpdate);
            this.groupBox1.Controls.Add(this.textHexPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обновление обработчика";
            // 
            // buttonFirmwareUpdate
            // 
            this.buttonFirmwareUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFirmwareUpdate.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFirmwareUpdate.Location = new System.Drawing.Point(6, 82);
            this.buttonFirmwareUpdate.Name = "buttonFirmwareUpdate";
            this.buttonFirmwareUpdate.Size = new System.Drawing.Size(342, 33);
            this.buttonFirmwareUpdate.TabIndex = 10;
            this.buttonFirmwareUpdate.Text = "Поставить обновление в очередь";
            this.buttonFirmwareUpdate.UseVisualStyleBackColor = true;
            this.buttonFirmwareUpdate.Click += new System.EventHandler(this.buttonFirmwareUpdate_Click);
            // 
            // textHexPath
            // 
            this.textHexPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textHexPath.BackColor = System.Drawing.SystemColors.Control;
            this.textHexPath.Location = new System.Drawing.Point(9, 43);
            this.textHexPath.Name = "textHexPath";
            this.textHexPath.Size = new System.Drawing.Size(342, 20);
            this.textHexPath.TabIndex = 2;
            this.textHexPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textHexPathClickHandler);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MAP файл прошивки ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HEX файл прошивки ";
            // 
            // eventLogView1
            // 
            this.eventLogView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventLogView1.Location = new System.Drawing.Point(375, 12);
            this.eventLogView1.Name = "eventLogView1";
            this.eventLogView1.Size = new System.Drawing.Size(456, 264);
            this.eventLogView1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bWriteSettings);
            this.groupBox2.Controls.Add(this.checkBoxEnablePulseScanning);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textIrqFrequency);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textMessageFrequency);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 133);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры устройства";
            // 
            // checkBoxEnablePulseScanning
            // 
            this.checkBoxEnablePulseScanning.AutoSize = true;
            this.checkBoxEnablePulseScanning.Location = new System.Drawing.Point(186, 80);
            this.checkBoxEnablePulseScanning.Name = "checkBoxEnablePulseScanning";
            this.checkBoxEnablePulseScanning.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEnablePulseScanning.TabIndex = 7;
            this.checkBoxEnablePulseScanning.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Опрос импульсных датчиков:";
            // 
            // textIrqFrequency
            // 
            this.textIrqFrequency.Location = new System.Drawing.Point(187, 52);
            this.textIrqFrequency.Name = "textIrqFrequency";
            this.textIrqFrequency.Size = new System.Drawing.Size(164, 20);
            this.textIrqFrequency.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Частота опроса датчиков (Hz)";
            // 
            // textMessageFrequency
            // 
            this.textMessageFrequency.Location = new System.Drawing.Point(187, 26);
            this.textMessageFrequency.Name = "textMessageFrequency";
            this.textMessageFrequency.Size = new System.Drawing.Size(164, 20);
            this.textMessageFrequency.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Частота сообщений в день:";
            // 
            // bWriteSettings
            // 
            this.bWriteSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bWriteSettings.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bWriteSettings.Location = new System.Drawing.Point(6, 100);
            this.bWriteSettings.Name = "bWriteSettings";
            this.bWriteSettings.Size = new System.Drawing.Size(342, 27);
            this.bWriteSettings.TabIndex = 11;
            this.bWriteSettings.Text = "Записать параметры";
            this.bWriteSettings.UseVisualStyleBackColor = true;
            this.bWriteSettings.Click += new System.EventHandler(this.bWriteSettings_Click);
            // 
            // BigTiffanyImrs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 288);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.eventLogView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BigTiffanyImrs";
            this.Text = "BigTiffany RS232/RS485 Modem";
            this.Load += new System.EventHandler(this.BigTiffanyImrs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textHexPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFirmwareUpdate;
        private WaviotAPI.Controls.EventLogView eventLogView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxEnablePulseScanning;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textIrqFrequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMessageFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bWriteSettings;
    }
}