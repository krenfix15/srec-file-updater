namespace HWCAL
{
    partial class HWCalForm
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
            this.OpenSrecFile = new System.Windows.Forms.OpenFileDialog();
            this.dgvHWCAL = new System.Windows.Forms.DataGridView();
            this.saveFileDialogHWCAL = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadSrecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHWCAL)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenSrecFile
            // 
            this.OpenSrecFile.FileName = "OpenSrecFile";
            // 
            // dgvHWCAL
            // 
            this.dgvHWCAL.AllowUserToAddRows = false;
            this.dgvHWCAL.AllowUserToDeleteRows = false;
            this.dgvHWCAL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHWCAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHWCAL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.Gain,
            this.Offset,
            this.Signal});
            this.dgvHWCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHWCAL.Location = new System.Drawing.Point(0, 24);
            this.dgvHWCAL.Name = "dgvHWCAL";
            this.dgvHWCAL.Size = new System.Drawing.Size(652, 342);
            this.dgvHWCAL.TabIndex = 1;
            this.dgvHWCAL.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHWCAL_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSrecToolStripMenuItem,
            this.writeChangesToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadSrecToolStripMenuItem
            // 
            this.loadSrecToolStripMenuItem.Name = "loadSrecToolStripMenuItem";
            this.loadSrecToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.loadSrecToolStripMenuItem.Text = "LOAD SREC FILE";
            this.loadSrecToolStripMenuItem.Click += new System.EventHandler(this.LoadSrecToolStripMenuItem_Click);
            // 
            // writeChangesToolStripMenuItem
            // 
            this.writeChangesToolStripMenuItem.Name = "writeChangesToolStripMenuItem";
            this.writeChangesToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.writeChangesToolStripMenuItem.Text = "WRITE UPDATED FILE";
            this.writeChangesToolStripMenuItem.Click += new System.EventHandler(this.WriteChangesToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.infoToolStripMenuItem.Text = "INFO";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // Position
            // 
            this.Position.FillWeight = 50F;
            this.Position.HeaderText = "Index";
            this.Position.Name = "Position";
            this.Position.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Gain
            // 
            this.Gain.HeaderText = "Gain [Float]";
            this.Gain.Name = "Gain";
            // 
            // Offset
            // 
            this.Offset.HeaderText = "Offset [Float]";
            this.Offset.Name = "Offset";
            // 
            // Signal
            // 
            this.Signal.HeaderText = "Signal name";
            this.Signal.Name = "Signal";
            // 
            // HWCalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 366);
            this.Controls.Add(this.dgvHWCAL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HWCalForm";
            this.Text = "Hardware Calibration Updater";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHWCAL)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenSrecFile;
        private System.Windows.Forms.DataGridView dgvHWCAL;
        private System.Windows.Forms.SaveFileDialog saveFileDialogHWCAL;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadSrecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signal;
    }
}

