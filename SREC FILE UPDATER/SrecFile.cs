using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HWCAL
{
    public class SrecFile
    {
        string FileName_;
        public List<SrecLine> SrecLineList = new List<SrecLine>();
        String SrecTerminationLine; 

        /// <summary>
        /// Create the mirror of th srec file in RAM
        /// </summary>
        /// <param name="FileName"></param>
        public SrecFile(string FileName)
        {
            FileName_ = FileName;
            string currenLine;
            StreamReader srecRead = new StreamReader(FileName);
            while (((currenLine = srecRead.ReadLine()) != null) && (currenLine != ""))
            {
                if (currenLine.Substring(0,2).ToUpper() == "S3")
                {
                    SrecLineList.Add(new SrecLine(currenLine));
                }
                else if (currenLine.Substring(0, 2).ToUpper() == "S7")
                {
                    SrecTerminationLine = currenLine;
                }
            }
        }

        /// <summary>
        /// Get one word of the Srec file
        /// </summary>
        /// <param name="WordIndex"></param>
        /// <returns></returns>
        public byte[] GetDataWord(int WordIndex)
        {
            byte[] word = new byte[4];
            int lineindex = 0x0;
            int wordInLineIndex = 0x0;

            lineindex = WordIndex / 8;
            wordInLineIndex = WordIndex % 8;

            word = SrecLineList.ElementAt(lineindex).GetDataWord(wordInLineIndex);
            return word;
        }

        /// <summary>
        /// Update one word of the srec file
        /// </summary>
        /// <param name="WordIndex"></param>
        /// <param name="NewVal"></param>
        public void UpdateSrecDataWord(int WordIndex, UInt32 NewVal)
        {
            int lineindex = 0x0;
            int wordInLineIndex = 0x0;

            lineindex = WordIndex / 8;
            wordInLineIndex = WordIndex % 8;

            SrecLineList[lineindex].UpdateDataWord(wordInLineIndex, NewVal);
        }

        /// <summary>
        /// Write the Srec file in file
        /// </summary>
        /// <param name="FilePath"></param>
        public void WriteSrecToFile(string FilePath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath))
            {
                foreach (SrecLine srecLine in SrecLineList)
                {
                    file.WriteLine(srecLine);
                }
                file.WriteLine(SrecTerminationLine);
            }
        }
    }
}
