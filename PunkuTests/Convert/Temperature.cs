using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Convert")]
public class Convert_Temperature
{
	[Test]
	public static void Celsius1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "F", 300m), 572m);
	}

	[Test]
	public static void Celsius2 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "K", 300m), 573.15m);
	}

	[Test]
	public static void Celsius3 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "R", 300m), 1031.67m);
	}

	[Test]
	public static void Farenheit1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("F", "C", 500m), 260.00000000000000000000000002m);
	}

	[Test]
	public static void Farenheit2 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("F", "K", 500m), 533.15000000000000000000000002m);
	}

	[Test]
	public static void Farenheit3 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("F", "R", 500m), 959.67m);
	}

	[Test]
	public static void Kelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("K", "C", 0m), -273.15m);
	}

	[Test]
	public static void Kelvin2 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("K", "F", 0m), -459.67m);
	}

	[Test]
	public static void Kelvin3 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("K", "R", 0m), 0m);
	}

	[Test]
	public static void Rankine1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("R", "C", 509.67m), 10.000000000000000000000000001m);
	}

	[Test]
	public static void Rankine2 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("R", "F", 509.67m), 50.000000000000000000000000002m);
	}

	[Test]
	public static void Rankiner3 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("R", "K", 509.67m), 283.15m);
	}

	[Test]
	public static void Celcius4 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("C", "kelvin", 100m), 373.15m);
	}

	[Test]
	public static void Celcius5 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToRomer (300), 165m);
	}

	[Test]
	public static void Test15 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.RomerToCelcius (300), 557.14285714285714285714285715m);
	}

	[Test]
	public static void Celcius6 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToDelisle (300), -300m);
	}

	[Test]
	public static void Delisle1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.DelisleToCelcius (13), 91.33333333333333333333333333m);
	}

	[Test]
	public static void Newton1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.NewtonToCelcius (130), 393.93939393939393939393939394m);
	}

	[Test]
	public static void Celcius7 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToNewton (130), 42.9m);
	}

	[Test]
	public static void Reaumur1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.ReaumurToCelcius (300), 375m);
	}

	[Test]
	public static void Celcius8 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.CelciusToReaumur (123), 98.4m);
	}

	[Test]
	public static void Millikelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("millikelvin", "kelvin", 1m), 0.001m);
	}

	[Test]
	public static void Millikelvin2 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("millikelvin", "C", 1m), -273.149m);
	}

	[Test]
	public static void Microkelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("microkelvin", "C", 1m), -273.149999m);
	}

	[Test]
	public static void Nanokelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("nanokelvin", "C", 1m), -273.149999999m);
	}

	[Test]
	public static void Picokelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("picokelvin", "C", 1m), -273.149999999999m);
	}

	[Test]
	public static void Femtokelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("femtokelvin", "C", 1m), -273.149999999999999m);
	}

	[Test]
	public static void Attokelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("attokelvin", "C", 1m), -273.149999999999999999m);
	}

	[Test]
	public static void Zeptokelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("zeptokelvin", "C", 1m), -273.149999999999999999999m);
	}

	[Test]
	public static void Yoctokelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("yoctokelvin", "C", 1m), -273.149999999999999999999999m);
	}

	[Test]
	public static void Megakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("megakelvin", "C", 1m), 999726.85m);
	}

	[Test]
	public static void Gigakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("gigakelvin", "C", 1m), 999999726.85m);
	}

	[Test]
	public static void Terakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("terakelvin", "C", 1m), 999999999726.85m);
	}

	[Test]
	public static void Petakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("petakelvin", "C", 1m), 999999999999726.85m);
	}

	[Test]
	public static void Exakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("exakelvin", "C", 1m), 999999999999999726.85m);
	}

	[Test]
	public static void Zettakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("zettakelvin", "C", 1m), 999999999999999999726.85m);
	}

	[Test]
	public static void Yottakelvin1 ()
	{
		Assert.AreEqual (Punku.Convert.Temperature.Convert ("yottakelvin", "C", 1m), 999999999999999999999726.85m);
	}
}
