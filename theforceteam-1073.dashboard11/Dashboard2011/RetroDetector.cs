#undef origmeth
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
 
namespace Dashboard2011
{
    class RetroDetector
    {
        Queue<Bitmap> inq;
        Queue<List<PointF>> outq;
        Queue<Rectangle> searchq;

        /// <summary>
        /// Initializes a new RetroDetector
        /// </summary>
        /// <param name="inq">The queue of images</param>
        /// <param name="outq">The que returning tape lists</param>
        /// <param name="searchq">Search areas passed in here. One dimension = 0: whole image.  Both dimensions = 0: Don't search / stop twilight search</param>
        public RetroDetector(Queue<Bitmap> inq, Queue<List<PointF>> outq,Queue<Rectangle> searchq)
        {
            this.inq = inq;
            this.outq = outq;
            this.searchq = searchq;

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
            t.Start();
        }
#if origmeth
        Bitmap prev = null;
        Bitmap curr = null;
        private void Run()
        {
            Rectangle r = Rectangle.Empty;
            while (true)
            {
                System.Threading.Thread.Sleep(10);
                if (inq.Count > 0)
                {
#if true
                    if (inq.Count == 1)
                    {
                        prev = curr;
                        curr = inq.Dequeue();
                    }
                    else
                    {
                        prev = inq.Dequeue();
                        curr = inq.Dequeue();
                    }
#else
                    prev = curr;
                    curr = inq.Dequeue();
#endif
                    inq.Clear();
                }
                if (searchq.Count > 0)
                {
                    try
                    {
                        r = searchq.Last();
                    }
                    catch (InvalidOperationException)
                    {
                        r = searchq.Dequeue();
                    }
                    searchq.Clear();
                }
                if (prev != null)
                {
                    List<PointF> points;
                    if (r.Width == 0 ^ r.Height == 0)
                    {
                        if (Compare(prev, curr, out points))
                        {
                            outq.Enqueue(points);
                        }
                    }
                    else if (r.Width == 0 && r.Height == 0) { continue; }
                    else
                    {
                        r.Intersect(new Rectangle(0, 0, prev.Width, prev.Height));
                        if (Compare(prev, curr, r.X, r.Right, r.Y, r.Bottom, out points))
                        {
                            outq.Enqueue(points);
                        }
                    }
                }
            }
        }

        Change chR = Change.LH;
        Change chG = Change.LL;
        Change chB = Change.Undef;
        int controlsize = 7; // size of corner region where a tape is known to be

