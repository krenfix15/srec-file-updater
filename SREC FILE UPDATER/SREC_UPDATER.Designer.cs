namespace HWCAL
{
    partial class SREC_UPDATER
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OpenSrecFile = new System.Windows.Forms.OpenFileDialog();
            this.dgvHWCAL = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialogHWCAL = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadSrecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHWCAL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHWCAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHWCAL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.Gain,
            this.Offset,
            this.Signal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHWCAL.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHWCAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHWCAL.Location = new System.Drawing.Point(0, 24);
            this.dgvHWCAL.Name = "dgvHWCAL";
            this.dgvHWCAL.Size = new System.Drawing.Size(652, 342);
            this.dgvHWCAL.TabIndex = 1;
            this.dgvHWCAL.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHWCAL_CellEndEdit);
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
            this.Gain.HeaderText = "Gain [Hex]";
            this.Gain.Name = "Gain";
            // 
            // Offset
            // 
            this.Offset.HeaderText = "Offset [Hex]";
            this.Offset.Name = "Offset";
            // 
            // Signal
            // 
            this.Signal.HeaderText = "Signal name";
            this.Signal.Name = "Signal";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSrecToolStripMenuItem,
            this.writeChangesToolStripMenuItem,
            this.helpToolStripMenuItem,
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
            this.loadSrecToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.loadSrecToolStripMenuItem.Text = "Load Srec File";
            this.loadSrecToolStripMenuItem.Click += new System.EventHandler(this.LoadSrecToolStripMenuItem_Click);
            // 
            // writeChangesToolStripMenuItem
            // 
            this.writeChangesToolStripMenuItem.Name = "writeChangesToolStripMenuItem";
            this.writeChangesToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.writeChangesToolStripMenuItem.Text = "Write Updated File";
            this.writeChangesToolStripMenuItem.Click += new System.EventHandler(this.WriteChangesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // SREC_UPDATER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 366);
            this.Controls.Add(this.dgvHWCAL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SREC_UPDATER";
            this.Text = "SREC File Updater";
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

