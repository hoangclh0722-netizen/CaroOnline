namespace CaroOnline.Client
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer? components = null;

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
            panel1 = new Panel();
            panel2 = new Panel();
            panelBoard = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 125);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panelBoard);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1199, 516);
            panel2.TabIndex = 0;
            // 
            // panelBoard
            // 
            panelBoard.Location = new Point(58, 30);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(700, 595);
            panelBoard.TabIndex = 1;
            panelBoard.Paint += panel3_Paint;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 671);
            Controls.Add(panel1);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online";
            Load += GameForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panelBoard;
    }
}