using System;
using System.Diagnostics;
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
        private readonly Form1 _form1;

        public DDA(double xStart, double yStart, double xEnd, double yEnd, Form1 form1) : base(xStart, yStart, xEnd,
            yEnd)
        {
            _x1 = xStart;
            _y1 = yStart;
            _x2 = xEnd;
            _y2 = yEnd;
            _form1 = form1;
        }

        private int Width()
        {
            return (int) Math.Abs(XStart - XEnd);
        }

        private int Height()
        {
            return (int) Math.Abs(YStart - YEnd);
        }

        private int Length()
        {
            return  Math.Max(Width(), Height());
        }

        private double DeltaX()
        {
            return (_x2 - _x1) / Length();
        }

        private double DeltaY()
        {
            return (_y2 - _y1) / Length();
        }

        public override void Draw(Graphics graphics)
        {
            Stopwatch stopwatch = new Stopwatch();
            int length = Length();

            stopwatch.Start();
            while (length != 0)
            {
                _x1 += DeltaX();
                _y1 += DeltaY();
                PutPixel(graphics, (int) Math.Round(_x1), (int) Math.Round(_y1));
                length--;
            }

            stopwatch.Stop();
            _form1.GetLabel().Text = stopwatch.Elapsed.ToString();
        }
    }
}