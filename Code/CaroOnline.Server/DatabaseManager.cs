using System;
using Microsoft.Data.Sqlite;

namespace CaroOnline.Server
{
    public class DatabaseManager
    {
        private readonly string connectionString = "Data Source=CaroGame.db";

        // Hàm 1: Tự động tạo file và tạo bảng nếu chưa có 
        public void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Players (
                        Username TEXT PRIMARY KEY,
                        Password TEXT NOT NULL,
                        Wins INTEGER DEFAULT 0,
                        TotalGames INTEGER DEFAULT 0
                    );";
                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
                string createHistoryQuery = @"
                    CREATE TABLE IF NOT EXISTS MatchHistory (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Player1 TEXT,
                        Player2 TEXT,
                        Winner TEXT,
                        MatchDate TEXT
                    );";
                using (var command = new SqliteCommand(createHistoryQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Database CaroGame.db da duoc khoi tao OK!");
        }

        // Hàm 2: Kiểm tra Đăng nhập
        public bool CheckLogin(string username, string password)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Players WHERE Username = @user AND Password = @pass";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", password);

                    long result = (long)command.ExecuteScalar();
                    return result > 0; // Trả về true nếu có tài khoản
                }
            }
        }

        // Hàm 3: Đăng ký tài khoản (Tạo sẵn 1 tài khoản test)
        public bool RegisterTestUser(string username, string password)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Players (Username, Password) VALUES (@user, @pass)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@user", username);
                        command.Parameters.AddWithValue("@pass", password);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false; // Lỗi (ví dụ trùng Username)
            }
        }
        // Hàm 4: Lưu lịch sử ván đấu và tự động cộng điểm kỷ lục
        public void SaveMatchResult(string player1, string player2, string winner)
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // 1. Ghi nhận vào lịch sử trận đấu
                    string insertHistory = "INSERT INTO MatchHistory (Player1, Player2, Winner, MatchDate) VALUES (@p1, @p2, @winner, @date)";
                    using (var command = new SqliteCommand(insertHistory, connection))
                    {
                        command.Parameters.AddWithValue("@p1", player1);
                        command.Parameters.AddWithValue("@p2", player2);
                        command.Parameters.AddWithValue("@winner", winner);
                        command.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                        command.ExecuteNonQuery();
                    }

                    // 2. Cập nhật số trận tổng (TotalGames) cho cả 2 người chơi
                    string updateTotals = "UPDATE Players SET TotalGames = TotalGames + 1 WHERE Username = @p1 OR Username = @p2";
                    using (var command = new SqliteCommand(updateTotals, connection))
                    {
                        command.Parameters.AddWithValue("@p1", player1);
                        command.Parameters.AddWithValue("@p2", player2);
                        command.ExecuteNonQuery();
                    }

                    // 3. Nếu có người thắng thực sự (không hòa), cộng 1 trận thắng (Wins) vào kỷ lục của họ
                    if (!string.IsNullOrEmpty(winner) && winner != "Hòa")
                    {
                        string updateWins = "UPDATE Players SET Wins = Wins + 1 WHERE Username = @winner";
                        using (var command = new SqliteCommand(updateWins, connection))
                        {
                            command.Parameters.AddWithValue("@winner", winner);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                Console.WriteLine($"[DB] Da luu lich su tran dau: {player1} vs {player2}. Winner: {winner}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DB Error] Khong the luu ket qua: " + ex.Message);
            }
        }
        // Hàm 5: Lấy danh sách kỉ lục
        public string GetBestRecords()
        {
            string records = "";
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Username, Wins, TotalGames FROM Players ORDER BY Wins DESC LIMIT 10";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            int rank = 1;
                            while (reader.Read())
                            {
                                string uName = reader.GetString(0);
                                long wins = reader.GetInt64(1);
                                long totals = reader.GetInt64(2);

                                records += $"{rank}. {uName} - Thắng: {wins}/{totals}\n";
                                rank++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                records = "Lỗi lấy kỷ lục: " + ex.Message;
            }

            return string.IsNullOrEmpty(records) ? "Chưa có kỷ lục nào!" : records;
        }
    }
}
