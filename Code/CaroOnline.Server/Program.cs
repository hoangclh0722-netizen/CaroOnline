using CaroOnline.Server;
using System;
using System.Threading.Tasks;

Console.WriteLine("=== CHAY THU HE THONG DEM NGUOC ===");
TurnTimerManager timer = new TurnTimerManager();

// Tình huống 1: Khang tới lượt nhưng quên không đánh cờ
timer.StartNewTurn("Thanh Khang");
await Task.Delay(16000); // Đợi 16 giây để xem hệ thống báo hết giờ

Console.WriteLine("\n-----------------------------------\n");

// Tình huống 2: Hoàng đánh rất nhanh ở giây thứ 3
timer.StartNewTurn("Huy Hoang");
await Task.Delay(3000); // Mới qua 3 giây
timer.PlayerMoved();    // Giả lập hành động Hoàng click đánh cờ

await Task.Delay(5000); // Đợi thêm một chút để xem có bị lỗi chạy bậy không
Console.WriteLine("=== KET THUC TEST ===");
Console.WriteLine("\n=== KICH HOAT SERVER GOC CUA HOANG ===");

// Đây là code gốc ban đầu của Hoàng để khởi động Server chạy thật
Server server = new Server(9999);
server.Start();