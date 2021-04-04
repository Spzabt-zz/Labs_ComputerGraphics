using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    class DDA : Figures
    {
        private double _x1;
        private double _y1;
        private readonly double _x2;
        private readonly double _y2;

        public DDA(double xStart, double yStart, double xEnd, double yEnd, Color color, Label label) :
            base(xStart, yStart, xEnd, yEnd, color, label)
        {
            _x1 = xStart;
            _y1 = yStart;
            _x2 = xEnd;
            _y2 = yEnd;
        }

        private int Dx()
        {
            return (int) Math.Abs(XStart - XEnd);
        }

        private int Dy()
        {
            return (int) Math.Abs(YStart - YEnd);
        }

        private int Length()
        {
            return Math.Max(Dx(), Dy());
        }

        private double DeltaX()
        {
            return (_x2 - _x1) / Length();
        }

        private double DeltaY()
        {
            return (_y2 - _y1) / Length();
        }

        public override void Draw(Graphics graphics, Color color)
        {
            int length = Length();
            double dx = DeltaX();
            double dy = DeltaY();

            PutPixel(graphics, (int) _x1, (int) _y1, color);
            while (length != 0)
            {
                _x1 += dx;
                _y1 += dy;
                PutPixel(graphics, (int) Math.Round(_x1), (int) Math.Round(_y1), color);
                length--;
            }
        }

        protected override void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics,
            Color color)
        {
            int deltaX = Math.Abs(x1 - x2), deltaY = Math.Abs(y1 - y2);
            int length = Math.Max(deltaX, deltaY);

            double dX = deltaX / (float) length, dY = deltaY / (float) length;
            double x = x1, y = y1;

            PutPixel(graphics, (int) _x1, (int) _y1, color);
            while (length != 0)
            {
                x += dX;
                y += dY;
                PutPixel(graphics, (int) Math.Round(x), (int) Math.Round(y), color);
                length--;
            }
        }
    }
}