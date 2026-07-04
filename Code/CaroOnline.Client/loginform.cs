using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

namespace CaroOnline.Client
{
    public partial class Form1 : Form
    {
        private readonly ClientConnection _connection = new();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _connection.Dispose();
            base.OnFormClosed(e);
        }

        private async void LoginButton_Click(object? sender, EventArgs e)
        {
            string host = _hostTextBox.Text.Trim();
            string playerName = txtUsername.Text.Trim();
            int port = 9999;

            if (string.IsNullOrWhiteSpace(host))
            {
                SetStatus("Vui long nhap dia chi server.");
                return;
            }

            if (string.IsNullOrWhiteSpace(playerName))
            {
                SetStatus("Vui long nhap ten choi.");
                return;
            }

            _loginButton.Enabled = false;
            SetStatus("Dang ket noi...");

            try
            {
                SharedMessage response = await Task.Run(() =>
                {
                    _connection.Connect(host, port);
                    return _connection.Login(playerName);
                });

                if (response.Type == MessageType.LOGIN_OK)
                {
                    _connection.StartListening();
                    string loggedInPlayerId = response.PlayerId ?? "";
                    string loggedInPlayerName = response.PlayerName ?? playerName;

                    _connection.Send(new SharedMessage { Type = MessageType.GET_LEADERBOARD });

                    LobbyForm lobbyForm = new LobbyForm(_connection, loggedInPlayerId, loggedInPlayerName);
                    lobbyForm.FormClosed += (_, _) => Close();
                    lobbyForm.Show();

                    this.Hide();

                    return;
                }

                SetStatus(response.Message2 ?? "Server tra ve phan hoi khong hop le.");
                _connection.Disconnect();
            }
            catch (Exception ex)
            {
                SetStatus("Khong ket noi duoc server: " + ex.Message);
                _connection.Disconnect();
            }
            finally
            {
                _loginButton.Enabled = true;
            }
        }

        private void SetStatus(string text)
        {
            _statusLabel.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _connection.MessageReceived += (message) =>
            {
                // Kiểm tra xem có đúng là gói tin Bảng Xếp Hạng không
                if (message.Type == MessageType.RESPONSE_LEADERBOARD)
                {
                    if (this.IsHandleCreated)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            dgvLeaderboard.Rows.Clear(); // Xóa trắng dòng cũ

                            if (message.HistoryList != null)
                            {
                                foreach (var item in message.HistoryList)
                                {
                                    string[] parts = item.Split('|');
                                    if (parts.Length == 3)
                                    {
                                        dgvLeaderboard.Rows.Add(parts[0], parts[1], parts[2]);
                                    }
                                }
                            }
                        });
                    }
                }
            };
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