        int off = 4; // where to search when high pixel found
        int size = 20;
        int minpixnum = 10;
        /// <summary>
        /// Determines if flash went off, and, if so, where the tapes are.
        /// </summary>
        /// <param name="b0">First image</param>
        /// <param name="b1">2nd image</param>
        /// <param name="xmax">Bounds to search</param>
        /// <param name="ymax">Bounds to search</param>
        /// <param name="xmin">Bounds to search</param>
        /// <param name="ymin">Bounds to search</param>
        /// <param name="tapes">Sets a list of points giving pixel coords. of tapes</param>
        /// <returns>Whether a flash was detected</returns>
        public bool Compare(Bitmap b0, Bitmap b1, int xmin, int xmax, int ymin, int ymax, out List<PointF> tapes)
        {
            tapes = new List<PointF>();

            int w = b0.Width;
            int h = b0.Height;


            int cnton = 0;
            int xtoton = 0;
            int ytoton = 0;
            int cntoff = 0;
            int xtotoff = 0;
            int ytotoff = 0;

            for (int x = xmin; x < xmax; x++)
            {
                for (int y = ymin; y < ymax; y++)
                {
                    Color c0 = b0.GetPixel(x, y);
                    Color c1 = b1.GetPixel(x, y);

                    ulong discrepOn = Compare(c0, c1);
                    ulong discrepOff = Compare(c1, c0);

                    if (discrepOn >= threshval) { cnton++; xtoton += x; ytoton += y; }
                    else if (discrepOff >= threshval) { cntoff++; xtotoff += x; ytotoff += y; }
                }
            }

            if (cnton == 0 && cntoff == 0) { return false; }
            if (cnton >= cntoff)
            {
                var p = new PointF(
                    ((float)(xtoton)) / cnton,
                    ((float)(ytoton)) / cnton
                    );

                tapes.Add(p);
            }
            else
            {
                var p = new PointF(
                    ((float)(xtotoff)) / cntoff,
                    ((float)(ytotoff)) / cntoff
                    );

                tapes.Add(p);
            }
            return true;
        }
        public bool Compare(Bitmap b0, Bitmap b1, out List<PointF> tapes)
        {
            tapes = new List<PointF>();

            int w = b0.Width;
            int h = b0.Height;

            FlashType[,] vals = new FlashType[w, h];

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Color c0 = b0.GetPixel(x, y);
                    Color c1 = b1.GetPixel(x, y);

                    ulong discrepOn = Compare(c0, c1);
                    ulong discrepOff = Compare(c1, c0);

                    vals[x, y] = discrepOn >= threshval ? FlashType.On : (discrepOff >= threshval ? FlashType.Off : FlashType.Zero);
                }
            }

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (vals[x, y] != FlashType.Zero)
                    {
                        int cnton = 0;
                        int xtoton = 0;
                        int ytoton = 0;
                        int cntoff = 0;
                        int xtotoff = 0;
                        int ytotoff = 0;
                        for (int _x = x; _x < x + size && _x < w; _x++)
                        {
                            for (int _y = y - off < 0 ? 0 : y - off; _y < y - off + size && _y < h; _y++)
                            {
                                if (vals[_x, _y] != FlashType.Zero)
                                {
                                    if (vals[_x, _y] == FlashType.On) { cnton++; xtoton += _x; ytoton += _y; }
                                    else if (vals[_x, _y] == FlashType.Off) { cntoff++; xtotoff += _x; ytotoff += _y; }
                                    vals[_x, _y] = FlashType.Zero;
                                }
                            }
                        }

                        if (cnton >= minpixnum)
                        {
                            var p = new PointF(
                                ((float)(xtoton)) / cnton,
                                ((float)(ytoton)) / cnton
                                );

                            tapes.Add(p);
                        }
                        else if (cntoff >= minpixnum)
                        {
                            var p = new PointF(
                                ((float)(xtotoff)) / cntoff,
                                ((float)(ytotoff)) / cntoff
                                );

                            tapes.Add(p);
                        }
                    }
                }
            }
            return true;
        }

        ulong threshval = 61293554419900;
        FlashType getflash(Bitmap b0, Bitmap b1)
        {
            int on = 0;
            int off = 0;
            for (int x = 0; x < controlsize; x++)
            {
                for (int y = b0.Height - controlsize; y < b0.Height; y++)
                {
                    Color c0 = b0.GetPixel(x, y);
                    Color c1 = b1.GetPixel(x, y);

                    ulong _on = Compare(c0, c1);
                    ulong _off = Compare(c1, c0);

                    if (_on >= threshval) { on++; }
                    if (_off >= threshval) { off++; }
                }
            }

            int minnum = (int)(.9 * controlsize * controlsize);
            if (on > minnum) { return FlashType.On; }
            if (off > minnum) { return FlashType.Off; }
            return FlashType.Zero;
        }

        private const int KK = 10000;
        private const int MAX = 255;

        private ulong Compare(Color _0, Color _1)
        {
            ulong _R = Compare(_0.R, _1.R, chR);
            ulong _G = Compare(_0.G, _1.G, chG);
            ulong _B = Compare(_0.B, _1.B, chB);
            return _R * _G * _B;
        }
        private ulong Compare(byte _0, byte _1, Change c)
        {
            ulong _a = (ulong)(MAX - _0) * (ulong)(MAX - _0);
            ulong _b = (ulong)(MAX - _1) * (ulong)(MAX - _1);

            switch (c)
            {
                case Change.HH: return (4294967296 * KK) / (_a * _b + KK);
                case Change.HL: return (_b * KK * 65536) / (_a + KK);
                case Change.LH: return (_a * KK * 65536) / (_b + KK);
                case Change.LL: return 4294967296 - (4294967296*KK) / (_a * _b + KK);
                default: return 1;
            }
        }
