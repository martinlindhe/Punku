using System;
using System.Drawing;

namespace Punku
{
    public class RollingParticleMap
    {
        private static Random random = new Random ();
        public int Width = 88;
        public int Height = 32;

        public static Bitmap Generate (int width, int height)
        {
            Bitmap bitmap = new Bitmap (width, height);

            Graphics g = Graphics.FromImage (bitmap);
            g.Clear (Color.Black); 



            // XXX pick a starting position near center.

            // XXX decide directioin
            // XXX draw 50 times for each particle, color is reduced when painting.
            // XXX repeat with 3000 particles

            return bitmap;
        }

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

            while (i < this.Width) {
                this.tiles [i++] = new uint [this.Height];
            }
            return;
        }

        private void CreateRollingParticleMap (bool param1 = true)
        {
            uint _loc_3 = 0;
            uint _loc_4 = 0;
            uint _loc_5 = 0;
            var _loc_6 = new Array ();
            uint _loc_7 = 0;
            init ();
            uint _loc_2 = 0;
            while (_loc_2 < PARTICLE_ITERATIONS) {

                if (param1) {
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
            this.blurEdges ();
            normalize ();
            return;
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

            return;
        }
    }
}

