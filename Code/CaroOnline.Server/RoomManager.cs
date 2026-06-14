using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using CaroOnline.Shared;
using static CaroOnline.Server.NetworkSender;

namespace CaroOnline.Server
{
	public class RoomManager
	{
		//Lưu tất cả các phòng đang có: RoomId -> GameRoom
		private readonly ConcurrentDictionary<string, GameRoom> rooms = new();

		//Lưu tất cả các Client đang kết nối: PlayerId -> NetworkStream
		private readonly ConcurrentDictionary<string, NetworkStream> allClients = new();

		//Đăng ký / Hủy client
		public void RegisgerClient(string playerId, NetworkStream stream)
		{
			allClients[playerId] = stream;
		}
		public void UnregisgerClient(string playerId)
		{
			allClients.TryRemove(playerId, out _);
			//Nếu player có trong phòng nào thì xử lý disconect
            foreach (var room in rooms.Values)
            {
                if (room.HasPlayer(playerId))
                {
                    HandlePlayerDisconnect(room, playerId);
                    break;
                }
            }
        }
		//Tạo phòng
		public void CreateRoom(string playerId, string playerName, NetworkStream stream)
        {
            //Kiểm tra Player đã có ở trong phòng khác không
            if (FindRoomByPlayer(playerId) != null)
            {
                Send(stream, new Message
                {
                    Type = MessageType.ERROR,
                    Message2 = "Bạn đang trong phòng rồi, hãy rời phòng trước."
                });
                return;
            }

            string roomId = GenerateRoomId();
            var room = new GameRoom(roomId, playerId, playerName, stream);
            rooms[roomId] = room;

            Send(stream, new Message
            {
                Type = MessageType.ROOM_CREATED,
                RoomId = roomId
            });

            Console.WriteLine($"[Room] {playerName} tạo phòng {roomId}");

            BroadcastRoomList();
        }
        // Vào phòng
        public void JoinRoom(string roomId, string playerId, string playerName, NetworkStream stream)
        {
            //Kiểm tra phòng có tồn tại không
            if (!rooms.TryGetValue(roomId, out GameRoom? room))
            {
                Send(stream, new Message
                {
                    Type = MessageType.ERROR,
                    Message2 = $"Phòng {roomId} không tồn tại."
                });
                return;
            }

            //Kiểm tra phòng xem đầy chưa
            if (room.IsFull)
			{

                Send(stream, new Message
                {
                    Type = MessageType.ERROR,
                    Message2 = $"Phòng {roomId} đã đầy."
                });
                return;
            }
			//Kiểm tra Player đã có ở trong phòng khác không
			if (FindRoomByPlayer(playerId) != null)
			{

                Send(stream, new Message
                {
                    Type = MessageType.ERROR,
                    Message2 = "Bạn đang trong phòng rồi, hãy rời phòng trước."
                });
                return;
            }

			room.AddGuest(playerId, playerName, stream);

            Send(stream, new Message
            {
                Type = MessageType.ROOM_JOINED,
                RoomId = roomId
            });

            Console.WriteLine($"[Room] {playerName} vào phòng {roomId}");

            BroadcastRoomList();
            //Dã đủ 2 người bắt đầu chơi
            room.StartGame();
        }
        //Rời phòng
        public void LeaveRoom(string playerId)
        {
            GameRoom? room = FindRoomByPlayer(playerId);
            if (room == null) return;

            HandlePlayerDisconnect(room, playerId);
        }
        //Xử lý Disconnect
        private void HandlePlayerDisconnect(GameRoom room, string playerId)
        {
            // Thông báo cho đối thủ
            room.NotifyOpponentLeft(playerId);

            // Xóa phòng
            rooms.TryRemove(room.RoomId, out _);
            Console.WriteLine($"[Room] Phòng {room.RoomId} bị xóa do player {playerId} rời.");

            BroadcastRoomList();
        }
        //Lấy danh sách phòng
        public List<RoomInfo> GetRoomList() 
        {
            var list = new List<RoomInfo>();
            foreach (var room in rooms.Values)
            {
                list.Add(new RoomInfo
                {
                    RoomId = room.RoomId,
                    HostName = room.HostName,
                    IsFull = room.IsFull
                });
            }
            return list;
        }
        //Gửi danh sách phòng cho tất cả các Client
        public void BroadcastRoomList()
        {
            var message = new Message
            {
                Type = MessageType.ROOM_LIST,
                Rooms = GetRoomList()
            };

            foreach (var stream in allClients.Values)
            {
                try { Send(stream, message); }
                catch { /* client đã disconnect, bỏ qua */ }
            }
        }
        public void PlaceStone(string playerId, int row, int col)
        {
            GameRoom? room = FindRoomByPlayer(playerId);
            if (room == null) return;

            room.PlaceStone(playerId, row, col);
        }
        private GameRoom? FindRoomByPlayer(string playerId)
        {
            foreach (var room in rooms.Values)
                if (room.HasPlayer(playerId)) return room;
            return null;
        }

        private static string GenerateRoomId()
        {
            return Guid.NewGuid().ToString("N")[..6].ToUpper(); // VD: "A9F5T6"
        }

    }
}
