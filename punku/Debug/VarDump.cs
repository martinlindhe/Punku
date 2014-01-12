using System;
using Newtonsoft.Json;

namespace Punku
{
	public static class VarDump
	{
		/**
		 * @return pretty-printed JSON representation of the object
		 */
		public static void Pretty (this object value)
		{
			Console.WriteLine (JsonConvert.SerializeObject (value, Formatting.Indented));
		}
	}
}