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
        private Bitmap _bitmap;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _x1TextBox.Text = "20";
            _y1TextBox.Text = "0";
            _x2TextBox.Text = "40";
            _y2TextBox.Text = "20";
            _x3TextBox.Text = "0";
            _y3TextBox.Text = "20";
            _countOfIterations.Text = "20000";
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //_bitmap = new Bitmap(splitContainer1.Panel2.Width,splitContainer1.Panel2.Height);
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

                _figures = new Figures[]
                {
                    new TriangleFilling(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3),
                        Color.Black, _showDDATime),
                    new ColorFillingWithBounds(new Point(x1 + x1 + x1, y1), new Point(x2 + x2, y2),
                        new Point(x3 + x2, y3), Color.DarkRed, _showBresenhamTime, _bitmap, this)
                    /*new ColorFillingWithBounds(new Point(x1, y1), new Point(x2, y2),
                        new Point(x3, y3), Color.DarkRed, _showBresenhamTime, _bitmap, this)*/
                };

                //splitContainer1.Panel2.Paint += panel2_Paint;
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

        public SplitContainer GetSplitContainer()
        {
            return splitContainer1;
        }

        public PictureBox GetPictureBox()
        {
            return pictureBox1;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //_graphics = e.Graphics;
            splitContainer1.Panel2.BackgroundImage = _bitmap;
            //using (_graphics = Graphics.FromImage(_bitmap))
                foreach (var figure in _figures)
                    figure.Draw(_graphics, figure.Color);

            splitContainer1.Panel2.Paint -= panel2_Paint;
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
    }
}