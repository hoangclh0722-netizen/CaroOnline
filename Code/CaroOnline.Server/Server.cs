using System;
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

        public Server(int port)
        {
            this.port = port;
        }

        public void Start()
        {
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
            byte[] buffer = new byte[4096];

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    Message? message = MessageHelper.Deserialize(buffer, bytesRead);

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
            catch (Exception ex)
            {
                Console.WriteLine("Client error: " + ex.Message);
            }
            finally
            {
                client.Close();
                Console.WriteLine("Client disconnected");
            }
        }

        private void ProcessMessage(NetworkStream stream, Message message)
        {
            if (message.Type == MessageType.LOGIN)
            {
                string playerId = Guid.NewGuid().ToString("N").Substring(0, 8);

                Message response = new Message
                {
                    Type = MessageType.LOGIN_OK,
                    PlayerName = message.PlayerName,
                    PlayerId = playerId
                };

                Send(stream, response);

                Console.WriteLine("Login OK: " + message.PlayerName + " - " + playerId);
                return;
            }

            Send(stream, new Message
            {
                Type = MessageType.ERROR,
                Message2 = "Unknown message type"
            });
        }

        private void Send(NetworkStream stream, Message message)
        {
            byte[] data = MessageHelper.Serialize(message);
            stream.Write(data, 0, data.Length);
        }
    }
}
