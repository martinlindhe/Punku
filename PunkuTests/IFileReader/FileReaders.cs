using System;
using System.IO;
using NUnit.Framework;
using Punku;

[TestFixture]
public class TestFileReaders
{
    [Test]
    public void TestBinary ()
    {
        var x = new Punku.BinaryReader ("binary_file.jpg");

        Console.WriteLine ("size is " + x.Length);
    }

    [Test]
    public void TestImage ()
    {
        var x = new Punku.ImageReader ("binary_file.jpg");

        Console.WriteLine ("size is " + x.Width + " x " + x.Height);
    }
}