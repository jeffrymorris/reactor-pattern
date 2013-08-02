using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    /// <summary>
    /// Entry point to the process. Starts the server sets it up to listen to port 1234 on localhost.
    /// To start run reactor.exe. To connect to the server, start a telnet session on 127.0.0.1:1234
    /// like this: telnet 127.0.0.1 1234. Multiple clients can connect, but server blocks on all but
    /// most recent - the rest queue up.
    /// </summary>
    class Program
    {
        private Dispatcher _reactor;
        
        static void Main(string[] args)
        {
            new Program().StartServer();
        }

        /// <summary>
        /// Starts the server listening for client connections on localhost port 1234
        /// </summary>
        void StartServer()
        {
            Console.Write("Starting server on 127.0.0.1:1234...");
            _reactor = new Dispatcher();
            var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
            var acceptor = new Acceptor(listener, _reactor);
            _reactor.HandleRequests();
            Console.WriteLine("done");
        }
    }
}
