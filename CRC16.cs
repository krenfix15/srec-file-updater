using System;

namespace HWCAL
{
    public class Crc16
    {
        /// <summary>
        /// Polinom used to compute the CRC
        /// </summary>
        const ushort polynomial = 0x1021;
        /// <summary>
        /// Initial value of the CRC
        /// </summary>
        const ushort initialValue = 0xFFFF;

        /// <summary>
        /// Compute the CRC16
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] Compute_CRC16_Simple(byte[] bytes)
        {
            const ushort generator = polynomial; /* divisor is 16bit */
            ushort crc = initialValue; /* CRC value is 16bit */

            foreach (byte b in bytes)
            {
                crc ^= ((ushort)(b << 8)); /* move byte into MSB of 16bit CRC */

                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0) /* test for MSB = bit 15 */
                    {
                        crc = ((ushort)((crc << 1) ^ generator));
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }
            /* Return the computed CRC16 */
            return BitConverter.GetBytes(crc);
        }
    }
}