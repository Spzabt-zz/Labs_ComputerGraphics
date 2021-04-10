using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    public class TriangleFilling : Figures
    {
        private readonly Point _point0;
        private readonly Point _point1;
        private readonly Point _point2;

        public TriangleFilling(Point point0, Point point1, Point point2, Color color, Label label) : base(point0,
            point1, point2, color, label)
        {
            _point0 = point0;
            _point1 = point1;
            _point2 = point2;
        }

        public override void Draw(Graphics graphics, Color color)
        {
            DdaLine(graphics, color, _point0, _point1);
            DdaLine(graphics, color, _point1, _point2);
            DdaLine(graphics, color, _point2, _point0);
            Box2D box2D = FindTriangleBoundingBox(_point0, _point1, _point2);
            for (int y = box2D.TopLeft.Y; y < box2D.BottomRight.Y; y++)
            {
                for (int x = box2D.TopLeft.X; x < box2D.BottomRight.X; x++)
                {
                    if (IsTriangle(new Point(x, y), _point0, _point1, _point2))
                    {
                        PutPixel(graphics, x, y, color);
                    }
                }
            }
        }

        protected override void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics, Color color)
        {
            throw new System.NotImplementedException();
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

        private Box2D FindTriangleBoundingBox( /*Graphics g, Color c, */ Point point0, Point point1, Point point2)
        {
            Box2D result = new Box2D();
            int minX = Min(point0.X, point1.X, point2.X);
            int minY = Min(point0.Y, point1.Y, point2.Y);
            int maxX = Max(point0.X, point1.X, point2.X);
            int maxY = Max(point0.Y, point1.Y, point2.Y);
            result.TopLeft = new Point(minX, minY);
            result.BottomRight = new Point(maxX, maxY);
            return result;
        }

        private bool IsTriangle(Point p, Point a, Point b, Point c)
        {
            int aSide = (a.Y - b.Y) * p.X + (b.X - a.X) * p.Y + (a.X * b.Y - b.X * a.Y);
            int bSide = (b.Y - c.Y) * p.X + (c.X - b.X) * p.Y + (b.X * c.Y - c.X * b.Y);
            int cSide = (c.Y - a.Y) * p.X + (a.X - c.X) * p.Y + (c.X * a.Y - a.X * c.Y);

            return (aSide >= 0 && bSide >= 0 && cSide >= 0) || (aSide < 0 && bSide < 0 && cSide < 0);
        }

        private int Max(int x1, int x2, int x3)
        {
            int res;
            if (x1 > x2)
                if (x1 > x3) /*A - наибольшее*/
                    res = x1;
                else /*С - наибольшее*/
                    res = x3;
            else if (x2 > x3) /*B - наибольшее*/
                res = x2;
            else /*С - наибольшее*/
                res = x3;

            return res;
        }

        private int Min(int x1, int x2, int x3)
        {
            int res;
            if (x1 < x2)
                if (x1 < x3) /*A - наибольшее*/
                    res = x1;
                else /*С - наибольшее*/
                    res = x3;
            else if (x2 < x3) /*B - наибольшее*/
                res = x2;
            else /*С - наибольшее*/
                res = x3;

            return res;
        }
    }
}