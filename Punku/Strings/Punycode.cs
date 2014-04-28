using System;
using System.Text;

namespace Punku
{
	/**
	 * Encode/decode punycode according to RFC 3492
	 */
	public class Punycode
	{
		static int TMIN = 1;
		static int TMAX = 26;
		static int BASE = 36;
		static int INITIAL_N = 128;
		static int INITIAL_BIAS = 72;
		static int DAMP = 700;
		static int SKEW = 38;
		static string PREFIX = "xn--";

		/**
 		 * Punycodes a unicode string
 		 *
 		 * @param input Unicode string
 	     * @return Punycoded string
 		 */
		public static string Encode (string input)
		{
			int n = INITIAL_N;
			int delta = 0;
			int bias = INITIAL_BIAS;

			StringBuilder output = new StringBuilder ();
			output.Append (PREFIX);

			// Copy all basic code points to the output
			int b = 0;
			for (int i = 0; i < input.Length; i++) {
				char c = input [i];
				if (IsBasic (c)) {
					output.Append (c);
					b++;
				}
			}

			if (b > 0) {
				output.Append ('-');
			}

			int h = b;
			while (h < input.Length) {
				int m = int.MaxValue;

				// Find the minimum code point >= n
				for (int i = 0; i < input.Length; i++) {
					int c = input [i];
					if (c >= n && c < m) {
						m = c;
					}
				}

				if (m - n > (int.MaxValue - delta) / (h + 1)) {
					throw new OverflowException ();
				}

				delta = delta + (m - n) * (h + 1);
				n = m;

				for (int j = 0; j < input.Length; j++) {

					int c = input [j];

					if (c < n) {
						delta++;
						if (0 == delta) {
							throw new OverflowException ();
						}
					}

					if (c == n) {
						int q = delta;
						for (int k = BASE;; k += BASE) {
							int t;
							if (k <= bias) {
								t = TMIN;
							} else if (k >= bias + TMAX) {
								t = TMAX;
							} else {
								t = k - bias;
							}
							if (q < t) {
								break;
							}

							output.Append ((char)DigitToCodepoint (t + (q - t) % (BASE - t)));
							q = (q - t) / (BASE - t);
						}

						output.Append ((char)DigitToCodepoint (q));
						bias = Adapt (delta, h + 1, h == b);
						delta = 0;
						h++;
					}
				}

				delta++;
				n++;
			}
			return output.ToString ();
		}

		/**
		 * Checks if s is a punycoded string
		 */
		public static bool IsPunycode (string s)
		{
			if (!s.StartsWith (PREFIX))
				return false;

			for (int i = 4; i < s.Length; i++) {
				if (!s [i].IsAsciiLetterOrDigit ()) {
					return false;
				}
			}

			return true;
		}

		/**
         * Decode a punycoded string
 		 *
 		 * @param input Punycode string
 		 * @return Unicode string
 		 */
		public static string Decode (string input)
		{
			if (!IsPunycode (input))
				throw new ArgumentException ();

			input = input.Substring (PREFIX.Length, input.Length - PREFIX.Length);

			int n = INITIAL_N;
			int i = 0;
			int bias = INITIAL_BIAS;
			StringBuilder output = new StringBuilder ();
			int d = input.LastIndexOf ('-');

			if (d > 0) {
				for (int j = 0; j < d; j++) {
					char c = input [j];
					if (!IsBasic (c)) {
						throw new ArgumentException ();
					}
					output.Append (c);
				}
				d++;
			} else {
				d = 0;
			}

			while (d < input.Length) {
				int oldi = i;
				int w = 1;

				for (int k = BASE;; k += BASE) {
					if (d == input.Length) {
						throw new ArgumentException ();
					}

					int c = input [d++];
					int digit = CodepointToDigit (c);

					if (digit > (int.MaxValue - i) / w) {
						throw new OverflowException ();
					}

					i = i + digit * w;

					int t;
					if (k <= bias) {
						t = TMIN;
					} else if (k >= bias + TMAX) {
						t = TMAX;
					} else {
						t = k - bias;
					}

					if (digit < t) {
						break;
					}
					w = w * (BASE - t);
				}

				bias = Adapt (i - oldi, output.Length + 1, oldi == 0);

				if (i / (output.Length + 1) > int.MaxValue - n) {
					throw new OverflowException ();
				}

				n = n + i / (output.Length + 1);
				i = i % (output.Length + 1);
				output.Insert (i, (char)n);
				i++;
			}

			return output.ToString ();
		}

		private static int Adapt (int delta, int numpoints, bool first)
		{
			if (first) {
				delta = delta / DAMP;
			} else {
				delta = delta / 2;
			}

			delta += delta / numpoints;

			int k = 0;
			while (delta > ((BASE - TMIN) * TMAX) / 2) {
				delta = delta / (BASE - TMIN);
				k = k + BASE;
			}

			return k + ((BASE - TMIN + 1) * delta) / (delta + SKEW);
		}

		private static bool IsBasic (char c)
		{
			return c < 0x80;
		}

		private static int DigitToCodepoint (int d)
		{
			if (d < 26) {
				// a-z
				return d + 'a';
			} else if (d < 36) {
				// 0-9
				return d - 26 + '0';
			} else {
				throw new ArgumentException ();
			}
		}

		private static int CodepointToDigit (int c)
		{
			if (c - '0' < 10) {
				// 0-9
				return c - '0' + 26;
			} else if (c - 'a' < 26) {
				// a-z
				return c - 'a';
			} else {
				throw new ArgumentException ();
			}
		}
	}
}

