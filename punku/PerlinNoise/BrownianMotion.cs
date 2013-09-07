using System;
using System.Drawing;

// or what its called. blur together a set of perlin noise images
// based on http://devmag.org.za/2009/04/25/perlin-noise/
namespace Punku
{
    public class FractalBrownianMotionTests : FractalBrownianMotion
    {
        private static void DemoImageBlend ()
        {
            int octaveCount = 8;

            Color gradientStart1 = Color.FromArgb (0, 255, 255);
            Color gradientEnd1 = Color.FromArgb (0, 255, 0);

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

            Color[][] perlinImage = MapGradient (gradientStart, gradientEnd, perlinNoise);
            SaveImage (perlinImage, "perlin_DemoGradientMap.png");
        }

        public static void RunTests ()
        {
            DemoGradientMap ();
            DemoImageBlend ();
        }
    }

    public class FractalBrownianMotion
    {        
        static Random random = new Random ();

        public static Bitmap GenerateBrownian (int width, int height, int octaveCount = 12)
        {
            float[][] baseNoise = GenerateWhiteNoise (width, height);

            var perlinNoise = GeneratePerlinNoise (baseNoise, octaveCount);

            perlinNoise = AdjustLevels (perlinNoise, 0.2f, 0.8f);

            Color gradientStart = Color.FromArgb (0, 0, 0);
            Color gradientEnd = Color.FromArgb (255, 255, 255);
            Color[][] perlinImage = MapGradient (gradientStart, gradientEnd, perlinNoise);
                     
            SaveImage (perlinImage, "perlin_noise.png");

            Bitmap x = ToBitmap (perlinImage);
            //x.Save ("perlin_noise.png");

            return x;
        }

        private static Bitmap ToBitmap (Color[][] img)
        {        
            int width = img.Length;
            int height = img [0].Length;

            Bitmap bitmap = new Bitmap (width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    bitmap.SetPixel (x, y, img [x] [y]);
                }
            }

            return bitmap;            
        }

        protected static float[][] GenerateWhiteNoise (int width, int height)
        {            
            float[][] noise = GetEmptyArray<float> (width, height);

            int border_width = 4;

            for (int i = border_width; i < width - border_width; i++) {
                for (int j = border_width; j < height - border_width; j++) {
                    noise [i] [j] = (float)random.NextDouble () % 1;
                }
            }

            return noise;
        }

        private static float Interpolate (float x0, float x1, float alpha)
        {
            return x0 * (1 - alpha) + alpha * x1;
        }

        private static Color Interpolate (Color col0, Color col1, float alpha)
        {
            float beta = 1 - alpha;
            return Color.FromArgb (
                255,
                (int)(col0.R * alpha + col1.R * beta),
                (int)(col0.G * alpha + col1.G * beta),
                (int)(col0.B * alpha + col1.B * beta));
        }

        public static Color GetColor (Color gradientStart, Color gradientEnd, float t)
        {        
            float u = 1 - t;

            return Color.FromArgb (
                255,
                (int)(gradientStart.R * u + gradientEnd.R * t),
                (int)(gradientStart.G * u + gradientEnd.G * t),
                (int)(gradientStart.B * u + gradientEnd.B * t));
        }

