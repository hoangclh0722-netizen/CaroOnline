using CaroOnline.Server;
using System;
using System.Threading.Tasks;
Server server = new Server(9999);
server.Start();
DatabaseManager.Initialize();
