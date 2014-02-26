using System;
using System.IO;
using NUnit.Framework;
using Punku;
using System.Drawing;
using System.Drawing.Imaging;

[TestFixture]
[Category ("Files")]
public class FileReaders
{
	[Test]
	public void Binary01 ()
	{
		var binary = new Punku.BinaryReader ("../../_Resources/binary_file.jpg");
		Assert.AreEqual (binary.Length, 67698);
	}

	[Test]
	public void Binary02 ()
	{
		// verifies we could read the full file
		var binary = new Punku.BinaryReader ("../../_Resources/binary_file.jpg");

		Assert.AreEqual (
			new Punku.Hash.Sha1 (binary.Data).ToString (),
			"07a66fe243a73aea9d5e1f10a54a317a24af27bc"
		);
	}

	[Test]
	public void Image01 ()
	{
		var x = new Punku.ImageReader ("../../_Resources/binary_file.jpg");

		Assert.AreEqual (x.Width, 459);
		Assert.AreEqual (x.Height, 761);
	}

	public void ImageResize01 ()
	{
		// TODO resize content of a created image
	}

	[Test]
	public void BitmapDrawPixel01 ()
	{
		// Draws a pixel on image, writes as BMP and verifies output

		// TODO verify by more examples: draw line, draw circle, draw polygon, draw letter

		var x = new Bitmap (3, 3);

		x.SetPixel (0, 0, Color.Black); // pixel in top left corner

		var filename = "tmp3.bmp";
		x.Save (filename, ImageFormat.Bmp);


		x.Dispose ();

		// TODO write tiff directly to memory stream, then decode from stream, instead of to disk in between


		var yy = Punku.ImageReader.Read (filename);
		Assert.AreEqual (yy.Width, 3);
		Assert.AreEqual (yy.Height, 3);
		yy.Dispose ();


		var data = Punku.BinaryReader.Read (filename);

		// TODO show header & dimensions, split bytes in 3x3 grid etc
		Assert.AreEqual (data.ToHexString (),
			"424d5a00000000000000360000002800" +
			"00000300000003000000010020000000" +
			"000000000000c40e0000c40e00000000" +
			"00000000000000000000000000000000" +
			"00000000000000000000000000000000" +
			"00ff0000000000000000");
	}
}
