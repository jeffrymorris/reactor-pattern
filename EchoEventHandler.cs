using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    /// <summary>
    /// Handles client connections and echos input to the console
    /// </summary>
    public class EchoEventHandler : IEventHandler
    {
        private IDispatcher _dispatcher;
        private TcpClient _client;

        public EchoEventHandler(TcpClient client, IDispatcher dispatcher)
        {
            _client = client;
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// Provides implementation specific processing of client input. More specifically
        /// writes client input to the output stream (console).
        /// </summary>
        public void HandleRequest()
        {
            var received = 0;
            var buffer = new byte[1];
            var data = new List<byte>();

            do
            {
                received = Handle.Receive(buffer);
                if (received <= 0) continue;
                if(Encoding.UTF8.GetString(buffer) != Environment.NewLine)
                {
                    Console.Write(Encoding.UTF8.GetString(data.ToArray()));
                    data.Clear();
                }
                data.Add(buffer[0]);
            } while (received > 0);

            _dispatcher.Remove(this);
            _client.Close();
        }

        public Socket Handle
        {
            get { return _client.Client; }
        }
    }
}
