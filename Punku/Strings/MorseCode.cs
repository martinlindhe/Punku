using System;
using System.Collections.Generic;

namespace Punku.Strings
{
	public class MorseITU
	{
		public string code;
		public char letter;

		public MorseITU (string code, char letter)
		{
			this.code = code;
			this.letter = letter;
		}
	}

	public class MorseCode
	{
		public static List<MorseITU> MorseITUCodes ()
		{			
			List<MorseITU> list = new List<MorseITU> ();

			// ITU standard morse codes
			list.Add (new MorseITU (".-", 'a'));
			list.Add (new MorseITU ("-...", 'b'));
			list.Add (new MorseITU ("-.-.", 'c'));
			list.Add (new MorseITU ("-..", 'd'));
			list.Add (new MorseITU (".", 'e'));
			list.Add (new MorseITU ("..-.", 'f'));
			list.Add (new MorseITU ("--.", 'g'));
			list.Add (new MorseITU ("....", 'h'));
			list.Add (new MorseITU ("..", 'i'));
			list.Add (new MorseITU (".---", 'j'));
			list.Add (new MorseITU ("-.-", 'k'));
			list.Add (new MorseITU (".-..", 'l'));
			list.Add (new MorseITU ("--", 'm'));
			list.Add (new MorseITU ("-.", 'n'));
			list.Add (new MorseITU ("---", 'o'));
			list.Add (new MorseITU (".--.", 'p'));
			list.Add (new MorseITU ("--.-", 'q'));
			list.Add (new MorseITU (".-.", 'r'));
			list.Add (new MorseITU ("...", 's'));
			list.Add (new MorseITU ("-", 't'));
			list.Add (new MorseITU ("..-", 'u'));
			list.Add (new MorseITU ("...-", 'v'));
			list.Add (new MorseITU (".--", 'w'));
			list.Add (new MorseITU ("-..-", 'x'));
			list.Add (new MorseITU ("-.--", 'y'));
			list.Add (new MorseITU ("--..", 'z'));

			list.Add (new MorseITU (".----", '1'));
			list.Add (new MorseITU ("..---", '2'));
			list.Add (new MorseITU ("...--", '3'));
			list.Add (new MorseITU ("....-", '4'));
			list.Add (new MorseITU (".....", '5'));
			list.Add (new MorseITU ("-....", '6'));
			list.Add (new MorseITU ("--...", '7'));
			list.Add (new MorseITU ("---..", '8'));
			list.Add (new MorseITU ("----.", '9'));
			list.Add (new MorseITU ("-----", '0'));

			return list;
		}

		public static string Decode (string s)
		{
			var list = MorseITUCodes ();

			string[] words = s.Split (' ');

			string res = "";

			foreach (string word in words) {

				if (word == "") {
					res += " ";
					continue;
				}

				bool found = false;

				foreach (var x in list) {
					if (word == x.code) {
						res += x.letter;
						found = true;
					}
				}

				if (!found)
					throw new Exception ("unknown: '" + word + "'");
			}

			return res;
		}

		public static string Encode (string s)
		{
			var list = MorseITUCodes ();

			string res = "";

			foreach (char c in s.ToLower()) {
	
				if (c == ' ') {
					res += " ";
					continue;
				}

				bool found = false;

				foreach (var x in list) {
					if (c == x.letter) {
						res += x.code + " ";
						found = true;
						break;
					}
				}
				if (!found)
					throw new Exception ("cant encode: '" + c + "'");
			}

			return res.Trim ();
		}
	}
}

