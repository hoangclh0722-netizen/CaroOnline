using System;
using System.Windows.Forms;
using CaroOnline.Shared; // Nạp thư viện chứa MessageType của nhóm

namespace CaroOnline.Client
{
    public partial class LoginForm : Form
    {
        // STEP 11: Gọi duy nhất class kết nối mạng do Hoàng viết
        private ClientConnection _connection = new ClientConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        // --- STEP 11: TỰ ĐỘNG KẾT NỐI KHI FORM VỪA MỞ LÊN ---
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Kết nối tới IP và Port của Server
                _connection.Connect("127.0.0.1", 9999);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến Server! Vui lòng bật Server lên trước.\n" + ex.Message,
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- STEP 12: XỬ LÝ SỰ KIỆN KHI BẤM NÚT ĐĂNG NHẬP ---
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy tên người chơi từ ô TextBox của bạn (bạn nhớ sửa lại đúng tên Name ô TextBox của bạn nhé)
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên người chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_connection.IsConnected)
            {
                MessageBox.Show("Chưa kết nối được với Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Gọi hàm Login có sẵn của Hoàng để gửi gói tin chuẩn qua Server
                var response = _connection.Login(username);

                // Nếu Server phản hồi kết quả hợp lệ
                if (response.Type == MessageType.LOGIN)
                {
                    this.Hide(); // Ẩn màn hình đăng nhập

                    // MỞ SẢNH CHỜ VÀ BÀN GIAO "CỤC MẠNG" CHO LOBBYFORM
                    LobbyForm lobby = new LobbyForm(_connection, username);
                    lobby.ShowDialog();

                    this.Close(); // Đóng hẳn khi thoát sảnh
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại từ phía Server!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truyền tải mạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên người chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_connection.IsConnected)
            {
                MessageBox.Show("Chưa kết nối được với Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Gọi hàm Login có sẵn của Hoàng để gửi gói tin chuẩn qua Server
                var response = _connection.Login(username);

                // Nếu Server phản hồi kết quả hợp lệ
                if (response.Type == MessageType.LOGIN)
                {
                    this.Hide(); // Ẩn màn hình đăng nhập

                    // MỞ SẢNH CHỜ VÀ BÀN GIAO "CỤC MẠNG" CHO LOBBYFORM
                    LobbyForm lobby = new LobbyForm(_connection, username);
                    lobby.ShowDialog();

                    this.Close(); // Đóng hẳn khi thoát sảnh
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại từ phía Server!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truyền tải mạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}