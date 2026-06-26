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
            string playerName = _nameTextBox.Text.Trim();
            int port = (int)_portInput.Value;

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

        }
    }
}
