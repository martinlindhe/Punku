using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Convert")]
public class SpeedTest
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Speed.Convert ("mph", "km/h", 18), 28.968168825464939628048297561m);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Speed.Convert ("km/h", "m/s", 18), 5.000004m);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Speed.Convert ("ft/s", "mph", 12), 8.181818181818181818181818182m);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Speed.Convert ("knot", "m/s", 20), 10.28888m);
	}
}