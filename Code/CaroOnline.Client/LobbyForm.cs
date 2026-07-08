using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

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
            _connection.MessageReceived += OnMessageReceived;
            _connection.StartListening();

            YeuCauLayDanhSachPhong();
        }

        private void OnMessageReceived(SharedMessage msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnMessageReceived(msg)));
                return;
            }

            switch (msg.Type)
            {
                case MessageType.ROOM_LIST:
                    CapNhatBangDanhSachPhong(msg.Rooms);
                    break;

                // Khi Server báo phòng đã được tạo (ROOM_CREATED) hoặc đã vào phòng thành công (ROOM_JOINED)
                case MessageType.ROOM_CREATED:
                    MessageBox.Show("Tạo phòng thành công! Đang chờ đối thủ vào...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageType.GAME_START:
                    MoManHinhBanCo(msg.Symbol);
                    break;
                case MessageType.ROOM_JOINED:
                    Console.WriteLine("Đã vào phòng thành công, chờ lệnh bắt đầu trận đấu...");
                    break;

                case MessageType.ERROR:
                    MessageBox.Show(msg.Message2 ?? "Có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            if (msg.Type == MessageType.ROOM_LIST)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (msg.Rooms != null)
                    {
                        foreach (var room in msg.Rooms)
                        {
                            string status = room.IsFull ? "Đang chơi" : "Đang chờ";
                        }
                    }
                });
            }
        }

        private void CapNhatBangDanhSachPhong(List<RoomInfo> rooms)
        {
            dgvDanhSachPhong.Rows.Clear();

            if (rooms == null) return;

            foreach (var r in rooms)
            {
                string slot = r.IsFull ? "2/2" : "1/2";
                string status = r.IsFull ? "🔴 Đang chơi" : "🟢 Đang chờ";

                dgvDanhSachPhong.Rows.Add(r.RoomId, r.HostName, slot, status);
            }
        }

        private void YeuCauLayDanhSachPhong()
        {
            _connection.Send(new SharedMessage { Type = MessageType.GET_ROOM_LIST });
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            _connection.Send(new SharedMessage { Type = MessageType.CREATE_ROOM });
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachPhong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng trong danh sách để vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string roomId = dgvDanhSachPhong.CurrentRow.Cells[0].Value?.ToString();

            if (!string.IsNullOrEmpty(roomId))
            {
                _connection.Send(new SharedMessage
                {
                    Type = MessageType.JOIN_ROOM,
                    RoomId = roomId
                });
            }
        }

        private void btnQuickJoin_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachPhong.Rows)
            {
                if (row.Cells[3].Value?.ToString() == "🟢 Đang chờ")
                {
                    string roomId = row.Cells[0].Value?.ToString();
                    _connection.Send(new SharedMessage { Type = MessageType.JOIN_ROOM, RoomId = roomId });
                    return;
                }
            }

            MessageBox.Show("Hiện tại không có phòng nào trống, bạn hãy tự Tạo phòng mới nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MoManHinhBanCo(string symbol)
        {
            _connection.MessageReceived -= OnMessageReceived;
            _connection.StopListening();

            this.Hide();
            GameForm game = new GameForm(_connection, _username, symbol);
            game.ShowDialog();

            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var refreshMsg = new CaroOnline.Shared.Message
            {
                Type = MessageType.GET_ROOM_LIST
            };
            _connection.Send(refreshMsg);
        }

        private void dgvBaxXepHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}