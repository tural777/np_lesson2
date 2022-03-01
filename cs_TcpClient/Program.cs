using System;
using System.IO;
using System.Net.Sockets;

namespace cs_TcpClient
{
    class Program
    {
        static void Main()
        {
            var client = new TcpClient();
            client.Connect("127.0.0.1", 27001);

            var stream = client.GetStream();

            var bw = new BinaryWriter(stream);
            var br = new BinaryReader(stream);

            while (true)
            {
                bw.Write(Console.ReadLine());
                Console.WriteLine($"Answer: {br.ReadString()}");
            }


        }
    }
}
