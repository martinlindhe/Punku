using System;
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
	public void NumbersOnly06 ()
	{
		Assert.AreEqual ("1".IsNumbersOnly (), true);
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
	public void ValidUrlHttp ()
	{
		Assert.AreEqual (
			"http://test.com/".IsUrl (), 
			true);
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
	/* valid urls
http://www.google.se/search?hl=sv&source=hp&q=&btnI=Jag+har+tur&meta=&aq=f&aqi=&aql=&oq=&gs_rfai=
'https://some-url.com/?query=&name=joe?filter=*.*#some_anchor',
'http://hh-1hallo.msn.blabla.com:80800/test/test/test.aspx?dd=dd&id=dki',
'http://web5.uottawa.ca/admingov/reglements-methodes.html',
'ftp://username:password@example.com:21/file.zip',
'http://www.esa.int',
'http://at.activation.com/track/me;1442:PPS35:tta/',
'http://maps.google.com/maps/geo?ll=11.11,11.11&output=json&key=2sddf-d3d3-d3d3d',
'http://url.com/path|path2',
'http://url.net/What\'s%20new%20in%20V4.9a.txt',
'http://username@server.com/path?arg=value',
'http://username:password@server.com/path?arg=value',
'http://digg.com/submit?phase=2&url=http&#37;3A&#37;2F&#37;2Fexample.com%2Fpath%2F2on%2F%3Fdomain%3Dp1&p2=text%3A+string',
'http://en.wikipedia.org/wiki/Yahoo!',
'http://server.com/aaa@aaa@bbb',
'HTTP://server.com/aaa@aaa@bbb',

INVALID urls:
'x',
'x.com',
'x.x',
'http:/invalid.com/test',
'http://-invalid.leading-char.com',
'http:// invalid with spaces.com',
'http://invalid.url-with a.space.com',
'http://space in url.com/path.php',
'http://good-domain.com/bad url with space',
'https://ssl.',   //XXX is detected as valid
*/
}