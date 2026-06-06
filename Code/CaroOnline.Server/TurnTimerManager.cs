using System;
using System.Threading;
using System.Threading.Tasks;

namespace CaroOnline.Server
{
    public class TurnTimerManager
    {
        private CancellationTokenSource? _cts;
        private const int TurnTimeoutSeconds = 15; // 15 giây đếm ngược theo kế hoạch

        public void StartNewTurn(string playerName)
        {
            _cts?.Cancel(); // Hủy lượt cũ trước đó nếu có
            _cts = new CancellationTokenSource();

            Console.WriteLine($"[SERVER] Bắt đầu lượt của: {playerName}");

            // Tạo luồng chạy ngầm để đếm ngược từng giây
            Task.Run(async () =>
            {
                try
                {
                    for (int i = TurnTimeoutSeconds; i > 0; i--)
                    {
                        _cts.Token.ThrowIfCancellationRequested();

                        // In ra số giây còn lại (khớp với TIMER_TICK nhóm đã định nghĩa)
                        Console.WriteLine($"[TIMER_TICK] {playerName} còn lại: {i} giây.");

                        await Task.Delay(1000, _cts.Token); // Chờ đúng 1 giây
                    }

                    // Nếu chạy hết 15 giây mà không bị bấm nút hủy -> Hết giờ!
                    HandleTimeout(playerName);
                }
                catch (TaskCanceledException)
                {
                    // Lọt vào đây nghĩa là người chơi đã đánh cờ kịp thời
                    Console.WriteLine($"[SERVER] {playerName} đã đánh cờ. Đã dừng đồng hồ đếm ngược.");
                }
            });
        }

        private void HandleTimeout(string playerName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[GAME_OVER] {playerName} đã HẾT GIỜ! Bị xử thua lượt này.");
            Console.ResetColor();
        }

        public void PlayerMoved()
        {
            _cts?.Cancel(); // Hàm này được gọi khi nhận được nước cờ để dừng thời gian lại
        }
    }
}