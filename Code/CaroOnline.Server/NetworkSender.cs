using System.Net.Sockets;
using CaroOnline.Shared;

namespace CaroOnline.Server
{
    public static class NetworkSender
    {
        public static void Send(NetworkStream stream, Message message)
        {
            byte[] data = MessageHelper.Serialize(message);
            stream.Write(data, 0, data.Length);
        }
    }
}