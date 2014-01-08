// toy
using System;
using Punku;

namespace Punku
{
	public class NarcissisticNumber
	{
		/**
		 * narcissistic number finder
		 */
		public static void Finder (uint numberBase)
		{
			var time = new MeasureTime ();

			for (ulong i = 1; i < ulong.MaxValue; i++) {

				if (Punku.Math.IsNarcissisticNumber (i, numberBase)) {
					Console.WriteLine ("nars in base " + numberBase + " = " + Punku.Convert.Base.ToBase (i, numberBase));
				}
			}

			time.Stop ();
		}
	}
}

