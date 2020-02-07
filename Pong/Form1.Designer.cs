namespace Pong
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
            this.components = new System.ComponentModel.Container();
            this.gameUpdateLoop = new System.Windows.Forms.Timer(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.p1Score = new System.Windows.Forms.Label();
            this.p2Score = new System.Windows.Forms.Label();
            this.aiButton = new System.Windows.Forms.Button();
            this.twoP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameUpdateLoop
            // 
            this.gameUpdateLoop.Interval = 16;
            this.gameUpdateLoop.Tick += new System.EventHandler(this.gameUpdateLoop_Tick);
            // 
            // startLabel
            // 
            this.startLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.startLabel.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.Color.Black;
            this.startLabel.Location = new System.Drawing.Point(105, 71);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(794, 93);
            this.startLabel.TabIndex = 0;
            this.startLabel.Text = "Press Space To Start";
            this.startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startLabel.Visible = false;
            // 
            // p1Score
            // 
            this.p1Score.AutoSize = true;
            this.p1Score.BackColor = System.Drawing.Color.Transparent;
            this.p1Score.Font = new System.Drawing.Font("Comic Sans MS", 30F);
            this.p1Score.ForeColor = System.Drawing.Color.Red;
            this.p1Score.Location = new System.Drawing.Point(64, 9);
            this.p1Score.Name = "p1Score";
            this.p1Score.Size = new System.Drawing.Size(0, 56);
            this.p1Score.TabIndex = 1;
            // 
            // p2Score
            // 
            this.p2Score.AutoSize = true;
            this.p2Score.BackColor = System.Drawing.Color.Transparent;
            this.p2Score.Font = new System.Drawing.Font("Comic Sans MS", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Score.ForeColor = System.Drawing.Color.Blue;
            this.p2Score.Location = new System.Drawing.Point(899, 9);
            this.p2Score.Name = "p2Score";
            this.p2Score.Size = new System.Drawing.Size(0, 56);
            this.p2Score.TabIndex = 2;
            // 
            // aiButton
            // 
            this.aiButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.aiButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aiButton.Location = new System.Drawing.Point(450, 214);
            this.aiButton.Name = "aiButton";
            this.aiButton.Size = new System.Drawing.Size(105, 41);
            this.aiButton.TabIndex = 3;
            this.aiButton.Text = "Ai Mode";
            this.aiButton.UseVisualStyleBackColor = false;
            this.aiButton.Click += new System.EventHandler(this.AiButton_Click);
            // 
            // twoP
            // 
            this.twoP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.twoP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.twoP.Location = new System.Drawing.Point(450, 167);
            this.twoP.Name = "twoP";
            this.twoP.Size = new System.Drawing.Size(105, 41);
            this.twoP.TabIndex = 4;
            this.twoP.Text = "2 Player Mode";
            this.twoP.UseVisualStyleBackColor = false;
            this.twoP.Click += new System.EventHandler(this.TwoP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.twoP);
            this.Controls.Add(this.aiButton);
            this.Controls.Add(this.p2Score);
            this.Controls.Add(this.p1Score);
            this.Controls.Add(this.startLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameUpdateLoop;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label p1Score;
        private System.Windows.Forms.Label p2Score;
        private System.Windows.Forms.Button aiButton;
        private System.Windows.Forms.Button twoP;
    }
}

