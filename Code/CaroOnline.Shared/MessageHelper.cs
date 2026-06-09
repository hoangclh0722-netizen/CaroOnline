using System.Buffers.Binary;
using System.Text;
using System.Text.Json;

namespace CaroOnline.Shared
{
    public static class MessageHelper
    {
        private const int MaxMessageSize = 64 * 1024;

        public static byte[] Serialize(Message message)
        {
            string json = JsonSerializer.Serialize(message);
            return Encoding.UTF8.GetBytes(json);
        }

        public static Message? Deserialize(byte[] data, int length)
        {
            string json = Encoding.UTF8.GetString(data, 0, length);
            return JsonSerializer.Deserialize<Message>(json);
        }

        public static void Send(Stream stream, Message message)
        {
            byte[] payload = Serialize(message);
            byte[] header = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(header, payload.Length);

            stream.Write(header, 0, header.Length);
            stream.Write(payload, 0, payload.Length);
            stream.Flush();
        }

        public static Message? Receive(Stream stream)
        {
            byte[] header = ReadExact(stream, 4);
            int length = BinaryPrimitives.ReadInt32BigEndian(header);

            if (length <= 0 || length > MaxMessageSize)
            {
                throw new InvalidDataException("Invalid message length");
            }

            byte[] payload = ReadExact(stream, length);
            return Deserialize(payload, payload.Length);
        }

        public static Message Create(MessageType type)
        {
            return new Message { Type = type };
        }

        private static byte[] ReadExact(Stream stream, int length)
        {
            byte[] data = new byte[length];
            int offset = 0;

            while (offset < length)
            {
                int bytesRead = stream.Read(data, offset, length - offset);
                if (bytesRead == 0)
                {
                    throw new EndOfStreamException("Connection closed");
                }

                offset += bytesRead;
            }

            return data;
        }
    }
}
