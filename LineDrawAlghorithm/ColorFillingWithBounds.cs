using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    class ColorFillingWithBounds : Figures
    {
        private readonly Point _point0;
        private readonly Point _point1;
        private readonly Point _point2;
        private readonly Bitmap _bitmap;
        private readonly Form3 _form3;
        private Stack<Point> _points;

        public ColorFillingWithBounds(Point point0, Point point1, Point point2, Color color, Label label, Bitmap bitmap,
            Form3 form3) : base(point0, point1, point2, color, label)
        {
            _point0 = point0;
            _point1 = point1;
            _point2 = point2;
            _bitmap = bitmap;
            _form3 = form3;
        }

        private Point TriangleCentre(Point point0, Point point1, Point point2)
        {
            int x = (point0.X + point1.X + point2.X) / 3;
            int y = (point0.Y + point1.Y + point2.Y) / 3;
            var point = new Point(x, y);
            return point;
        }

        public override void Draw(Graphics graphics, Color color)
        {
            DdaLine(graphics, color, _point0, _point1);
            DdaLine(graphics, color, _point1, _point2);
            DdaLine(graphics, color, _point2, _point0);
            var p = TriangleCentre(_point0, _point1, _point2);
            //BoundaryFill4(graphics, p.X, p.Y, color, color);
            ModifiedBoundaryFill4(graphics, p.X, p.Y, color, color);
        }

        private bool IsColorEqual(Color clr1, Color clr2)
        {
            return clr1.ToArgb() != clr2.ToArgb();
        }

        private void ModifiedBoundaryFill4(Graphics g, int x, int y, Color fillColor,
            Color boundaryColor)
        {
            var firstPoint = new Point(x, y);
            _points = new Stack<Point>();
            _points.Push(firstPoint);
            while (_points.Count != 0)
            {
                var secondPoint = _points.Pop();

                if (IsColorEqual(_bitmap.GetPixel(secondPoint.X, secondPoint.Y), fillColor))
                {
                    PutPixel(g, secondPoint.X, secondPoint.Y, fillColor);
                }

                if (IsColorEqual(_bitmap.GetPixel(secondPoint.X + 1, secondPoint.Y), fillColor) &&
                    IsColorEqual(_bitmap.GetPixel(secondPoint.X + 1, secondPoint.Y), boundaryColor))
                {
                    _points.Push(new Point(secondPoint.X + 1, secondPoint.Y));
                }

                if (IsColorEqual(_bitmap.GetPixel(secondPoint.X, secondPoint.Y + 1), fillColor) &&
                    IsColorEqual(_bitmap.GetPixel(secondPoint.X, secondPoint.Y + 1), boundaryColor))
                {
                    _points.Push(new Point(secondPoint.X, secondPoint.Y + 1));
                }

                if (IsColorEqual(_bitmap.GetPixel(secondPoint.X - 1, secondPoint.Y), fillColor) &&
                    IsColorEqual(_bitmap.GetPixel(secondPoint.X - 1, secondPoint.Y), boundaryColor))
                {
                    _points.Push(new Point(secondPoint.X - 1, secondPoint.Y));
                }

                if (IsColorEqual(_bitmap.GetPixel(secondPoint.X, secondPoint.Y - 1), fillColor) &&
                    IsColorEqual(_bitmap.GetPixel(secondPoint.X, secondPoint.Y - 1), boundaryColor))
                {
                    _points.Push(new Point(secondPoint.X, secondPoint.Y - 1));
                }
            }
        }

        private void BoundaryFill4(Graphics g, int x, int y, Color fillColor, Color boundaryColor)
        {
            var color = _bitmap.GetPixel(x, y);

            if (color.ToArgb() != fillColor.ToArgb() && color.ToArgb() != boundaryColor.ToArgb())
            {
                PutPixel(g, x, y, fillColor);
                BoundaryFill4(g, x + 1, y, fillColor, boundaryColor);
                BoundaryFill4(g, x, y + 1, fillColor, boundaryColor);
                BoundaryFill4(g, x - 1, y, fillColor, boundaryColor);
                BoundaryFill4(g, x, y - 1, fillColor, boundaryColor);
            }
        }

        private void DdaLine(Graphics g, Color c, Point point0, Point point1)
        {
            int x1 = point0.X, y1 = point0.Y, x2 = point1.X, y2 = point1.Y;
            int deltaX = Math.Abs(x1 - x2), deltaY = Math.Abs(y1 - y2);
            int length = Math.Max(deltaX, deltaY);

            double dX = (x2 - x1) / (float) length, dY = (y2 - y1) / (float) length;
            double x = x1, y = y1;

            PutPixel(g, x1, y1, c);
            while (length != 0)
            {
                x += dX;
                y += dY;
                PutPixel(g, (int) Math.Round(x), (int) Math.Round(y), c);
                length--;
            }
        }

        protected override void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics, Color color)
        {
            DdaLine(graphics, color, _point0, _point1);
            DdaLine(graphics, color, _point1, _point2);
            DdaLine(graphics, color, _point2, _point0);
            var p = TriangleCentre(_point0, _point1, _point2);
            //BoundaryFill4(graphics, p.X, p.Y, color, color);
            ModifiedBoundaryFill4(graphics, p.X, p.Y, color, color);
        }
    }
}