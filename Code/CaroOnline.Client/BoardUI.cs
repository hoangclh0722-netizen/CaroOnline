namespace CaroOnline.Client
{
    internal class BoardUI
    {
        private readonly Panel _panel;
        private readonly Button[,] _buttons;
        private bool _acceptInput;

        private const int CellSize = 35;

        public event Action<int, int>? CellClicked;

        public BoardUI(Panel panel)
        {
            _panel = panel;
            _buttons = new Button[Board.Rows, Board.Cols];

            CreateBoard();
        }

        public void SetInputEnabled(bool enabled)
        {
            _acceptInput = enabled;
        }

        public void PlaceStone(int row, int col, string symbol)
        {
            if (row < 0 || row >= Board.Rows || col < 0 || col >= Board.Cols)
            {
                return;
            }

            Button button = _buttons[row, col];
            button.Text = symbol;
            button.Enabled = false;
        }

        public void Reset()
        {
            foreach (Button button in _buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }

            _acceptInput = false;
        }

        private void CreateBoard()
        {
            _panel.Controls.Clear();

            for (int row = 0; row < Board.Rows; row++)
            {
                for (int col = 0; col < Board.Cols; col++)
                {
                    Button button = new()
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Left = col * CellSize,
                        Top = row * CellSize,
                        Tag = new Point(row, col),
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        FlatStyle = FlatStyle.Standard
                    };

                    button.Click += Button_Click;

                    _buttons[row, col] = button;
                    _panel.Controls.Add(button);
                }
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (!_acceptInput)
            {
                return;
            }

            Button button = (Button)sender!;
            Point p = (Point)button.Tag!;

            CellClicked?.Invoke(p.X, p.Y);
        }
    }
}
