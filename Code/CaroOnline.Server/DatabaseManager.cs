using System;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace CaroOnline.Server
{
    public static class DatabaseManager
    {
        private const string ConnectionString = "Data Source=caro_game.db";

        // Khởi tạo Database, tự động tạo bảng nếu chưa có
        public static void Initialize()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                // 1. Tạo bảng lưu Kỷ lục người chơi
                string createPlayerTable = @"
                    CREATE TABLE IF NOT EXISTS Players (
                        PlayerName TEXT PRIMARY KEY,
                        BestRecord INTEGER DEFAULT 0
                    );";

                // 2. Tạo bảng lưu Lịch sử trận đấu
                string createHistoryTable = @"
                    CREATE TABLE IF NOT EXISTS MatchHistory (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Player1 TEXT,
                        Player2 TEXT,
                        Winner TEXT,
                        PlayedAt TEXT
                    );";

                using (var command = new SqliteCommand(createPlayerTable, connection)) { command.ExecuteNonQuery(); }
                using (var command = new SqliteCommand(createHistoryTable, connection)) { command.ExecuteNonQuery(); }
            }
        }

        // Lấy kỷ lục cao nhất của một người chơi
        public static int GetBestRecord(string playerName)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT BestRecord FROM Players WHERE PlayerName = @name";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", playerName);
                    var result = command.ExecuteScalar();
                    if (result != null) return Convert.ToInt32(result);
                }
            }
            return 0; // Chưa có thì kỷ lục bằng 0
        }

        // Cập nhật kỷ lục mới nếu cao hơn kỷ lục cũ
        public static void UpdateBestRecord(string playerName, int currentStreak)
        {
            int oldRecord = GetBestRecord(playerName);
            if (currentStreak <= oldRecord) return; // Không cao hơn thì bỏ qua

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Players (PlayerName, BestRecord) VALUES (@name, @record)
                    ON CONFLICT(PlayerName) DO UPDATE SET BestRecord = @record;";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", playerName);
                    command.Parameters.AddWithValue("@record", currentStreak);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Lưu lịch sử trận đấu vào DB
        public static void SaveMatch(string p1, string p2, string winner)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO MatchHistory (Player1, Player2, Winner, PlayedAt) VALUES (@p1, @p2, @winner, @time)";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@p1", p1);
                    command.Parameters.AddWithValue("@p2", p2);
                    command.Parameters.AddWithValue("@winner", winner);
                    command.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }
        }

        // Lấy danh sách lịch sử trận đấu (Trả về chuỗi dạng danh sách để dễ gửi qua mạng)
        public static List<string> GetHistory(string playerName)
        {
            var history = new List<string>();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Player1, Player2, Winner, PlayedAt FROM MatchHistory WHERE Player1 = @name OR Player2 = @name ORDER BY Id DESC LIMIT 10";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", playerName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string p1 = reader.GetString(0);
                            string p2 = reader.GetString(1);
                            string win = reader.GetString(2);
                            string time = reader.GetString(3);
                            history.Add($"{p1} vs {p2} | Thắng: {win} | ({time})");
                        }
                    }
                }
            }
            return history;
        }
        public static List<string> GetLeaderboard()
        {
            var leaderboard = new List<string>();
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                // Lấy tên và kỷ lục, sắp xếp giảm dần, giới hạn 10 người
                string query = "SELECT PlayerName, BestRecord FROM Players ORDER BY BestRecord DESC LIMIT 10";
                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int rank = 1;
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int record = reader.GetInt32(1);
                            leaderboard.Add($"{rank}|{name}|{record}");
                            rank++;
                        }
                    }
                }
            }
            return leaderboard;
        }
    }
}