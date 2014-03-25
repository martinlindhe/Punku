using System;
using System.IO;

namespace Punku
{
	/** 
	 * Reads binary data from files
	 */
	public class BinaryReader : IFileReader
	{
		public byte[] Data;

		public int Length { get { return this.Data.Length; } }

		public BinaryReader (string filename)
		{
			this.Data = Read (filename);
		}

		/**
		 * Returns file content in a byte array
		 * NOTE: src.Read() can throw FileNotFoundException
		 */
		public static byte[] Read (string filename)
		{
			var src = new FileStream (filename, FileMode.Open, FileAccess.Read);

			var length = src.Length;
			var data = new byte[length];

			var bytesToRead = length;            
			var totBytesRead = 0;

			while (bytesToRead > 0) {                   
				int bytesRead = src.Read (data, totBytesRead, (int)bytesToRead);

				if (bytesRead == 0)
					break;

				totBytesRead += bytesRead;
				bytesToRead -= bytesRead;
			}

			src.Dispose ();

			return data;
		}
	}
}
