using System;
using System.Windows.Forms;
using CaroOnline.Shared;

namespace CaroOnline.Client
{
    public partial class LoginForm : Form
    {
        private ClientConnection _connection = new ClientConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        // TỰ ĐỘNG KẾT NỐI KHI FORM VỪA MỞ LÊN
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                _connection.Connect("127.0.0.1", 9999);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến Server! Vui lòng bật Server lên trước.\n" + ex.Message,
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // XỬ LÝ SỰ KIỆN KHI BẤM NÚT ĐĂNG NHẬP
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            string password = "";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản người chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_connection.IsConnected)
            {
                MessageBox.Show("Chưa kết nối được với Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var response = _connection.Login(username, password);

                if (response.Type == MessageType.LOGIN_OK)
                {
                    this.Hide();

                    // MỞ SẢNH CHỜ VÀ BÀN GIAO "CỤC MẠNG" CHO LOBBYFORM
                    LobbyForm lobby = new LobbyForm(_connection, username);
                    lobby.ShowDialog();

                    this.Close();
                }
                else
                {
                    // Hiển thị lý do lỗi chi tiết từ Server trả về (Ví dụ: Sai mật khẩu)
                    MessageBox.Show(response.Message2 ?? "Đăng nhập thất bại từ phía Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truyền tải mạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}