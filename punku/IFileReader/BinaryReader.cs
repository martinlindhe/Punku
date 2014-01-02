using System;
using System.IO;

namespace Punku
{
	public class BinaryReader : IFileReader
	{
		public byte[] Data { get; private set; }

		public long Length { get; private set; }

		public BinaryReader (string filename)
		{
			Read (filename);
		}

		/**
		 * NOTE: src.Read() can throw FileNotFoundException
		 */
		public void Read (string filename)
		{            
            
			var src = new FileStream (filename, FileMode.Open, FileAccess.Read);

			this.Length = src.Length;
			this.Data = new byte[this.Length];
                             
			var numBytesToRead = this.Length;            
			var numBytesRead = 0;

			// TODO redo to a  do-while loop when test case first exist
               
			while (numBytesToRead > 0) {                   
				int n = src.Read (this.Data, numBytesRead, (int)numBytesToRead);

				if (n == 0)
					break;

				numBytesRead += n;
				numBytesToRead -= n;
			}
		}
	}
}
