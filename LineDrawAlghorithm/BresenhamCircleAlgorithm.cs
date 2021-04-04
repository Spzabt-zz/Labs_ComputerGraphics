using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    public class BresenhamCircleAlgorithm : Figures
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _radius;

        public BresenhamCircleAlgorithm(int xStart, int yStart, int radius, Color color, Label label) :
            base(xStart, yStart, radius, color, label)
        {
            _x = xStart;
            _y = yStart;
            _radius = radius;
        }

        private void DrawCircle(Graphics graphics, Color color, int x, int y)
        {
            PutPixel(graphics, _x + x, _y + y, color);
            PutPixel(graphics, _x + x, _y - y, color);
            PutPixel(graphics, _x - x, _y + y, color);
            PutPixel(graphics, _x - x, _y - y, color);
            PutPixel(graphics, _x + y, _y + x, color);
            PutPixel(graphics, _x + y, _y - x, color);
            PutPixel(graphics, _x - y, _y + x, color);
            PutPixel(graphics, _x - y, _y - x, color);
        }

        public override void Draw(Graphics graphics, Color color)
        {
            Algorithm(graphics, color);
        }

        protected override void AlgImplementation(int x1, int y1, int radius, int neverUsed, Graphics graphics,
            Color color)
        {
            Algorithm(graphics, color);
        }

        private void Algorithm(Graphics graphics, Color color)
        {
            int x = 0, y = _radius, d = 3 - (2 * _radius);

            while (x <= y)
            {
                DrawCircle(graphics, color, x, y);
                if (d <= 0)
                {
                    d += (4 * x) + 6;
                }
                else
                {
                    y--;
                    d += (4 * x) - (4 * y) + 10;
                }

                x++;
            }
        }
    }
}