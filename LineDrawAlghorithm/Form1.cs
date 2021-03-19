using System;
using System.Drawing;
using System.Windows.Forms;
using static System.String;

namespace LineDrawAlghorithm
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private Figures[] _figures;

        public Form1()
        {
            InitializeComponent();
            /*_xStartTextBox.Text = "90";
            _yStartTextBox.Text = "180";*/
        }

        public Label GetLabel()
        {
            return _showTime;
        }

        private void _drawButton_Click(object sender, EventArgs e)
        {
            try
            {
                var xStart = Convert.ToDouble(_xStartTextBox.Text);
                var yStart = Convert.ToDouble(_yStartTextBox.Text);
                var xEnd = Convert.ToDouble(_xEndTextBox.Text);
                var yEnd = Convert.ToDouble(_yEndTextBox.Text);
                
                _figures = new Figures[]
                {
                    new DDA(xStart, yStart, xEnd, yEnd, this),
                    new DDA(xStart + 10, yStart + 10, xEnd + 10, yEnd + 10, this),
                    //new DDA(10, 30, 100, 100, this)
                };

                splitContainer1.Panel2.Paint += Panel2_Paint;
                Refresh();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _xStartTextBox.Text = Empty;
                _yStartTextBox.Text = Empty;
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            _graphics = e.Graphics;
            foreach (var figure in _figures)
            {
                figure.Draw(_graphics);
            }

            splitContainer1.Panel2.Paint -= Panel2_Paint;
        }
    }
}