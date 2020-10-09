using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;

namespace HWCAL
{
    public partial class SREC_UPDATER : Form
    {
        const int CELL_VALUE_LENGHT = 8;
        SrecFile SrecFile;
        HwCal HwCalStruct;

        /* Version of the application */
        int MajorVersion = 1;
        int MinorVersion = 0;
        int PatchVersion = 1;

        bool SrecFileWasAdded = false;

        public SREC_UPDATER()
        {
            InitializeComponent();
            this.Width = 650;

            dgvHWCAL.Columns[0].ReadOnly = true;
            dgvHWCAL.Columns[3].ReadOnly = true;

            dgvHWCAL.Columns[0].Width = 50;
            dgvHWCAL.Columns[1].Width = 100;
            dgvHWCAL.Columns[2].Width = 104;
            dgvHWCAL.Columns[3].Width = 240;

            dgvHWCAL.BackgroundColor = Color.White;
            dgvHWCAL.RowsDefaultCellStyle.BackColor = Color.White;
            dgvHWCAL.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgvHWCAL.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHWCAL.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            dgvHWCAL.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHWCAL.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHWCAL.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHWCAL.EnableHeadersVisualStyles = false; 
        }

        /// <summary>
        /// Open file object
        /// </summary>
        OpenFileDialog OpenSRECFile = new OpenFileDialog()
        {
            InitialDirectory = @"C:\",
            Title = "Browse SREC Files",

            CheckFileExists = true,
            CheckPathExists = true,

            DefaultExt = "txt",
            Filter = "srec files (*.srec;*.s19;*.sx)|*.srec;*.s19;*.sx",
            FilterIndex = 2,
            RestoreDirectory = true,

            ReadOnlyChecked = true,
            ShowReadOnly = true
        };

        /// <summary>
        /// Read the SREC input file and create the HwCal structure in RAM
        /// </summary>
        /// <param name="FileName"></param>
        private void ReadInputData(string FileName)
        {
            SrecFile = new SrecFile(FileName);
            HwCalStruct = new HwCal(SrecFile);
            SrecFileWasAdded = true;
        }

        /// <summary>
        /// Populate the DGV with the HwCal struct values
        /// </summary>
        private void PopulateInDataGridView()
        {
            /* Populate the calibration values of all channels in the DGV */
            foreach (var currentCh in HwCalStruct.hwcal_chans)
            {
                AddHwCalCh_InDGV(currentCh);
            }
        }

        /// <summary>
        /// Add calibration values of one channel in the DGV
        /// </summary>
        /// <param name="hwcal_Chan"></param>
        private void AddHwCalCh_InDGV(hwcal_chan hwcal_Chan)
        {
            UInt32 gain_reverse = HwCal.BigEndianToLittleEndian(hwcal_Chan.gain);
            UInt32 offset_reverse = HwCal.BigEndianToLittleEndian(hwcal_Chan.offs);
            dgvHWCAL.Rows.Add(dgvHWCAL.Rows.Count, gain_reverse.ToString("X8"), offset_reverse.ToString("X8"), hwcal_Chan.ChannelName);
        }


        /// <summary>
        /// Event called by the "Load Srec File" option of the ToolStripMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSrecToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (OpenSRECFile.ShowDialog() == DialogResult.OK)
            {
                ReadInputData(OpenSRECFile.FileName);
                PopulateInDataGridView();
            }
        }

        /// <summary>
        /// Event called by the "Write Updated File" option of the ToolStripMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteChangesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (SrecFileWasAdded)
            {
                
                string filepath = OpenSRECFile.FileName;
                string extension = Path.GetExtension(filepath);

                if(extension == ".srec")
                {
                    filepath = filepath.Replace(".srec", "_Updated.srec");
                }
                if(extension == ".s19")
                {
                    filepath = filepath.Replace(".s19", "_Updated.s19");
                }
                if(extension == ".sx")
                {
                    filepath = filepath.Replace(".sx", "_Updated.sx");
                }
                
                HwCalStruct.UpdateHwCalValuesFromDvg(dgvHWCAL);
                SrecFile = HwCalStruct.ConvertHwCalToSrec();

                SrecFile.WriteSrecToFile(filepath);
                string message = String.Format("The output file was saved in the same folder as the input file!\n{0}", filepath);
                MessageBox.Show(message, "Write Updated File - Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("First step: Load a SREC file.", "Write Updated File - Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event handler of the "Info" option of the ToolStripMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(string.Format("Pascal Vasile-Marian\nSREC File Updater\nVersion {0}.{1}.{2}", MajorVersion, MinorVersion, PatchVersion), "SREC File Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Event handler of the "Help" option of the ToolStripMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("1. Click on 'Load Srec File' and select the .srec/.s19/.sx file containing the hardware calibrations.\n\n" +
                                          "2. Update Gain and Offset for the desired channels, values MUST be in hexadecimal format.\n\n" +
                                          "3. Click on 'Write Updated File'. ​A new file having the _Updated suffix will be saved in the same folder as the original file and can be flashed on the ECU.\n\n" +
                                          "Version 1.0.0 Initial version\nVersion 1.0.1 Resolved handling of .s19 and .sx extensions"), "SREC File Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Event handler for cell editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHWCAL_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvHWCAL.CurrentCell.Style.BackColor = Color.White;
            menuStrip1.Items[1].Enabled = true;
            dgvHWCAL.CurrentCell.Style.BackColor = Color.LightGoldenrodYellow;

            if (dgvHWCAL[e.ColumnIndex, e.RowIndex].Value != null)
            {
                if ((OnlyHexInString(dgvHWCAL[e.ColumnIndex, e.RowIndex].Value.ToString()) == false) ||
                    (dgvHWCAL[e.ColumnIndex, e.RowIndex].Value.ToString().Length > CELL_VALUE_LENGHT) ||
                    (dgvHWCAL[e.ColumnIndex, e.RowIndex].Value.ToString() == string.Empty))
                {
                    dgvHWCAL.CurrentCell.Style.BackColor = Color.Red;
                    menuStrip1.Items[1].Enabled = false;
                    MessageBox.Show("Cell value is not in HEX format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cell value is not in HEX format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvHWCAL.CurrentCell.Style.BackColor = Color.Red;
                menuStrip1.Items[1].Enabled = false;
            }      
        }

        /// <summary>
        /// Regular expressions for HEX values
        /// </summary>
        public bool OnlyHexInString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }  
    }
}
        
