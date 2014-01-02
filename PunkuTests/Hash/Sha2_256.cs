using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
[Category ("Hash")]
public class Hash_Sha2_256
{
	[Test]
	public void EmptyString ()
	{
		Assert.AreEqual (
			"e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855",
			new Sha2_256 ("").ToString ());
	}

	[Test]
	public void BrownFox ()
	{
		Assert.AreEqual (
			"d7a8fbb307d7809469ca9abcb0082e4f8d5651e46d3cdb762d02d0bf37c9e592",
			new Sha2_256 ("The quick brown fox jumps over the lazy dog").ToString ());
	}

	[Test]
	public void ChecksumFromFile ()
	{
		Assert.AreEqual (
			"5855923abba91083d74c8411f00cc04102ac58ee030169859d90d8845482e210",
			Sha2_256.FromFile ("../../_Resources/binary_file.jpg").ToString ());
	}

	[Test]
	[ExpectedException (typeof(FileNotFoundException))]
	public void FileNotFoundException ()
	{
		Sha2_256.FromFile ("/tmp/no_such_file");
	}
}
