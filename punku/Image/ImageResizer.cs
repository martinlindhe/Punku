using System;
using System.Drawing;

namespace Punku
{
    public class ImageResizer
    {
        public static Image Resize (Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = size.Width / sourceWidth;
            nPercentH = size.Height / sourceHeight;

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bitmap = new Bitmap (destWidth, destHeight);
            Graphics g = Graphics.FromImage (bitmap);

            // will increase size in a pixelized way: use HighQualityBicubic to scale smoothly
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

            g.DrawImage (imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose ();

            return bitmap;
        }
    }
}

