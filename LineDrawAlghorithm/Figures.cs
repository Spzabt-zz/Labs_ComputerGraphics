using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace LineDrawAlghorithm
{
    public abstract class Figures
    {
        protected double XStart { get; private set; }
        protected double YStart { get; private set; }
        protected double XEnd { get; private set; }
        protected double YEnd { get; private set; }
        protected double Radius { get; private set; }
        public Color Color { get; private set; }
        public Label Label { get; private set; }
        protected Point Point0 {get; private set;}
        protected Point Point1 {get; private set;}
        protected Point Point2 {get; private set;}

        protected Figures(double xStart, double yStart, double xEnd, double yEnd, Color color, Label label)
        {
            XStart = (int) Math.Round(xStart);
            YStart = (int) Math.Round(yStart);
            XEnd = (int) Math.Round(xEnd);
            YEnd = (int) Math.Round(yEnd);
            Color = color;
            Label = label;
        }

        protected Figures(int xStart, int yStart, int radius, Color color, Label label)
        {
            XStart = xStart;
            YStart = yStart;
            Radius = radius;
            Color = color;
            Label = label;
        }
        
        protected Figures(Point point0, Point point1, Point point2, Color color, Label label)
        {
            Point0 = point0;
            Point1 = point1;
            Point2 = point2;
            Color = color;
            Label = label;
        }

        public abstract void Draw(Graphics graphics, Color color);

        protected abstract void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics,
            Color color);

        public void ShowAlgTime(Figures figures, Graphics g, Color c, Label label, PictureBox pictureBox,
            BaseForm form1, int count, TextBox textBox)
        {
            int countOfIter = form1.Count(textBox, count);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < countOfIter; i++)
            {
                figures.AlgImplementation((int) XStart, (int) YStart, (int) XEnd, (int) YEnd, g, c);
            }

            stopwatch.Stop();
            form1.ToLabel(label, c, stopwatch.Elapsed.ToString());
            g?.Clear(pictureBox.BackColor);
        }

        protected static void PutPixel(Graphics g, int x, int y, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color))
                g.FillRectangle(brush, x, y, 1, 1);
        }
    }
}