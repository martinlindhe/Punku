using System;
using System.Diagnostics;

namespace Punku
{
	public class MeasureTime : Stopwatch
	{
		public MeasureTime ()
		{
			Start ();
		}

		public new void Stop ()
		{
			Console.WriteLine ("Stop after " + Elapsed.ToString () + " s (" + ElapsedMilliseconds + " milliseconds, " + ElapsedTicks + " ticks)");
			base.Stop ();
		}
	}
}

