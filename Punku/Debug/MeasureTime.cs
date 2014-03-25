using System;
using System.Diagnostics;

namespace Punku
{
	public class MeasureTime : Stopwatch
	{
		public MeasureTime ()
		{
			Console.WriteLine ("[MeasureTime] Started at " + System.Environment.TickCount);
			Start ();
		}

		public new void Stop ()
		{
			Console.WriteLine ("[MeasureTime] Stopped after " + Elapsed.ToString () + " s (" + ElapsedMilliseconds + " milliseconds, " + ElapsedTicks + " ticks), at " + System.Environment.TickCount);
			base.Stop ();
		}
	}
}
