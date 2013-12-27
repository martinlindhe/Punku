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
		Assert.AreEqual (Punku.Strings.Shift.ShiftLetters ("qrpgle.kyicrpylq()", 2), "string.maketrans()");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Shift.ShiftLetters ("rpylqjyrc", 2), "translate");
	}
}

