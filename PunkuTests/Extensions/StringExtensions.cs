﻿using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Extensions")]
public class Extensions_String
{
	[Test]
	public void Repeat01 ()
	{
		Assert.AreEqual ("hej".Repeat (2), "hejhej");
	}

	[Test]
	public void Repeat02 ()
	{
		Assert.AreEqual ("häj".Repeat (2), "häjhäj");
	}

	[Test]
	public void Reverse01 ()
	{
		Assert.AreEqual ("hello".Reverse (), "olleh");
	}

	[Test]
	public void Reverse02 ()
	{
		// verify unicode characters are handled correctly (ie not byte-by-byte reversing)
		Assert.AreEqual ("höger".Reverse (), "regöh");
	}

	[Test]
	public void Count01 ()
	{
		Assert.AreEqual ("haj".Count ('a'), 1);
	}

	[Test]
	public void Count02 ()
	{
		Assert.AreEqual ("haaj".Count ('a'), 2);
	}

	[Test]
	public void Count03 ()
	{
		Assert.AreEqual ("häj".Count ('a'), 0);
	}

	[Test]
	public void Count04 ()
	{
		Assert.AreEqual ("haj".Count ('ä'), 0);
	}

	[Test]
	public void NumbersOnly01 ()
	{
		Assert.AreEqual ("123".IsNumbersOnly (), true);
	}

