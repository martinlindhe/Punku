using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Shift
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.Shift.ShiftString ("abcdefghijklmnopqrstuvwxyz", 1), "bcdefghijklmnopqrstuvwxyza");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Shift.ShiftString ("abcdefghijklmnopqrstuvwxyz", 2), "cdefghijklmnopqrstuvwxyzab");
	}

	[Test]
	public void Test03 ()
	{
		Assert.AreEqual (Punku.Strings.Shift.ShiftString ("abcdefghijklmnopqrstuvwxyz", 3), "defghijklmnopqrstuvwxyzabc");
	}

	[Test]
	public void Test04 ()
	{
		Assert.AreEqual (Punku.Strings.Shift.ShiftString ("abcdefghijklmnopqrstuvwxyz", 13), "nopqrstuvwxyzabcdefghijklm");
	}

	[Test]
	public void Test05 ()
	{
		Assert.AreEqual (Punku.Strings.Shift.ShiftString ("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 2), "CDEFGHIJKLMNOPQRSTUVWXYZAB");
	}
}

