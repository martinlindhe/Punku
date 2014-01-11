using System;
using System.Text;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_Base64String
{
	[Test]
	public void ByteArrayToBase64_01 ()
	{
		byte[] x = { 1, 2, 3 };

		Assert.AreEqual (
			x.ToBase64 (),
			"AQID"
		);
	}

	[Test]
	public void StringToBase64_01 ()
	{
		Assert.AreEqual ("pleasure.".ToBase64 (), "cGxlYXN1cmUu");
	}

	[Test]
	public void StringFromBase64_01 ()
	{
		Assert.AreEqual ("aGVsbG8=".FromBase64 (), "hello");
	}

	[Test]
	public void FromBase64ToByteArray01 ()
	{
		Assert.AreEqual (
			"AgME".FromBase64ToByteArray (),
			new byte[] { 2, 3, 4 }
		);
	}
}