
namespace WAVIOT.Water7Client.devices
{
    partial class Aqua
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFirmwareUpdate = new System.Windows.Forms.Button();
            this.textHexPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressUpdateFw = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelProgress);
            this.groupBox1.Controls.Add(this.progressUpdateFw);
            this.groupBox1.Controls.Add(this.buttonFirmwareUpdate);
            this.groupBox1.Controls.Add(this.textHexPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обновление ПО";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonFirmwareUpdate
            // 
            this.buttonFirmwareUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFirmwareUpdate.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFirmwareUpdate.Location = new System.Drawing.Point(10, 95);
            this.buttonFirmwareUpdate.Name = "buttonFirmwareUpdate";
            this.buttonFirmwareUpdate.Size = new System.Drawing.Size(346, 33);
            this.buttonFirmwareUpdate.TabIndex = 11;
            this.buttonFirmwareUpdate.Text = "Поставить обновление в очередь";
            this.buttonFirmwareUpdate.UseVisualStyleBackColor = true;
            this.buttonFirmwareUpdate.Click += new System.EventHandler(this.buttonFirmwareUpdate_Click);
            // 
            // textHexPath
            // 
            this.textHexPath.Location = new System.Drawing.Point(74, 69);
            this.textHexPath.Name = "textHexPath";
            this.textHexPath.Size = new System.Drawing.Size(282, 20);
            this.textHexPath.TabIndex = 1;
            this.textHexPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textHexPathClickHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Прошивка";
            // 
            // progressUpdateFw
            // 
            this.progressUpdateFw.Location = new System.Drawing.Point(10, 40);
            this.progressUpdateFw.Name = "progressUpdateFw";
            this.progressUpdateFw.Size = new System.Drawing.Size(346, 23);
            this.progressUpdateFw.Step = 1;
            this.progressUpdateFw.TabIndex = 12;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(9, 24);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(69, 13);
            this.labelProgress.TabIndex = 13;
            this.labelProgress.Text = "Обновление";
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Aqua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Aqua";
            this.Text = "Aqua";
            this.Load += new System.EventHandler(this.Aqua_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textHexPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFirmwareUpdate;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressUpdateFw;
    }
}