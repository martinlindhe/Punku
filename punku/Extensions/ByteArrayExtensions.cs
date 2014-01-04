﻿using System;
using System.Text;

public static class ByteArrayExtensions
{
	/**
	 * Returns a hex string representation of the content
	 */
	public static string ToHexString (this byte[] bytes)
	{
		var res = new StringBuilder ();

		foreach (byte b in bytes)
			res.Append (b.ToString ("x2"));

		return res.ToString ();
	}

	/**
	 * Decodes byte array to a C-string (each letter is 1 byte, 0 = end of text)
	 */
	public static string ToCString (this byte[] bytes)
	{
		var res = new StringBuilder ();

		foreach (byte x in bytes) {

			if (x == 0)
				break;

			res.Append ((char)x);
		}

		return res.ToString ();
	}

	/**
	 * Decodes byte array to a DOS $-terminated string (each letter is 1 byte, $ = end of text)
	 */
	public static string ToDosString (this byte[] bytes)
	{
		var res = new StringBuilder ();

		foreach (byte x in bytes) {
	
			if (x == (byte)'$')
				break;

			res.Append ((char)x);
		}

		return res.ToString ();
	}

	/** 
	 * Returns a char[] from the byte[]
	 */
	public static char[] ToCharArray (this byte[] bytes)
	{
		var res = new char[bytes.Length];

		for (int i = 0; i < bytes.Length; i++)
			res [i] = (char)bytes [i];

		return res;
	}

	/**
	 * Returns an array shifted to the right by shift
	 */
	public static byte[] RotateRight (this byte[] bytes, int shift)
	{
		byte[] Table = new byte[byte.MaxValue + 1];

		// NOTE: we exploit byte rounding to fill the shift table
		for (int i = 0; i <= byte.MaxValue; i++)
			Table [i] = (byte)(i + shift);

		byte[] arr = new byte[bytes.Length];

		for (int i = 0; i < bytes.Length; i++)
			arr [i] = Table [bytes [i]];

		return arr;
	}

	/**
	 * Returns an array shifted to the left by shift
	 */
	public static byte[] RotateLeft (this byte[] bytes, int shift)
	{
		byte[] Table = new byte[byte.MaxValue + 1];

		// NOTE: we exploit byte rounding to fill the shift table
		for (int i = 0; i <= byte.MaxValue; i++)
			Table [i] = (byte)(i - shift);

		byte[] arr = new byte[bytes.Length];

		for (int i = 0; i < bytes.Length; i++)
			arr [i] = Table [bytes [i]];

		return arr;
	}

	/**
	 * Returns a Base64 encoded representation of the data
	 */
	public static string ToBase64 (this byte[] bytes)
	{
		return System.Convert.ToBase64String (bytes);
	}
}

