using CaroOnline.Server;
using System;
using System.Threading.Tasks;
CaroOnline.Server.DatabaseManager db = new CaroOnline.Server.DatabaseManager();
db.InitializeDatabase();
db.RegisterTestUser("Vu", "123");
Server server = new Server(9999);
server.Start();