using System;
using System.Text;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_ByteArray
{
	[Test]
	public void HexString01 ()
	{
		byte[] x = { 1, 2, 3 };

		Assert.AreEqual (
			x.ToHexString (),
			"010203"
		);
	}

	[Test]
	public void CString01 ()
	{
		byte[] x = { (byte)'a', (byte)'b', (byte)'c' };
		Assert.AreEqual (
			x.ToCString (),
			"abc"
		);    
	}
}
