namespace CaroOnline.Client
{
    partial class LoginForm
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
            label1 = new Label();
            txtUsername = new TextBox();
            btnLogin = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(150, 123);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(266, 120);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(145, 27);
            txtUsername.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(160, 163);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(241, 36);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(130, 71);
            label2.Name = "label2";
            label2.Size = new Size(312, 31);
            label2.TabIndex = 3;
            label2.Text = "CARO ONLINE - ĐĂNG NHẬP";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 327);
            Controls.Add(label2);
            Controls.Add(btnLogin);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsername;
        private Button btnLogin;
        private Label label2;
    }
}