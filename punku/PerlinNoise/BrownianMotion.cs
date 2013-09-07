using System;
using System.Drawing;

// or what its called. blur together a set of perlin noise images
// based on http://devmag.org.za/2009/04/25/perlin-noise/
namespace Punku
{
    public class FractalBrownianMotion
    {        
        private static Random random = new Random ();

        public static Bitmap GenerateBrownian (int width, int height, int octaveCount = 8)
        {
            float[][] baseNoise = GenerateWhiteNoise (width, height);

//            SaveImage (baseNoise, "perlin_base.png");

            var perlinNoise = GeneratePerlinNoise (baseNoise, octaveCount);
//            SaveImage (perlinNoise, "perlin_noise1.png");

            perlinNoise = AdjustLevels (perlinNoise, 0.2f, 0.8f);
//            SaveImage (perlinNoise, "perlin_noise_adjusted.png");

            Color gradientStart = Color.FromArgb (0, 0, 0);
            Color gradientEnd = Color.FromArgb (255, 255, 255);
            Bitmap perlinBmp = MapGradient (gradientStart, gradientEnd, perlinNoise);
                     
            perlinBmp.Save ("perlin_noise_mapped.png");

            return perlinBmp;
        }

        protected static float[][] GenerateWhiteNoise (int width, int height)
        {            
            float[][] noise = GetEmptyArray<float> (width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    noise [x] [y] = (float)random.NextDouble () % 1;
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

        protected static Bitmap MapGradient (Color gradientStart, Color gradientEnd, float[][] perlinNoise)
        {
            int width = perlinNoise.Length;
            int height = perlinNoise [0].Length;

            Bitmap bitmap = new Bitmap (width, height);

            //Color[][] image = GetEmptyArray<Color> (width, height); //an array of colours

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    bitmap.SetPixel (x, y, GetColor (gradientStart, gradientEnd, perlinNoise [x] [y]));
                }
            }

            return bitmap;
        }

        private static Color[][] MapToGrey (float[][] greyValues)
        {
            int width = greyValues.Length;
            int height = greyValues [0].Length;

            Color[][] image = GetEmptyArray<Color> (width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    int grey = (int)(255 * greyValues [x] [y]);
                    Color color = Color.FromArgb (255, grey, grey, grey);

                    image [x] [y] = color;
                }
            }

            return image;
        }

        private static T[][] GetEmptyArray<T> (int width, int height)
        {
            T[][] o = new T[width][];

            for (int i = 0; i < width; i++) {
                o [i] = new T[height];
            }

            return o;
        }

        public static float[][] GenerateSmoothNoise (float[][] baseNoise, int octave)
        {
            int width = baseNoise.Length;
            int height = baseNoise [0].Length;

            float[][] smoothNoise = GetEmptyArray<float> (width, height);

            int samplePeriod = 1 << octave; // calculates 2 ^ k
            float sampleFrequency = 1.0f / samplePeriod;

            for (int x = 0; x < width; x++) {
                //calculate the horizontal sampling indices
                int sample_x0 = (x / samplePeriod) * samplePeriod;
                int sample_x1 = (sample_x0 + samplePeriod) % width; //wrap around
                float horizontal_blend = (x - sample_x0) * sampleFrequency;

                for (int y = 0; y < height; y++) {
                    //calculate the vertical sampling indices
                    int sample_y0 = (y / samplePeriod) * samplePeriod;
                    int sample_y1 = (sample_y0 + samplePeriod) % height; //wrap around
                    float vertical_blend = (y - sample_y0) * sampleFrequency;

                    //blend the top two corners
                    float top = Interpolate (baseNoise[sample_x0][sample_y0],
                    baseNoise [sample_x1] [sample_y0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolate (baseNoise[sample_x0][sample_y1],
                    baseNoise [sample_x1] [sample_y1], horizontal_blend);

                    //final blend
                    smoothNoise [x] [y] = Interpolate (top, bottom, vertical_blend);                    
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

                for (int x = 0; x < width; x++) {
                    for (int y = 0; y < height; y++) {
                        perlinNoise [x] [y] += smoothNoise [octave] [x] [y] * amplitude;
                    }
                }
            }

            //normalisation
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    perlinNoise [x] [y] /= totalAmplitude;
                }
            }        

            return perlinNoise;
        }

        public static void SaveImage (Color[][] image, string fileName)
        {
            int width = image.Length;
            int height = image [0].Length;

            Bitmap bitmap = new Bitmap (width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    bitmap.SetPixel (x, y, image [x] [y]);
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

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    image [x] [y] = bitmap.GetPixel (x, y);
                }
            }

            return image;
        }

        public static Color[][] BlendImages (Color[][] image1, Color[][] image2, float[][] perlinNoise)
        {
            int width = image1.Length;
            int height = image1 [0].Length;

            Color[][] image = GetEmptyArray<Color> (width, height); //an array of colours for the new image

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    image [x] [y] = Interpolate (image1[x][y], image2 [x] [y], perlinNoise [x] [y]);
                }
            }

            return image;
        }

        public static float[][] AdjustLevels (float[][] image, float low, float high)
        {
            int width = image.Length;
            int height = image [0].Length;

            float[][] newImage = GetEmptyArray<float> (width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    float col = image [x] [y];

                    if (col <= low) {
                        newImage [x] [y] = 0;
                    } else if (col >= high) {
                        newImage [x] [y] = 1;
                    } else {
                        newImage [x] [y] = (col - low) / (high - low);
                    }
                }
            }

            return newImage;
        }
    }
}

