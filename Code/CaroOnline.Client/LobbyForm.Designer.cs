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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnCreateRoom = new Button();
            btnJoinRoom = new Button();
            btnQuickJoin = new Button();
            label3 = new Label();
            dgvDanhSachPhong = new DataGridView();
            colPhong = new DataGridViewTextBoxColumn();
            colChuPhong = new DataGridViewTextBoxColumn();
            colNguoiChoi = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
            lblBaxXepHang = new Label();
            dgvBaxXepHang = new DataGridView();
            colHang = new DataGridViewTextBoxColumn();
            colTenNguoiChoi = new DataGridViewTextBoxColumn();
            colSoTranThang = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachPhong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaxXepHang).BeginInit();
            SuspendLayout();
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.BackColor = Color.Tomato;
            btnCreateRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnCreateRoom.ForeColor = Color.Navy;
            btnCreateRoom.Image = (Image)resources.GetObject("btnCreateRoom.Image");
            btnCreateRoom.ImageAlign = ContentAlignment.TopCenter;
            btnCreateRoom.Location = new Point(166, 120);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(146, 110);
            btnCreateRoom.TabIndex = 1;
            btnCreateRoom.Text = "Tạo phòng";
            btnCreateRoom.TextAlign = ContentAlignment.BottomCenter;
            btnCreateRoom.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCreateRoom.UseVisualStyleBackColor = false;
            btnCreateRoom.Click += btnCreateRoom_Click;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.BackColor = Color.MediumTurquoise;
            btnJoinRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnJoinRoom.ForeColor = Color.Navy;
            btnJoinRoom.Image = (Image)resources.GetObject("btnJoinRoom.Image");
            btnJoinRoom.ImageAlign = ContentAlignment.TopCenter;
            btnJoinRoom.Location = new Point(424, 120);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(146, 110);
            btnJoinRoom.TabIndex = 2;
            btnJoinRoom.Text = "Vào phòng";
            btnJoinRoom.TextAlign = ContentAlignment.BottomCenter;
            btnJoinRoom.TextImageRelation = TextImageRelation.ImageAboveText;
            btnJoinRoom.UseVisualStyleBackColor = false;
            btnJoinRoom.Click += btnJoinRoom_Click;
            // 
            // btnQuickJoin
            // 
            btnQuickJoin.BackColor = Color.Gold;
            btnQuickJoin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnQuickJoin.ForeColor = Color.Navy;
            btnQuickJoin.Image = (Image)resources.GetObject("btnQuickJoin.Image");
            btnQuickJoin.ImageAlign = ContentAlignment.TopCenter;
            btnQuickJoin.Location = new Point(689, 120);
            btnQuickJoin.Name = "btnQuickJoin";
            btnQuickJoin.Size = new Size(146, 110);
            btnQuickJoin.TabIndex = 5;
            btnQuickJoin.Text = "Vào nhanh";
            btnQuickJoin.TextAlign = ContentAlignment.BottomCenter;
            btnQuickJoin.TextImageRelation = TextImageRelation.ImageAboveText;
            btnQuickJoin.UseVisualStyleBackColor = false;
            btnQuickJoin.Click += btnQuickJoin_Click;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDanhSachPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDanhSachPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachPhong.Columns.AddRange(new DataGridViewColumn[] { colPhong, colChuPhong, colNguoiChoi, colTrangThai });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightCyan;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDanhSachPhong.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDanhSachPhong.EnableHeadersVisualStyles = false;
            dgvDanhSachPhong.GridColor = Color.Gainsboro;
            dgvDanhSachPhong.Location = new Point(254, 275);
            dgvDanhSachPhong.Name = "dgvDanhSachPhong";
            dgvDanhSachPhong.RowHeadersVisible = false;
            dgvDanhSachPhong.RowHeadersWidth = 51;
            dgvDanhSachPhong.Size = new Size(498, 188);
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
            // btnRefresh
            // 
            btnRefresh.Location = new Point(758, 275);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblBaxXepHang
            // 
            lblBaxXepHang.AutoSize = true;
            lblBaxXepHang.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblBaxXepHang.ForeColor = Color.Navy;
            lblBaxXepHang.Location = new Point(960, 120);
            lblBaxXepHang.Name = "lblBaxXepHang";
            lblBaxXepHang.Size = new Size(348, 38);
            lblBaxXepHang.TabIndex = 10;
            lblBaxXepHang.Text = "BẢNG XẾP HẠNG KỶ LỤC";
            // 
            // dgvBaxXepHang
            // 
            dgvBaxXepHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaxXepHang.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            dataGridViewCellStyle3.ForeColor = Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvBaxXepHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvBaxXepHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaxXepHang.Columns.AddRange(new DataGridViewColumn[] { colHang, colTenNguoiChoi, colSoTranThang });
            dgvBaxXepHang.EnableHeadersVisualStyles = false;
            dgvBaxXepHang.Location = new Point(886, 177);
            dgvBaxXepHang.Name = "dgvBaxXepHang";
            dgvBaxXepHang.RowHeadersVisible = false;
            dgvBaxXepHang.RowHeadersWidth = 51;
            dgvBaxXepHang.Size = new Size(444, 300);
            dgvBaxXepHang.TabIndex = 11;
            dgvBaxXepHang.CellContentClick += dgvBaxXepHang_CellContentClick;
            // 
            // colHang
            // 
            colHang.FillWeight = 96.25668F;
            colHang.HeaderText = "Hạng";
            colHang.MinimumWidth = 6;
            colHang.Name = "colHang";
            // 
            // colTenNguoiChoi
            // 
            colTenNguoiChoi.FillWeight = 101.871658F;
            colTenNguoiChoi.HeaderText = "Tên Người Chơi";
            colTenNguoiChoi.MinimumWidth = 6;
            colTenNguoiChoi.Name = "colTenNguoiChoi";
            // 
            // colSoTranThang
            // 
            colSoTranThang.FillWeight = 101.871658F;
            colSoTranThang.HeaderText = "Số Trận Thắng";
            colSoTranThang.MinimumWidth = 6;
            colSoTranThang.Name = "colSoTranThang";
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(1366, 527);
            Controls.Add(dgvBaxXepHang);
            Controls.Add(lblBaxXepHang);
            Controls.Add(btnRefresh);
            Controls.Add(dgvDanhSachPhong);
            Controls.Add(label3);
            Controls.Add(btnQuickJoin);
            Controls.Add(btnJoinRoom);
            Controls.Add(btnCreateRoom);
            Name = "LobbyForm";
            Text = "LobbyForm";
            Load += LobbyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachPhong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaxXepHang).EndInit();
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
        private Button btnRefresh;
        private Label lblBaxXepHang;
        private DataGridView dgvBaxXepHang;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colTenNguoiChoi;
        private DataGridViewTextBoxColumn colSoTranThang;
    }
}