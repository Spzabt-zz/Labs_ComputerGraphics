using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    class DDA
    {
        private double _x1;
        private double _y1;
        private readonly double _x2;
        private readonly double _y2;
        public double XStart { get; private set; }
        public double YStart { get; private set; }
        public double XEnd { get; private set; }
        public double YEnd { get; private set; }
        private readonly Form1 _form1;

        public DDA(double xStart, double yStart, double xEnd, double yEnd, Form1 form1)
        {
            _x1 = xStart;
            _y1 = yStart;
            _x2 = xEnd;
            _y2 = yEnd;
            XStart = Math.Round(xStart);
            YStart = Math.Round(yStart);
            XEnd = Math.Round(xEnd);
            YEnd = Math.Round(yEnd);
            _form1 = form1;
        }

        private double Width()
        {
            return Math.Abs(XStart - XEnd);
        }

        private double Height()
        {
            return Math.Abs(YStart - YEnd);
        }

        private int Length()
        {
            int width = (int) Width();
            int height = (int) Height();
            return Math.Max(width, height);
        }

        private double DeltaX()
        {
            return (_x2 - _x1) / Length();
        }

        private double DeltaY()
        {
            return (_y2 - _y1) / Length();
        }

        private static void PutPixel(Graphics g, int x, int y)
        {
            g.FillRectangle(Brushes.DarkRed, x, y, 1, 1);
        }

        public void Draw(Graphics graphics)
        {
            Stopwatch stopwatch = new Stopwatch();
            int i = 1;
            int x, y;
            int length = Length();
            //Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            //pictureBox.Image = bmp;
            //Graphics graphics = Graphics.FromImage(pictureBox.Image);
            stopwatch.Start();
            while ( /*i <= length*/length != 0)
            {
                _x1 += DeltaX();
                x = (int) Math.Round(_x1);
                _y1 += DeltaY();
                y = (int) Math.Round(_y1);
                PutPixel(graphics, x, y);
                length--;
            }

            stopwatch.Stop();
            _form1.GetLabel().Text = stopwatch.Elapsed.ToString();
        }
    }
}