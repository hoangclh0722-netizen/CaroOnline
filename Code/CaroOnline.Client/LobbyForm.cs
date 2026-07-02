using System;
using System.Windows.Forms;
using CaroOnline.Shared; 

namespace CaroOnline.Client
{
    public partial class LobbyForm : Form
    {
        private ClientConnection _connection;
        private string _username;

        public LobbyForm(ClientConnection connection, string username)
        {
            InitializeComponent();

            this._connection = connection;
            this._username = username;
        }

        private void LobbyForm_Load(object sender, EventArgs e)
        {
            dgvDanhSachPhong.Rows.Clear();
            dgvDanhSachPhong.Rows.Add("Phòng 01", _username, "1/2", "🟢 Đang chờ");
            dgvDanhSachPhong.Rows.Add("Phòng 02", "Nguyễn Văn A", "2/2", "🔴 Đang chơi");
            dgvDanhSachPhong.Rows.Add("Phòng 03", "CaroBot", "1/2", "Đang chờ");
        }
    }
}