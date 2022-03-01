using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cs_Udp_Server
{
    class Program
    {

        /*
        static void Main()
        {
            var listener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);

            var ip = IPAddress.Parse("127.0.0.1");
            var port = 45678;
            var listenerEP = new IPEndPoint(ip, port);
            listener.Bind(listenerEP);


            var buffer = new byte[ushort.MaxValue - 30];
            EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            var len = 0;
            var msg = "";

            while (true)
            {
                len = listener.ReceiveFrom(buffer, ref remoteEP);
                msg = Encoding.Default.GetString(buffer, 0, len);
                Console.WriteLine($"{remoteEP}: {msg}");
            }
        }
        */



        static void Main() => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            var listener = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);

            var ip = IPAddress.Parse("127.0.0.1");
            var port = 45678;
            var listenerEP = new IPEndPoint(ip, port);
            listener.Bind(listenerEP);


            EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);

            var buffer = new byte[ushort.MaxValue - 30];
            var segment = new ArraySegment<byte>(buffer);

            while (true)
            {
                var res = await listener.ReceiveFromAsync(segment, SocketFlags.None, remoteEP);
                var endPoint = res.RemoteEndPoint;
                var len = res.ReceivedBytes;
                var msg = Encoding.Default.GetString(buffer, 0, len);
                Console.WriteLine($"{endPoint}: {msg}");
            }
        }
    }
}
