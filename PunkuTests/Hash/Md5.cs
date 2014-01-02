using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
[Category ("Hash")]
public class Hash_Md5
{
	[Test]
	public void Datablock01 ()
	{
		byte[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
		Assert.AreEqual (
			"0ee0646c1c77d8131cc8f4ee65c7673b", 
			new Md5 (x).ToString ());
	}

	[Test]
	public void EmptyString ()
	{
		Assert.AreEqual (
			"d41d8cd98f00b204e9800998ecf8427e",
			new Md5 ("").ToString ());
	}

	[Test]
	public void BrownFox ()
	{
		Assert.AreEqual (
			"9e107d9d372bb6826bd81d3542a419d6",
			new Md5 ("The quick brown fox jumps over the lazy dog").ToString ());
	}

	[Test]
	public void ChecksumFromFile ()
	{
		Assert.AreEqual (
			"5523c90d6373e63b34c483683434f45e",
			Md5.FromFile ("../../_Resources/binary_file.jpg").ToString ());
	}

	[Test]
	[ExpectedException (typeof(FileNotFoundException))]
	public void FileNotFoundException ()
	{
		Md5.FromFile ("/tmp/no_such_file");
	}
}
