using System;
using System.Drawing;
using System.Windows.Forms;

namespace LineDrawAlghorithm
{
    public partial class BaseForm : Form
    {
        protected BaseForm()
        {
            InitializeComponent();
        }

        public void ToLabel(Label label, Color color, string text)
        {
            label.ForeColor = color;
            if (label.InvokeRequired)
                label.Invoke(new Action<string>(s => label.Text = text), text);
            else
                label.Text = text;
        }

        public int Count(TextBox textBox, int count)
        {
            var iter = int.Parse(textBox.Text);
            if (textBox.InvokeRequired)
                textBox.Invoke(new Action<int>(c => iter = count), count);
            else
                iter = count;
            return iter;
        }
    }
}