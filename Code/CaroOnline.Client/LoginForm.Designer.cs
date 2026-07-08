namespace CaroOnline.Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelLeft = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            _statusLabel = new Label();
            _loginButton = new Button();
            txtUsername = new TextBox();
            _hostTextBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelRight = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            dgvLeaderboard = new DataGridView();
            label5 = new Label();
            colRank = new DataGridViewTextBoxColumn();
            colPlayerName = new DataGridViewTextBoxColumn();
            colRecord = new DataGridViewTextBoxColumn();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLeaderboard).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(pictureBox3);
            panelLeft.Controls.Add(pictureBox2);
            panelLeft.Controls.Add(pictureBox1);
            panelLeft.Controls.Add(_statusLabel);
            panelLeft.Controls.Add(_loginButton);
            panelLeft.Controls.Add(txtUsername);
            panelLeft.Controls.Add(_hostTextBox);
            panelLeft.Controls.Add(label4);
            panelLeft.Controls.Add(label3);
            panelLeft.Controls.Add(label2);
            panelLeft.Controls.Add(label1);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(505, 439);
            panelLeft.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(17, 359);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 46);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(10, 214);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 170);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(41, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // _statusLabel
            // 
            _statusLabel.AutoSize = true;
            _statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 163);
            _statusLabel.ForeColor = Color.DarkGray;
            _statusLabel.Location = new Point(62, 373);
            _statusLabel.Name = "_statusLabel";
            _statusLabel.Size = new Size(91, 20);
            _statusLabel.TabIndex = 7;
            _statusLabel.Text = "Chưa kết nối";
            // 
            // _loginButton
            // 
            _loginButton.BackColor = Color.DarkTurquoise;
            _loginButton.FlatAppearance.BorderSize = 0;
            _loginButton.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            _loginButton.FlatStyle = FlatStyle.Flat;
            _loginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            _loginButton.ForeColor = Color.White;
            _loginButton.Location = new Point(213, 300);
            _loginButton.Name = "_loginButton";
            _loginButton.Size = new Size(249, 43);
            _loginButton.TabIndex = 6;
            _loginButton.Text = "ĐĂNG NHẬP";
            _loginButton.UseVisualStyleBackColor = false;
            _loginButton.Click += LoginButton_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.WhiteSmoke;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(213, 237);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(249, 27);
            txtUsername.TabIndex = 5;
            // 
            // _hostTextBox
            // 
            _hostTextBox.BackColor = Color.WhiteSmoke;
            _hostTextBox.BorderStyle = BorderStyle.FixedSingle;
            _hostTextBox.Location = new Point(213, 177);
            _hostTextBox.Name = "_hostTextBox";
            _hostTextBox.Size = new Size(249, 27);
            _hostTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.ForeColor = Color.DarkSlateGray;
            label4.Location = new Point(62, 239);
            label4.Name = "label4";
            label4.Size = new Size(143, 25);
            label4.TabIndex = 3;
            label4.Text = "Tên người chơi:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.DarkSlateGray;
            label3.Location = new Point(62, 179);
            label3.Name = "label3";
            label3.Size = new Size(145, 25);
            label3.TabIndex = 2;
            label3.Text = "Server Address:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(194, 107);
            label2.Name = "label2";
            label2.Size = new Size(75, 31);
            label2.TabIndex = 1;
            label2.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(104, 37);
            label1.Name = "label1";
            label1.Size = new Size(300, 60);
            label1.TabIndex = 0;
            label1.Text = "Caro - Online";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.LightCyan;
            panelRight.Controls.Add(pictureBox5);
            panelRight.Controls.Add(pictureBox4);
            panelRight.Controls.Add(dgvLeaderboard);
            panelRight.Controls.Add(label5);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(505, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(590, 439);
            panelRight.TabIndex = 1;
            panelRight.Paint += panelRight_Paint;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(466, 48);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(62, 62);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(106, 48);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(62, 62);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // dgvLeaderboard
            // 
            dgvLeaderboard.AllowUserToAddRows = false;
            dgvLeaderboard.AllowUserToDeleteRows = false;
            dgvLeaderboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaderboard.BackgroundColor = Color.White;
            dgvLeaderboard.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.LightGray;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLeaderboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLeaderboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaderboard.Columns.AddRange(new DataGridViewColumn[] { colRank, colPlayerName, colRecord });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvLeaderboard.DefaultCellStyle = dataGridViewCellStyle4;
            dgvLeaderboard.GridColor = Color.LightGray;
            dgvLeaderboard.Location = new Point(72, 155);
            dgvLeaderboard.Name = "dgvLeaderboard";
            dgvLeaderboard.ReadOnly = true;
            dgvLeaderboard.RowHeadersVisible = false;
            dgvLeaderboard.RowHeadersWidth = 51;
            dgvLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeaderboard.Size = new Size(490, 228);
            dgvLeaderboard.TabIndex = 1;
            dgvLeaderboard.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.ForeColor = Color.DarkSlateGray;
            label5.Location = new Point(174, 48);
            label5.Name = "label5";
            label5.Size = new Size(297, 46);
            label5.TabIndex = 0;
            label5.Text = "BẢNG XẾP HẠNG";
            // 
            // colRank
            // 
            colRank.HeaderText = "Hạng";
            colRank.MinimumWidth = 6;
            colRank.Name = "colRank";
            colRank.ReadOnly = true;
            // 
            // colPlayerName
            // 
            colPlayerName.HeaderText = "Tên người chơi";
            colPlayerName.MinimumWidth = 6;
            colPlayerName.Name = "colPlayerName";
            colPlayerName.ReadOnly = true;
            // 
            // colRecord
            // 
            colRecord.HeaderText = "Số trận thắng";
            colRecord.MinimumWidth = 6;
            colRecord.Name = "colRecord";
            colRecord.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1095, 439);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online - Login";
            Load += Form1_Load;
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLeaderboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Label label1;
        private Panel panelRight;
        private Label label3;
        private Label label2;
        private TextBox txtUsername;
        private TextBox _hostTextBox;
        private Label label4;
        private Button _loginButton;
        private Label _statusLabel;
        private Label label5;
        private DataGridView dgvLeaderboard;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private DataGridViewTextBoxColumn colRank;
        private DataGridViewTextBoxColumn colPlayerName;
        private DataGridViewTextBoxColumn colRecord;
    }
}
