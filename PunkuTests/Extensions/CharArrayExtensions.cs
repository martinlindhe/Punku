using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_CharArray
{
	[Test]
	public void ToUtf16String01 ()
	{
		string s1 = "hello";
		string s2 = s1.ToCharArray ().ToUtf16String ();

		Assert.AreEqual (s1, s2);
	}

	[Test]
	public void ToHexString01 ()
	{
		string s = "hej";

		char[] x = s.ToCharArray ();

		Assert.AreEqual (
			x.ToHexString (),
			"00680065006a"
		);
	}
}
