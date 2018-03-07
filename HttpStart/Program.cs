using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpStart
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("10.200.123.158"), 6789);
            tcpListener.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                HttpCommandHandler handler = new HttpCommandHandler(tcpListener.AcceptTcpClient());
                Task.Run(() => handler.HandleCommand());
            }
        }
    }
}
