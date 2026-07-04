using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using CaroOnline.Shared;

namespace CaroOnline.Server
{
    public class Server
    {
        private readonly int port;
        private TcpListener? listener;

        private readonly RoomManager roomManager = new();
        private readonly ConcurrentDictionary<NetworkStream, (string PlayerId, string PlayerName)> sessions = new();

        public Server(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            DatabaseManager.Initialize();

            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            Console.WriteLine("Server started on port " + port);

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");

                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.IsBackground = true;
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            try
            {
                while (true)
                {
                    Message? message = MessageHelper.Receive(stream);

                    if (message == null)
                    {
                        Send(stream, new Message
                        {
                            Type = MessageType.ERROR,
                            Message2 = "Invalid message"
                        });

                        continue;
                    }

                    ProcessMessage(stream, message);
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("Client closed connection");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client error: " + ex.Message);
            }
            finally
            {
                // Xu ly disconnect: roi phong + xoa session
                if (sessions.TryRemove(stream, out var session))
                {
                    roomManager.UnregisgerClient(session.PlayerId);
                }

                client.Close();
                Console.WriteLine("Client disconnected");
            }
        }

        private void ProcessMessage(NetworkStream stream, Message message)
        {
            // LOGIN xu ly truoc, chua can session
            if (message.Type == MessageType.LOGIN)
            {
                if (string.IsNullOrWhiteSpace(message.PlayerName))
                {
                    Send(stream, new Message
                    {
                        Type = MessageType.ERROR,
                        Message2 = "Player name is required"
                    });
                    return;
                }

                string playerName = message.PlayerName.Trim();
                string playerId = Guid.NewGuid().ToString("N").Substring(0, 8);

                sessions[stream] = (playerId, playerName);
                roomManager.RegisgerClient(playerId, stream);

                int recordFromDB = DatabaseManager.GetBestRecord(playerName);

                Message response = new Message
                {
                    Type = MessageType.LOGIN_OK,
                    PlayerName = playerName,
                    PlayerId = playerId,
                    BestRecord = recordFromDB
                };

                Send(stream, response);

                Console.WriteLine("Login OK: " + playerName + " - " + playerId);
                return;
            }

            // Cac message khac can da login
            if (!sessions.TryGetValue(stream, out var sessionInfo))
            {
                Send(stream, new Message
                {
                    Type = MessageType.ERROR,
                    Message2 = "Ban chua dang nhap"
                });
                return;
            }

            string pid = sessionInfo.PlayerId;
            string pname = sessionInfo.PlayerName;

            switch (message.Type)
            {
                case MessageType.CREATE_ROOM:
                    roomManager.CreateRoom(pid, pname, stream);
                    break;

                case MessageType.JOIN_ROOM:
                    roomManager.JoinRoom(message.RoomId!, pid, pname, stream);
                    break;

                case MessageType.LEAVE_ROOM:
                    roomManager.LeaveRoom(pid);
                    break;

                case MessageType.PLACE_STONE:
                    roomManager.PlaceStone(pid, message.Row, message.Col);
                    break;

                case MessageType.GET_ROOM_LIST:
                    Send(stream, new Message
                    {
                        Type = MessageType.ROOM_LIST,
                        Rooms = roomManager.GetRoomList()
                    });
                    break;

                case MessageType.GET_HISTORY:
                    List<string> matchHistory = DatabaseManager.GetHistory(pname);

                    Send(stream, new Message
                    {
                        Type = MessageType.GET_HISTORY,
                        HistoryList = matchHistory
                    });
                    break;

                case MessageType.GET_LEADERBOARD:
                    List<string> topPlayers = DatabaseManager.GetLeaderboard();

                    Send(stream, new CaroOnline.Shared.Message
                    {
                        Type = MessageType.RESPONSE_LEADERBOARD,
                        HistoryList = topPlayers // Hoặc gán vào thuộc tính danh sách nào tương tự trong class Message của ông
                    });
                    break;

                default:
                    Send(stream, new Message
                    {
                        Type = MessageType.ERROR,
                        Message2 = "Unknown message type"
                    });
                    break;
            }
        }

        private void Send(NetworkStream stream, Message message)
        {
            NetworkSender.Send(stream, message);
        }
    }
}
