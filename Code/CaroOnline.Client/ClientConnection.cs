using System.Net.Sockets;
using CaroOnline.Shared;
using SharedMessage = CaroOnline.Shared.Message;

namespace CaroOnline.Client
{
    public sealed class ClientConnection : IDisposable
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private CancellationTokenSource? _listenCts;
        private Task? _listenTask;
        private readonly object _sendLock = new();

        public bool IsConnected => _client?.Connected == true;
        public event Action<SharedMessage>? MessageReceived;
        public event Action<Exception>? ConnectionError;
        public event Action? Disconnected;

        public void Connect(string host, int port)
        {
            Disconnect();

            _client = new TcpClient();
            _client.Connect(host, port);
            _stream = _client.GetStream();
        }
        public SharedMessage Login(string playerName, string password)
        {
            Send(new SharedMessage
            {
                Type = MessageType.LOGIN,
                PlayerName = playerName,
                Message2 = password 
            });

            return MessageHelper.Receive(GetStream())
                   ?? throw new InvalidOperationException("Server returned an empty response");
        }

        public void Send(SharedMessage message)
        {
            NetworkStream stream = GetStream();

            lock (_sendLock)
            {
                MessageHelper.Send(stream, message);
            }
        }

        public void StartListening()
        {
            if (_listenTask is { IsCompleted: false })
            {
                return;
            }

            NetworkStream stream = GetStream();
            _listenCts = new CancellationTokenSource();
            CancellationToken token = _listenCts.Token;

            _listenTask = Task.Run(() => ListenLoop(stream, token), token);
        }

        public void StopListening()
        {
            _listenCts?.Cancel();
            _listenCts?.Dispose();
            _listenCts = null;
            _listenTask = null;
        }

        public void Disconnect()
        {
            StopListening();
            _stream?.Dispose();
            _client?.Close();
            _stream = null;
            _client = null;
        }

        public void Dispose()
        {
            Disconnect();
        }

        private void ListenLoop(NetworkStream stream, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    SharedMessage? message = MessageHelper.Receive(stream);
                    if (message != null)
                    {
                        MessageReceived?.Invoke(message);
                    }
                }
            }
            catch (ObjectDisposedException) when (token.IsCancellationRequested)
            {
            }
            catch (IOException) when (token.IsCancellationRequested)
            {
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    ConnectionError?.Invoke(ex);
                    Disconnected?.Invoke();
                }
            }
        }

        private NetworkStream GetStream()
        {
            return _stream ?? throw new InvalidOperationException("Client is not connected");
        }
    }
}
