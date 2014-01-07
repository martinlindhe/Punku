using System;
using Newtonsoft.Json;

namespace Punku
{
	public class ObjectDump
	{
		/**
		 * Returns a pretty-printed JSON representation of the object
		 */
		public static string Dump (this object value)
		{
			return JsonConvert.SerializeObject (value, Formatting.Indented);
		}
	}
}

