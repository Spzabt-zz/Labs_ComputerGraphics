using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.String;

namespace LineDrawAlghorithm
{
    public partial class Form2 : BaseForm
    {
        private Graphics _graphics;
        private Figures[] _figures;
        private Bitmap _bitmap;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xStartTextBox.Text = "150";
            _yStartTextBox.Text = "130";
            _radius.Text = "100";
            _countOfIterations.Text = "10000";
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void _drawButton_Click(object sender, EventArgs e)
        {
            try
            {
                var xStart = Convert.ToInt32(_xStartTextBox.Text);
                var yStart = Convert.ToInt32(_yStartTextBox.Text);
                var radius = Convert.ToInt32(_radius.Text);
                float cast = yStart + (radius / 1.25f);
                int _yStart = Convert.ToInt32(cast);
                float cast1 = xStart + (radius * 2.1f);
                int _xStart = Convert.ToInt32(cast1);
                float cast2 = xStart + (radius / 14f);
                int _xStart1 = Convert.ToInt32(cast2);

                _figures = new Figures[]
                {
                    new BresenhamCircleAlgorithm(xStart, yStart, radius, Color.Orange, _showBresenhamTime),
                    new ModifiedCircleAlg(_xStart, yStart, radius, Color.Red,
                        _showDDATime),
                    new LibraryCircle(_xStart1, _yStart, radius, Color.Chocolate, _showLibraryTime)
                };

                pictureBox1.Paint += pictureBox1_Paint;
                Refresh();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _xStartTextBox.Text = Empty;
                _yStartTextBox.Text = Empty;
                _radius.Text = Empty;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (_graphics = Graphics.FromImage(_bitmap))
            {
                _graphics?.Clear(pictureBox1.BackColor);
                foreach (var figure in _figures)
                    figure.Draw(_graphics, figure.Color);
                pictureBox1.Image = _bitmap;
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
    }
}