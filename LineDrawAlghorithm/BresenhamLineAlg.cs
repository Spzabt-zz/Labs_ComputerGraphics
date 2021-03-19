using System.Drawing;

namespace LineDrawAlghorithm
{
    class BresenhamLineAlg : Figures
    {
        private Form1 _form1;

        public BresenhamLineAlg(int xStart, double yStart, double xEnd, double yEnd, Form1 form1) : base(xStart, yStart,
            xEnd, yEnd)
        {
            _form1 = form1;
        }

        public override void Draw(Graphics graphics)
        {
            
        }
    }
}