
namespace WAVIOT.Water7Client.devices
{
    partial class BigTiffanyCurrentLoop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BigTiffanyCurrentLoop));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxRawMode = new System.Windows.Forms.CheckBox();
            this.bSettingsWrite = new System.Windows.Forms.Button();
            this.textMessagesPerDay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxStepUp = new System.Windows.Forms.CheckBox();
            this.textMinScaleValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textMaxScaleValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMaxCurrentValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textMinCurrentValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventMessageView = new WaviotAPI.Controls.EventLogView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBoxRawMode);
            this.groupBox1.Controls.Add(this.bSettingsWrite);
            this.groupBox1.Controls.Add(this.textMessagesPerDay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxStepUp);
            this.groupBox1.Controls.Add(this.textMinScaleValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textMaxScaleValue);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textMaxCurrentValue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textMinCurrentValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(537, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 241);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "RAW данные";
            // 
            // checkBoxRawMode
            // 
            this.checkBoxRawMode.AutoSize = true;
            this.checkBoxRawMode.Location = new System.Drawing.Point(215, 180);
            this.checkBoxRawMode.Name = "checkBoxRawMode";
            this.checkBoxRawMode.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRawMode.TabIndex = 13;
            this.checkBoxRawMode.UseVisualStyleBackColor = true;
            // 
            // bSettingsWrite
            // 
            this.bSettingsWrite.Location = new System.Drawing.Point(9, 200);
            this.bSettingsWrite.Name = "bSettingsWrite";
            this.bSettingsWrite.Size = new System.Drawing.Size(297, 33);
            this.bSettingsWrite.TabIndex = 12;
            this.bSettingsWrite.Text = "Отправить настройки";
            this.bSettingsWrite.UseVisualStyleBackColor = true;
            this.bSettingsWrite.Click += new System.EventHandler(this.bSettingsWrite_Click);
            // 
            // textMessagesPerDay
            // 
            this.textMessagesPerDay.Location = new System.Drawing.Point(215, 127);
            this.textMessagesPerDay.Name = "textMessagesPerDay";
            this.textMessagesPerDay.Size = new System.Drawing.Size(91, 20);
            this.textMessagesPerDay.TabIndex = 11;
            this.textMessagesPerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMessagesPerDay.TextChanged += new System.EventHandler(this.ControlStateTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Кол-во сообщений в сутки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Повышающий преобразователь";
            // 
            // checkBoxStepUp
            // 
            this.checkBoxStepUp.AutoSize = true;
            this.checkBoxStepUp.Location = new System.Drawing.Point(215, 155);
            this.checkBoxStepUp.Name = "checkBoxStepUp";
            this.checkBoxStepUp.Size = new System.Drawing.Size(15, 14);
            this.checkBoxStepUp.TabIndex = 8;
            this.checkBoxStepUp.UseVisualStyleBackColor = true;
            this.checkBoxStepUp.CheckedChanged += new System.EventHandler(this.ControlStateTextChanged);
            // 
            // textMinScaleValue
            // 
            this.textMinScaleValue.Location = new System.Drawing.Point(215, 102);
            this.textMinScaleValue.Name = "textMinScaleValue";
            this.textMinScaleValue.Size = new System.Drawing.Size(91, 20);
            this.textMinScaleValue.TabIndex = 7;
            this.textMinScaleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMinScaleValue.TextChanged += new System.EventHandler(this.ControlStateTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Нижнее значение шкалы";
            // 
            // textMaxScaleValue
            // 
            this.textMaxScaleValue.Location = new System.Drawing.Point(215, 77);
            this.textMaxScaleValue.Name = "textMaxScaleValue";
            this.textMaxScaleValue.Size = new System.Drawing.Size(91, 20);
            this.textMaxScaleValue.TabIndex = 5;
            this.textMaxScaleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMaxScaleValue.TextChanged += new System.EventHandler(this.ControlStateTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Верхнее значение шкалы";
            // 
            // textMaxCurrentValue
            // 
            this.textMaxCurrentValue.Location = new System.Drawing.Point(215, 52);
            this.textMaxCurrentValue.Name = "textMaxCurrentValue";
            this.textMaxCurrentValue.Size = new System.Drawing.Size(91, 20);
            this.textMaxCurrentValue.TabIndex = 3;
            this.textMaxCurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMaxCurrentValue.TextChanged += new System.EventHandler(this.ControlStateTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Максимальное значение тока петли";
            // 
            // textMinCurrentValue
            // 
            this.textMinCurrentValue.Location = new System.Drawing.Point(215, 27);
            this.textMinCurrentValue.Name = "textMinCurrentValue";
            this.textMinCurrentValue.Size = new System.Drawing.Size(91, 20);
            this.textMinCurrentValue.TabIndex = 1;
            this.textMinCurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMinCurrentValue.TextChanged += new System.EventHandler(this.ControlStateTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Минимальное значение тока петли";
            // 
            // eventMessageView
            // 
            this.eventMessageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventMessageView.Location = new System.Drawing.Point(12, 12);
            this.eventMessageView.Name = "eventMessageView";
            this.eventMessageView.Size = new System.Drawing.Size(507, 291);
            this.eventMessageView.TabIndex = 0;
            // 
            // BigTiffanyCurrentLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.eventMessageView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BigTiffanyCurrentLoop";
            this.Text = "BigTiffanyCurrentLoop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingEventHandler);
            this.Load += new System.EventHandler(this.BigTiffanyCurrentLoop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WaviotAPI.Controls.EventLogView eventMessageView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textMaxCurrentValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMinCurrentValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMinScaleValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMaxScaleValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxStepUp;
        private System.Windows.Forms.TextBox textMessagesPerDay;
        private System.Windows.Forms.Button bSettingsWrite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxRawMode;
    }
}