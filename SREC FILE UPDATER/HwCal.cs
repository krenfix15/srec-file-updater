using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWCAL
{
    public struct hwcal_head
    {
        public UInt16 start;
        public byte struct_ver;
        public byte data_ver;
    }

    public struct hwcal_chan
    {
        public HWCAL_CHANS_ENUM ChannelName;
        public UInt32 gain;
        public UInt32 offs;
    }

    public struct hwcal_tail
    {
        public UInt16 stop;
        public UInt16 crc;
    }

    public class HwCal
    {
        #region Private Members
        private SrecFile HwCal_SrecFile;
        #endregion

        #region Public Members
        public hwcal_head hwcal_head;
        public hwcal_chan[] hwcal_chans;
        public hwcal_tail hwcal_tail;
        #endregion

        #region Public Methods
        /// <summary>
        /// Create the HwCalibration structure from one SREC line
        /// </summary>
        /// <param name="srecFile"></param>
        public HwCal(SrecFile srecFile)
        {
            HwCal_SrecFile = srecFile;
            int hwCal_WordIndex = 0;
            UInt32 currentWord;

            /* create the channels array */
            hwcal_chans = new hwcal_chan[(int)HWCAL_CHANS_ENUM.HWCAL_CHAN_MAX_NO];

            /* Read head of the HwCal structure */
            hwcal_head.start = (UInt16)((UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[0] << 8) | (UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[1]));
            hwcal_head.struct_ver = srecFile.GetDataWord(hwCal_WordIndex)[2];
            hwcal_head.data_ver = srecFile.GetDataWord(hwCal_WordIndex)[3];
            hwCal_WordIndex++;

            /* Read calibration for all channels */
            for (int i = 0; i < hwcal_chans.Length; i++)
            {
                hwcal_chans[i].ChannelName = (HWCAL_CHANS_ENUM)(i);
                currentWord = ConvertWordBytesToUint32(srecFile.GetDataWord(hwCal_WordIndex++));
                hwcal_chans[i].gain = currentWord;
                currentWord = ConvertWordBytesToUint32(srecFile.GetDataWord(hwCal_WordIndex++));
                hwcal_chans[i].offs = currentWord;
            }

            /* Read tail of the Hw structure */
            hwcal_tail.stop = (UInt16)((UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[0] << 8) | (UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[1]));
            hwcal_tail.crc = (UInt16)((UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[2] << 8) | (UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[3]));
        }

        /// <summary>
        /// Convert Hw calibration structure to srec file
        /// </summary>
        /// <returns></returns>
        public SrecFile ConvertHwCalToSrec()
        {
            int hwCal_WordIndex = 0;
            UInt32 header = (UInt32)(hwcal_head.start << 16);
            header |= (UInt32)(hwcal_head.struct_ver << 8);
            header |= (UInt32)(hwcal_head.data_ver);
            UInt32 tail;

            /* Update the header of the Hwcal */
            HwCal_SrecFile.UpdateSrecDataWord(hwCal_WordIndex++, header);

            /* Update the channels calibrations */
            for (int i = 0; i < hwcal_chans.Length; i++)
            {
                HwCal_SrecFile.UpdateSrecDataWord(hwCal_WordIndex++, hwcal_chans[i].gain);
                HwCal_SrecFile.UpdateSrecDataWord(hwCal_WordIndex++, hwcal_chans[i].offs);
            }

            /* Compute CRC16 of the HwCal structure */
            UpdateCrc16();
            tail = (UInt32)(((UInt32)hwcal_tail.stop) << 16 | hwcal_tail.crc);
            /* Update crc16 of the hwCal structure */
            HwCal_SrecFile.UpdateSrecDataWord(hwCal_WordIndex++, tail);

            /* Update the checksum of all srec lines */
            foreach (var srecLine in HwCal_SrecFile.SrecLineList)
            {
                srecLine.UpdateCheckSum();
            }

            /* Return the new srec file content */
            return HwCal_SrecFile;
        }

        /// <summary>
        /// Get data from DataGridView and update the HwCal structure
        /// </summary>
        /// <param name="dataGridView"></param>
        public void UpdateHwCalValuesFromDvg(DataGridView dataGridView)
        {
            UInt32 newGain;
            UInt32 newOffset;
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if (dataGridView.Rows[i] != null)
                {
                    //newGain = UInt32.Parse(dataGridView.Rows[i].Cells[1].Value.ToString(), System.Globalization.NumberStyles.HexNumber);
                    //newOffset = UInt32.Parse(dataGridView.Rows[i].Cells[2].Value.ToString(), System.Globalization.NumberStyles.HexNumber);
                    newGain = ConvertFloatValToUint32(float.Parse(dataGridView.Rows[i].Cells[1].Value.ToString()));
                    newOffset = ConvertFloatValToUint32(float.Parse(dataGridView.Rows[i].Cells[2].Value.ToString()));

                    UpdateChannel(i, newGain, newOffset);
                }
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Convert the HwCal structure into byte array to be able to compute and update the CRC16 of the HwCalStruct
        /// </summary>
        /// <returns></returns>
        private byte[] ConvertHwCalToBytes()
        {
            int hwCal_ByteIndex = 0x0;
            /* 4 bytes header, 4 bytes offset, 4 bytes gain, 2 bytes stop pattern */
            int hwCalBytesNo = 4 + (int)HWCAL_CHANS_ENUM.HWCAL_CHAN_MAX_NO * 8 + 2;
            byte[] ret_bytes = new byte[hwCalBytesNo];
            byte[] aux_arr;

            /* Convert the head of the structure */
            ret_bytes[hwCal_ByteIndex++] += (byte)(hwcal_head.start >> 8);
            ret_bytes[hwCal_ByteIndex++] += (byte)(hwcal_head.start);
            ret_bytes[hwCal_ByteIndex++] += (byte)(hwcal_head.struct_ver);
            ret_bytes[hwCal_ByteIndex++] += (byte)(hwcal_head.data_ver);

            /* Convert the calibration values to bytes */
            foreach (var ch in hwcal_chans)
            {
                /* CH GAIN */
                aux_arr = ConvertUInt32ToBytes(ch.gain);
                ret_bytes[hwCal_ByteIndex++] += aux_arr[0];
                ret_bytes[hwCal_ByteIndex++] += aux_arr[1];
                ret_bytes[hwCal_ByteIndex++] += aux_arr[2];
                ret_bytes[hwCal_ByteIndex++] += aux_arr[3];

                /* CH OFFSET */
                aux_arr = ConvertUInt32ToBytes(ch.offs);
                ret_bytes[hwCal_ByteIndex++] += aux_arr[0];
                ret_bytes[hwCal_ByteIndex++] += aux_arr[1];
                ret_bytes[hwCal_ByteIndex++] += aux_arr[2];
                ret_bytes[hwCal_ByteIndex++] += aux_arr[3];
            }

            /* Convert tail to bytes */
            ret_bytes[hwCal_ByteIndex++] += (byte)(hwcal_tail.stop >> 8);
            ret_bytes[hwCal_ByteIndex++] += (byte)(hwcal_tail.stop);

            return ret_bytes;
        }

        /// <summary>
        /// Update one HwCal channel values for Gain and Offset
        /// </summary>
        /// <param name="index"></param>
        /// <param name="new_gain"></param>
        /// <param name="new_offset"></param>
        private void UpdateChannel(int index, UInt32 new_gain, UInt32 new_offset)
        {
            hwcal_chans[index].gain = new_gain;
            hwcal_chans[index].offs = new_offset;
        }

        /// <summary>
        /// Compute the CRC16 of the HwCalStruct and update it
        /// </summary>
        private void UpdateCrc16()
        {
            byte[] result;
            byte[] data;
            /* Get the HwCal structure as a byte array*/
            data = ConvertHwCalToBytes();
            /* Compute the CRC16 of the HwCal struct */
            result = Crc16.Compute_CRC16_Simple(data);
            /* Update the crc16 of the HwCal Struct */
            hwcal_tail.crc = (UInt16)((UInt16)(result[0] << 8) | (UInt16)(result[1]));
        }

        /// <summary>
        /// Convert one array of bytes into UInt32 word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private UInt32 ConvertWordBytesToUint32(byte[] word)
        {
            UInt32 convertedWord = 0x0;
            convertedWord = (UInt32)(word[0] << 24);
            convertedWord |= (UInt32)(word[1] << 16);
            convertedWord |= (UInt32)(word[2] << 8);
            convertedWord |= (UInt32)(word[3]);
            return convertedWord;
        }

        /// <summary>
        /// Convert one Uint32 value into byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private byte[] ConvertUInt32ToBytes(UInt32 value)
        {
            byte[] arr = new byte[4];
            arr[0] = (byte)(value >> 24);
            arr[1] = (byte)(value >> 16);
            arr[2] = (byte)(value >> 8);
            arr[3] = (byte)(value);

            return arr;
        }

        /// <summary>
        /// Convert one float value into UInt32 hex value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private UInt32 ConvertFloatValToUint32(float value)
        {
            UInt32 ret_val = 0x0;
            byte[] arr = new byte[4];
            arr = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                arr = arr.Reverse().ToArray();
            }
            ret_val = BitConverter.ToUInt32(arr, 0);
            return ret_val;
        }
        #endregion
    }
}
