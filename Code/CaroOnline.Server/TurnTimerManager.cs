using System;
using System.Threading;
using System.Threading.Tasks;

namespace CaroOnline.Server
{
    public class TurnTimerManager
    {
        private CancellationTokenSource? _cts;
        private readonly object _lock = new();
        private const int TurnTimeoutSeconds = 15; // 15 giây đếm ngược theo kế hoạch

        public void StartNewTurn(string playerName, string playerId, Action<int> onTick, Action<string> onTimeout)
        {
            CancellationTokenSource newCts = new();

            lock (_lock)
            {
                _cts?.Cancel(); // Hủy lượt cũ trước đó nếu có
                _cts?.Dispose(); // fix leak
                _cts = newCts;
            }
            
            Console.WriteLine($"[SERVER] Bắt đầu lượt của: {playerName}");

            // Tạo luồng chạy ngầm để đếm ngược từng giây
            Task.Run(async () =>
            {
                try
                {
                    for (int i = TurnTimeoutSeconds; i > 0; i--)
                    {
                        newCts.Token.ThrowIfCancellationRequested();

                        // Báo cho GameRoom số giây còn lại → gửi TIMER_TICK
                        onTick(i);

                        await Task.Delay(1000, newCts.Token); // Chờ đúng 1 giây
                    }

                    // Nếu chạy hết 15 giây mà không bị hủy -> Hết giờ!
                    newCts.Token.ThrowIfCancellationRequested();

                    // Báo cho GameRoom playerId đã hết giờ → gửi GAME_OVER
                    onTimeout(playerId);
                }
                catch (OperationCanceledException)
                {
                    // Lọt vào đây nghĩa là người chơi đã đánh cờ kịp thời
                    Console.WriteLine($"[SERVER] {playerName} đã đánh cờ. Đã dừng đồng hồ đếm ngược.");
                }
            });
        }
        public void PlayerMoved()
        {
            lock (_lock) { _cts?.Cancel(); } // Hàm này được gọi khi nhận được nước cờ để dừng thời gian lại
        }
        public void Dispose()
        {
            lock (_lock) { _cts?.Cancel(); _cts?.Dispose(); }
        }
    }
}