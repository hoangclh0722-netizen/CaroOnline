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
            dgvRooms.Rows.Add("Phòng 01", "Bảo An", "1/2", "Đang chờ");
            dgvRooms.Rows.Add("Phòng 02", "Công Bình", "1/2", "Đang chờ");
            dgvRooms.Rows.Add("Phòng 03", "Giản Lý", "1/2", "Đang chờ");
        }
    }
}