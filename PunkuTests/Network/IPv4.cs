using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Network")]
public class Network_IPv4
{
	[Test]
	public void ToString01 ()
	{
		Assert.AreEqual (Punku.IPv4.ToString (0xFF), "0.0.0.255");
	}

	[Test]
	public void ToString02 ()
	{
		Assert.AreEqual (Punku.IPv4.ToString (0xFFFF0000), "255.255.0.0");
	}

	[Test]
	public void ToUInt01 ()
	{
		Assert.AreEqual (Punku.IPv4.ToUInt32 ("0.0.0.255"), 0xFF);
	}

	[Test]
	public void ToUInt02 ()
	{
		Assert.AreEqual (Punku.IPv4.ToUInt32 ("255.255.0.0"), 0xFFFF0000);
	}

	[Test]
	public void IsIPv4_01 ()
	{
		Assert.AreEqual (Punku.IPv4.IsIPv4 ("255.255.0.0"), true);
	}

	[Test]
	public void IsIPv4_02 ()
	{
		Assert.AreEqual (Punku.IPv4.IsIPv4 ("255.255.0."), false);
	}

	[Test]
	public void IsIPv4_03 ()
	{
		Assert.AreEqual (Punku.IPv4.IsIPv4 ("255.255.0"), false);
	}

	[Test]
	public void IsIPv4_04 ()
	{
		Assert.AreEqual (Punku.IPv4.IsIPv4 ("255.255.255.255.0"), false);
	}

	[Test]
	public void IsIPv4_05 ()
	{
		Assert.AreEqual (Punku.IPv4.IsIPv4 ("256.255.0.0"), false);
	}
}