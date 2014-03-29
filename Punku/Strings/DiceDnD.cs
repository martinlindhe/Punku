/**
 * Rolls dices, according to Dungeons & Dragons dice format
 */
using System;

namespace Punku.Game
{
	public class DiceDnD
	{
		protected int numberOfDices;
		protected int numberOfDots;
		public int MinValue;
		public int MaxValue;
		protected int adjustment;

		/**
         * @param cmd nDd([+/-]m)
         *
         * where
         * n - is the number of dices to roll
         * d - is the number of dots on each dice
         * m - modifier
         * and optional modifier as a signed integer
         */
		public DiceDnD (string cmd)
		{
			int pos = cmd.IndexOfAny (new char[] { 'D', 'd' });
			if (pos < 0)
				throw new ArgumentException ();

			numberOfDices = System.Convert.ToInt32 (cmd.Substring (0, pos));  
			adjustment = 0;

			string s = cmd.Substring (pos + 1);

			pos = s.IndexOf ('+');
			if (pos < 0)
				pos = s.IndexOf ('-');

			if (pos < 0) {
				numberOfDots = System.Convert.ToInt32 (s);
			} else {
				numberOfDots = System.Convert.ToInt32 (s.Substring (0, pos));
				adjustment = System.Convert.ToInt32 (s.Substring (pos));
			}

			MinValue = numberOfDices + adjustment;
			MaxValue = (numberOfDices * numberOfDots) + adjustment;
		}

		public static int Roll (string cmd)
		{
			var dice = new DiceDnD (cmd);
			return dice.Roll ();
		}

		public int Roll ()
		{
			int result = 0;

			Random random = new Random ();

			for (int i = 0; i < numberOfDices; i++)
				result += random.Next (numberOfDots) + 1;

			return result + adjustment;
		}
	}
}
