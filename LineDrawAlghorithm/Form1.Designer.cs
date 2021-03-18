namespace LineDrawAlghorithm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._showTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._yTextBox = new System.Windows.Forms.TextBox();
            this._xTextBox = new System.Windows.Forms.TextBox();
            this._drawButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._showTime);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this._yTextBox);
            this.splitContainer1.Panel1.Controls.Add(this._xTextBox);
            this.splitContainer1.Panel1.Controls.Add(this._drawButton);
            this.splitContainer1.Size = new System.Drawing.Size(700, 437);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 0;
            // 
            // _showTime
            // 
            this._showTime.Location = new System.Drawing.Point(22, 136);
            this._showTime.Name = "_showTime";
            this._showTime.Size = new System.Drawing.Size(100, 23);
            this._showTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // _yTextBox
            // 
            this._yTextBox.Location = new System.Drawing.Point(19, 33);
            this._yTextBox.Name = "_yTextBox";
            this._yTextBox.Size = new System.Drawing.Size(100, 20);
            this._yTextBox.TabIndex = 2;
            // 
            // _xTextBox
            // 
            this._xTextBox.Location = new System.Drawing.Point(19, 7);
            this._xTextBox.Name = "_xTextBox";
            this._xTextBox.Size = new System.Drawing.Size(100, 20);
            this._xTextBox.TabIndex = 1;
            // 
            // _drawButton
            // 
            this._drawButton.Location = new System.Drawing.Point(19, 59);
            this._drawButton.Name = "_drawButton";
            this._drawButton.Size = new System.Drawing.Size(100, 23);
            this._drawButton.TabIndex = 0;
            this._drawButton.Text = "Draw";
            this._drawButton.UseVisualStyleBackColor = true;
            this._drawButton.Click += new System.EventHandler(this._drawButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 437);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Line Drawer 5000";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label _showTime;

        private System.Windows.Forms.TextBox _xTextBox;
        private System.Windows.Forms.TextBox _yTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button _drawButton;

        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion
    }
}