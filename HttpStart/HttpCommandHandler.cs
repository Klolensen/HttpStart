using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpStart
{
    class HttpCommandHandler
    {
        private TcpClient _client;
        public HttpCommandHandler(TcpClient client)
        {
            _client = client;
        }

        public void HandleCommand()
        {
            while (true)
            {
                try
                {
                    Stream stream = _client.GetStream();
                    StreamWriter streamWriter = new StreamWriter(stream) {AutoFlush = true};
                    StreamReader streamReader = new StreamReader(stream);

                    string message = streamReader.ReadLine();

                    while (!string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine(message);
                        if (message == "STOP")
                        {
                            return;
                        }
                        List<string> messageList = message.Split(' ').ToList();
                        foreach (string messageFragment in messageList)
                        {
                            Console.WriteLine(messageFragment);
                        }
                        message = "";
                        messageList.Clear();
                    }
                }
                catch (IOException)
                {
                    return;
                }
            }
        }
    }
}
