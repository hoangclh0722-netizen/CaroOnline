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
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 595);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 638);
            Controls.Add(panel1);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online";
            Load += GameForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
    }
}