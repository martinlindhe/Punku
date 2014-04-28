using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Strings")]
public class Strings_Punycode
{
	[Test]
	public void Encode1 ()
	{
		Assert.AreEqual (Punycode.Encode ("københavn"), "xn--kbenhavn-54a");
	}

	[Test]
	public void Decode1 ()
	{
		Assert.AreEqual (Punycode.Decode ("xn--ferv28lgza"), "近身剪");
	}

	[Test]
	public void IsPunycode1 ()
	{
		Assert.AreEqual (Punycode.IsPunycode ("xn--ferv28lgza"), true);
	}

	[Test]
	public void IsPunycode2 ()
	{
		Assert.AreEqual (Punycode.IsPunycode ("xn--feöherr"), false);
	}
}