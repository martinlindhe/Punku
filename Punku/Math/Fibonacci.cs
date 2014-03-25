/**
 * toy
 */
using System;

namespace Punku.Math
{
	public class Fibonacci
	{
		public static void PrintFibonacci ()
		{ 
			ulong fib = 1;
			ulong[] hold = new ulong[2];

			for (int i = 0; i < 10; i++) {
				hold [0] = hold [1];
				hold [1] = fib;
				fib = hold [0] + hold [1];
				Console.WriteLine (hold [0] + " + " + hold [1] + " = " + fib);
			} 
		}
		// dunno a name of this sequence :-P
		public static void PrintFibonacci3 ()
		{ 
			ulong fib3 = 1;
			ulong[] hold = new ulong[3];

			for (int i = 0; i < 10; i++) {
				hold [0] = hold [1];
				hold [1] = hold [2];
				hold [2] = fib3;
				fib3 = hold [0] + hold [1] + hold [2];
				Console.WriteLine (hold [0] + " + " + hold [1] + " + " + hold [2] + " = " + fib3);
			} 
		}
	}
}
