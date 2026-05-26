using System.Collections.Generic;
namespace CaroOnline.Shared
{
    // Tất cả loại message có thể gửi/nhận
    public enum MessageType
    {
        // Client → Server
        LOGIN,          // đăng nhập, gửi tên người chơi
        CREATE_ROOM,    // tạo phòng mới
        JOIN_ROOM,      // vào phòng bằng ID
        LEAVE_ROOM,     // rời phòng
        PLACE_STONE,    // đặt quân tại (row, col)
        REMATCH,        // xin đánh lại

        // Server → Client
        LOGIN_OK,       // đăng nhập thành công, trả về PlayerId
        ROOM_CREATED,   // phòng được tạo, trả về RoomId
        ROOM_JOINED,    // vào phòng thành công
        ROOM_LIST,      // danh sách phòng đang chờ
        GAME_START,     // ván đấu bắt đầu, cho biết bạn là X hay O
        STONE_PLACED,   // server relay nước đi cho cả 2
        TIMER_TICK,     // đếm ngược còn bao nhiêu giây
        GAME_OVER,      // ván kết thúc — ai thắng
        OPPONENT_LEFT,  // đối thủ thoát
        ERROR,          // lỗi gì đó
    }

    // Cấu trúc 1 message — mọi tin nhắn đều dùng class này
    public class Message
    {
        public MessageType Type { get; set; }

        // Dùng cho: LOGIN
        public string? PlayerName { get; set; }

        // Dùng cho: LOGIN_OK
        public string? PlayerId { get; set; }

        // Dùng cho: CREATE_ROOM, JOIN_ROOM, ROOM_CREATED, ROOM_JOINED
        public string? RoomId { get; set; }

        // Dùng cho: PLACE_STONE, STONE_PLACED
        public int Row { get; set; }
        public int Col { get; set; }

        // Dùng cho: GAME_START — cho biết bạn đánh quân X hay O
        public string? Symbol { get; set; }  // "X" hoặc "O"

        // Dùng cho: TIMER_TICK
        public int SecondsLeft { get; set; }

        // Dùng cho: GAME_OVER
        public string? Winner { get; set; }  // "X", "O", hoặc "DRAW"

        // Dùng cho: ERROR, NOTIFY
        public string? Message2 { get; set; }

        // Dùng cho: ROOM_LIST
        public List<RoomInfo>? Rooms { get; set; }
    }

    // Thông tin 1 phòng — dùng trong danh sách phòng
    public class RoomInfo
    {
        public string? RoomId { get; set; }
        public string? HostName { get; set; }   // tên người tạo phòng
        public bool IsFull { get; set; }   // true = đã có 2 người
    }
}