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
            titleLabel = new Label();
            hostLabel = new Label();
            _hostTextBox = new TextBox();
            _portInput = new NumericUpDown();
            nameLabel = new Label();
            _nameTextBox = new TextBox();
            _loginButton = new Button();
            _statusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)_portInput).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(24, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(159, 41);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Caro Online";
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(28, 72);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(50, 20);
            hostLabel.TabIndex = 1;
            hostLabel.Text = "Server";
            // 
            // _hostTextBox
            // 
            _hostTextBox.Location = new Point(110, 68);
            _hostTextBox.Name = "_hostTextBox";
            _hostTextBox.Size = new Size(160, 27);
            _hostTextBox.TabIndex = 2;
            _hostTextBox.Text = "127.0.0.1";
            // 
            // _portInput
            // 
            _portInput.Location = new Point(280, 68);
            _portInput.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            _portInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _portInput.Name = "_portInput";
            _portInput.Size = new Size(70, 27);
            _portInput.TabIndex = 3;
            _portInput.Value = new decimal(new int[] { 9999, 0, 0, 0 });
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(28, 112);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(62, 20);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Ten choi";
            // 
            // _nameTextBox
            // 
            _nameTextBox.Location = new Point(110, 108);
            _nameTextBox.Name = "_nameTextBox";
            _nameTextBox.Size = new Size(240, 27);
            _nameTextBox.TabIndex = 5;
            // 
            // _loginButton
            // 
            _loginButton.Location = new Point(110, 150);
            _loginButton.Name = "_loginButton";
            _loginButton.Size = new Size(120, 34);
            _loginButton.TabIndex = 6;
            _loginButton.Text = "Dang nhap";
            _loginButton.UseVisualStyleBackColor = true;
            _loginButton.Click += LoginButton_Click;
            // 
            // _statusLabel
            // 
            _statusLabel.Location = new Point(28, 200);
            _statusLabel.Name = "_statusLabel";
            _statusLabel.Size = new Size(322, 32);
            _statusLabel.TabIndex = 7;
            _statusLabel.Text = "Chua ket noi";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 250);
            Controls.Add(_statusLabel);
            Controls.Add(_loginButton);
            Controls.Add(_nameTextBox);
            Controls.Add(nameLabel);
            Controls.Add(_portInput);
            Controls.Add(_hostTextBox);
            Controls.Add(hostLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro Online - Login";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)_portInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label hostLabel;
        private TextBox _hostTextBox;
        private NumericUpDown _portInput;
        private Label nameLabel;
        private TextBox _nameTextBox;
        private Button _loginButton;
        private Label _statusLabel;
    }
}
