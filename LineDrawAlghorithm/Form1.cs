using System;
using System.Drawing;
using System.Windows.Forms;
using static System.String;

namespace LineDrawAlghorithm
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private DDA[] _dda;

        public Form1()
        {
            InitializeComponent();
            _xTextBox.Text = "100";
            _yTextBox.Text = "200";
        }

        public Label GetLabel()
        {
            return _showTime;
        }

        private void _drawButton_Click(object sender, EventArgs e)
        {
            try
            {
                var xStart = Convert.ToDouble(_xTextBox.Text);
                var yStart = Convert.ToDouble(_xTextBox.Text);
                var xEnd = Convert.ToDouble(_yTextBox.Text);
                var yEnd = Convert.ToDouble(_yTextBox.Text);

                _dda = new[]
                {
                    new DDA(xStart, yStart, xEnd, yEnd, this),
                    new DDA(xStart, yStart + 10, xEnd, yEnd + 10, this)
                };

                splitContainer1.Panel2.Paint += Panel2_Paint;
                Refresh();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _xTextBox.Text = Empty;
                _yTextBox.Text = Empty;
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            _graphics = e.Graphics;
            foreach (var line in _dda)
            {
                line.Draw(_graphics);
            }

            splitContainer1.Panel2.Paint -= Panel2_Paint;
        }
    }
}