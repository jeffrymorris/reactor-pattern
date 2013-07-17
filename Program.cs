using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    class Program
    {
        static void Main(string[] args)
        {
            var reactor = new Dispatcher();
            var listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
            var acceptor = new Acceptor(listener, reactor);
            reactor.HandleRequests();
        }
    }
}
