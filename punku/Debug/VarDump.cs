using System;
using Newtonsoft.Json;

namespace Punku
{
	public static class VarDump
	{
		/**
		 * @return pretty-printed JSON representation of the object
		 */
		public static string Pretty (this object value)
		{
			return JsonConvert.SerializeObject (value, Formatting.Indented);
		}
	}
}