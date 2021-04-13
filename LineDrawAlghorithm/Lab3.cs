using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.String;

namespace LineDrawAlghorithm
{
    public partial class Form3 : BaseForm
    {
        private Graphics _graphics;
        private Figures[] _figures;
        private PointInsideTriangle[] _pointInside;
        private Bitmap _bitmap;
        private Box2D _box;

        public Form3()
        {
            InitializeComponent();
            pictureBox1.MouseMove += pictureBox1_MouseMove;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            _showTriangleFillingTime.ForeColor = Color.White;
            _showColorFillingWithBoundsTime.ForeColor = Color.White;
            _showCoordinates.ForeColor = Color.White;
            ////////////////////////
            _x1TextBox.Text = /*"20"*/ /*"300"*/"100";
            _y1TextBox.Text = /*"0"*/"100";
            _x2TextBox.Text = /*"40"*/"400";
            _y2TextBox.Text = /*"20"*/ /*"300"*/"500";
            _x3TextBox.Text = /*"0"*/"100";
            _y3TextBox.Text = /*"20"*/ /*"300"*/"500";
            /*_x1TextBox.Text = "300";
            _y1TextBox.Text = "0";
            _x2TextBox.Text = "400";
            _y2TextBox.Text = "300";
            _x3TextBox.Text = "100";
            _y3TextBox.Text = "300";*/
            _countOfIterations.Text = "1";
            _countOfIterations.Enabled = false;
            pictureBox1.BackColor = Color.Black;
            splitContainer1.Panel1.BackColor = Color.Gray;
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void _drawButton_Click(object sender, EventArgs e)
        {
            try
            {
                var x1 = Convert.ToInt32(_x1TextBox.Text);
                var y1 = Convert.ToInt32(_y1TextBox.Text);
                var x2 = Convert.ToInt32(_x2TextBox.Text);
                var y2 = Convert.ToInt32(_y2TextBox.Text);
                var x3 = Convert.ToInt32(_x3TextBox.Text);
                var y3 = Convert.ToInt32(_y3TextBox.Text);

                var p0 = new Point(x1, y1);
                var p1 = new Point(x2, y2);
                var p2 = new Point(x3, y3);
                var box = _box.FindTriangleBoundingBox(p0, p1, p2);
                //0
                var left = Math.Sqrt(Math.Pow(x1 - box.TopLeft.X, 2) + Math.Pow(y1 - box.TopLeft.Y, 2));
                //300
                var right = Math.Sqrt(Math.Pow(x1 - box.BottomRight.X, 2));
                //var right = Math.Sqrt(Math.Pow(x1 - box.BottomRight.X, 2) + Math.Pow(y1 - 0, 2));

                _figures = new Figures[]
                {
                    new TriangleFilling(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3),
                        Color.White, _showTriangleFillingTime),
                    new ColorFillingWithBounds(new Point(x1 + (int) left + (int) right + x3, y1),
                        new Point(x2 + x2, y2),
                        new Point(x3 + x2, y3), Color.Red, _showColorFillingWithBoundsTime, _bitmap, this)
                    /*new ColorFillingWithBounds(new Point(x1, y1), new Point(x2, y2),
                        new Point(x3, y3), Color.DarkRed, _showColorFillingWithBoundsTime, _bitmap, this)*/
                };

                _pointInside = new PointInsideTriangle[]
                {
                    new PointInsideTriangle(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3)),
                    new PointInsideTriangle(new Point(x1 + (int) left + (int) right + x3, y1), new Point(x2 + x2, y2),
                        new Point(x3 + x2, y3))
                };

                pictureBox1.Paint += pictureBox1_Paint;
                Refresh();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _x1TextBox.Text = Empty;
                _y1TextBox.Text = Empty;
                _x2TextBox.Text = Empty;
                _y2TextBox.Text = Empty;
                _x3TextBox.Text = Empty;
                _y3TextBox.Text = Empty;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = _bitmap;
            using (_graphics = Graphics.FromImage(pictureBox1.Image))
            {
                _graphics?.Clear(pictureBox1.BackColor);
                foreach (var figure in _figures)
                    figure.Draw(_graphics, figure.Color);
            }

            pictureBox1.Paint -= pictureBox1_Paint;
        }

        private async void benchButton_Click(object sender, EventArgs e)
        {
            _drawButton.Enabled = false;
            _benchButton.Enabled = false;

            try
            {
                var iter = int.Parse(_countOfIterations.Text);
                using (_graphics = Graphics.FromImage(_bitmap))
                    foreach (var figure in _figures)
                        await Task.Run(() => figure.ShowAlgTime(figure, _graphics, figure.Color, figure.Label,
                            pictureBox1, this, iter, _countOfIterations));
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _countOfIterations.Text = "10000";
            }

            _drawButton.Enabled = true;
            _benchButton.Enabled = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var point = new Point(e.X, e.Y);
            if (_pointInside == null) return;
            if (_pointInside[0].IsActive(point))
                _showCoordinates.Text = "X-" + e.X + " Y-" + e.Y + "\n" + _pointInside[0]?.IsInside(point);
            else
                _showCoordinates.Text = "X-" + e.X + " Y-" + e.Y + "\n" + _pointInside[1]?.IsInside(point);
        }
    }
}