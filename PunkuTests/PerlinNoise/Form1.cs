using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Punku;

namespace NoiseTest
{
    public class Form1 : Form
    {
        public Form1()
        {
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 515);
            this.Name = "Form1";
            this.Text = "Form1";

            this.ResumeLayout(false);

            CreateBitmapAtRuntime();
        }

        PictureBox pictureBox1 = new PictureBox();

        public void CreateBitmapAtRuntime()
        {
            int width = 512;

            pictureBox1.Size = new Size(width + 10, width + 10);
            this.Controls.Add(pictureBox1);

            Bitmap flag = new Bitmap(width, width);
            Graphics flagGraphics = Graphics.FromImage(flag);

            for (int x = 0; x < 500; ++x)
            {
                for (int y = 0; y < 500; ++y)
                {
                    int cval = (int)(PerlinNoise.Generate(x / 60f, y / 60f) * 128 + 128);
                    //int cval = (int)(PerlinNoise.Generate (x / 20f, y / 200f) * 64 + 128);

                    //int cval = (int)(Martins2dNoise.InterpolatedNoise2 (x / 200f, y / 200f) * 128 + 128);

                    Color col = Color.FromArgb(cval, cval, cval);
                    SolidBrush brush = new SolidBrush(col);

                    Rectangle rect = new Rectangle(x, y, 1, 1);
                    flagGraphics.FillRectangle(brush, rect);
                }
            }

            pictureBox1.Image = flag;
        }
    }
}
