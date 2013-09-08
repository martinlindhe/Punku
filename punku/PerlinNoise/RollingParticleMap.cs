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

    public class RollingParticleMap
    {
        private static Random random = new Random ();

        public static Image Generate (int width, int height)
        {
            byte[] map = new byte[height * width];

            int edge_bias = 12;

            int iterations = 0;
            while (iterations++ < 9000) {

                // pick a random start particle near center
                int y = random.Next (edge_bias, height - edge_bias - 1);                
                int x = random.Next (edge_bias, width - edge_bias - 1);

                //   map [(y * width) + x] ++;
        

                // draw 50 times for each particle, color is increased when painting.
                int particle_lifetime = 0;
                while (particle_lifetime++ < 50) {
                    byte c = map [(y * width) + x];

                    if ((x < 1 || x >= width - 1) || (y < 1 || y >= height - 1) || c == 255) {
                        // Log ("killed of particle at iteration " + iteration);
                        break;
                    }

                    // välj alla 3x3 runtomkring mig, blanda dem och börja från början 
                    // tills jag hittar en som är lägre färg än aktuella och hoppa till den positionen
                    var offsets = GetNeighbours3x3 (map, x, y, width, height);

                    bool found = false;
                   
                    for (int i = 0; i < offsets.Count; i++) {
                        byte new_c = map [(offsets[i].y * width) + offsets[i].x];
                        if (new_c <= c) {
                            // Log ("walking from " + x + "," + y + " + to " + offsets [i].x + ", " + offsets [i].y);
                            x = offsets [i].x;
                            y = offsets [i].y;
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        //Log ("no lower point found, killing particle at iteration " + iterations);
                        break;
                    }

                    // Log ("setting " + x + ", " + y + " to " + c);

                    map [(y * width) + x]++;
                }
            }

            map = NormalizeData (map, 0, 255);

            return ToImage (map, width, height);
        }

        static void PrintHexMap (byte[] map, int width, int height)
        {
            for (int y = 0; y < height; y++) {
                byte[] second = new byte[width];            
                Buffer.BlockCopy (map, y * width, second, 0, width);
                Log (ByteArrayPrinter.ToHexString (second));
            }
        }
        // return 3x3 (up to 8) valid coordinates around specified position
        private static List<Coordinate> GetNeighbours3x3 (byte[] data, int x, int y, int width, int height)
        {
            List<Coordinate> res = new List<Coordinate> ();

            for (int a = -1; a <= 1; a++) {
                for (int b = -1; b <= 1; b++) {
                    if (a != 0 || b != 0) {
                        if (x + a >= 0 && x + a < width && y + b >= 0 && y + b < height) {
                            res.Add (new Coordinate(x + a, y + b));
                        }
                    }
                }
            }

            Random random = new Random ((int)DateTime.Now.Ticks);  

            res.Shuffle (random);

            return res;
        }

        private static byte[] NormalizeData (byte[] data, int min, int max)
        {
            byte[] ret = new byte[data.Length];

            byte dataMin = data.Min ();
            byte dataMax = data.Max ();

            if (dataMax == 0)
                return data;

            for (int i = 0; i < data.Length; i++)
                ret [i] = (byte)(min + ((data [i] - dataMin) * (max - min) / (dataMax - dataMin)));

            return ret;
        }

        public static Image ToImage (byte[] map, int width, int height)
        {
            Bitmap bitmap = new Bitmap (width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    byte value = map [(y * width) + x];

                    Color color = Color.FromArgb (value, value, value);

                    bitmap.SetPixel (x, y, color);
                }
            }

            return bitmap;
        }

        private static void Log (string s)
        {
            Console.WriteLine ("[RollingParticleMap] " + s);
        }
    }
}
/*
        private float INNER_BLUR = 0.88f;
        private float OUTER_BLUR = 0.75f;

        private void blurEdges ()
        {
            uint _loc_2 = 0;
            uint _loc_1 = 0;

            while (_loc_1 < this.Width) {

                _loc_2 = 0;
                while (_loc_2 < this.Height) {

                    if (_loc_1 == 0 || _loc_1 == (this.Width - 1) || _loc_2 == 0 || _loc_2 == (this.Height - 1)) {
                        tiles [_loc_1] [_loc_2].elevation = tiles [_loc_1] [_loc_2].elevation * OUTER_BLUR;
                    } else if (_loc_1 == 1 || _loc_1 == this.Width - 2 || _loc_2 == 1 || _loc_2 == this.Height - 2) {
                        tiles [_loc_1] [_loc_2].elevation = tiles [_loc_1] [_loc_2].elevation * INNER_BLUR;
                    }
                    _loc_2 = _loc_2 + 1;
                }
                _loc_1 = _loc_1 + 1;
            }           
        }
*/    

