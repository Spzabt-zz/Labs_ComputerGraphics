using System.Drawing;

namespace LineDrawAlghorithm
{
    struct Box2D
    {
        public Point TopLeft { get; private set; }
        public Point BottomRight { get; private set; }

        public Box2D(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public Box2D FindTriangleBoundingBox(Point point0, Point point1, Point point2)
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

        private int Max(int x1, int x2, int x3)
        {
            int res;
            if (x1 > x2 && x1 > x3) res = x1;
            else if (x2 > x3) res = x2;
            else res = x3;
            return res;
        }

        private int Min(int x1, int x2, int x3)
        {
            int res;
            if (x1 < x2 && x1 < x3) res = x1;
            else if (x2 < x3) res = x2;
            else res = x3;
            return res;
        }
    }
}