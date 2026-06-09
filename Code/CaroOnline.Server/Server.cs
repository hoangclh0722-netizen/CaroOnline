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
            try
            {
                NetworkStream stream = client.GetStream();

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
                client.Close();
                Console.WriteLine("Client disconnected");
            }
        }

        private void ProcessMessage(NetworkStream stream, Message message)
        {
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

                Message response = new Message
                {
                    Type = MessageType.LOGIN_OK,
                    PlayerName = playerName,
                    PlayerId = playerId
                };

                Send(stream, response);

                Console.WriteLine("Login OK: " + playerName + " - " + playerId);
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
            MessageHelper.Send(stream, message);
        }
    }
}
