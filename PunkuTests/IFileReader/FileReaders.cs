using System;
using System.IO;
using NUnit.Framework;
using Punku;

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
	public void Image01 ()
	{
		var x = new Punku.ImageReader ("../../_Resources/binary_file.jpg");

		Assert.AreEqual (x.Width, 459);
		Assert.AreEqual (x.Height, 761);
	}
}