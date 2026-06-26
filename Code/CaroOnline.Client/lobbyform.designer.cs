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
            titleLabel = new Label();
            playerNameLabel = new Label();
            playerNameValueLabel = new Label();
            playerIdLabel = new Label();
            playerIdValueLabel = new Label();
            roomsGrid = new DataGridView();
            roomIdColumn = new DataGridViewTextBoxColumn();
            hostNameColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            createRoomButton = new Button();
            refreshButton = new Button();
            joinRoomButton = new Button();
            statusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)roomsGrid).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(24, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(181, 41);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Phong cho";
            // 
            // playerNameLabel
            // 
            playerNameLabel.AutoSize = true;
            playerNameLabel.Location = new Point(28, 76);
            playerNameLabel.Name = "playerNameLabel";
            playerNameLabel.Size = new Size(75, 20);
            playerNameLabel.TabIndex = 1;
            playerNameLabel.Text = "Nguoi choi:";
            // 
            // playerNameValueLabel
            // 
            playerNameValueLabel.AutoSize = true;
            playerNameValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            playerNameValueLabel.Location = new Point(115, 76);
            playerNameValueLabel.Name = "playerNameValueLabel";
            playerNameValueLabel.Size = new Size(15, 20);
            playerNameValueLabel.TabIndex = 2;
            playerNameValueLabel.Text = "-";
            // 
            // playerIdLabel
            // 
            playerIdLabel.AutoSize = true;
            playerIdLabel.Location = new Point(28, 104);
            playerIdLabel.Name = "playerIdLabel";
            playerIdLabel.Size = new Size(68, 20);
            playerIdLabel.TabIndex = 3;
            playerIdLabel.Text = "Player ID:";
            // 
            // playerIdValueLabel
            // 
            playerIdValueLabel.AutoSize = true;
            playerIdValueLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            playerIdValueLabel.Location = new Point(115, 104);
            playerIdValueLabel.Name = "playerIdValueLabel";
            playerIdValueLabel.Size = new Size(15, 20);
            playerIdValueLabel.TabIndex = 4;
            playerIdValueLabel.Text = "-";
            // 
            // roomsGrid
            // 
            roomsGrid.AllowUserToAddRows = false;
            roomsGrid.AllowUserToDeleteRows = false;
            roomsGrid.AllowUserToResizeRows = false;
            roomsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roomsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            roomsGrid.BackgroundColor = SystemColors.Window;
            roomsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            roomsGrid.Columns.AddRange(new DataGridViewColumn[] { roomIdColumn, hostNameColumn, statusColumn });
            roomsGrid.Location = new Point(28, 144);
            roomsGrid.MultiSelect = false;
            roomsGrid.Name = "roomsGrid";
            roomsGrid.ReadOnly = true;
            roomsGrid.RowHeadersVisible = false;
            roomsGrid.RowHeadersWidth = 51;
            roomsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            roomsGrid.Size = new Size(594, 274);
            roomsGrid.TabIndex = 5;
            roomsGrid.CellDoubleClick += roomsGrid_CellDoubleClick;
            // 
            // roomIdColumn
            // 
            roomIdColumn.HeaderText = "Ma phong";
            roomIdColumn.MinimumWidth = 6;
            roomIdColumn.Name = "roomIdColumn";
            roomIdColumn.ReadOnly = true;
            // 
            // hostNameColumn
            // 
            hostNameColumn.HeaderText = "Chu phong";
            hostNameColumn.MinimumWidth = 6;
            hostNameColumn.Name = "hostNameColumn";
            hostNameColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            statusColumn.HeaderText = "Trang thai";
            statusColumn.MinimumWidth = 6;
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            // 
            // createRoomButton
            // 
            createRoomButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createRoomButton.Location = new Point(646, 144);
            createRoomButton.Name = "createRoomButton";
            createRoomButton.Size = new Size(126, 34);
            createRoomButton.TabIndex = 6;
            createRoomButton.Text = "Tao phong";
            createRoomButton.UseVisualStyleBackColor = true;
            createRoomButton.Click += createRoomButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshButton.Location = new Point(646, 190);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(126, 34);
            refreshButton.TabIndex = 7;
            refreshButton.Text = "Lam moi";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // joinRoomButton
            // 
            joinRoomButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            joinRoomButton.Location = new Point(646, 236);
            joinRoomButton.Name = "joinRoomButton";
            joinRoomButton.Size = new Size(126, 34);
            joinRoomButton.TabIndex = 8;
            joinRoomButton.Text = "Vao phong";
            joinRoomButton.UseVisualStyleBackColor = true;
            joinRoomButton.Click += joinRoomButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusLabel.Location = new Point(28, 434);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(744, 30);
            statusLabel.TabIndex = 9;
            statusLabel.Text = "San sang.";
            // 
            // LobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 483);
            Controls.Add(statusLabel);
            Controls.Add(joinRoomButton);
            Controls.Add(refreshButton);
            Controls.Add(createRoomButton);
            Controls.Add(roomsGrid);
            Controls.Add(playerIdValueLabel);
            Controls.Add(playerIdLabel);
            Controls.Add(playerNameValueLabel);
            Controls.Add(playerNameLabel);
            Controls.Add(titleLabel);
            MinimumSize = new Size(720, 430);
            Name = "LobbyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online - Lobby";
            ((System.ComponentModel.ISupportInitialize)roomsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label playerNameLabel;
        private Label playerNameValueLabel;
        private Label playerIdLabel;
        private Label playerIdValueLabel;
        private DataGridView roomsGrid;
        private DataGridViewTextBoxColumn roomIdColumn;
        private DataGridViewTextBoxColumn hostNameColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private Button createRoomButton;
        private Button refreshButton;
        private Button joinRoomButton;
        private Label statusLabel;
    }
}
