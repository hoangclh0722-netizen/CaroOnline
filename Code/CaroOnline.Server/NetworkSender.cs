using System.Collections.Concurrent;
using System.Net.Sockets;
using CaroOnline.Shared;

namespace CaroOnline.Server
{
    public static class NetworkSender
    {
        private static readonly ConcurrentDictionary<NetworkStream, object> StreamLocks = new();

        public static void Send(NetworkStream stream, Message message)
        {
            object streamLock = StreamLocks.GetOrAdd(stream, _ => new object());

            lock (streamLock)
            {
                MessageHelper.Send(stream, message);
            }
        }
    }
}
