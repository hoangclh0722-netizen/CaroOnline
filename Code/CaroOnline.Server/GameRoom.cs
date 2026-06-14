using System;
using System.Net.Sockets;
using CaroOnline.Shared;
using static CaroOnline.Server.NetworkSender;

namespace CaroOnline.Server
{
    public class GameRoom
    {
        //Thong tin phong
        public string RoomId { get; }
        public string HostName { get; }
        public bool IsFull => guestId != null;

        //Host
        private readonly string hostId;
        private readonly NetworkStream hostStream;

        //Guest
        private string? guestId;
        private string? guestName;
        private NetworkStream? guestStream;
        private bool isGameOver;

        //Turn timer
        private readonly TurnTimerManager turnTimerManager = new();
        private string? currentTurnPlayerId;
        public GameRoom(string roomId, string hostId, string hostName, NetworkStream hostStream)
        {
            RoomId = roomId;
            HostName = hostName;
            this.hostId = hostId;
            this.hostStream = hostStream;
        }

        //Them guest vao phong
        public void AddGuest(string playerId, string playerName, NetworkStream stream)
        {
            guestId = playerId;
            guestName = playerName;
            guestStream = stream;
        }

        //Kiem tra player co trong phong khong
        public bool HasPlayer(string playerId)
        {
            return playerId == hostId || playerId == guestId;
        }

        //Bat dau game
        public void StartGame()
        {
            if (guestStream == null)
            {
                return;
            }

            //Host danh X, Guest danh O
            Send(hostStream, new Message
            {
                Type = MessageType.GAME_START,
                RoomId = RoomId,
                Symbol = "X"
            });

            Send(guestStream, new Message
            {
                Type = MessageType.GAME_START,
                RoomId = RoomId,
                Symbol = "O"
            });

            Console.WriteLine($"[Room {RoomId}] Game bat dau - {HostName}(X) vs {guestName}(O)");

            //Host di truoc
            currentTurnPlayerId = hostId;
            StartTurnTimer();
        }

        //Relay nuoc di
        public void PlaceStone(string playerId, int row, int col)
        {
            if (isGameOver) return;
            //Khong phai luot cua player nay
            if (playerId != currentTurnPlayerId)
            {
                NetworkStream? senderStream = GetStream(playerId);
                if (senderStream != null)
                {
                    Send(senderStream, new Message
                    {
                        Type = MessageType.ERROR,
                        Message2 = "Chua den luot cua ban."
                    });
                }

                return;
            }

            //Dung timer luot bang TurnTimerManager
            StopTurnTimer();

            var moveMessage = new Message
            {
                Type = MessageType.STONE_PLACED,
                Row = row,
                Col = col,
                Symbol = playerId == hostId ? "X" : "O"
            };

            Send(hostStream, moveMessage);
            if (guestStream != null)
            {
                Send(guestStream, moveMessage);
            }

            Console.WriteLine($"[Room {RoomId}] {playerId} dat tai ({row},{col})");

            //Chuyen luot va bat dau dem gio luot moi
            SwitchTurn();
            StartTurnTimer();
        }

        //Thong bao doi thu roi phong
        public void NotifyOpponentLeft(string playerId)
        {
            isGameOver = true;
            StopTurnTimer();

            NetworkStream? opponentStream = playerId == hostId ? guestStream : hostStream;
            if (opponentStream != null)
            {
                Send(opponentStream, new Message
                {
                    Type = MessageType.OPPONENT_LEFT,
                    Message2 = "Doi thu da roi phong."
                });
            }

            Console.WriteLine($"[Room {RoomId}] Player {playerId} da roi phong");
        }

        private void StartTurnTimer()
        {
            string playerName = GetPlayerName(currentTurnPlayerId);

            turnTimerManager.StartNewTurn(
                playerId: currentTurnPlayerId!,
                playerName: playerName,
                onTick: seconds =>
                {
                    var tick = new Message
                    {
                        Type = MessageType.TIMER_TICK,
                        SecondsLeft = seconds
                    };
                    Send(hostStream, tick);
                    if (guestStream != null) Send(guestStream, tick);
                },
                onTimeout: timedOutPlayerId =>
                {
                    isGameOver = true;
                    StopTurnTimer();

                    string winnerSymbol = timedOutPlayerId == hostId ? "O" : "X";

                    var gameOver = new Message
                    {
                        Type = MessageType.GAME_OVER,
                        Winner = winnerSymbol
                    };
                    Send(hostStream, gameOver);
                    if (guestStream != null) Send(guestStream, gameOver);

                    Console.WriteLine($"[Room {RoomId}] {playerName} het gio - {winnerSymbol} thang.");
                }
            );
        }

        private void StopTurnTimer()
        {
            turnTimerManager.PlayerMoved();
        }

        private void SwitchTurn()
        {
            if (currentTurnPlayerId == hostId)
            {
                currentTurnPlayerId = guestId;
            }
            else
            {
                currentTurnPlayerId = hostId;
            }
        }

        private NetworkStream? GetStream(string playerId)
        {
            if (playerId == hostId)
            {
                return hostStream;
            }

            if (playerId == guestId)
            {
                return guestStream;
            }

            return null;
        }

        private string GetPlayerName(string? playerId)
        {
            if (playerId == hostId)
            {
                return HostName;
            }

            if (playerId == guestId)
            {
                return guestName ?? "Guest";
            }

            return "Unknown";
        }
    }
}
