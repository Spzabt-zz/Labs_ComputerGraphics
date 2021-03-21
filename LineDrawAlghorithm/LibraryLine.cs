using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    class LibraryLine : Figures
    {
        private readonly Point _p1;
        private readonly Point _p2;
        private Pen _pen;

        public LibraryLine(double xStart, double yStart, double xEnd, double yEnd, Color color, Label label) : base(
            xStart, yStart, xEnd, yEnd, color, label)
        {
            _p1 = new Point((int) xStart, (int) yStart);
            _p2 = new Point((int) xEnd, (int) yEnd);
        }

        public override void Draw(Graphics graphics, Color color)
        {
            using (_pen = new Pen(color))
                graphics.DrawLine(_pen, _p1, _p2);
        }

        protected override void AlgImplementation(int x1, int y1, int x2, int y2, Graphics graphics,
            Color color)
        {
            using (_pen = new Pen(color))
                graphics.DrawLine(_pen, x1, y1, x2, y2);
        }
    }
}