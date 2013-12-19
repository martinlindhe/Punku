using System;
using System.Drawing;
using Punku;

namespace PunkuTests
{
	public class FractalBrownianMotionTests : FractalBrownianMotion
	{
		/*
        private static void DemoImageBlend ()
        {
            int octaveCount = 8;

            Color[][] image1 = LoadImage ("grass.png");
            Color[][] image2 = LoadImage ("sand.png");

            int width = image1.Length;
            int height = image1 [0].Length;

            float[][] baseNoise = GenerateWhiteNoise (width, height);

            var perlinNoise = GeneratePerlinNoise (baseNoise, octaveCount);

            perlinNoise = AdjustLevels (perlinNoise, 0.2f, 0.8f);

            Color[][] perlinImage = BlendImages (image1, image2, perlinNoise);

            SaveImage (perlinImage, "perlin_DemoImageBlend.png");
        }

        public static void DemoGradientMap ()
        {
            int width = 256;
            int height = 256;
            int octaveCount = 8;

            Color gradientStart = Color.FromArgb (0, 0, 0);
            Color gradientEnd = Color.FromArgb (255, 255, 255);

            float[][] baseNoise = GenerateWhiteNoise (width, height);

            var perlinNoise = GeneratePerlinNoise (baseNoise, octaveCount);

            Color[][] perlinImage = ToBitmap (gradientStart, gradientEnd, perlinNoise);
            SaveImage (perlinImage, "perlin_DemoGradientMap.png");
        }
*/

	}
}

