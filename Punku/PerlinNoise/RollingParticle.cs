using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Punku
{
	public static class MyExtensions
	{
		public static void Shuffle<T> (this IList<T> list, Random random)
		{              
			int n = list.Count;  

			while (n > 1) {  
				n--;  
				int k = random.Next (n + 1);  
				T value = list [k];  
				list [k] = list [n];  
				list [n] = value;  
			}          
		}
	}

	public class RollingParticle
	{
		private static Random random = new Random ();

		public static Image Generate (int width, int height)
		{
			// TODO measure & print time it took to generate this, using own measure time class???

			byte[][] map = new byte[height] [];

			for (int i = 0; i < height; i++)
				map [i] = new byte[width];

			int max_lifetime = 20;

			int edge_left_bias = 10;
			int edge_right_bias = 10;

			int edge_bottom_bias = 10;
			int edge_top_bias = 10;

			int iterations = 0;
			while (iterations++ < 900) {

				// pick a random start particle near center
				int y = random.Next (edge_bottom_bias, height - edge_top_bias - 1);                
				int x = random.Next (edge_left_bias, width - edge_right_bias - 1);

				int particle_lifetime = 0;
				while (particle_lifetime++ < max_lifetime || (x < 3 || x >= width - 3) || (y < 3 || y >= height - 3)) {
					byte c = map [y] [x];

					var offsets = GetNeighbours3x3 (map, x, y);

					bool found = false;
                   
					for (int i = 0; i < offsets.Count; i++) {
						byte new_c = map [offsets [i].y] [offsets [i].x];
						if (new_c <= c) {
							// Log ("walking from " + x + "," + y + " + to " + offsets [i].x + ", " + offsets [i].y);
							x = offsets [i].x;
							y = offsets [i].y;
							found = true;
							break;
						}
					}
					if (!found) {
						// Log ("no lower point found, killing particle at iteration " + iterations);
						break;
					}

					// Log ("setting " + x + ", " + y + " to " + c);
					map [y] [x]++;
				}
			}

			map = NormalizeData (map, 0, 255);

			return ToImage (map, width, height);
		}
		// return 3x3 (up to 8) valid coordinates around specified position
		private static List<Coordinate> GetNeighbours3x3 (byte[][] data, int x, int y)
		{
			List<Coordinate> res = new List<Coordinate> ();

			int height = data.Length;
			int width = data [0].Length;

			for (int a = -1; a <= 1; a++) {
				for (int b = -1; b <= 1; b++) {
					if (a != 0 || b != 0) {
						if (x + a >= 0 && x + a < width && y + b >= 0 && y + b < height) {
							res.Add (new Coordinate (x + a, y + b));
						}
					}
				}
			}

			res.Shuffle (random);

			return res;
		}

		private static byte FindMin (byte[][] data)
		{
			byte res = byte.MaxValue;

			for (int y = 0; y < data.Length; y++) {
				for (int x = 0; x < data [0].Length; x++) {
					if (data [y] [x] < res)
						res = data [y] [x];
				}
			}
			return res;
		}

		private static byte FindMax (byte[][] data)
		{
			byte res = byte.MinValue;

			for (int y = 0; y < data.Length; y++) {
				for (int x = 0; x < data [0].Length; x++) {
					if (data [y] [x] > res)
						res = data [y] [x];
				}
			}
			return res;
		}

		private static byte[][] NormalizeData (byte[][] data, int min, int max)
		{
			byte dataMin = FindMin (data);
			byte dataMax = FindMax (data);

			Log ("Normalizing from data range " + dataMin + " - " + dataMax + ", to " + min + " - " + max);

			if (dataMax == 0)
				return data;

			int scaledRange = max - min;
			int dataRange = dataMax - dataMin;

			byte[][] ret = new byte[data.Length][];

			for (int y = 0; y < data.Length; y++) {
				ret [y] = new byte[data [0].Length];
				for (int x = 0; x < data [0].Length; x++) {
					ret [y] [x] = (byte)(min + ((data [y] [x] - dataMin) * scaledRange / dataRange));
				}
			}

			return ret;
		}

		public static Image ToImage (byte[][] map, int width, int height)
		{
			Bitmap bitmap = new Bitmap (width, height);

			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					byte value = map [y] [x];

					Color color = Color.FromArgb (255, value, value, value);
					//Color color = Color.FromArgb (value, 0, 0, 0);

					bitmap.SetPixel (x, y, color);
				}
			}

			return bitmap;
		}

		static void PrintHexMap (byte[][] map, int width, int height)
		{
			for (int y = 0; y < map.Length; y++) {
				Log (map [y].ToHexString ());
			}
		}

		private static void Log (string s)
		{
			Console.WriteLine ("[RollingParticleMap] " + s);
		}
	}
}
