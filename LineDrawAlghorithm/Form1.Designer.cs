﻿namespace LineDrawAlghorithm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._yEndTextBox = new System.Windows.Forms.TextBox();
            this._xEndTextBox = new System.Windows.Forms.TextBox();
            this._showTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._yStartTextBox = new System.Windows.Forms.TextBox();
            this._xStartTextBox = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this._yEndTextBox);
            this.splitContainer1.Panel1.Controls.Add(this._xEndTextBox);
            this.splitContainer1.Panel1.Controls.Add(this._showTime);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this._yStartTextBox);
            this.splitContainer1.Panel1.Controls.Add(this._xStartTextBox);
            this.splitContainer1.Panel1.Controls.Add(this._drawButton);
            this.splitContainer1.Size = new System.Drawing.Size(700, 437);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Y end";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "X end";
            // 
            // _yEndTextBox
            // 
            this._yEndTextBox.Location = new System.Drawing.Point(50, 85);
            this._yEndTextBox.Name = "_yEndTextBox";
            this._yEndTextBox.Size = new System.Drawing.Size(83, 20);
            this._yEndTextBox.TabIndex = 7;
            // 
            // _xEndTextBox
            // 
            this._xEndTextBox.Location = new System.Drawing.Point(50, 59);
            this._xEndTextBox.Name = "_xEndTextBox";
            this._xEndTextBox.Size = new System.Drawing.Size(83, 20);
            this._xEndTextBox.TabIndex = 6;
            // 
            // _showTime
            // 
            this._showTime.Location = new System.Drawing.Point(19, 403);
            this._showTime.Name = "_showTime";
            this._showTime.Size = new System.Drawing.Size(100, 23);
            this._showTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y start";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "X start";
            // 
            // _yStartTextBox
            // 
            this._yStartTextBox.Location = new System.Drawing.Point(50, 33);
            this._yStartTextBox.Name = "_yStartTextBox";
            this._yStartTextBox.Size = new System.Drawing.Size(83, 20);
            this._yStartTextBox.TabIndex = 2;
            // 
            // _xStartTextBox
            // 
            this._xStartTextBox.Location = new System.Drawing.Point(50, 7);
            this._xStartTextBox.Name = "_xStartTextBox";
            this._xStartTextBox.Size = new System.Drawing.Size(83, 20);
            this._xStartTextBox.TabIndex = 1;
            // 
            // _drawButton
            // 
            this._drawButton.Location = new System.Drawing.Point(3, 111);
            this._drawButton.Name = "_drawButton";
            this._drawButton.Size = new System.Drawing.Size(130, 23);
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

        private System.Windows.Forms.TextBox _yEndTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox _xEndTextBox;

        private System.Windows.Forms.Label _showTime;

        private System.Windows.Forms.TextBox _xStartTextBox;
        private System.Windows.Forms.TextBox _yStartTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button _drawButton;

        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion
    }
}