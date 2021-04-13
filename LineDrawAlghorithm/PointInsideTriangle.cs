using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    public class PointInsideTriangle
    {
        private readonly Point _point0;
        private readonly Point _point1;
        private readonly Point _point2;

        public PointInsideTriangle(Point point0, Point point1, Point point2)
        {
            _point0 = point0;
            _point1 = point1;
            _point2 = point2;
        }

        private double Area(Point a, Point b, Point c)
        {
            return Math.Abs((a.X * (b.Y - c.Y) +
                             b.X * (c.Y - a.Y) +
                             c.X * (a.Y - b.Y)) / 2.0);
        }

        public bool IsInside(Point p)
        {
            double a = Area(_point0, _point1, _point2);
            double a1 = Area(p, _point1, _point2);
            double a2 = Area(_point0, p, _point2);
            double a3 = Area(_point0, _point1, p);
            return a == a1 + a2 + a3;
        }

        public bool IsActive(Point p)
        {
            return IsInside(p);
        }
    }
}