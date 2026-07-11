using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

namespace CaroOnline.Client
{
    public partial class GameForm : Form
    {
        private readonly BoardUI _boardUI;
        private ClientConnection? _connection;
        private string _roomId = "";
        private string _mySymbol = "";
        private bool _isMyTurn;
        private bool _closingFromDisconnect;
        private System.Windows.Forms.Timer? _returnToLobbyTimer;

        public GameForm()
        {
            InitializeComponent();

            _boardUI = new BoardUI(panelBoard);
            _boardUI.SetInputEnabled(false);

        }

        public GameForm(ClientConnection connection, string roomId, string mySymbol, string playerName) : this()
        {
            _connection = connection;
            _roomId = roomId;
            _mySymbol = mySymbol;

            roomLabel.Text = "Phong: " + _roomId;
            symbolLabel.Text = "Quan: " + _mySymbol;

            _boardUI.CellClicked += BoardUI_CellClicked;
            _connection.MessageReceived += Connection_MessageReceived;
            _connection.ConnectionError += Connection_ConnectionError;
            _connection.Disconnected += Connection_Disconnected;

            SetMyTurn(_mySymbol == "X");

            lblMyName.Text = playerName;
            lblMyBestRecord.Text = $"(Kỷ lục: {_myBestRecord})";
            lblEnemyBestRecord.Text = "(Kỷ lục: 0)";
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_connection != null)
            {
                _boardUI.CellClicked -= BoardUI_CellClicked;
                _connection.MessageReceived -= Connection_MessageReceived;
                _connection.ConnectionError -= Connection_ConnectionError;
                _connection.Disconnected -= Connection_Disconnected;
                _returnToLobbyTimer?.Stop();
                _returnToLobbyTimer?.Dispose();

                if (!_closingFromDisconnect)
                {
                    TrySend(new SharedMessage { Type = MessageType.LEAVE_ROOM });
                }
            }

            base.OnFormClosed(e);
        }

        private void BoardUI_CellClicked(int row, int col)
        {
            if (!_isMyTurn)
            {
                return;
            }

            SetStatus("Dang gui nuoc di...");
            _boardUI.SetInputEnabled(false);

            TrySend(new SharedMessage
            {
                Type = MessageType.PLACE_STONE,
                Row = row,
                Col = col
            });
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

            BeginInvoke(() =>
            {
                _boardUI.SetInputEnabled(false);
                SetStatus("Mat ket noi server: " + ex.Message);
            });
        }

        private void Connection_Disconnected()
        {
            if (IsDisposed)
            {
                return;
            }

            BeginInvoke(() =>
            {
                _closingFromDisconnect = true;
                _boardUI.SetInputEnabled(false);
                SetStatus("Da mat ket noi server.");
            });
        }

        private void HandleServerMessage(SharedMessage message)
        {
            switch (message.Type)
            {
                case MessageType.GAME_START:
                    if (message.PlayerName != null)
                    {
                        lblEnemyName.Text = message.PlayerName;
                    }
                    break;

                case MessageType.STONE_PLACED:
                    HandleStonePlaced(message);
                    if (message.PlayerName != null && message.PlayerName != lblMyName.Text)
                    {
                        lblEnemyName.Text = message.PlayerName;
                    }
                    break;

                case MessageType.TIMER_TICK:
                    timerLabel.Text = "Thoi gian: " + message.SecondsLeft + "s";
                    break;

                case MessageType.GAME_OVER:
                    _boardUI.SetInputEnabled(false);
                    SetStatus("Ket thuc. Nguoi thang: " + (message.Winner ?? "-"));
                    if (message.Winner == _mySymbol) 
                    {
                        _myCurrentStreak++; 
                        if (_myCurrentStreak > _myBestRecord)
                        {
                            _myBestRecord = _myCurrentStreak; 
                        }
                        ReturnToLobbyAfterResult($"Bạn đã thắng! Chuỗi thắng hiện tại: {_myCurrentStreak}");
                    }
                    else if (message.Winner == "DRAW") 
                    {
                        ReturnToLobbyAfterResult("Trận đấu hòa.");
                    }
                    else 
                    {
                        _myCurrentStreak = 0; 
                        ReturnToLobbyAfterResult("Bạn đã thua. Chuỗi thắng bị ngắt.");
                    }

                    lblMyBestRecord.Text = $"(Kỷ lục: {_myBestRecord})";
                    break;

                case MessageType.OPPONENT_LEFT:
                    _boardUI.SetInputEnabled(false);
                    SetStatus(message.Message2 ?? "Doi thu da roi phong.");
                    break;

                case MessageType.ERROR:
                    SetStatus(message.Message2 ?? "Server bao loi.");
                    _boardUI.SetInputEnabled(_isMyTurn);
                    break;
            }
        }

        private void HandleStonePlaced(SharedMessage message)
        {
            string placedSymbol = message.Symbol ?? "";
            _boardUI.PlaceStone(message.Row, message.Col, placedSymbol);

            bool nextTurnIsMine = placedSymbol != _mySymbol;
            SetMyTurn(nextTurnIsMine);
        }

        private void SetMyTurn(bool isMyTurn)
        {
            _isMyTurn = isMyTurn;
            _boardUI.SetInputEnabled(isMyTurn);
            SetStatus(isMyTurn ? "Den luot ban." : "Dang cho doi thu...");
        }

        private void SetStatus(string text)
        {
            turnLabel.Text = text;
        }

        private void ReturnToLobbyAfterResult(string resultMessage)
        {
            SetStatus(resultMessage + " Dang quay ve sanh...");

            _returnToLobbyTimer?.Stop();
            _returnToLobbyTimer?.Dispose();

            _returnToLobbyTimer = new System.Windows.Forms.Timer
            {
                Interval = 1500
            };
            _returnToLobbyTimer.Tick += (_, _) =>
            {
                _returnToLobbyTimer?.Stop();
                Close();
            };
            _returnToLobbyTimer.Start();
        }

        private void TrySend(SharedMessage message)
        {
            try
            {
                _connection?.Send(message);
            }
            catch (Exception ex)
            {
                SetStatus("Khong gui duoc toi server: " + ex.Message);
                _boardUI.SetInputEnabled(_isMyTurn);
            }
            //_boardUI = new BoardUI(panel1);
        }
        private static int _myBestRecord = 0;
        private static int _myCurrentStreak = 0;
    }
}
