using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace socket_prog
{
    class Client
    {
        private static void Main(String[] args)
        {
            using (TcpClient client = new TcpClient())
            {
                client.Connect("10.160.138.83", 32000);
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes("This is message from SAMA5D27-WLSOM1-EK client 10.160.138.76");
                    stream.Write(data, 0, data.Length);
                    byte[] recByte = new byte[40960000];
                    var bytes = stream.Read(recByte, 0, recByte.Length);
                    string recStr = Encoding.UTF8.GetString(recByte, 0, bytes);
                    //var result22 = recStr.Replace("\n", "<br/>");
                    Console.WriteLine(recStr);
                    Console.WriteLine("\n.......................\n");
                }
            }

        }
    }
}
