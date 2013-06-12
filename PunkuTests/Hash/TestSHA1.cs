using System;
using System.IO;
using NUnit.Framework;
using Punku.Hash;

[TestFixture]
public class TestSHA1
{
    [Test]
    public void RunTestEmptyString()
    {
        Assert.AreEqual(
            "da39a3ee5e6b4b0d3255bfef95601890afd80709",
            new SHA1("").ToString());
    }

    [Test]
    public void RunTestBrownFox()
    {
        Assert.AreEqual(
            "2fd4e1c67a2d28fced849ee1bb76e7391b93eb12",
            new SHA1("The quick brown fox jumps over the lazy dog").ToString());
    }

    [Test]
    public void RunTestChecksumFromFile()
    {
        Assert.AreEqual(
            "07a66fe243a73aea9d5e1f10a54a317a24af27bc",
            SHA1.FromFile("../../resources/binary_file.jpg").ToString());
    }

    [Test]
    [ExpectedException(typeof(FileNotFoundException))]
    public void TestFileNotFoundException()
    {
        SHA1.FromFile("/tmp/no_such_file");
    }
}
