namespace CaroOnline.Client
{
    public class Board
    {
        public const int Size = 15;
        private int[,] _cells; // 0 = trống, 1 = X (người chơi 1), 2 = O (người chơi 2)

        public Board()
        {
            _cells = new int[Size, Size];
        }

        // Lấy giá trị ô
        public int Get(int row, int col) => _cells[row, col];

        // Đặt quân, trả về false nếu ô đã có quân
        public bool Place(int row, int col, int player)
        {
            if (row < 0 || row >= Size || col < 0 || col >= Size) return false;
            if (_cells[row, col] != 0) return false;
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
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (_cells[r, c] == 0) return false;
            return true;
        }

        // Reset bàn cờ
        public void Reset()
        {
            _cells = new int[Size, Size];
        }
    }
}
