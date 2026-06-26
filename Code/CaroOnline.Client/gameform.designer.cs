namespace CaroOnline.Client
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
<<<<<<< HEAD
            panelBoard = new Panel();
            roomLabel = new Label();
            symbolLabel = new Label();
            turnLabel = new Label();
            timerLabel = new Label();
            SuspendLayout();
            // 
            // panelBoard
            // 
            panelBoard.Location = new Point(24, 66);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(700, 595);
            panelBoard.TabIndex = 4;
            // 
            // roomLabel
            // 
            roomLabel.AutoSize = true;
            roomLabel.Location = new Point(24, 24);
            roomLabel.Name = "roomLabel";
            roomLabel.Size = new Size(71, 20);
            roomLabel.TabIndex = 0;
            roomLabel.Text = "Phong: -";
            // 
            // symbolLabel
            // 
            symbolLabel.AutoSize = true;
            symbolLabel.Location = new Point(155, 24);
            symbolLabel.Name = "symbolLabel";
            symbolLabel.Size = new Size(69, 20);
            symbolLabel.TabIndex = 1;
            symbolLabel.Text = "Quan: -";
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            turnLabel.Location = new Point(292, 24);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(123, 20);
            turnLabel.TabIndex = 2;
            turnLabel.Text = "Dang cho tran...";
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(600, 24);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(86, 20);
            timerLabel.TabIndex = 3;
            timerLabel.Text = "Thoi gian: -";
=======
            panel1 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 595);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
>>>>>>> f4654aafe2fd30c151b336811023f86395576263
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
            AutoScroll = true;
            ClientSize = new Size(805, 720);
            Controls.Add(timerLabel);
            Controls.Add(turnLabel);
            Controls.Add(symbolLabel);
            Controls.Add(roomLabel);
            Controls.Add(panelBoard);
=======
            ClientSize = new Size(919, 638);
            Controls.Add(panel1);
>>>>>>> f4654aafe2fd30c151b336811023f86395576263
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online";
            Load += GameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

<<<<<<< HEAD
        private Panel panelBoard;
        private Label roomLabel;
        private Label symbolLabel;
        private Label turnLabel;
        private Label timerLabel;
=======
        private Panel panel1;
>>>>>>> f4654aafe2fd30c151b336811023f86395576263
    }
}
