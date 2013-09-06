using System;

// or what its called. blur together a set of perlin noise images
// based on http://devmag.org.za/2009/04/25/perlin-noise/
namespace punku
{
    public class BrownianMotion
    {
        // 1. random feed start

        // 2. genereate a set of perlin noise images
        // 3. blend together

        public static float[,] GenerateWhiteNoise (int height, int width)
        {
            int seed = 0; // seed 0 for testing
            Random random = new Random (seed);
            float[,] noise = new float[width, height];

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    noise [y, x] = (float)random.NextDouble () % 1;
                }
            }

            return noise;
        }

        public static float[,] GenerateSmoothNoise (float[,] baseNoise, int octave)
        {
            int height = baseNoise.GetLength (0);
            int width = baseNoise.GetLength (1);

            float[,] smoothNoise = new float[height, width];

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
                    float top = Interpolate (baseNoise[sample_i0, sample_j0],
                    baseNoise [sample_i1, sample_j0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolate (baseNoise[sample_i0, sample_j1],
                    baseNoise [sample_i1, sample_j1], horizontal_blend);

                    //final blend
                    smoothNoise [i, j] = Interpolate (top, bottom, vertical_blend);
                }
            }

            return smoothNoise;
        }

        private static float Interpolate (float x0, float x1, float alpha)
        {
            return x0 * (1 - alpha) + alpha * x1;
        }
    }
}

