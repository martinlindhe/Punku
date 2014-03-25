using System;
using System.Drawing;

namespace Punku
{
	public class ImageReader : IFileReader
	{
		public int Width { get { return Image.Width; } }

		public int Height { get { return Image.Height; } }

		public Image Image { get; private set; }

		public ImageReader (string filename)
		{
			this.Image = Read (filename);
		}
		/*
		 * Handles BMP, GIF, PNG, JPEG, TIFF 
		 */
		public static Image Read (string filename)
		{
			return Image.FromFile (filename);
		}
	}
}
