using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
[Category ("Hash")]
public class Hash_Sha1
{
	[Test]
	public void EmptyString ()
	{
		Assert.AreEqual (
			"da39a3ee5e6b4b0d3255bfef95601890afd80709",
			new Sha1 ("").ToString ());
	}

	[Test]
	public void Datablock01 ()
	{
		byte[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
		Assert.AreEqual (
			"dd5783bcf1e9002bc00ad5b83a95ed6e4ebb4ad5", 
			new Sha1 (x).ToString ());
	}

	[Test]
	public void BrownFox ()
	{
		Assert.AreEqual (
			"2fd4e1c67a2d28fced849ee1bb76e7391b93eb12",
			new Sha1 ("The quick brown fox jumps over the lazy dog").ToString ());
	}

	[Test]
	public void ChecksumFromFile ()
	{
		Assert.AreEqual (
			"07a66fe243a73aea9d5e1f10a54a317a24af27bc",
			Sha1.FromFile ("../../_Resources/binary_file.jpg").ToString ());
	}

	[Test]
	[ExpectedException (typeof(FileNotFoundException))]
	public void FileNotFoundException ()
	{
		Sha1.FromFile ("/tmp/no_such_file");
	}
}
