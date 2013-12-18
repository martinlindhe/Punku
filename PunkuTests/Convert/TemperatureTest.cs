using System;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TemperatureTest
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "F", 300m), 572m);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "K", 300m), 573.15m);
	}

	[Test]
	public static void Test03 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "R", 300m), 1031.67m);
	}

	[Test]
	public static void Test04 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("F", "C", 500m), 260.00000000000000000000000002m);
	}

	[Test]
	public static void Test05 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("F", "K", 500m), 533.15000000000000000000000002m);
	}

	[Test]
	public static void Test06 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("F", "R", 500m), 959.67m);
	}

	[Test]
	public static void Test07 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("K", "C", 0m), -273.15m);
	}

	[Test]
	public static void Test08 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("K", "F", 0m), -459.67m);
	}

	[Test]
	public static void Test09 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("K", "R", 0m), 0m);
	}

	[Test]
	public static void Test10 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("R", "C", 509.67m), 10.000000000000000000000000001m);
	}

	[Test]
	public static void Test11 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("R", "F", 509.67m), 50.000000000000000000000000002m);
	}

	[Test]
	public static void Test12 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("R", "K", 509.67m), 283.15m);
	}

	[Test]
	public static void Test13 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "kelvin", 100m), 373.15m);
	}

	[Test]
	public static void Test14 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToRomer (300), 165m);
	}

	[Test]
	public static void Test15 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.RomerToCelcius (300), 557.14285714285714285714285715m);
	}

	[Test]
	public static void Test16 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToDelisle (300), -300m);
	}

	[Test]
	public static void Test17 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.DelisleToCelcius (13), 91.33333333333333333333333333m);
	}

	[Test]
	public static void Test18 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.NewtonToCelcius (130), 393.93939393939393939393939394m);
	}

	[Test]
	public static void Test19 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToNewton (130), 42.9m);
	}

	[Test]
	public static void Test20 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.ReaumurToCelcius (300), 375m);
	}

	[Test]
	public static void Test21 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToReaumur (123), 98.4m);
	}

	[Test]
	public static void Test22 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("millikelvin", "kelvin", 1m), 0.001m);
	}

	[Test]
	public static void Test23 ()
	{
		// TODO according to google: 1 millikelvin = -273.14900 degrees Celsius
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("millikelvin", "C", 1m), -273.149m);
	}
}
