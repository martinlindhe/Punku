using System;

// based on http://freespace.virgin.net/hugo.elias/models/m_perlin.htm
namespace Punku
{
	public class Martins2dNoise
	{
		public Martins2dNoise ()
		{
		}
		//linear interpolation, straight lines between point a and b
		//x = a point between v1 and v2, between 0.0f and 1.0f
		private static float Linear_Interpolate (float v1, float v2, float x)
		{
			return v1 * (1 - x) + v2 * x;
		}
		//cosine interpolation, smooth curves between point a and b
		//x = a point between a and b, between 0.0f and 1.0f
		private static float Cosine_Interpolate (float a, float b, float x)
		{
			double f = (1 - System.Math.Cos (x * System.Math.PI)) * 0.5f;

			return (float)(a * (1 - f) + b * f);
		}
		//cubic interpolation, perfect curves between point a and b
		//v0 = the point before v1
		//v1 = the point v1
		//v2 = the point v2
		//v3 = the point after v2
		//x = a point between v1 and v2, between 0.0f and 1.0f
		private static float Cubic_Interpolate (float v0, float v1, float v2, float v3, float x)
		{
			float P = (v3 - v2) - (v0 - v1);
			float Q = (v0 - v1) - P;
			float R = v2 - v0;

			return (P * (x * x * x)) + (Q * (x * x)) + (R * x) + v1;
		}
		// 2-Dimensional noise
		public static float Generate (uint x, uint y)
		{
			uint n = x + y * 57;

			n = (n << 13) ^ n;
			return (1.0f - ((n * (n * n * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0f);
		}
		//fixme: borde gå att undvika att räkna ut noise om och om igen här?
		public static float SmoothNoise2 (uint x, uint y)
		{
			float corners = (Generate (x - 1, y - 1) + Generate (x + 1, y - 1) + Generate (x - 1, y + 1) + Generate (x + 1, y + 1)) / 16;	//25% influence
			float sides = (Generate (x - 1, y) + Generate (x + 1, y) + Generate (x, y - 1) + Generate (x, y + 1)) / 8;	//50% influence
			float center = Generate (x, y) / 4;																	//25% influence

			return corners + sides + center;
		}

		public static float InterpolatedNoise2 (float x, float y)
		{
			uint integer_X = (uint)x;
			float fractional_X = x - integer_X;

			uint integer_Y = (uint)y;
			float fractional_Y = y - integer_Y;

			float v1, v2, v3, v4;
			float i1, i2;

			//printf("  x: %f, int_X: %d, fract_X: %f.   y: %f, int_Y: %d, fract_Y: %f\n", x, integer_X, fractional_X, y, integer_Y, fractional_Y);

			v1 = SmoothNoise2 (integer_X, integer_Y);
			v2 = SmoothNoise2 (integer_X + 1, integer_Y);
			v3 = SmoothNoise2 (integer_X, integer_Y + 1);
			v4 = SmoothNoise2 (integer_X + 1, integer_Y + 1);

			i1 = Cosine_Interpolate (v1, v2, fractional_X);
			i2 = Cosine_Interpolate (v3, v4, fractional_X);

			//printf("  %f, %f, %f, %f: %f, %f\n", v1, v2, v3, v4, i1, i2);

			return Cosine_Interpolate (i1, i2, fractional_Y);
		}
		// amplitude och frequency avgör utseendet på resultatet
		//
		// @param buf calloc(length+2, sizeof(float)), passa den existerande buffern igen igenom alla passen
		// @param length antal pixlar totalt,  delbart med 2
		// @param amplitude skillnaden mellan högsta å lägsta möjliga variation, delbart med 2
		// @param frequency antalet noise-prickar som finns i arrayen, delbart med 2
		//
		// koden är beroende av detta för att fungera som den ska
		float[] GenerateNoiseOctave2D (float[] buf, int length, int amplitude, int frequency)
		{
			int pos;
			float bx, by;

			Console.WriteLine ("amp: " + amplitude + ", freq: " + frequency);

			for (by = 0.0f; by < (length / amplitude); by += (1.0f / amplitude)) {
				for (bx = 0.0f; bx < (length / amplitude); bx += (1.0f / amplitude)) {

					pos = (int)((by * amplitude) * length + (bx * amplitude));
					buf [pos] += InterpolatedNoise2 (bx, by);
				}
			}

			return buf;
		}
		// 1-Dimensional noise
		/*
		// Returns pseudorandom floating point numbers between -1.0 and 1.0
		// 15731, 789221, 1376312589 are prime numbers
		float Noise1 (uint x)
		{
			x = (x << 13) ^ x;
			return (1.0f - ((x * (x * x * 15731 + 789221) + 1376312589) & 0x7fffffff) / 1073741824.0f);
		}

		//Noise smoother function
		//generates smoother noise by returning 50% of the noise value from position x and 25% of x-1 and 25% of x+1
		float SmoothNoise1 (float x)
		{
			return (Noise1 (x) / 2) + (Noise1 (x - 1) / 4) + (Noise1 (x + 1) / 4);
		}


		// buf = existing array to fill, or _empty_ if this is first pass
		// Each successive noise function you add is known as an octave. The reason for 
		// this is that each noise function is twice the frequency of the previous one.
		// In music, octaves also have this property.
		//amplitude och frequency avgör utseendet på resultatet
		//amplitude = skillnaden mellan högsta å lägsta möjliga variation, delbart med 2
		//frequency = antalet noise-prickar som finns i arrayen, delbart med 2
		//length = antal pixlar totalt,  delbart med 2
		//buf = calloc(length+2, sizeof(float)), passa den existerande buffern igen igenom alla passen
		//koden är beroende av detta för att fungera som den ska
		float[] GenerateNoiseOctave (float[] buf, int length, int amplitude, int frequency, int seed)
		{
			int x, i;
			float bx, t;

			int lenfreq;

			lenfreq = length / frequency;

			//1. calculate some smooth noise, and merge with existing data (if any)
			for (x=0; x<length; x+=lenfreq) {
				buf [x] = buf [x] + SmoothNoise1 (seed) * amplitude;
				seed++;
			}

			//2. interpolate in between each dot
			for (x=0; x<length; x+=lenfreq) {
				for (bx=0.0f; bx<1.0f; bx+=(1.0f/(float)amplitude)) {
					i = (int)(x + (bx * amplitude));

					if (i > x) {
						if (x == 0)
							t = 0;
						else
							t = buf [x - lenfreq];

						// buf _must_ hold at least length+2 slots or this will crash. this is an optimization instead of checking index value all the time
						buf [i] = Cubic_Interpolate (t, buf [x], buf [x + lenfreq], buf [x + lenfreq + lenfreq], bx);

						// Cosine_Interpolate() is cheaper but looks worse
						//buf[i] = Cosine_Interpolate(buf[x], buf[x+lenfreq], bx);
					}
				}
			}

			return buf;
		}
		*/
	}
}
