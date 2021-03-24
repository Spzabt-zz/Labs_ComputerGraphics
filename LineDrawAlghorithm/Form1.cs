using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.String;

namespace LineDrawAlghorithm
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private Figures[] _figures;
        private Bitmap _bitmap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _xStartTextBox.Text = "100";
            _yStartTextBox.Text = "100";
            _xEndTextBox.Text = "300";
            _yEndTextBox.Text = "100";
            _countOfIterations.Text = "20000";
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void _drawButton_Click(object sender, EventArgs e)
        {
            try
            {
                var xStart = Convert.ToDouble(_xStartTextBox.Text);
                var yStart = Convert.ToDouble(_yStartTextBox.Text);
                var xEnd = Convert.ToDouble(_xEndTextBox.Text);
                var yEnd = Convert.ToDouble(_yEndTextBox.Text);

                if (Math.Abs(xStart - xEnd) > Math.Abs(yStart - yEnd))
                    _figures = new Figures[]
                    {
                        new DDA(xStart, yStart, xEnd, yEnd, Color.Brown, _showDDATime),
                        new BresenhamLineAlg(xStart, yStart + 10, xEnd, yEnd + 10, Color.Blue, _showBresenhamTime),
                        new LibraryLine(xStart, yStart + 20, xEnd, yEnd + 20, Color.Green, _showLibraryTime)
                    };
                else
                    _figures = new Figures[]
                    {
                        new DDA(xStart, yStart, xEnd, yEnd, Color.Brown, _showDDATime),
                        new BresenhamLineAlg(xStart + 10, yStart, xEnd + 10, yEnd, Color.Blue, _showBresenhamTime),
                        new LibraryLine(xStart + 20, yStart, xEnd + 20, yEnd, Color.Green, _showLibraryTime)
                    };

                pictureBox1.Paint += pictureBox1_Paint;
                Refresh();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _xStartTextBox.Text = Empty;
                _yStartTextBox.Text = Empty;
                _yStartTextBox.Text = Empty;
                _yEndTextBox.Text = Empty;
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
                await Task.Run(() =>
                {
                    using (_graphics = Graphics.FromImage(_bitmap))
                        foreach (var figure in _figures)
                            figure.ShowAlgTime(figure, _graphics, figure.Color, figure.Label, pictureBox1, this, iter);
                });
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

        public void ToLabel(Label label, Color color, string text)
        {
            label.ForeColor = color;
            if (label.InvokeRequired)
                label.Invoke(new Action<string>(s => label.Text = text), text);
            else
                label.Text = text;
        }

        public int Count(int count)
        {
            var iter = int.Parse(_countOfIterations.Text);
            if (_countOfIterations.InvokeRequired)
                _countOfIterations.Invoke(new Action<int>(c => iter = count), count);
            else
                iter = count;
            return iter;
        }
    }
}