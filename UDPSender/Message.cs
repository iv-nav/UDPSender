using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPSender
{
    public class Message
    {
        public static Encoding win1251 = Encoding.GetEncoding("Windows-1251");
        private static DateTime epoch = new DateTime(1970, 1, 1);
        private int timeStamp;
        private string content;

        public Message(string userId, string cityId, string stationId)
        {
            timeStamp = (Int32)(DateTime.UtcNow.Subtract(epoch)).TotalSeconds;
            content = $"{timeStamp};{userId};{cityId};{stationId}";
        }

        public override string ToString()
        {
            return content;
        }

        public byte[] GetBytes()
        {
            byte[] data = win1251.GetBytes(content);

            byte[] res = new byte[data.Length + 1];
            res[0] = (byte)data.Length;

            Array.Copy(data, 0, res, 1, data.Length);

            return res;

        }
    }
}
