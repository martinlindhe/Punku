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
		// NOTE: we assume a uncompressed 32bpp bitmap will be created

		// TODO verify by more examples: draw line, draw circle, draw polygon, draw letter

		var x = new Bitmap (3, 3);

		x.SetPixel (0, 0, Color.Black); // pixel in top left corner

		var filename = "tmp3.bmp";
		x.Save (filename, ImageFormat.Bmp);


		x.Dispose ();

		// TODO write tiff directly to memory stream, then decode from stream, instead of to disk in between


		var yy = Punku.ImageReader.Read (filename); // TODO add ImageReader.Read( MemoryStream )
		Assert.AreEqual (yy.Width, 3);
		Assert.AreEqual (yy.Height, 3);
		yy.Dispose ();


		var data = Punku.BinaryReader.Read (filename);

		Assert.AreEqual (data.ToHexString (),
			"424d" + // header
			"5a000000" + // file size
			"00000000" + // reserved
			"36000000" + // offset
			"28000000" + // length of BitMapInfoHeader
			"03000000" + // width
			"03000000" + // height
			"0100" + // planes
			"2000" + // bpp
			"00000000" + // compression
			"00000000" + // size of pic in bytes
			"c40e0000" + // horiz resolution
			"c40e0000" + // vert resolution
			"00000000" + // number of used colors
			"00000000" + // number of important colors
             // img data
			"00000000" + "00000000" + "00000000" +
			"00000000" + "00000000" + "00000000" +
			"000000ff" + "00000000" + "00000000"
		);
	}
}
