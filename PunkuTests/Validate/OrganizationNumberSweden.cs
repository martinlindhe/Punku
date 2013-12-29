using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Validate")]
public class Validate_OrganizationNumberSweden
{
	[Test]
	public void IsAkiteBolag01 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsAktieBolag ("5566848635"), true);
	}

	[Test]
	public void IsAkiteBolag02 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsAktieBolag ("8112189876"), false);
	}

	[Test]
	public void IsValid01 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsValid ("8112189876"), true);
	}

	[Test]
	public void IsValid02 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsValid ("811218-9876"), true);
	}

	[Test]
	public void IsValid03 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsValid ("19811218-9876"), true);
	}

	[Test]
	public void IsValid04 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsValid ("198112189876"), true);
	}

	[Test]
	public void IsValid05 ()
	{
		Assert.AreEqual (OrganizationNumberSweden.IsValid ("5566848635"), true);
	}
}