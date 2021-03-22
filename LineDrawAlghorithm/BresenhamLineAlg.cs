using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    class BresenhamLineAlg : Figures
    {
        private readonly int _x1;
        private readonly int _y1;
        private readonly int _x2;
        private readonly int _y2;

        public BresenhamLineAlg(double xStart, double yStart, double xEnd, double yEnd, Color color, Label label) :
            base(xStart, yStart, xEnd, yEnd, color, label)
        {
            _x1 = (int) xStart;
            _y1 = (int) yStart;
            _x2 = (int) xEnd;
            _y2 = (int) yEnd;
        }

        private int DeltaX()
        {
            return Math.Abs(_x2 - _x1);
        }

        private int DeltaY()
        {
            return Math.Abs(_y2 - _y1);
        }

        private int DirectionIncrementingX()
        {
            return _x2 >= _x1 ? 1 : -1;
        }

        private int DirectionIncrementingY()
        {
            return _y2 >= _y1 ? 1 : -1;
        }

        public override void Draw(Graphics graphics, Color color)
        {
            int dx = DeltaX(), dy = DeltaY();
            int directionIncrementingX = DirectionIncrementingX(), directionIncrementingY = DirectionIncrementingY();

            if (dy <= dx)
            {
                int d = (dy << 1) - dx, d1 = dy << 1, d2 = (dy - dx) << 1;
                PutPixel(graphics, _x1, _y1, color);
                for (int x = _x1 + directionIncrementingX, y = _y1, i = 1; i <= dx; i++, x += directionIncrementingX)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += directionIncrementingY;
                    }
                    else
                        d += d1;

                    PutPixel(graphics, x, y, color);
                }
            }
            else
            {
                int d = (dx << 1) - dy, d1 = dx << 1, d2 = (dx - dy) << 1;
                PutPixel(graphics, _x1, _y1, color);
                for (int y = _y1 + directionIncrementingY, x = _x1, i = 1; i <= dy; i++, y += directionIncrementingY)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += directionIncrementingX;
                    }
                    else
                        d += d1;

                    PutPixel(graphics, x, y, color);
                }
            }
        }

        protected override void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics,
            Color color)
        {
            int dx = Math.Abs(x2 - x1), dy = Math.Abs(y2 - y1);
            int sx = x2 >= x1 ? 1 : -1, sy = y2 >= y1 ? 1 : -1;

            if (dy <= dx)
            {
                int d = (dy << 1) - dx, d1 = dy << 1, d2 = (dy - dx) << 1;
                PutPixel(graphics, x1, y1, color);
                for (int x = x1 + sx, y = y1, i = 1; i <= dx; i++, x += sx)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                        d += d1;

                    PutPixel(graphics, x, y, color);
                }
            }
            else
            {
                int d = (dx << 1) - dy, d1 = dx << 1, d2 = (dx - dy) << 1;
                PutPixel(graphics, x1, y1, color);
                for (int y = y1 + sy, x = x1, i = 1; i <= dy; i++, y += sy)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                        d += d1;

                    PutPixel(graphics, x, y, color);
                }
            }
        }
    }
}