        protected static Color[][] MapGradient (Color gradientStart, Color gradientEnd, float[][] perlinNoise)
        {
            int width = perlinNoise.Length;
            int height = perlinNoise [0].Length;

            Color[][] image = GetEmptyArray<Color> (width, height); //an array of colours

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    image [i] [j] = GetColor (gradientStart, gradientEnd, perlinNoise [i] [j]);
                }
            }

            return image;
        }

        private static T[][] GetEmptyArray<T> (int width, int height)
        {
            T[][] image = new T[width][];

            for (int i = 0; i < width; i++) {
                image [i] = new T[height];
            }

            return image;
        }

        public static float[][] GenerateSmoothNoise (float[][] baseNoise, int octave)
        {
            int width = baseNoise.Length;
            int height = baseNoise [0].Length;

            float[][] smoothNoise = GetEmptyArray<float> (width, height);

            int samplePeriod = 1 << octave; // calculates 2 ^ k
            float sampleFrequency = 1.0f / samplePeriod;

            for (int i = 0; i < width; i++) {
                //calculate the horizontal sampling indices
                int sample_i0 = (i / samplePeriod) * samplePeriod;
                int sample_i1 = (sample_i0 + samplePeriod) % width; //wrap around
                float horizontal_blend = (i - sample_i0) * sampleFrequency;

                for (int j = 0; j < height; j++) {
                    //calculate the vertical sampling indices
                    int sample_j0 = (j / samplePeriod) * samplePeriod;
                    int sample_j1 = (sample_j0 + samplePeriod) % height; //wrap around
                    float vertical_blend = (j - sample_j0) * sampleFrequency;

                    //blend the top two corners
                    float top = Interpolate (baseNoise[sample_i0][sample_j0],
                    baseNoise [sample_i1] [sample_j0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolate (baseNoise[sample_i0][sample_j1],
                    baseNoise [sample_i1] [sample_j1], horizontal_blend);

                    //final blend
                    smoothNoise [i] [j] = Interpolate (top, bottom, vertical_blend);                    
                }
            }

            return smoothNoise;
        }

        public static float[][] GeneratePerlinNoise (float[][] baseNoise, int octaveCount)
        {
            int width = baseNoise.Length;
            int height = baseNoise [0].Length;

            float[][][] smoothNoise = new float[octaveCount][][]; //an array of 2D arrays containing

            float persistance = 0.7f;

            //generate smooth noise
            for (int i = 0; i < octaveCount; i++) {
                smoothNoise [i] = GenerateSmoothNoise (baseNoise, i);
            }

            float[][] perlinNoise = GetEmptyArray<float> (width, height); //an array of floats initialised to 0

            float amplitude = 1.0f;
            float totalAmplitude = 0.0f;

            //blend noise together
            for (int octave = octaveCount - 1; octave >= 0; octave--) {
                amplitude *= persistance;
                totalAmplitude += amplitude;

                for (int i = 0; i < width; i++) {
                    for (int j = 0; j < height; j++) {
                        perlinNoise [i] [j] += smoothNoise [octave] [i] [j] * amplitude;
                    }
                }
            }

            //normalisation
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    perlinNoise [i] [j] /= totalAmplitude;
                }
            }        

            return perlinNoise;
        }

        private static Color[][] MapToGrey (float[][] greyValues)
        {
            int width = greyValues.Length;
            int height = greyValues [0].Length;

            Color[][] image = GetEmptyArray<Color> (width, height);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    int grey = (int)(255 * greyValues [i] [j]);
                    Color color = Color.FromArgb (255, grey, grey, grey);

                    image [i] [j] = color;
                }
            }

            return image;
        }

        public static void SaveImage (Color[][] image, string fileName)
        {
            int width = image.Length;
            int height = image [0].Length;

            Bitmap bitmap = new Bitmap (width, height);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    bitmap.SetPixel (i, j, image [i] [j]);
                }
            }

            bitmap.Save (fileName);
        }

        public static Color[][] LoadImage (string fileName)
        {
            Bitmap bitmap = new Bitmap (fileName);

            int width = bitmap.Width;
            int height = bitmap.Height;

            Color[][] image = GetEmptyArray<Color> (width, height);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    image [i] [j] = bitmap.GetPixel (i, j);
                }
            }

            return image;
        }

        public static Color[][] BlendImages (Color[][] image1, Color[][] image2, float[][] perlinNoise)
        {
            int width = image1.Length;
            int height = image1 [0].Length;

            Color[][] image = GetEmptyArray<Color> (width, height); //an array of colours for the new image

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    image [i] [j] = Interpolate (image1[i][j], image2 [i] [j], perlinNoise [i] [j]);
                }
            }

            return image;
        }

        public static float[][] AdjustLevels (float[][] image, float low, float high)
        {
            int width = image.Length;
            int height = image [0].Length;

            float[][] newImage = GetEmptyArray<float> (width, height);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    float col = image [i] [j];

                    if (col <= low) {
                        newImage [i] [j] = 0;
                    } else if (col >= high) {
                        newImage [i] [j] = 1;
                    } else {
                        newImage [i] [j] = (col - low) / (high - low);
                    }
                }
            }

            return newImage;
        }
    }
}

