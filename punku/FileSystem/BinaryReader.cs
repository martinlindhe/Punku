using System;
using System.IO;

namespace punku
{
    public class BinaryReader : IFileReader
    {
        public byte[] Data { get; set; }

        public int Length { get; set; }

        public void Read (string filename)
        {            
            try {
                FileStream src = new FileStream (filename, FileMode.Open, FileAccess.Read);
                                          
                this.Data = new byte[src.Length];
                             
                int numBytesToRead = (int)src.Length;
                int numBytesRead = 0;
                this.Length = numBytesToRead;

                while (numBytesToRead > 0) {                   
                    int n = src.Read (this.Data, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
            
            } catch (FileNotFoundException e) {
                Console.WriteLine (e.Message);
            }
        }
    }
}
