namespace tetris
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            CmdLeft = new Button();
            CmdDown = new Button();
            CmdRight = new Button();
            CmdPause = new Button();
            TimTetris = new System.Windows.Forms.Timer(components);
            PanLeft = new Panel();
            PanRight = new Panel();
            PanBelow = new Panel();
            SuspendLayout();
            // 
            // CmdLeft
            // 
            CmdLeft.Location = new Point(45, 12);
            CmdLeft.Name = "CmdLeft";
            CmdLeft.Size = new Size(40, 28);
            CmdLeft.TabIndex = 41;
            CmdLeft.Text = "L";
            CmdLeft.UseVisualStyleBackColor = true;
            CmdLeft.Click += CmdLeft_Click;
            // 
            // CmdDown
            // 
            CmdDown.Location = new Point(85, 47);
            CmdDown.Name = "CmdDown";
            CmdDown.Size = new Size(40, 28);
            CmdDown.TabIndex = 42;
            CmdDown.Text = "D";
            CmdDown.UseVisualStyleBackColor = true;
            // 
            // CmdRight
            // 
            CmdRight.Location = new Point(125, 12);
            CmdRight.Name = "CmdRight";
            CmdRight.Size = new Size(40, 28);
            CmdRight.TabIndex = 43;
            CmdRight.Text = "R";
            CmdRight.UseVisualStyleBackColor = true;
            // 
            // CmdPause
            // 
            CmdPause.Location = new Point(71, 361);
            CmdPause.Name = "CmdPause";
            CmdPause.Size = new Size(70, 28);
            CmdPause.TabIndex = 44;
            CmdPause.Text = "Pause";
            CmdPause.UseVisualStyleBackColor = true;
            // 
            // TimTetris
            // 
            TimTetris.Enabled = true;
            TimTetris.Interval = 500;
            // 
            // PanLeft
            // 
            PanLeft.BackColor = Color.Black;
            PanLeft.Location = new Point(25, 77);
            PanLeft.Name = "PanLeft";
            PanLeft.Size = new Size(1, 260);
            PanLeft.TabIndex = 47;
            // 
            // PanRight
            // 
            PanRight.BackColor = Color.Black;
            PanRight.Location = new Point(185, 77);
            PanRight.Name = "PanRight";
            PanRight.Size = new Size(1, 260);
            PanRight.TabIndex = 49;
            // 
            // PanBelow
            // 
            PanBelow.BackColor = Color.Black;
            PanBelow.Location = new Point(25, 337);
            PanBelow.Name = "PanBelow";
            PanBelow.Size = new Size(160, 1);
            PanBelow.TabIndex = 49;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(212, 413);
            Controls.Add(PanBelow);
            Controls.Add(PanRight);
            Controls.Add(PanLeft);
            Controls.Add(CmdPause);
            Controls.Add(CmdRight);
            Controls.Add(CmdDown);
            Controls.Add(CmdLeft);
            Name = "Form1";
            Text = "Tetris";
            ResumeLayout(false);
        }

        #endregion

        private Button CmdLeft;
        private Button CmdDown;
        private Button CmdRight;
        private Button CmdPause;
        private System.Windows.Forms.Timer TimTetris;
        private Panel PanLeft;
        private Panel PanRight;
        private Panel PanBelow;
    }
}
