using System;

namespace HWCAL
{
    public class SrecLine
    {
        /* Address length in bytes */
        const int S3ADDRESS_LENGHT = 4;
        /* Content of one SREC line */
        string SrecType;
        byte ByteCount;
        byte[] Address;
        byte[] Data;
        byte CheckSum;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="SrecFileLine">Content of one SREC line as a string</param>
        public SrecLine(string SrecFileLine)
        {
            /* Get the SREC type - usualy must be S3 */
            SrecType = SrecFileLine.Substring(0, 2);
            /* Get the bytes number of the srec line - usually 37 bytes (4 addrss, 32 data, 1 checksum) */
            ByteCount = Convert.ToByte(SrecFileLine.Substring(2, 2), 16);
            /* Extract the address of the Srec line */
            string dataLine = SrecFileLine.Substring(4);
            Address = new byte[S3ADDRESS_LENGHT];
            for (int i = 0; i < S3ADDRESS_LENGHT; i++)
            {
                Address[i] = Convert.ToByte(dataLine.Substring(i * 2, 2), 16);
            }

            /* Extract data from the srec line */
            dataLine = dataLine.Substring((int)S3ADDRESS_LENGHT * 2);
            Data = new byte[ByteCount - S3ADDRESS_LENGHT - 1];
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = Convert.ToByte(dataLine.Substring(i * 2, 2), 16);
            }

            /* Get the checksum of the srec line */
            dataLine = dataLine.Substring(dataLine.Length - 2, 2);
            CheckSum = Convert.ToByte(dataLine.Substring(0, 2), 16);              
        }

        /// <summary>
        /// Update the checksum of the srec line after update the values
        /// </summary>
        public void UpdateCheckSum()
        {
            byte ComputedCheckSum = (byte)ByteCount;
            for (int i = 0; i < Address.Length; i++)
            {
                ComputedCheckSum += Address[i];
            }
            for (int i = 0; i < ByteCount - S3ADDRESS_LENGHT - 1; i++)
            {
                ComputedCheckSum += Data[i];
            }
            ComputedCheckSum = (byte)~ComputedCheckSum;

            CheckSum = ComputedCheckSum;
        }

        /// <summary>
        /// Override ToString for SrecDataLine object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string returnString = "";
            returnString = String.Format("{0}{1:X2}", SrecType, ByteCount);

            for (int i = 0; i < Address.Length; i++)
            {
                returnString += String.Format("{0:X2}", Address[i]);
            }

            for (int i = 0; i < Data.Length; i++)
            {
                returnString += String.Format("{0:X2}", Data[i]);
            }

            returnString += String.Format("{0:X2}", CheckSum);

            return returnString;
        }

        /// <summary>
        /// Get one word of one srec line
        /// </summary>
        /// <param name="WordIndex"></param>
        /// <returns></returns>
        public byte[] GetDataWord(int WordIndex)
        {
            byte[] word = new byte[4];
            word[0] = Data[WordIndex * 4];
            word[1] = Data[WordIndex * 4+1];
            word[2] = Data[WordIndex * 4+2];
            word[3] = Data[WordIndex * 4+3];

            return word;
        }

        /// <summary>
        /// Update one word of one srec line
        /// </summary>
        /// <param name="StartWordPos"></param>
        /// <param name="newVal"></param>
        public void UpdateDataWord(int StartWordPos, UInt32 newVal)
        {
            Data[StartWordPos * 4] = (Byte)(newVal >> 24);
            Data[StartWordPos * 4+1] = (Byte)(newVal >> 16);
            Data[StartWordPos * 4+2] = (Byte)(newVal >> 8);
            Data[StartWordPos * 4+3] = (Byte)(newVal);
        }
    }
}
