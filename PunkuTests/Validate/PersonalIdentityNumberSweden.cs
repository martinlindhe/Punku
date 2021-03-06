﻿using System;
using NUnit.Framework;
using Punku;

[TestFixture]
[Category ("Validate")]
public class Validate_PersonalIdentityNumberSweden
{
	[Test]
	public void IsPersonnummer01 ()
	{
		Assert.AreEqual (PersonalIdentityNumberSweden.IsValid ("8112189876"), true);
	}

	[Test]
	public void IsPersonnummer02 ()
	{
		Assert.AreEqual (PersonalIdentityNumberSweden.IsValid ("5566848635"), false);
	}

	[Test]
	public void IsMale01 ()
	{
		Assert.AreEqual (PersonalIdentityNumberSweden.IsMale ("8112189876"), true);
	}

	[Test]
	public void IsFemale01 ()
	{
		Assert.AreEqual (PersonalIdentityNumberSweden.IsFemale ("8112189876"), false);
	}

	[Test]
	public void ParseDateTime01 ()
	{
		var x = PersonalIdentityNumberSweden.ToDateTime ("811218-9876");
		Assert.AreEqual (x.Year, 1981);
		Assert.AreEqual (x.Month, 12);
		Assert.AreEqual (x.Day, 18);
	}

	[Test]
	[ExpectedException (typeof(FormatException))]
	public void ParseDateTime02 ()
	{
		PersonalIdentityNumberSweden.ToDateTime ("801232-0000");
	}

	[Test]
	[ExpectedException (typeof(FormatException))]
	public void ParseDateTime03 ()
	{
		PersonalIdentityNumberSweden.ToDateTime ("abc123-0000");
	}
}
