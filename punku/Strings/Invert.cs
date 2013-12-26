using System;

// TODO drop static lookup table
namespace Punku.Strings
{
	public static class Invert
	{
		/**
		 * Inverts all letters (a=z, b=y etc)
		 */
		public static string InvertEnglish (string s)
		{
			char[] tbl = new char[char.MaxValue];

			// init tbl
			for (int i = 0; i < char.MaxValue; i++) {
				tbl [i] = (char)i;
			}
			tbl ['a'] = 'z';
			tbl ['b'] = 'y';
			tbl ['c'] = 'x';
			tbl ['d'] = 'w';
			tbl ['e'] = 'v';
			tbl ['f'] = 'u';
			tbl ['g'] = 't';
			tbl ['h'] = 's';
			tbl ['i'] = 'r';
			tbl ['j'] = 'q';
			tbl ['k'] = 'p';
			tbl ['l'] = 'o';
			tbl ['m'] = 'n';
			tbl ['n'] = 'm';
			tbl ['o'] = 'l';
			tbl ['p'] = 'k';
			tbl ['q'] = 'j';
			tbl ['r'] = 'i';
			tbl ['s'] = 'h';
			tbl ['t'] = 'g';
			tbl ['u'] = 'f';
			tbl ['v'] = 'e';
			tbl ['w'] = 'd';
			tbl ['x'] = 'c';
			tbl ['y'] = 'b';
			tbl ['z'] = 'a';

			// ellwll/hrnkov/proo

			// invert az
		
			char[] array = s.ToCharArray ();
			for (int i = 0; i < array.Length; i++) {
				int number = (int)array [i];


				array [i] = tbl [number];
			}
			return new string (array);
		}
	}
}

