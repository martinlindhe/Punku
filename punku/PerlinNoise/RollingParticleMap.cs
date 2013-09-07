using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Punku
{
    public class RollingParticleMap
    {
        private static Random random = new Random ();
        public int Width = 88;
        public int Height = 32;

        public static Bitmap Generate (int width, int height)
        {
            byte[] map = new byte[width * height];

            // repeat with 3000 particles
            int particle = 0;
            while (particle++ < 300) {

                // pick a random start particle
                int x = random.Next (0, width - 1);
                int y = random.Next (0, height - 1);

                // get its color
                byte c = map [(y * width) + x];
                if (c == 255) {
                    Log ("skipping white");
                    continue;
                }

                // draw 50 times for each particle, color is increased when painting.
                int iteration = 0;
                while (iteration++ < 50) {
                    if ((x < 0 || x >= width) || (y < 0 || y >= height)) {
                        Log ("killed of particle at iteration " + iteration);
                        iteration = 999;
                        continue;
                    }

                    map [(y * width) + x] = ++c;

                    // decide direction
                    int direction = random.Next (0, 3);
                    switch (direction) {
                    case 0:
                        x++;
                        break;
                    case 1:
                        x--;
                        break;
                    case 2:
                        y++;
                        break;
                    case 3:
                        y--;
                        break;
                    }

                }
            }

            map = NormalizeData (map, 0, 256);

            return ToBitmap (map, width, height);
        }

        private static byte[] NormalizeData (byte[] data, int min, int max)
        {
            byte[] ret = new byte[data.Length];

            byte dataMin = data.Min ();
            byte dataMax = data.Max ();

            for (int i = 0; i < data.Length; i++)
                ret [i] = (byte)(min + ((data [i] - dataMin) * (max - min) / (dataMax - dataMin)));

            return ret;
        }

        public static Bitmap ToBitmap (byte[] map, int width, int height)
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
        public uint[][] tiles;
        public uint ELEVATION_MAX = 255;
        private float INNER_BLUR = 0.88f;
        private float OUTER_BLUR = 0.75f;
        private int PARTICLE_ITERATIONS = 3000;
        private uint EDGE_BIAS = 12;
        private uint PARTICLE_LENGTH = 50;

        private void init ()
        {
            this.tiles = new uint [this.Width][];

            int i = 0;

            while (i < this.Width)
                this.tiles [i++] = new uint [this.Height];
        }

        private void CreateRollingParticleMap (bool biasEdges = true)
        {
            uint _loc_3 = 0;
            uint _loc_4 = 0;
            uint _loc_5 = 0;
            var _loc_6 = new Array ();
            uint _loc_7 = 0;
            init ();
            uint _loc_2 = 0;

            while (_loc_2 < PARTICLE_ITERATIONS) {
                if (biasEdges) {
                    _loc_4 = (uint)(random.NextDouble () * (this.Width - EDGE_BIAS * 2) + EDGE_BIAS);
                    _loc_5 = (uint)(random.NextDouble () * (this.Height - EDGE_BIAS * 2) + EDGE_BIAS);
                } else {
                    _loc_4 = (uint)(random.NextDouble () * (this.Width - 1));
                    _loc_5 = (uint)(random.NextDouble () * (this.Height - 1));
                }
                _loc_3 = 0;

                while (_loc_3 < PARTICLE_LENGTH) {

                    _loc_4 = _loc_4 + Math.Round (Math.Random() * 2 - 1);
                    _loc_5 = _loc_5 + Math.Round (Math.Random() * 2 - 1);
                    if (_loc_4 < 1 || _loc_4 > this.Width - 2 || _loc_5 < 1 || _loc_5 > this.Height - 2) {
                        break;
                    }
                    _loc_6 = this.getNeighborhood (_loc_4, _loc_5);
                    _loc_7 = 0;
                    while (_loc_7 < _loc_6.length) {

                        if (tiles [_loc_6[_loc_7].x] [_loc_6[_loc_7].y].elevation < tiles [_loc_4] [_loc_5].elevation) {
                            _loc_4 = _loc_6 [_loc_7].x;
                            _loc_5 = _loc_6 [_loc_7].y;
                            break;
                        }
                        _loc_7 = _loc_7 + 1;
                    }
                    var _loc_8 = tiles [_loc_4] [_loc_5];
                    var _loc_9 = tiles [_loc_4] [_loc_5].elevation + 1;
                    _loc_8.elevation = _loc_9;
                    _loc_3 = _loc_3 + 1;
                }
                _loc_2 = _loc_2 + 1;
            }
            blurEdges ();
            normalize ();
        }

        public void normalize ()
        {
            uint _loc_4 = 0;
            decimal _loc_5 = NaN;
            uint _loc_1 = 1000000;
            uint _loc_2 = 0;
            uint _loc_3 = 0;

            while (_loc_3 < this.Width) {

                _loc_4 = 0;
                while (_loc_4 < this.Height) {

                    if (this.tiles [_loc_3] [_loc_4].elevation > _loc_2) {
                        _loc_2 = this.tiles [_loc_3] [_loc_4].elevation;
                    }
                    if (this.tiles [_loc_3] [_loc_4].elevation < _loc_1) {
                        _loc_1 = this.tiles [_loc_3] [_loc_4].elevation;
                    }
                    _loc_4 = _loc_4 + 1;
                }
                _loc_3 = _loc_3 + 1;
            }
            _loc_3 = 0;
            while (_loc_3 < this.Width) {

                _loc_4 = 0;
                while (_loc_4 < this.Height) {

                    _loc_5 = (this.tiles [_loc_3] [_loc_4].elevation - _loc_1) / (_loc_2 - _loc_1);
                    this.tiles [_loc_3] [_loc_4].elevation = Math.round (_loc_5 * ELEVATION_MAX);
                    _loc_4 = _loc_4 + 1;
                }
                _loc_3 = _loc_3 + 1;
            }
        }

        private Array getNeighborhood (uint param1, uint param2)
        {
            int _loc_5 = 0;
            var _loc_3 = new Array ();
            int _loc_4 = -1;

            while (_loc_4 <= 1) {

                _loc_5 = -1;
                while (_loc_5 <= 1) {

                    if (_loc_4 || _loc_5) {
                        if (param1 + _loc_4 >= 0 && param1 + _loc_4 < this.Width && param2 + _loc_5 >= 0 && param2 + _loc_5 < HEIGHT) {
                            _loc_3.push (new Point(param1 + _loc_4, param2 + _loc_5));
                        }
                    }
                    _loc_5++;
                }
                _loc_4++;
            }
            ArrayUtils.shuffle (_loc_3);
            return _loc_3;
        }

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

