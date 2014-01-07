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
	public void Binary02 ()
	{
		// verifies we could read the full file
		var binary = new Punku.BinaryReader ("../../_Resources/binary_file.jpg");

		var xx = binary.Data; // FIXME simplify!?!?

		Assert.AreEqual (
			new Punku.Hash.Sha1 (xx).ToString (),
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
}