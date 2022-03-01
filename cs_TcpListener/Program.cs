using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace cs_TcpListener
{
    class Program
    {
        static void Main()
        {
            var listener = new TcpListener(IPAddress.Parse("10.1.18.4"), 45678);
            listener.Start(10);

            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();

                var bw = new BinaryWriter(stream);
                var br = new BinaryReader(stream);

                while (true)
                {
                    var data = br.ReadString();
                    Console.WriteLine(data);
                    bw.Write("Roger that!");
                }
            }

        }
    }
}
