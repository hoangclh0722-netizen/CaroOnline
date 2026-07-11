using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

namespace CaroOnline.Client
{
    public partial class LobbyForm : Form
    {
        private readonly ClientConnection _connection;
        private readonly string _playerId;
        private readonly string _playerName;
        private bool _gameOpened;

        public LobbyForm(ClientConnection connection, string playerId, string playerName)
        {
            _connection = connection;
            _playerId = playerId;
            _playerName = playerName;

            InitializeComponent();

            playerNameValueLabel.Text = _playerName;
            playerIdValueLabel.Text = _playerId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _connection.MessageReceived += Connection_MessageReceived;
            _connection.ConnectionError += Connection_ConnectionError;
            _connection.Disconnected += Connection_Disconnected;

            RequestRoomList();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DetachConnectionEvents();

            if (!_gameOpened)
            {
                _connection.Disconnect();
            }

            base.OnFormClosed(e);
        }

        private void createRoomButton_Click(object sender, EventArgs e)
        {
            SendToServer(new SharedMessage { Type = MessageType.CREATE_ROOM });
            SetStatus("Dang tao phong...");
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RequestRoomList();
        }

        private void joinRoomButton_Click(object sender, EventArgs e)
        {
            string? roomId = GetSelectedRoomId();
            if (string.IsNullOrWhiteSpace(roomId))
            {
                SetStatus("Hay chon mot phong truoc.");
                return;
            }

            SendToServer(new SharedMessage
            {
                Type = MessageType.JOIN_ROOM,
                RoomId = roomId
            });
            SetStatus("Dang vao phong " + roomId + "...");
        }

        private void roomsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                joinRoomButton.PerformClick();
            }
        }

        private void Connection_MessageReceived(SharedMessage message)
        {
            if (IsDisposed)
            {
                return;
            }

            BeginInvoke(() => HandleServerMessage(message));
        }

        private void Connection_ConnectionError(Exception ex)
        {
            if (IsDisposed)
            {
                return;
            }

            BeginInvoke(() => SetStatus("Mat ket noi server: " + ex.Message));
        }

        private void Connection_Disconnected()
        {
            if (IsDisposed)
            {
                return;
            }

            BeginInvoke(() => SetStatus("Da mat ket noi server."));
        }

        private void HandleServerMessage(SharedMessage message)
        {
            switch (message.Type)
            {
                case MessageType.ROOM_LIST:
                    ShowRooms(message.Rooms ?? new List<RoomInfo>());
                    SetStatus("Da cap nhat danh sach phong.");
                    break;

                case MessageType.ROOM_CREATED:
                    SetStatus("Da tao phong " + message.RoomId + ". Dang cho doi thu...");
                    RequestRoomList();
                    break;

                case MessageType.ROOM_JOINED:
                    SetStatus("Da vao phong " + message.RoomId + ".");
                    break;

                case MessageType.GAME_START:
                    OpenGame(message);
                    break;

                case MessageType.ERROR:
                    SetStatus(message.Message2 ?? "Server bao loi.");
                    break;

                case MessageType.GET_HISTORY:
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (message.HistoryList != null)
                        {
                            listBoxHistory.Items.Clear();

                            foreach (string match in message.HistoryList)
                            {
                                listBoxHistory.Items.Add(match);
                            }

                            MessageBox.Show("Đã cập nhật lịch sử đấu mới nhất!", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Bạn chưa tham gia trận đấu nào hoặc không có lịch sử!", "Thông báo");
                        }
                    });
                    break;
            }
        }

        private void ShowRooms(List<RoomInfo> rooms)
        {
            roomsGrid.Rows.Clear();

            foreach (RoomInfo room in rooms)
            {
                int rowIndex = roomsGrid.Rows.Add(
                    room.RoomId ?? "",
                    room.HostName ?? "",
                    room.IsFull ? "Day" : "Dang cho");

                roomsGrid.Rows[rowIndex].Tag = room.RoomId;
            }
        }

        private void RequestRoomList()
        {
            SendToServer(new SharedMessage { Type = MessageType.GET_ROOM_LIST });
            SetStatus("Dang tai danh sach phong...");
        }

        private void SendToServer(SharedMessage message)
        {
            try
            {
                _connection.Send(message);
            }
            catch (Exception ex)
            {
                SetStatus("Khong gui duoc toi server: " + ex.Message);
            }
        }

        private string? GetSelectedRoomId()
        {
            if (roomsGrid.SelectedRows.Count == 0)
            {
                return null;
            }

            return roomsGrid.SelectedRows[0].Tag as string;
        }

        private void OpenGame(SharedMessage message)
        {
            if (_gameOpened)
            {
                return;
            }

            _gameOpened = true;
            DetachConnectionEvents();

            GameForm gameForm = new GameForm(
                _connection,
                message.RoomId ?? "",
                message.Symbol ?? "",
                _playerName
             );

            gameForm.FormClosed += (_, _) => ReturnToLobby();
            gameForm.Show();

            Hide();
        }

        private void ReturnToLobby()
        {
            _gameOpened = false;

            DetachConnectionEvents();
            _connection.MessageReceived += Connection_MessageReceived;
            _connection.ConnectionError += Connection_ConnectionError;
            _connection.Disconnected += Connection_Disconnected;

            Show();
            RequestRoomList();
        }

        private void SetStatus(string text)
        {
            statusLabel.Text = text;
        }

        private void DetachConnectionEvents()
        {
            _connection.MessageReceived -= Connection_MessageReceived;
            _connection.ConnectionError -= Connection_ConnectionError;
            _connection.Disconnected -= Connection_Disconnected;
        }
        private void leaveRoomButton_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Send(new SharedMessage
                {
                    Type = MessageType.LEAVE_ROOM
                });

                leaveRoomButton.Enabled = false;
                createRoomButton.Enabled = true;
                joinRoomButton.Enabled = false;


                RequestRoomList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể rời phòng: " + ex.Message, "Lỗi");
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            _connection.Send(new CaroOnline.Shared.Message
            {
                Type = MessageType.GET_HISTORY
            });
        }
    }
}
