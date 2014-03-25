using System;

namespace Punku
{
	public class Coordinate
	{
		public int x;
		public int y;
		public int z;

		public Coordinate ()
		{
		}

		public Coordinate (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Coordinate (int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}
}
