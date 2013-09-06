using System;

// or what its called. blur together a set of perlin noise images
// based on http://devmag.org.za/2009/04/25/perlin-noise/
namespace Punku
{
    public class BrownianMotion
    {        

        public void xx ()
        {
            int height = 32;
            int width = 32;
            int octaveCount = 8;

            float[,] baseNoise = GenerateWhiteNoise (width, height);
            var perlinNoise = GeneratePerlinNoise (baseNoise, octaveCount);
            perlinNoise = AdjustLevels (perlinNoise, 0.2f, 0.8f);


        }

        private static float[,] AdjustLevels (float[][] noise, float low, float high)
        {
            int height = noise.GetLength (0);
            int width = noise.GetLength (1);

            float[][] newNoise = new float[height, width];

            for (int j = 0; j < height; j++) {
                for (int i = 0; i < width; i++) {
                    float col = noise [i, j];

                    if (col <= low) {
                        newNoise [i, j] = 0;
                    } else if (col >= high) {
                        newNoise [i, j] = 1;
                    } else {
                        newNoise [i, j] = (col - low) / (high - low);
                    }
                }
            }

            return newNoise;
        }

        private static float[,] GenerateWhiteNoise (int height, int width)
        {
            int seed = 0; // seed 0 for testing
            Random random = new Random (seed);
            float[,] noise = new float[height, width];

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    noise [y, x] = (float)random.NextDouble () % 1;
                }
            }

            return noise;
        }

        private static float[,] GenerateSmoothNoise (float[,] baseNoise, int octave)
        {
            int height = baseNoise.GetLength (0);
            int width = baseNoise.GetLength (1);

            float[,] smoothNoise = new float[height, width];

            int samplePeriod = 1 << octave; // calculates 2 ^ k
            float sampleFrequency = 1.0f / samplePeriod;

            for (int x = 0; x < width; x++) {
                //calculate the horizontal sampling indices
                int sample_i0 = (x / samplePeriod) * samplePeriod;
                int sample_i1 = (sample_i0 + samplePeriod) % width; //wrap around
                float horizontal_blend = (x - sample_i0) * sampleFrequency;

                for (int y = 0; y < height; y++) {
                    //calculate the vertical sampling indices
                    int sample_j0 = (y / samplePeriod) * samplePeriod;
                    int sample_j1 = (sample_j0 + samplePeriod) % height; //wrap around
                    float vertical_blend = (y - sample_j0) * sampleFrequency;

                    //blend the top two corners
                    float top = Interpolate (baseNoise[sample_i0, sample_j0],
                    baseNoise [sample_i1, sample_j0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolate (baseNoise[sample_i0, sample_j1],
                    baseNoise [sample_i1, sample_j1], horizontal_blend);

                    //final blend
                    smoothNoise [x, y] = Interpolate (top, bottom, vertical_blend);
                }
            }

            return smoothNoise;
        }

        private static float Interpolate (float x0, float x1, float alpha)
        {
            return x0 * (1 - alpha) + alpha * x1;
        }

        private float[,] GeneratePerlinNoise (float[,] baseNoise, int octaveCount)
        {
            int height = baseNoise.GetLength (0);
            int width = baseNoise.GetLength (1);

            float[][,] smoothNoise = new float[octaveCount][,]; //an array of 2D arrays containing

            float persistance = 0.5f;

            //generate smooth noise
            for (int i = 0; i < octaveCount; i++) {
                smoothNoise [i] = GenerateSmoothNoise (baseNoise, i);
            }

            float[,] perlinNoise = new float[height, width];
            float amplitude = 1.0f;
            float totalAmplitude = 0.0f;

            //blend noise together
            for (int octave = octaveCount - 1; octave >= 0; octave--) {
                amplitude *= persistance;
                totalAmplitude += amplitude;

                for (int i = 0; i < width; i++) {
                    for (int j = 0; j < height; j++) {
                        perlinNoise [i, j] += smoothNoise [octave] [i, j] * amplitude;
                    }
                }
            }

            //normalisation
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    perlinNoise [i, j] /= totalAmplitude;
                }
            }

            return perlinNoise;
        }
    }
}

