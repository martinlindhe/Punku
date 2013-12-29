using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Invert
{
	[Test]
	public void Test01 ()
	{
		Assert.AreEqual (Punku.Strings.Invert.TransformStatic ("ellwll"), "voodoo");
	}

	[Test]
	public void Test02 ()
	{
		Assert.AreEqual (Punku.Strings.Invert.TransformStatic ("hrnkov"), "simple");
	}

	[Test]
	public void Test03 ()
	{
		Assert.AreEqual (Punku.Strings.Invert.TransformStatic ("FKKVI XZHV"), "UPPER CASE");
	}
}
