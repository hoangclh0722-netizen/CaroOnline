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
            panelBoard = new Panel();
            roomLabel = new Label();
            symbolLabel = new Label();
            turnLabel = new Label();
            timerLabel = new Label();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            lblMyName = new Label();
            lblMyBestRecord = new Label();
            lblEnemyName = new Label();
            lblEnemyBestRecord = new Label();
            SuspendLayout();
            // 
            // panelBoard
            // 
            panelBoard.BackColor = Color.Ivory;
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
            roomLabel.Size = new Size(64, 20);
            roomLabel.TabIndex = 0;
            roomLabel.Text = "Phong: -";
            // 
            // symbolLabel
            // 
            symbolLabel.AutoSize = true;
            symbolLabel.Location = new Point(155, 24);
            symbolLabel.Name = "symbolLabel";
            symbolLabel.Size = new Size(57, 20);
            symbolLabel.TabIndex = 1;
            symbolLabel.Text = "Quan: -";
            // 
            // turnLabel
            // 
            turnLabel.AutoSize = true;
            turnLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            turnLabel.Location = new Point(292, 24);
            turnLabel.Name = "turnLabel";
            turnLabel.Size = new Size(120, 20);
            turnLabel.TabIndex = 2;
            turnLabel.Text = "Dang cho tran...";
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(600, 24);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(84, 20);
            timerLabel.TabIndex = 3;
            timerLabel.Text = "Thoi gian: -";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Ivory;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 595);
            panel1.TabIndex = 0;
     //       panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(741, 138);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 5;
            label1.Text = "Bạn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(741, 188);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 6;
            label2.Text = "Đối thủ: ";
            // 
            // lblMyName
            // 
            lblMyName.AutoSize = true;
            lblMyName.Location = new Point(784, 138);
            lblMyName.Name = "lblMyName";
            lblMyName.Size = new Size(103, 20);
            lblMyName.TabIndex = 7;
            lblMyName.Text = "Đang kết nối...";
            // 
            // lblMyBestRecord
            // 
            lblMyBestRecord.AutoSize = true;
            lblMyBestRecord.Location = new Point(893, 138);
            lblMyBestRecord.Name = "lblMyBestRecord";
            lblMyBestRecord.Size = new Size(73, 20);
            lblMyBestRecord.TabIndex = 8;
            lblMyBestRecord.Text = "(Kỷ lục: 0)";
            // 
            // lblEnemyName
            // 
            lblEnemyName.AutoSize = true;
            lblEnemyName.Location = new Point(805, 188);
            lblEnemyName.Name = "lblEnemyName";
            lblEnemyName.Size = new Size(82, 20);
            lblEnemyName.TabIndex = 9;
            lblEnemyName.Text = "Đang chờ...";
            // 
            // lblEnemyBestRecord
            // 
            lblEnemyBestRecord.AutoSize = true;
            lblEnemyBestRecord.Location = new Point(893, 188);
            lblEnemyBestRecord.Name = "lblEnemyBestRecord";
            lblEnemyBestRecord.Size = new Size(73, 20);
            lblEnemyBestRecord.TabIndex = 10;
            lblEnemyBestRecord.Text = "(Kỷ lục: 0)";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Ivory;
            ClientSize = new Size(1070, 638);
            Controls.Add(lblEnemyBestRecord);
            Controls.Add(lblEnemyName);
            Controls.Add(lblMyBestRecord);
            Controls.Add(lblMyName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(timerLabel);
            Controls.Add(turnLabel);
            Controls.Add(symbolLabel);
            Controls.Add(roomLabel);
            Controls.Add(panelBoard);
            Controls.Add(panel1);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online";
     //       Load += GameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelBoard;
        private Label roomLabel;
        private Label symbolLabel;
        private Label turnLabel;
        private Label timerLabel;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label lblMyName;
        private Label lblMyBestRecord;
        private Label lblEnemyName;
        private Label lblEnemyBestRecord;
    }
}
