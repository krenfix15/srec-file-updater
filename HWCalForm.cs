using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System;
using System.Linq;

namespace HWCAL
{
    public partial class HWCalForm : Form
    {
        SrecFile SrecFile;
        HwCal HwCalStruct;

        /* Version of the application */
        int MajorVersion = 1;
        int MinorVersion = 0;
        int PatchVersion = 0;

        bool SrecFileWasAdded = false;

        public HWCalForm()
        {
            InitializeComponent();

            dgvHWCAL.Columns[0].ReadOnly = true;
            dgvHWCAL.Columns[3].ReadOnly = true;
            dgvHWCAL.Columns[3].Width = 240;
            this.Width = 600;
        }

        /// <summary>
        /// Open file object
        /// </summary>
        OpenFileDialog OpenSRECFile = new OpenFileDialog()
        {
            InitialDirectory = @"Y:\",
            Title = "Browse SREC Files",

            CheckFileExists = true,
            CheckPathExists = true,

            DefaultExt = "txt",
            Filter = "srec files (*.srec)|*.srec",
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

            float gain = ConvertUint32ToFloat(hwcal_Chan.gain);
            float offset = ConvertUint32ToFloat(hwcal_Chan.offs);

            dgvHWCAL.Rows.Add(dgvHWCAL.Rows.Count, gain, offset, hwcal_Chan.ChannelName);
        }

        /// <summary>
        /// Convert one UInt32 value in float value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private float ConvertUint32ToFloat(UInt32 value)
        {
            float ret_val = 0x0;
            byte[] arr = new byte[4];
            arr = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                arr = arr.Reverse().ToArray();
            }
            ret_val = BitConverter.ToSingle(arr, 0);
            return ret_val;
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

                HwCalStruct.UpdateHwCalValuesFromDvg(dgvHWCAL);
                SrecFile = HwCalStruct.ConvertHwCalToSrec();

                SrecFile.WriteSrecToFile(filepath.Replace(".srec", "_Updated.srec"));

                MessageBox.Show("The output file was saved in the same folder as the input file!", filepath);
            }
            else
            {
                MessageBox.Show("Load a SREC file!", "Error");
            }
        }

        /// <summary>
        /// Event handler of the "Info" option of the ToolStripMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(string.Format("© Powertrace SRL\nVersion {0}.{1}.{2}", MajorVersion, MinorVersion, PatchVersion), "Hw Calibration Updater");
        }

        /// <summary>
        /// Event handler to verify if the inserted data in DGV cells are ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvHWCAL_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int row = e.RowIndex;
            //int collumn = e.ColumnIndex;
            //if ((e != null) && (row < dgvHWCAL.Rows.Count) &&(collumn < dgvHWCAL.Rows[0].Cells.Count))
            //{
            //    string cellValue = dgvHWCAL.Rows[row].Cells[collumn].Value.ToString();
            //}
        }
    }
}
        