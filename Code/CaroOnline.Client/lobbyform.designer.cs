namespace CaroOnline.Client
{
    partial class LobbyForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            label3 = new Label();
            playerNameValueLabel = new Label();
            playerIdValueLabel = new Label();
            label5 = new Label();
            roomsGrid = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            createRoomButton = new Button();
            joinRoomButton = new Button();
            btnLamMoi = new Button();
            statusLabel = new Label();
            leaveRoomButton = new Button();
            btnViewHistory = new Button();
            listBoxHistory = new ListBox();
            ((System.ComponentModel.ISupportInitialize)roomsGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.DarkSlateGray;
            label1.Location = new Point(91, 39);
            label1.Name = "label1";
            label1.Size = new Size(252, 50);
            label1.TabIndex = 0;
            label1.Text = "Caro - Online";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(157, 100);
            label3.Name = "label3";
            label3.Size = new Size(97, 38);
            label3.TabIndex = 2;
            label3.Text = "Lobby";
            // 
            // playerNameValueLabel
            // 
            playerNameValueLabel.AutoSize = true;
            playerNameValueLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            playerNameValueLabel.Location = new Point(46, 176);
            playerNameValueLabel.Name = "playerNameValueLabel";
            playerNameValueLabel.Size = new Size(134, 23);
            playerNameValueLabel.TabIndex = 3;
            playerNameValueLabel.Text = "Tên người chơi:";
            // 
            // playerIdValueLabel
            // 
            playerIdValueLabel.AutoSize = true;
            playerIdValueLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            playerIdValueLabel.Location = new Point(46, 231);
            playerIdValueLabel.Name = "playerIdValueLabel";
            playerIdValueLabel.Size = new Size(33, 23);
            playerIdValueLabel.TabIndex = 4;
            playerIdValueLabel.Text = "ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.Location = new Point(481, 46);
            label5.Name = "label5";
            label5.Size = new Size(396, 41);
            label5.TabIndex = 5;
            label5.Text = "DANH SÁCH PHÒNG CHƠI";
            // 
            // roomsGrid
            // 
            roomsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            roomsGrid.BackgroundColor = Color.White;
            roomsGrid.BorderStyle = BorderStyle.None;
            roomsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            roomsGrid.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            roomsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            roomsGrid.Location = new Point(468, 100);
            roomsGrid.Name = "roomsGrid";
            roomsGrid.RowHeadersVisible = false;
            roomsGrid.RowHeadersWidth = 51;
            roomsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            roomsGrid.Size = new Size(419, 321);
            roomsGrid.TabIndex = 6;
            // 
            // Column1
            // 
            Column1.HeaderText = "Tên Phòng";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Chủ Phòng";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Trạng thái";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // createRoomButton
            // 
            createRoomButton.BackColor = Color.DarkTurquoise;
            createRoomButton.FlatAppearance.BorderSize = 0;
            createRoomButton.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            createRoomButton.FlatStyle = FlatStyle.Flat;
            createRoomButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            createRoomButton.ForeColor = Color.White;
            createRoomButton.Location = new Point(240, 214);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(137, 40);
            createRoomButton.TabIndex = 7;
            createRoomButton.Text = "Tạo Phòng";
            createRoomButton.UseVisualStyleBackColor = false;
            createRoomButton.Click += createRoomButton_Click;
            // 
            // joinRoomButton
            // 
            joinRoomButton.BackColor = Color.DarkTurquoise;
            joinRoomButton.FlatAppearance.BorderSize = 0;
            joinRoomButton.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            joinRoomButton.FlatStyle = FlatStyle.Flat;
            joinRoomButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            joinRoomButton.ForeColor = Color.White;
            joinRoomButton.Location = new Point(240, 293);
            joinRoomButton.Name = "joinRoomButton";
            joinRoomButton.Size = new Size(137, 40);
            joinRoomButton.TabIndex = 8;
            joinRoomButton.Text = "Vào Phòng";
            joinRoomButton.UseVisualStyleBackColor = false;
            joinRoomButton.Click += joinRoomButton_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnLamMoi.Location = new Point(893, 100);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(102, 32);
            btnLamMoi.TabIndex = 9;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += refreshButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(46, 401);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(68, 20);
            statusLabel.TabIndex = 10;
            statusLabel.Text = "Sẵn sàng";
            // 
            // leaveRoomButton
            // 
            leaveRoomButton.BackColor = Color.DarkTurquoise;
            leaveRoomButton.FlatAppearance.BorderSize = 0;
            leaveRoomButton.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            leaveRoomButton.FlatStyle = FlatStyle.Flat;
            leaveRoomButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            leaveRoomButton.ForeColor = Color.White;
            leaveRoomButton.Location = new Point(240, 369);
            leaveRoomButton.Name = "leaveRoomButton";
            leaveRoomButton.Size = new Size(137, 40);
            leaveRoomButton.TabIndex = 11;
            leaveRoomButton.Text = "Rời Phòng";
            leaveRoomButton.UseVisualStyleBackColor = false;
            leaveRoomButton.Click += leaveRoomButton_Click;
            // 
            // btnViewHistory
            // 
            btnViewHistory.Location = new Point(1035, 100);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(177, 50);
            btnViewHistory.TabIndex = 12;
            btnViewHistory.Text = "Xem Lịch Sử Đấu";
            btnViewHistory.UseVisualStyleBackColor = true;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // listBoxHistory
            // 
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.Location = new Point(1035, 156);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new Size(177, 244);
            listBoxHistory.TabIndex = 13;
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(1283, 483);
            Controls.Add(listBoxHistory);
            Controls.Add(btnViewHistory);
            Controls.Add(leaveRoomButton);
            Controls.Add(statusLabel);
            Controls.Add(btnLamMoi);
            Controls.Add(joinRoomButton);
            Controls.Add(createRoomButton);
            Controls.Add(roomsGrid);
            Controls.Add(label5);
            Controls.Add(playerIdValueLabel);
            Controls.Add(playerNameValueLabel);
            Controls.Add(label3);
            Controls.Add(label1);
            MinimumSize = new Size(720, 430);
            Name = "LobbyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online - Lobby";
            ((System.ComponentModel.ISupportInitialize)roomsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label playerNameValueLabel;
        private Label playerIdValueLabel;
        private Label label5;
        private DataGridView roomsGrid;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button createRoomButton;
        private Button joinRoomButton;
        private Button btnLamMoi;
        private Label statusLabel;
        private Button leaveRoomButton;
        private Button btnViewHistory;
        private ListBox listBoxHistory;
    }
}
