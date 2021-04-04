using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    public class LibraryCircle : Figures
    {
        private Pen _pen;
        private readonly Rectangle _rectangle;

        public LibraryCircle(int xStart, int yStart, int radius, Color color, Label label) :
            base(xStart, yStart, radius, color, label)
        {
            _rectangle = new Rectangle(xStart, yStart, radius * 2, radius * 2);
        }

        public override void Draw(Graphics graphics, Color color)
        {
            using (_pen = new Pen(color))
                graphics.DrawEllipse(_pen, _rectangle);
        }

        protected override void AlgImplementation(int x1, int y1, int radius, int neverUsed, Graphics graphics,
            Color color)
        {
            using (_pen = new Pen(color))
                 graphics.DrawEllipse(_pen, _rectangle);
        }
    }
}