	[Test]
	public void NumbersOnly02 ()
	{
		Assert.AreEqual ("".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly03 ()
	{
		Assert.AreEqual ("12a".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly04 ()
	{
		Assert.AreEqual ("1 ".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly05 ()
	{
		Assert.AreEqual (" 1".IsNumbersOnly (), false);
	}

	[Test]
	public void NumbersOnly06 ()
	{
		Assert.AreEqual ("1".IsNumbersOnly (), true);
	}

	[Test]
	public void Alphanumeric01 ()
	{
		Assert.AreEqual ("".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric02 ()
	{
		Assert.AreEqual (" ".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric03 ()
	{
		Assert.AreEqual ("1abcEEs".IsAlphanumeric (), true);
	}

	[Test]
	public void Alphanumeric04 ()
	{
		Assert.AreEqual ("ab-".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric05 ()
	{
		Assert.AreEqual ("'".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric06 ()
	{
		Assert.AreEqual ("ab'".IsAlphanumeric (), false);
	}

	[Test]
	public void Alphanumeric07 ()
	{
		Assert.AreEqual ("abå".IsAlphanumeric (), false);
	}

	[Test]
	public void AllLowerCase01 ()
	{
		Assert.AreEqual ("abc".IsAllLowerCase (), true);
	}

	[Test]
	public void AllLowerCase02 ()
	{
		Assert.AreEqual ("abc def".IsAllLowerCase (), true);
	}

	[Test]
	public void AllLowerCase03 ()
	{
		Assert.AreEqual ("aBc".IsAllLowerCase (), false);
	}

	[Test]
	public void AllUpperCase01 ()
	{
		Assert.AreEqual ("ABC".IsAllUpperCase (), true);
	}

	[Test]
	public void AllUpperCase02 ()
	{
		Assert.AreEqual ("ABC DEF".IsAllUpperCase (), true);
	}

	[Test]
	public void AllUpperCase03 ()
	{
		Assert.AreEqual ("Abc".IsAllUpperCase (), false);
	}

	[Test]
	public void IsMixedCase01 ()
	{
		Assert.AreEqual ("abC".IsMixedCase (), true);
	}

	[Test]
	public void IsMixedCase02 ()
	{
		Assert.AreEqual ("AbC".IsMixedCase (), true);
	}

	[Test]
	public void IsMixedCase03 ()
	{
		Assert.AreEqual ("Abc".IsMixedCase (), true);
	}

	[Test]
	public void IsMixedCase04 ()
	{
		Assert.AreEqual ("ABC DeF".IsMixedCase (), true);
	}

	[Test]
	public void IsMixedCase05 ()
	{
		Assert.AreEqual ("aBc".IsMixedCase (), true);
	}

	[Test]
	public void IsMixedCase06 ()
	{
		Assert.AreEqual ("abc".IsMixedCase (), false);
	}

	[Test]
	public void IsMixedCase07 ()
	{
		Assert.AreEqual ("ABC".IsMixedCase (), false);
	}

	[Test]
	public void IsMixedCase08 ()
	{
		Assert.AreEqual ("ABC DEF".IsMixedCase (), false);
	}

	[Test]
	public void StartsWithUpperCase01 ()
	{
		Assert.AreEqual ("Hello".StartsWithUpperCase (), true);
	}

	[Test]
	public void StartsWithUpperCase02 ()
	{
		Assert.AreEqual ("Hello there".StartsWithUpperCase (), true);
	}

	[Test]
	public void StartsWithUpperCase03 ()
	{
		Assert.AreEqual ("HELLO".StartsWithUpperCase (), false);
	}

	[Test]
	public void StartsWithUpperCase04 ()
	{
		Assert.AreEqual ("hello".StartsWithUpperCase (), false);
	}

	[Test]
	public void Palindrome01 ()
	{
		Assert.AreEqual ("".IsPalindrome (), false);
	}

	[Test]
	public void Palindrome02 ()
	{
		Assert.AreEqual (" ".IsPalindrome (), false);
	}

	[Test]
	public void Palindrome03 ()
	{
		Assert.AreEqual ("racecar".IsPalindrome (), true);
	}

	[Test]
	public void Palindrome04 ()
	{
		Assert.AreEqual ("hello".IsPalindrome (), false);
	}

	[Test]
	public void FromBase01 ()
	{
		Assert.AreEqual (
			"1234".FromBase (10),
			1234
		);
	}

	[Test]
	public void FromBase02 ()
	{
		Assert.AreEqual (
			"1023".FromBase (4),
			75
		);
	}

	[Test]
	public void ValidUrlIP ()
	{
		Assert.AreEqual (
			"http://127.0.0.1/test".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlHttp01 ()
	{
		Assert.AreEqual (
			"http://test.com".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlHttp02 ()
	{
		Assert.AreEqual (
			"http://test.com/".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlHttp03 ()
	{
		Assert.AreEqual (
			"http:/invalid.com/test".IsUrl (), 
			false);
	}

	[Test]
	public void ValidUrlHttp04 ()
	{
		Assert.AreEqual (
			"http:// invalid with spaces.com".IsUrl (), 
			false);
	}

	[Test]
	public void ValidUrlHttp05 ()
	{
		Assert.AreEqual (
			"x".IsUrl (), 
			false);
	}

	[Test]
	public void ValidUrlHttp06 ()
	{
		Assert.AreEqual (
			"http://test.".IsUrl (), 
			false);
	}

	[Test]
	public void ValidUrlHttp07 ()
	{
		// all url:s must start with http or https
		Assert.AreEqual (
			"x.x".IsUrl (), 
			false);
	}

	[Test]
	public void ValidUrlHttp08 ()
	{
		// NOTE domain names must start with a-z or 0-9
		Assert.AreEqual (
			"http://-invalid.leading.char.com".IsUrl (), 
			false);
	}

	[Test]
	public void ValidUrlHttps ()
	{
		Assert.AreEqual (
			"https://test.com/file.php".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlSubdomain ()
	{
		Assert.AreEqual (
			"http://sub.test.com".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlTilde ()
	{
		Assert.AreEqual (
			"http://test.com/~x/file.htm".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlParameter01 ()
	{
		Assert.AreEqual (
			"http://test.com/path?arg=value".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlParameter02 ()
	{
		Assert.AreEqual (
			"http://test.com/path?arg=value#anchor".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlParameter03 ()
	{
		Assert.AreEqual (
			"http://test.com/path?arg=value&arg2=4".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlParameter04 ()
	{
		Assert.AreEqual (
			"http://test.com/path?arg=value&amp;arg2=4".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlPort01 ()
	{
		Assert.AreEqual (
			"http://test.com:80/file.php".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrlPort02 ()
	{
		Assert.AreEqual (
			"http://test.com:1000/file.php".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl21 ()
	{
		Assert.AreEqual (
			"HTTP://WWW.SERVER.COM/".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl22 ()
	{
		Assert.AreEqual (
			"https://some-url.com/?query=&name=joe?filter=*.*#some_anchor".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl23 ()
	{
		Assert.AreEqual (
			"http://server.com:9999/".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl23c ()
	{
		Assert.AreEqual (
			"http://server.com:30000/".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl24 ()
	{
		Assert.AreEqual (
			"http://web5.uottawa.ca/admingov/reglements-methodes.html".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl25 ()
	{
		Assert.AreEqual (
			"http://www.esa.int".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl26 ()
	{
		Assert.AreEqual (
			"http://at.activation.com/track/me;1442:PPS35:tta/".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl27 ()
	{
		Assert.AreEqual (
			"http://maps.google.com/maps/geo?ll=11.11,11.11&output=json&key=2s22-d111-d111".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl29 ()
	{
		Assert.AreEqual (
			@"http://url.net/What's%20new%20in%20V2.9a.txt".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl32 ()
	{
		Assert.AreEqual (
			"http://server.com/submit?phase=2&url=http&#37;3A&#37;2F&#37;2Fexample.com%2Fpath%2F2on%2F%3Fdomain%3Dp1&p2=text%3A+string".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl33 ()
	{
		Assert.AreEqual (
			"http://en.wikipedia.org/wiki/Yahoo!".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl34 ()
	{
		Assert.AreEqual (
			"http://server.com/aaa@aaa@bbb".IsUrl (), 
			true);
	}

	[Test]
	public void ValidUrl35 ()
	{
		Assert.AreEqual (
			"http://good-domain.com/bad url with space".IsUrl (), 
			false);
	}
}
