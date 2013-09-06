using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TestPerlinNoise
{
    public void Test1()
    {
        int width = 256;
        int height = 256;

        Bitmap bitmap = new Bitmap(width, width);
        Graphics graphics = Graphics.FromImage(bitmap);

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                int cval = (int)(SimplexNoise.Generate(x / 60f, y / 60f) * 128 + 128);
                //int cval = (int)(SimplexNoise.Generate (x / 20f, y / 200f) * 64 + 128);

                //int cval = (int)(Martins2dNoise.InterpolatedNoise2 (x / 200f, y / 200f) * 128 + 128);

                Color color = Color.FromArgb(cval, cval, cval);
                SolidBrush brush = new SolidBrush(color);

                Rectangle rectangle = new Rectangle(x, y, 1, 1);
                graphics.FillRectangle(brush, rectangle);
            }
        }
        graphics.Dispose();

        bitmap.Save("perlin.png", System.Drawing.Imaging.ImageFormat.Png);
        bitmap.Dispose();
    }

    [Test]
    public void RunTest()
    { 
        Test1();
    }
}
