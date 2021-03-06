﻿using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Convert")]
public class Convert_Energy
{
	[Test]
	public static void Test01 ()
	{
		Assert.AreEqual (Punku.Convert.Energy.Convert ("kWh", "MWh", 15), 0.015m);
	}

	[Test]
	public static void Test02 ()
	{
		Assert.AreEqual (Punku.Convert.Energy.Convert ("GWh", "kWh", 15), 15000000);
	}
}
