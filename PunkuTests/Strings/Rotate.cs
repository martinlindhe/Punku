using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Rotate
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.Rot13 ("abcdefghijklmnopqrstuvwxyz"), "nopqrstuvwxyzabcdefghijklm");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.Rot13 ("nopqrstuvwxyzabcdefghijklm"), "abcdefghijklmnopqrstuvwxyz");
	}

	[Test]
	public void Test03 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.Rot13 ("ABCDEFGHIJKLMNOPQRSTUVWXYZ"), "NOPQRSTUVWXYZABCDEFGHIJKLM");
	}

	[Test]
	public void Test04 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.Rot13 ("NOPQRSTUVWXYZABCDEFGHIJKLM"), "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}

	[Test]
	public void Test05 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.RotateString ("abcdefghijklmnopqrstuvwxyz", 1), "bcdefghijklmnopqrstuvwxyza");
	}

	[Test]
	public void Test06 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.RotateString ("abcdefghijklmnopqrstuvwxyz", 2), "cdefghijklmnopqrstuvwxyzab");
	}

	[Test]
	public void Test07 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.RotateString ("abcdefghijklmnopqrstuvwxyz", 3), "defghijklmnopqrstuvwxyzabc");
	}

	[Test]
	public void Test08 ()
	{
		Assert.AreEqual (Punku.Strings.Rotate.RotateString ("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 2), "CDEFGHIJKLMNOPQRSTUVWXYZAB");
	}
}
