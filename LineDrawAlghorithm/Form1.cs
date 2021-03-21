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
            _xStartTextBox.Text = "0";
            _yStartTextBox.Text = "0";
            _xEndTextBox.Text = "497";
            _yEndTextBox.Text = "456";
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
                        //new DDA(xStart + 10, yStart, xEnd + 10, yEnd, Color.Blue, this),
                        new LibraryLine(xStart, yStart + 10, xEnd, yEnd + 10, Color.Chartreuse, _showLibraryTime)
                    };
                else
                    _figures = new Figures[]
                    {
                        new DDA(xStart, yStart, xEnd, yEnd, Color.Brown, _showDDATime),
                        //new DDA(xStart + 10, yStart, xEnd + 10, yEnd, Color.Blue, this),
                        new LibraryLine(xStart + 10, yStart, xEnd + 10, yEnd, Color.Chartreuse, _showLibraryTime)
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
            }

            pictureBox1.Image = _bitmap;
            pictureBox1.Paint -= pictureBox1_Paint;
        }

        private async void benchButton_Click(object sender, EventArgs e)
        {
            _drawButton.Enabled = false;
            _benchButton.Enabled = false;

            await Task.Run(() =>
            {
                using (_graphics = Graphics.FromImage(_bitmap))
                    foreach (var figure in _figures)
                        figure.ShowAlgTime(figure, _graphics, figure.Color, figure.Label, pictureBox1, this);
            });
            
            _drawButton.Enabled = true;
            _benchButton.Enabled = true;
        }

        public void ToLabel(Label label, string text)
        {
            if (label.InvokeRequired)
                label.Invoke(new Action<string>(s => label.Text = text), text);
            else
                label.Text = text;
        }
        
        /*public int Count()
        {
            if (_countOfIterations.InvokeRequired)
                _countOfIterations.Invoke(new Action<int>(c => _countOfIterations.Text = count), count);
            else
                _countOfIterations.Text = count;
            
            return 
        }*/
    }
}