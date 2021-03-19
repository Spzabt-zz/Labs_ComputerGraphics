using System;
using System.Drawing;

namespace LineDrawAlghorithm
{
    abstract class Figures
    {
        protected double XStart { get; private set; }
        protected double YStart { get; private set; }
        protected double XEnd { get; private set; }
        protected double YEnd { get; private set; }

        protected Figures(double xStart, double yStart, double xEnd, double yEnd)
        {
            XStart = Math.Round(xStart);
            YStart = Math.Round(yStart);
            XEnd = Math.Round(xEnd);
            YEnd = Math.Round(yEnd);
        }

        public abstract void Draw(Graphics graphics);
        
        protected void PutPixel(Graphics g, int x, int y)
        {
            g.FillRectangle(Brushes.DarkRed, x, y, 1, 1);
        }
    }
}