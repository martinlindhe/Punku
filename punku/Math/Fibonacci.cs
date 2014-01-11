/**
 * toy
 */
using System;

namespace Punku
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
	}
}

