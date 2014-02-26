using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;

//using Newtonsoft.Json;
namespace Punku
{
	public static class VarDump
	{
		/**
		 * @return pretty-printed JSON representation of the object
		 */
		public static void Pretty (this object value)
		{
			//Console.WriteLine (JsonConvert.SerializeObject (value, Formatting.Indented));
		
			throw new Exception (value.GetType () + "");


			// NOTE: https://stackoverflow.com/a/4235094/2295479

			MemoryStream stream1 = new MemoryStream ();
			DataContractJsonSerializer ser = new DataContractJsonSerializer (value.GetType ());
			ser.WriteObject (stream1, value);


			stream1.Position = 0;
			StreamReader sr = new StreamReader (stream1);
			Console.Write ("JSON form of Person object: ");
			Console.WriteLine (sr.ReadToEnd ());

			// de-serialize to obj

			// stream1.Position = 0;
			// Person p2 = (Person)ser.ReadObject(stream1);
		}
	}
}
