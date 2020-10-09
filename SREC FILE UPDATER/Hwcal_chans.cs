using System;
using System.Linq;
using System.Windows.Forms;

namespace HWCAL
{
    /// <summary>
    /// The configuration of the HW channels
    /// </summary>
    public enum HWCAL_CHANS_ENUM
    {
        Hwcal_chan_PORT0_idx,            /* 0U */
        Hwcal_chan_I_A__STBY_idx,        /* 1U */
        Hwcal_chan_I_A__U_idx,           /* 2U */
        Hwcal_chan_PORT0X_idx,           /* 3U */
        Hwcal_chan_I_A_CW_idx,           /* 4U */
        Hwcal_chan_I_A_idx,              /* 5U */
        Hwcal_chan_I_idx,                /* 6U */
        Hwcal_chan_PORT0XX_idx,          /* 7U */
        Hwcal_chan_PORT1_idx,            /* 8U */
        Hwcal_chan_I_A_TLF_idx,          /* 9U */
        Hwcal_chan_I_A_V_idx,            /* 10U */
        Hwcal_chan_PORT1X_idx,           /* 11U */
        Hwcal_chan_I_A_CWX_idx,          /* 12U */
        Hwcal_chan_I_A_GMR_COS,          /* 13U */
        Hwcal_chan_I_A_CTRL_REV_IN_idx,       /* 14U */
        Hwcal_chan_PORT3_idx,                 /* 15U */
        Hwcal_chan_PORT2_CHAN0,               /* 16U */
        Hwcal_chan_I_A_TLF_5V_T1_idx,             /* 17U */
        Hwcal_chan_I_A_UZK_P_idx,                 /* 18U */
        Hwcal_chan_PORT2_CHAN3_idx,               /* 19U */
        Hwcal_chan_I_A_TEMP3_idx,              /* 20U */
        Hwcal_chan_I_A_TEMP2_idx,              /* 21U */
        Hwcal_chan_I_A_PSIAG_1_idx,            /* 22U */
        Hwcal_chan_PORT2_CHAN7_idx,            /* 23U */
        Hwcal_chan_I_A_TEMP1_idx,              /* 24U */
        Hwcal_chan_I_A_TLF_5V_idx,             /* 25U */
        Hwcal_chan_I_A_UZK_idx,                /* 26U */
        Hwcal_chan_I_A_INT_idx,                /* 27U */
        Hwcal_chan_I_AX_CW_idx,                /* 28U */
        Hwcal_chan_I_A_BRD_TEMP1_idx,             /* 29U */
        Hwcal_chan_I_A_PSA_2_idx,                 /* 30U */
        Hwcal_chan_I_A_XM_DIAP_idx,               /* 31U */
        Hwcal_chan_I_A_AIN_idx,                   /* 32U */
        Hwcal_chan_IX_A_idx,                      /* 33U */
        Hwcal_chan_I_A_INV_TEMP_U_idx,            /* 34U */
        Hwcal_chan_AdcMcalDummy4_3_idx,           /* 35U */
        Hwcal_chan_PORT4_CHAN4,               /* 36U */
        Hwcal_chan_PORT4_CHAN5,               /* 37U */
        Hwcal_chan_PORT4_CHAN6,               /* 38U */
        Hwcal_chan_PORT4_CHAN7,               /* 39U */
        Hwcal_chan_Adc5_0_idx,                /* 40U */
        Hwcal_chan_I_A_1V3_idx,                   /* 41U */
        Hwcal_chan_I_A_INV_TEMP_idx,              /* 42U */
        Hwcal_chan_I_A_INV__WFUSI_idx,            /* 43U */
        Hwcal_chan_I_A_INV_TEE_idx,               /* 44U */
        Hwcal_chan_I_A_BRD_TE2_idx,               /* 45U */
        Hwcal_chan_I_A_CL_VAR_IN_idx,             /* 46U */
        Hwcal_chan_I_A_XMDIAG_N_idx,              /* 47U */
        Hwcal_chan_I_A_AMR_COS_idx,               /* 48U */
        Hwcal_chan_I_A_TLF__VREF_idx,             /* 49U */
        Hwcal_chan_I_A_INV_CUR_W_idx,             /* 50U */
        Hwcal_chan_I_A_INV_CUR_U_FUSI_idx,        /* 51U */
        Hwcal_chan_I_A_EM_STAT_TEMP_idx,          /* 52U */
        Hwcal_chan_PORT6_CHAN5_idx,               /* 53U */
        Hwcal_chan_I_A_AMR_DIAG_idx,              /* 54U */
        Hwcal_chan_I_A_VDIAG_2_idx,               /* 55U */
        Hwcal_chan_AdcMcalDummy7_0_idx,           /* 56U */
        Hwcal_chan_I_A_5V_UC_idx,                 /* 57U */
        Hwcal_chan_I_A_INV_W_idx,              /* 58U */
        Hwcal_chan_I_A_INV_CUR_V_idx,          /* 59U */
        Hwcal_chan_I_A_CONTEMP_idx,            /* 60U */
        Hwcal_chan_PORT7_CHAN5_,               /* 61U */
        Hwcal_chan_PORT_CHAN6,                 /* 62U */
        Hwcal_chan_I_A_PSA_VDIAG_1_idx,        /* 63U */
        Hwcal_chan_I_A_U_1V8_HVM_idx,          /* 64U */
        Hwcal_chan_I_A_U_3V3_HVM_idx,          /* 65U */
        Hwcal_chan_I_A_U_5V_idx,               /* 66U */
        Hwcal_chan_PORT8_CH3_idx,              /* 67U */
        Hwcal_chan_I_A_UZKX_idx,               /* 68U */
        Hwcal_chan_I_A_U_16V_HVM_idx,          /* 69U */
        Hwcal_chan_I_A_T_EXC_idx,              /* 70U */
        Hwcal_chan_I_A_T_HVSUP_idx,            /* 71U */
        Hwcal_chan_I_T_INV_TEMPU_1_idx,        /* 72U */
        Hwcal_chan_I_T_INV_TEMP_LS_idx,        /* 73U */
        Hwcal_chan_I_T_INV_TEMP_1_idx,         /* 74U */
        Hwcal_chan_I_T_INV_TEMSS_V_1_idx,      /* 75U */
        Hwcal_chan_I_T_INV_TEHSS_W_1_idx,      /* 76U */
        Hwcal_chan_I_T_INV_TEMP_LSS_W_1_idx,   /* 77U */
        Hwcal_chan_I_T_INV_TE_H_U_2_idx,       /* 78U */
        Hwcal_chan_I_T_INV_TEMP_L_U_2_idx,     /* 79U */
        Hwcal_chan_I_T_INV_TE_H_V_2_idx,       /* 80U */
        Hwcal_chan_I_T_INV_TEMP_LSV_2_idx,     /* 81U */
        Hwcal_chan_I_T_INV_TEHSS_W_2_idx,      /* 82U */
        Hwcal_chan_I_T_INV_LSS_W_2_idx,        /* 83U */
        HWCAL_CHAN_MAX_NO,
    }

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
            hwcal_head.start = (UInt16)((UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[0]<<8) | (UInt16)(srecFile.GetDataWord(hwCal_WordIndex)[1]));
            hwcal_head.struct_ver = srecFile.GetDataWord(hwCal_WordIndex)[2];
            hwcal_head.data_ver = srecFile.GetDataWord(hwCal_WordIndex)[3];
            hwCal_WordIndex ++;

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
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i] != null)
                {
                    newGain = BigEndianToLittleEndian(UInt32.Parse(dataGridView.Rows[i].Cells[1].Value.ToString(), System.Globalization.NumberStyles.HexNumber));
                    newOffset = BigEndianToLittleEndian(UInt32.Parse(dataGridView.Rows[i].Cells[2].Value.ToString(), System.Globalization.NumberStyles.HexNumber));

                    UpdateChannel(i, newGain, newOffset);
                }
                else
                {
                    MessageBox.Show("A cell must contain data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Convert value from Big Endian to Little Endian
        /// </summary>
        /// <param name="value"></param>
        public static UInt32 BigEndianToLittleEndian(UInt32 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes, 0, bytes.Length);

            value = BitConverter.ToUInt32(bytes, 0);
            return value;
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
        #endregion
    }
}
