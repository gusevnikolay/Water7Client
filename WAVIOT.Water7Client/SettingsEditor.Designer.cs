
namespace WAVIOT.Water7Client
{
    partial class SettingsEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsEditorForm));
            this.gridMetaData = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maximum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridMetaData)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMetaData
            // 
            this.gridMetaData.AllowUserToAddRows = false;
            this.gridMetaData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMetaData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridMetaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMetaData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.value,
            this.unit,
            this.max,
            this.maximum,
            this.comment});
            this.gridMetaData.Location = new System.Drawing.Point(0, 0);
            this.gridMetaData.Name = "gridMetaData";
            this.gridMetaData.RowHeadersVisible = false;
            this.gridMetaData.Size = new System.Drawing.Size(696, 387);
            this.gridMetaData.TabIndex = 0;
            // 
            // name
            // 
            this.name.FillWeight = 83.87334F;
            this.name.HeaderText = "Параметр";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // value
            // 
            this.value.FillWeight = 60.48043F;
            this.value.HeaderText = "Значение";
            this.value.Name = "value";
            // 
            // unit
            // 
            this.unit.FillWeight = 65.2631F;
            this.unit.HeaderText = "Ед. измерения";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // max
            // 
            this.max.FillWeight = 51.21251F;
            this.max.HeaderText = "Минимум";
            this.max.Name = "max";
            this.max.ReadOnly = true;
            // 
            // maximum
            // 
            this.maximum.FillWeight = 65.05897F;
            this.maximum.HeaderText = "Максимум";
            this.maximum.Name = "maximum";
            this.maximum.ReadOnly = true;
            // 
            // comment
            // 
            this.comment.FillWeight = 274.1117F;
            this.comment.HeaderText = "Описание";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            // 
            // SettingsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 386);
            this.Controls.Add(this.gridMetaData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsEditorForm";
            this.Text = "Детализация параметров";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingEventHandler);
            this.Load += new System.EventHandler(this.SettingsEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMetaData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView gridMetaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn max;
        private System.Windows.Forms.DataGridViewTextBoxColumn maximum;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
    }
}