#else
        int[,] totals = null;
        float[,] rats = null;
        int maxtot = 0;
        bool hasdonetwilight = false;
        Rectangle search = new Rectangle(0, 0, 1, 1);
        void Run()
        {
            while (true)
            {
                if (searchq.Count > 0) 
                {
                    search = searchq.Dequeue(); searchq.Clear();                    
                }

                if (inq.Count > 0)
                {
                    var b = inq.Dequeue();
                    inq.Clear();

                    // check to se if search is full search or no search

                    if (search.Width == 0 || search.Height == 0)
                    {
                        if (hasdonetwilight) { continue; }

                        if (search.Width == 0 && search.Height == 0)
                        {
                            // stop general twilight search, send all detected tapes
                            int threshnum = (int)(.5 * maxtot)+1;

                            List<PointF> alltapes = new List<PointF>();

                            int w = b.Width;
                            int h = b.Height;
                            
                            int ox1 = -5;
                            int ox2 = 15;
                            int oy1 = 0;
                            int oy2 = 15;

                            for (int x = 0; x < w; x++)
                            {
                                for (int y = 0; y < h; y++)
                                {
                                    if (totals[x, y] >= threshnum)
                                    {
                                        int cnt = 0;
                                        int xtot = 0;
                                        int ytot = 0;
                                        for (int _x = x + ox1 < 0 ? 0 : x + ox1; _x < x + ox2 && _x < w; _x++)
                                        {
                                            for (int _y = y + oy1 < 0 ? 0 : y + oy1; _y < y + oy2 && _y < h; _y++)
                                            {
                                                if (totals[_x, _y] >= threshnum)
                                                {
                                                    cnt++;
                                                    xtot += _x;
                                                    ytot += _y;
                                                    totals[_x, _y] = 0;
                                                }
                                            }
                                        }

                                        if (cnt > 5) // 5 = minimum # of pixels to be valid
                                        {
                                            float xx = ((float)(xtot)) / cnt;
                                            float yy = ((float)(ytot)) / cnt;

                                            alltapes.Add(new PointF(xx, yy));
                                        }
                                    }
                                }
                            }

                            outq.Enqueue(alltapes);
                            hasdonetwilight = true;
                        }
                        else
                        {
                            if (totals == null) { totals = new int[b.Width, b.Height]; rats = new float[b.Width, b.Height]; } // set dimensions
                            TwilightTapes(b, totals, rats, ref maxtot);
                        }
                    }
                    else
                    {
                        search.Intersect(new Rectangle(0, 0, b.Width, b.Height));
                        var tapes = FindTapes(b, search.Left, search.Right, search.Top, search.Bottom);
                        outq.Enqueue(tapes);
                    }
                }
                System.Threading.Thread.Sleep(8);
            }
        }

        /// <summary>
        /// A color with this redness or higher is considered red
        /// </summary>
        const float thresh = 11.0f;

        // searches part of image, returns just a single tape
        List<PointF> FindTapes(Bitmap b, int xmin, int xmax, int ymin, int ymax)
        {
            int cnt = 0;
            int sx = 0;
            int sy = 0;
            for (int x = xmin; x < xmax; x++)
            {
                for (int y = ymin; y < ymax; y++)
                {
                    var c = b.GetPixel(x, y);
                    float rat = rating(c);
                    if (rat >= thresh)
                    {
                        cnt++;
                        sx += x;
                        sy += y;
                    }
                }
            }

            if (cnt > 0)
            {
                return new List<PointF>(){
                    new PointF(
                        ((float)(sx))/cnt,
                        ((float)(sy))/cnt
                        )
                };
            }
            return new List<PointF>();
        }
        const float zombiethresh = 2.1F; // minimum ratio
        /// <summary>
        /// Adds to array determining validity of tapes
        /// </summary>
        /// <param name="b">The image</param>
        /// <param name="total"></param>
        /// <param name="prevreds"></param>
        void TwilightTapes(Bitmap b, int[,] totals, float[,] prevreds, ref int max)
        {
            int w = b.Width;
            int h = b.Height;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    Color c = b.GetPixel(x, y);
                    float rat = rating(c);

                    if ((rat / prevreds[x, y] >= zombiethresh || prevreds[x, y] / rat >= zombiethresh) && prevreds[x,y] != 0) { totals[x, y]++; }
                    prevreds[x, y] = rat;
                }
            }
        }

        /// <summary>
        /// Determines how red a colour is
        /// </summary>
        /// <param name="c">A colour that might be red</param>
        /// <returns>How red the colour is</returns>
        float rating(Color c)
        {
            float b = (float)(255 - c.R);
            float t = (float)(510 - c.G - c.B);
            //b *= b; // ***** should it be squared?????
            //t *= t;
            return (t + 2.5f) / (b + 1f); // ***** should try different constants
        }
#endif
    }
#if origmeth
    enum Change
    {
        HH,
        HL,
        LH,
        LL,
        Undef
    }
    enum FlashType
    {
        On = 2,
        Off = 1,
        Zero = 0
    }
#endif
}
