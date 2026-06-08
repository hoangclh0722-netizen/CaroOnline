using System.Net.Sockets;
using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

namespace CaroOnline.Client
{
    public sealed class ClientConnection : IDisposable
    {
        private TcpClient? _client;
        private NetworkStream? _stream;

        public bool IsConnected => _client?.Connected == true;

        public void Connect(string host, int port)
        {
            Disconnect();

            _client = new TcpClient();
            _client.Connect(host, port);
            _stream = _client.GetStream();
        }

        public SharedMessage Login(string playerName)
        {
            if (_stream == null)
            {
                throw new InvalidOperationException("Client is not connected");
            }

            MessageHelper.Send(_stream, new SharedMessage
            {
                Type = MessageType.LOGIN,
                PlayerName = playerName
            });

            return MessageHelper.Receive(_stream)
                   ?? throw new InvalidOperationException("Server returned an empty response");
        }

        public void Disconnect()
        {
            _stream?.Dispose();
            _client?.Close();
            _stream = null;
            _client = null;
        }

        public void Dispose()
        {
            Disconnect();
        }
    }
}
