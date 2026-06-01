namespace CaroOnline.Client
{
    public class GameLogic
    {
        public Board Board { get; private set; }
        public int CurrentPlayer { get; private set; } // 1 hoặc 2
        public bool IsGameOver { get; private set; }
        public int Winner { get; private set; }        // 0 = chưa có, 1 hoặc 2 = thắng, -1 = hòa

        // Lưu lịch sử nước đi để Undo
        private Stack<(int row, int col)> _history = new();

        // Các ô thắng để highlight
        public List<(int row, int col)> WinningCells { get; private set; } = new();

        public GameLogic()
        {
            Board = new Board();
            CurrentPlayer = 1;
            IsGameOver = false;
            Winner = 0;
        }

        // Đặt quân — trả về true nếu hợp lệ
        public bool MakeMove(int row, int col)
        {
            if (IsGameOver) return false;
            if (!Board.Place(row, col, CurrentPlayer)) return false;

            _history.Push((row, col));

            var winning = CheckWin(row, col);
            if (winning != null)
            {
                WinningCells = winning;
                IsGameOver = true;
                Winner = CurrentPlayer;
                return true;
            }

            if (Board.IsFull())
            {
                IsGameOver = true;
                Winner = -1; // hòa
                return true;
            }

            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
            return true;
        }

        // Hoàn tác nước đi
        public bool Undo()
        {
            if (_history.Count == 0) return false;
            var (row, col) = _history.Pop();
            Board.Undo(row, col);
            IsGameOver = false;
            Winner = 0;
            WinningCells.Clear();
            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
            return true;
        }

        // Reset game
        public void Reset()
        {
            Board.Reset();
            CurrentPlayer = 1;
            IsGameOver = false;
            Winner = 0;
            WinningCells.Clear();
            _history.Clear();
        }

        // Kiểm tra thắng — trả về danh sách 5 ô thắng, null nếu chưa thắng
        private List<(int row, int col)>? CheckWin(int row, int col)
        {
            int player = Board.Get(row, col);
            int[][] directions = new int[][]
            {
                new[] { 0, 1 },   // ngang
                new[] { 1, 0 },   // dọc
                new[] { 1, 1 },   // chéo xuống phải
                new[] { 1, -1 },  // chéo xuống trái
            };

            foreach (var dir in directions)
            {
                var cells = new List<(int, int)> { (row, col) };

                // Đi 2 hướng
                foreach (int sign in new[] { 1, -1 })
                {
                    int r = row + dir[0] * sign;
                    int c = col + dir[1] * sign;
                    while (r >= 0 && r < Board.Size && c >= 0 && c < Board.Size
                           && Board.Get(r, c) == player)
                    {
                        cells.Add((r, c));
                        r += dir[0] * sign;
                        c += dir[1] * sign;
                    }
                }

                if (cells.Count >= 5)
                    return cells;
            }

            return null;
        }
    }
}
