namespace CaroOnline.Client
{
    public class Board
    {
        public const int Rows = 17;
        public const int Cols = 20;

        private int[,] _cells;

        public Board()
        {
            _cells = new int[Rows, Cols];
        }

        // Lấy giá trị ô
        public int Get(int row, int col) => _cells[row, col];

        // Đặt quân, trả về false nếu ô đã có quân
        public bool Place(int row, int col, int player)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                return false;

            if (_cells[row, col] != 0)
                return false;

            _cells[row, col] = player;
            return true;
        }

        // Hoàn tác nước đi
        public void Undo(int row, int col)
        {
            _cells[row, col] = 0;
        }

        // Bàn cờ đầy chưa
        public bool IsFull()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (_cells[r, c] == 0)
                        return false;
                }
            }

            return true;
        }

        // Reset bàn cờ
        public void Reset()
        {
            _cells = new int[Rows, Cols];
        }
    }
}
