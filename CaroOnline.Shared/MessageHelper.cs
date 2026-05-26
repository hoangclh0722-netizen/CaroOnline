using System.Text;
using System.Text.Json;

namespace CaroOnline.Shared
{
    public static class MessageHelper
    {
        // Serialize: object Message → JSON string → byte[]
        // Dùng khi GỬI tin nhắn
        public static byte[] Serialize(Message message)
        {
            string json = JsonSerializer.Serialize(message);
            return Encoding.UTF8.GetBytes(json);
        }

        // Deserialize: byte[] → JSON string → object Message
        // Dùng khi NHẬN tin nhắn
        public static Message? Deserialize(byte[] data, int length)
        {
            string json = Encoding.UTF8.GetString(data, 0, length);
            return JsonSerializer.Deserialize<Message>(json);
        }

        // Tạo nhanh 1 Message chỉ có Type — dùng cho các lệnh đơn giản
        public static Message Create(MessageType type)
        {
            return new Message { Type = type };
        }
    }
}