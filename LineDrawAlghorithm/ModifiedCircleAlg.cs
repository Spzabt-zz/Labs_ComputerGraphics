using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    public class ModifiedCircleAlg : Figures
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _radius;

        public ModifiedCircleAlg(int xStart, int yStart, int radius, Color color, Label label) :
            base(xStart, yStart, radius, color, label)
        {
            _x = xStart;
            _y = yStart;
            _radius = radius;
        }

        public override void Draw(Graphics graphics, Color color)
        {
            for (int i = 0; i < 360; i++)
            {
                var x = _x + Math.Round(_radius * Math.Cos(i * Math.PI / 180));
                var y = _y - Math.Round(_radius * Math.Sin(i * Math.PI / 180));
                PutPixel(graphics, (int) x, (int) y, color);
            }
        }

        protected override void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics, Color color)
        {
            for (int i = 0; i < 360; i++)
            {
                var x = _x + Math.Round(_radius * Math.Cos(i * Math.PI / 180));
                var y = _y - Math.Round(_radius * Math.Sin(i * Math.PI / 180));
                PutPixel(graphics, (int) x, (int) y, color);
            }
        }
    }
}