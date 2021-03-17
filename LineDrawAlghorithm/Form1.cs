using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.String;

namespace LineDrawAlghorithm
{
    public partial class Form1 : Form
    {
        private DDA _dda;
        private readonly Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void _drawButton_Click(object sender, EventArgs e)
        {
            double x = _random.Next(10, 101);
            double y = _random.Next(10, 101);
            double x1 = _pictureBox.Width;
            double y1 = _pictureBox.Height;
            //_xTextBox.Text = xStart.*/
            //_dda = new DDA(x1, y1 / 2 , x1 / 2, y1);
            //_dda.Draw(_pictureBox);
            /*if (_xTextBox.Text != string.Empty && _yTextBox.Text != string.Empty)
            {
                _dda = new DDA(xStart, yStart, xEnd * 2, yEnd * 2);
                _dda.Draw(_pictureBox);   
            }
            else
                MessageBox.Show("Enter empty fields!");*/

            try
            {
                var xStart = Convert.ToDouble(_xTextBox.Text);
                var yStart = Convert.ToDouble(_xTextBox.Text);
                var xEnd = Convert.ToDouble(_yTextBox.Text);
                var yEnd = Convert.ToDouble(_yTextBox.Text);
                
                /*if (_xTextBox.Text == string.Empty || _yTextBox.Text == string.Empty)
                    throw new Exception("Fill empty fields");*/
                _dda = new DDA(xStart, yStart, xEnd * 2, yEnd * 2);
                _dda.Draw(_pictureBox);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                _xTextBox.Text = Empty;
                _yTextBox.Text = Empty;
            }
        }
    }
}