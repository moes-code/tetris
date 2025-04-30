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
            TimTetris = new System.Windows.Forms.Timer(components);
            PanLeft = new Panel();
            PanRight = new Panel();
            PanBelow = new Panel();
            SuspendLayout();
            // 
            // TimTetris
            // 
            TimTetris.Enabled = true;
            TimTetris.Interval = 500;
            TimTetris.Tick += TimTetris_Tick;
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
            Name = "Form1";
            Text = "Tetris";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer TimTetris;
        private Panel PanLeft;
        private Panel PanRight;
        private Panel PanBelow;
    }
}
