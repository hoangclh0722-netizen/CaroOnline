using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

namespace CaroOnline.Client
{
    public partial class Form1 : Form
    {
        private readonly ClientConnection _connection = new();
        private TextBox _hostTextBox = null!;
        private NumericUpDown _portInput = null!;
        private TextBox _nameTextBox = null!;
        private Button _loginButton = null!;
        private Label _statusLabel = null!;

        public Form1()
        {
            InitializeComponent();
            BuildLoginView();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _connection.Dispose();
            base.OnFormClosed(e);
        }

        private void BuildLoginView()
        {
            Text = "Caro Online - Login";
            ClientSize = new Size(380, 250);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            var titleLabel = new Label
            {
                Text = "Caro Online",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 18, FontStyle.Bold),
                Location = new Point(24, 20)
            };

            var hostLabel = new Label
            {
                Text = "Server",
                AutoSize = true,
                Location = new Point(28, 72)
            };

            _hostTextBox = new TextBox
            {
                Text = "127.0.0.1",
                Location = new Point(110, 68),
                Size = new Size(160, 27)
            };

            _portInput = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 65535,
                Value = 9999,
                Location = new Point(280, 68),
                Size = new Size(70, 27)
            };

            var nameLabel = new Label
            {
                Text = "Ten choi",
                AutoSize = true,
                Location = new Point(28, 112)
            };

            _nameTextBox = new TextBox
            {
                Location = new Point(110, 108),
                Size = new Size(240, 27)
            };

            _loginButton = new Button
            {
                Text = "Dang nhap",
                Location = new Point(110, 150),
                Size = new Size(120, 34)
            };
            _loginButton.Click += LoginButton_Click;

            _statusLabel = new Label
            {
                Text = "Chua ket noi",
                AutoSize = false,
                Location = new Point(28, 200),
                Size = new Size(322, 32)
            };

            Controls.AddRange(new Control[]
            {
                titleLabel,
                hostLabel,
                _hostTextBox,
                _portInput,
                nameLabel,
                _nameTextBox,
                _loginButton,
                _statusLabel
            });
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
                    SetStatus($"Dang nhap thanh cong. PlayerId: {response.PlayerId}");
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
    }
}
