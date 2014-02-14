using System;
using System.Drawing;

namespace Punku
{
    public class ImageReader : IFileReader
    {
        public int Width { get { return Image.Width; } }

        public int Height { get { return Image.Height; } }

        public Image Image { get; private set; }

        public ImageReader(string filename)
        {
            Read(filename);
        }

        public void Read(string filename)
        {
            // handles BMP, GIF, PNG, JPEG, TIFF
            this.Image = Image.FromFile(filename);
        }
    }
}

