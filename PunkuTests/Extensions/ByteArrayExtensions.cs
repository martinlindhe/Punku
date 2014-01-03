using System;
using System.Text;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_ByteArray
{
	[Test]
	public void DosString01 ()
	{
		byte[] x = { (byte)'a', (byte)'b', (byte)'c', (byte)'$' };
		Assert.AreEqual (
			x.ToDosString (),
			"abc"
		);    
	}

	[Test]
	public void DosString02 ()
	{
		byte[] x = { (byte)'$' };
		Assert.AreEqual (
			x.ToDosString (),
			""
		);    
	}

	[Test]
	public void DosString03 ()
	{
		byte[] x = { 0 };
		Assert.AreEqual (
			x.ToDosString (),
			"\u0000"
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

	[Test]
	public void CString02 ()
	{
		byte[] x = { (byte)'a', (byte)'b', (byte)'c', 0, (byte)'d' };
		Assert.AreEqual (
			x.ToCString (),
			"abc"
		);    
	}

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
	public void HexString02 ()
	{
		byte[] x = { 1, 2, 3, 0, 4 };

		Assert.AreEqual (
			x.ToHexString (),
			"0102030004"
		);
	}
}