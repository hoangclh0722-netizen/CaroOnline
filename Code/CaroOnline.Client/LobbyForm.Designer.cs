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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnCreateRoom = new Button();
            btnJoinRoom = new Button();
            btnQuickJoin = new Button();
            label3 = new Label();
            dgvDanhSachPhong = new DataGridView();
            colPhong = new DataGridViewTextBoxColumn();
            colChuPhong = new DataGridViewTextBoxColumn();
            colNguoiChoi = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachPhong).BeginInit();
            SuspendLayout();
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.BackColor = Color.Tomato;
            btnCreateRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnCreateRoom.ForeColor = Color.Navy;
            btnCreateRoom.Image = (Image)resources.GetObject("btnCreateRoom.Image");
            btnCreateRoom.ImageAlign = ContentAlignment.TopCenter;
            btnCreateRoom.Location = new Point(397, 120);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(146, 110);
            btnCreateRoom.TabIndex = 1;
            btnCreateRoom.Text = "Tạo phòng";
            btnCreateRoom.TextAlign = ContentAlignment.BottomCenter;
            btnCreateRoom.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCreateRoom.UseVisualStyleBackColor = false;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.BackColor = Color.MediumTurquoise;
            btnJoinRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnJoinRoom.ForeColor = Color.Navy;
            btnJoinRoom.Image = (Image)resources.GetObject("btnJoinRoom.Image");
            btnJoinRoom.ImageAlign = ContentAlignment.TopCenter;
            btnJoinRoom.Location = new Point(634, 120);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(146, 110);
            btnJoinRoom.TabIndex = 2;
            btnJoinRoom.Text = "Vào phòng";
            btnJoinRoom.TextAlign = ContentAlignment.BottomCenter;
            btnJoinRoom.TextImageRelation = TextImageRelation.ImageAboveText;
            btnJoinRoom.UseVisualStyleBackColor = false;
            // 
            // btnQuickJoin
            // 
            btnQuickJoin.BackColor = Color.Gold;
            btnQuickJoin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnQuickJoin.ForeColor = Color.Navy;
            btnQuickJoin.Image = (Image)resources.GetObject("btnQuickJoin.Image");
            btnQuickJoin.ImageAlign = ContentAlignment.TopCenter;
            btnQuickJoin.Location = new Point(864, 120);
            btnQuickJoin.Name = "btnQuickJoin";
            btnQuickJoin.Size = new Size(146, 110);
            btnQuickJoin.TabIndex = 5;
            btnQuickJoin.Text = "Vào nhanh";
            btnQuickJoin.TextAlign = ContentAlignment.BottomCenter;
            btnQuickJoin.TextImageRelation = TextImageRelation.ImageAboveText;
            btnQuickJoin.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(473, 22);
            label3.Name = "label3";
            label3.Size = new Size(458, 46);
            label3.TabIndex = 7;
            label3.Text = "CARO ONLINE - SẢNH CHỜ";
            // 
            // dgvDanhSachPhong
            // 
            dgvDanhSachPhong.AllowUserToAddRows = false;
            dgvDanhSachPhong.BackgroundColor = Color.White;
            dgvDanhSachPhong.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.LightCyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvDanhSachPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvDanhSachPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachPhong.Columns.AddRange(new DataGridViewColumn[] { colPhong, colChuPhong, colNguoiChoi, colTrangThai });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvDanhSachPhong.DefaultCellStyle = dataGridViewCellStyle4;
            dgvDanhSachPhong.EnableHeadersVisualStyles = false;
            dgvDanhSachPhong.GridColor = Color.Gainsboro;
            dgvDanhSachPhong.Location = new Point(473, 275);
            dgvDanhSachPhong.Name = "dgvDanhSachPhong";
            dgvDanhSachPhong.RowHeadersVisible = false;
            dgvDanhSachPhong.RowHeadersWidth = 51;
            dgvDanhSachPhong.Size = new Size(502, 188);
            dgvDanhSachPhong.TabIndex = 8;
            // 
            // colPhong
            // 
            colPhong.HeaderText = "Phòng";
            colPhong.MinimumWidth = 6;
            colPhong.Name = "colPhong";
            colPhong.Width = 125;
            // 
            // colChuPhong
            // 
            colChuPhong.HeaderText = "Chủ phòng";
            colChuPhong.MinimumWidth = 6;
            colChuPhong.Name = "colChuPhong";
            colChuPhong.Width = 125;
            // 
            // colNguoiChoi
            // 
            colNguoiChoi.HeaderText = "Người chơi";
            colNguoiChoi.MinimumWidth = 6;
            colNguoiChoi.Name = "colNguoiChoi";
            colNguoiChoi.Width = 125;
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.Width = 125;
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1317, 503);
            Controls.Add(dgvDanhSachPhong);
            Controls.Add(label3);
            Controls.Add(btnQuickJoin);
            Controls.Add(btnJoinRoom);
            Controls.Add(btnCreateRoom);
            Name = "LobbyForm";
            Text = "LobbyForm";
            Load += LobbyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCreateRoom;
        private Button btnJoinRoom;
        private Button btnQuickJoin;
        private Label label3;
        private DataGridView dgvDanhSachPhong;
        private DataGridViewTextBoxColumn colPhong;
        private DataGridViewTextBoxColumn colChuPhong;
        private DataGridViewTextBoxColumn colNguoiChoi;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}