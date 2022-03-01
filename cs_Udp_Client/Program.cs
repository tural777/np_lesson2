using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace cs_Udp_Client
{
    class Program
    {
        static void Main()
        {
            var client = new Socket(
               AddressFamily.InterNetwork,
               SocketType.Dgram,
               ProtocolType.Udp);

            var ip = IPAddress.Parse("127.0.0.1");
            var port = 45678;
            var remoteEP = new IPEndPoint(ip, port);

            var msg = "";
            byte[] buffer = null;

            while (true)
            {
                msg = Console.ReadLine();
                buffer = Encoding.Default.GetBytes(msg);
                client.SendTo(buffer, remoteEP);
            }

        }
    }
}
