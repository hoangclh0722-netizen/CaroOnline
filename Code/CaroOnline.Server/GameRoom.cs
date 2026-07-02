using System.Net.Sockets;
using CaroOnline.Shared;
using static CaroOnline.Server.NetworkSender;

namespace CaroOnline.Server
{
    public class GameRoom
    {
        private const int Rows = 17;
        private const int Cols = 20;
        private const int Empty = 0;
        private const int HostStone = 1;
        private const int GuestStone = 2;

        public string RoomId { get; }
        public string HostName { get; }
        public bool IsFull => guestId != null;

        private readonly string hostId;
        private readonly NetworkStream hostStream;
        private readonly int[,] board = new int[Rows, Cols];
        private readonly object stateLock = new();

        private string? guestId;
        private string? guestName;
        private NetworkStream? guestStream;
        private bool isGameOver;
        private int moveCount;
        private readonly DatabaseManager db = new DatabaseManager();

        private readonly TurnTimerManager turnTimerManager = new();
        private string? currentTurnPlayerId;

        public GameRoom(string roomId, string hostId, string hostName, NetworkStream hostStream)
        {
            RoomId = roomId;
            HostName = hostName;
            this.hostId = hostId;
            this.hostStream = hostStream;
        }

        public void AddGuest(string playerId, string playerName, NetworkStream stream)
        {
            guestId = playerId;
            guestName = playerName;
            guestStream = stream;
        }

        public bool HasPlayer(string playerId)
        {
            return playerId == hostId || playerId == guestId;
        }

        public void StartGame()
        {
            if (guestStream == null)
            {
                return;
            }

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

            currentTurnPlayerId = hostId;
            StartTurnTimer();
        }

        public void PlaceStone(string playerId, int row, int col)
        {
            Message? error = null;
            Message? moveMessage = null;
            Message? gameOverMessage = null;
            bool shouldStartNextTurn = false;

            lock (stateLock)
            {
                if (isGameOver)
                {
                    return;
                }

                if (playerId != currentTurnPlayerId)
                {
                    error = new Message
                    {
                        Type = MessageType.ERROR,
                        Message2 = "Chua den luot cua ban."
                    };
                }
                else if (!IsInsideBoard(row, col))
                {
                    error = new Message
                    {
                        Type = MessageType.ERROR,
                        Message2 = "Nuoc di nam ngoai ban co."
                    };
                }
                else if (board[row, col] != Empty)
                {
                    error = new Message
                    {
                        Type = MessageType.ERROR,
                        Message2 = "O nay da co quan."
                    };
                }
                else
                {
                    StopTurnTimer();

                    int stone = playerId == hostId ? HostStone : GuestStone;
                    string symbol = StoneToSymbol(stone);

                    board[row, col] = stone;
                    moveCount++;

                    moveMessage = new Message
                    {
                        Type = MessageType.STONE_PLACED,
                        Row = row,
                        Col = col,
                        Symbol = symbol
                    };

                    Console.WriteLine($"[Room {RoomId}] {playerId} dat tai ({row},{col})");

                    if (HasFiveInRow(row, col, stone))
                    {
                        isGameOver = true;
                        gameOverMessage = new Message
                        {
                            Type = MessageType.GAME_OVER,
                            Winner = symbol,
                            Message2 = symbol + " thang."
                        };
                        string winnerName = symbol == "X" ? HostName : (guestName ?? "Guest");
                        db.SaveMatchResult(HostName, guestName ?? "Guest", winnerName);
                    }
                    else if (moveCount >= Rows * Cols)
                    {
                        isGameOver = true;
                        gameOverMessage = new Message
                        {
                            Type = MessageType.GAME_OVER,
                            Winner = "DRAW",
                            Message2 = "Hoa."
                        };
                        db.SaveMatchResult(HostName, guestName ?? "Guest", "Hòa");
                    }
                    else
                    {
                        SwitchTurn();
                        shouldStartNextTurn = true;
                    }
                }
            }

            if (error != null)
            {
                NetworkStream? senderStream = GetStream(playerId);
                if (senderStream != null)
                {
                    Send(senderStream, error);
                }

                return;
            }

            if (moveMessage != null)
            {
                Broadcast(moveMessage);
            }

            if (gameOverMessage != null)
            {
                StopTurnTimer();
                Broadcast(gameOverMessage);
                Console.WriteLine($"[Room {RoomId}] Game over - {gameOverMessage.Winner}");
                return;
            }

            if (shouldStartNextTurn)
            {
                StartTurnTimer();
            }
        }

        public void NotifyOpponentLeft(string playerId)
        {
            lock (stateLock)
            {
                isGameOver = true;
            }

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
            string? playerId = currentTurnPlayerId;
            if (playerId == null)
            {
                return;
            }

            string playerName = GetPlayerName(playerId);

            turnTimerManager.StartNewTurn(
                playerId: playerId,
                playerName: playerName,
                onTick: seconds =>
                {
                    Broadcast(new Message
                    {
                        Type = MessageType.TIMER_TICK,
                        SecondsLeft = seconds
                    });
                },
                onTimeout: timedOutPlayerId =>
                {
                    string winnerSymbol;

                    lock (stateLock)
                    {
                        if (isGameOver)
                        {
                            return;
                        }

                        isGameOver = true;
                        winnerSymbol = timedOutPlayerId == hostId ? "O" : "X";
                    }

                    StopTurnTimer();
                    string winnerName = winnerSymbol == "X" ? HostName : (guestName ?? "Guest");
                    db.SaveMatchResult(HostName, guestName ?? "Guest", winnerName);

                    Broadcast(new Message
                    {
                        Type = MessageType.GAME_OVER,
                        Winner = winnerSymbol,
                        Message2 = "Het gio. " + winnerSymbol + " thang."
                    });

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
            currentTurnPlayerId = currentTurnPlayerId == hostId ? guestId : hostId;
        }

        private void Broadcast(Message message)
        {
            Send(hostStream, message);
            if (guestStream != null)
            {
                Send(guestStream, message);
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

        private static bool IsInsideBoard(int row, int col)
        {
            return row >= 0 && row < Rows && col >= 0 && col < Cols;
        }

        private bool HasFiveInRow(int row, int col, int stone)
        {
            int[][] directions =
            {
                new[] { 0, 1 },
                new[] { 1, 0 },
                new[] { 1, 1 },
                new[] { 1, -1 }
            };

            foreach (int[] direction in directions)
            {
                int count = 1
                    + CountStone(row, col, direction[0], direction[1], stone)
                    + CountStone(row, col, -direction[0], -direction[1], stone);

                if (count >= 5)
                {
                    return true;
                }
            }

            return false;
        }

        private int CountStone(int row, int col, int rowStep, int colStep, int stone)
        {
            int count = 0;
            int currentRow = row + rowStep;
            int currentCol = col + colStep;

            while (IsInsideBoard(currentRow, currentCol) && board[currentRow, currentCol] == stone)
            {
                count++;
                currentRow += rowStep;
                currentCol += colStep;
            }

            return count;
        }

        private static string StoneToSymbol(int stone)
        {
            return stone == HostStone ? "X" : "O";
        }
    }
}
