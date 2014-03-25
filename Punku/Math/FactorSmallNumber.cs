using System;
using System.Collections.Generic;

namespace Punku
{
	public class FactorSmallNumber
	{
		public static List<long> Factor (long value)
		{
			var res = new List<long> ();

			while (value > 1) {
				var factor = 2;
				if (value % factor != 0) {
					// find next factor faster
					factor += 1;
					do {
						if (value % factor == 0)
							break;

						factor += 2;
					} while (factor < value);
				}

				value /= factor;
				res.Add (factor);
			}

			return res;
		}
	}
}

