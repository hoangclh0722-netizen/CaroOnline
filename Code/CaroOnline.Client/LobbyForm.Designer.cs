namespace CaroOnline.Client
{
    partial class LobbyForm
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
            btnCreateRoom = new Button();
            btnJoinRoom = new Button();
            label1 = new Label();
            btnRefresh = new Button();
            btnQuickJoin = new Button();
            label3 = new Label();
            dgvRooms = new DataGridView();
            colRoom = new DataGridViewTextBoxColumn();
            colHost = new DataGridViewTextBoxColumn();
            colPlayers = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.Location = new Point(401, 150);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(125, 41);
            btnCreateRoom.TabIndex = 1;
            btnCreateRoom.Text = "Tạo phòng";
            btnCreateRoom.UseVisualStyleBackColor = true;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.Location = new Point(639, 150);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(125, 41);
            btnJoinRoom.TabIndex = 2;
            btnJoinRoom.Text = "Vào phòng";
            btnJoinRoom.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.Location = new Point(521, 249);
            label1.Name = "label1";
            label1.Size = new Size(350, 28);
            label1.TabIndex = 3;
            label1.Text = "DANH SÁCH CÁC PHÒNG ĐANG CHỜ:";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(895, 252);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(89, 29);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnQuickJoin
            // 
            btnQuickJoin.Location = new Point(850, 150);
            btnQuickJoin.Name = "btnQuickJoin";
            btnQuickJoin.Size = new Size(125, 41);
            btnQuickJoin.TabIndex = 5;
            btnQuickJoin.Text = "Vào nhanh";
            btnQuickJoin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(473, 22);
            label3.Name = "label3";
            label3.Size = new Size(437, 46);
            label3.TabIndex = 7;
            label3.Text = "CARO ONLINE - SẢNH CHỜ";
            // 
            // dgvRooms
            // 
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colRoom, colHost, colPlayers, colStatus });
            dgvRooms.Location = new Point(387, 283);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.Size = new Size(597, 188);
            dgvRooms.TabIndex = 9;
            // 
            // colRoom
            // 
            colRoom.HeaderText = "Phòng";
            colRoom.MinimumWidth = 6;
            colRoom.Name = "colRoom";
            // 
            // colHost
            // 
            colHost.HeaderText = "Chủ phòng";
            colHost.MinimumWidth = 6;
            colHost.Name = "colHost";
            // 
            // colPlayers
            // 
            colPlayers.HeaderText = "Người chơi";
            colPlayers.MinimumWidth = 6;
            colPlayers.Name = "colPlayers";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 503);
            Controls.Add(dgvRooms);
            Controls.Add(label3);
            Controls.Add(btnQuickJoin);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(btnJoinRoom);
            Controls.Add(btnCreateRoom);
            Name = "LobbyForm";
            Text = "LobbyForm";
            Load += LobbyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCreateRoom;
        private Button btnJoinRoom;
        private Label label1;
        private Button btnRefresh;
        private Button btnQuickJoin;
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colHost;
        private DataGridViewTextBoxColumn colPlayers;
        private DataGridViewTextBoxColumn colStatus;
    }
}