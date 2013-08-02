using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    /// <summary>
    /// Accepts incoming client connections and passes them off to the default echo event handler
    /// </summary>
    public class Acceptor : IEventHandler
    {
        private IDispatcher _dispatcher;
        private TcpListener _listener;

        public Acceptor(TcpListener listener, IDispatcher dispatcher)
        {
            _listener = listener;
            _listener.Start();
            _dispatcher = dispatcher;
            _dispatcher.Register(this);
        }

        /// <summary>
        /// Handles incoming connection and creates a default echo handler to recieve client input and pump to console
        /// </summary>
        public void HandleRequest()
        {
            var client = _listener.AcceptTcpClient();
            _dispatcher.Register(new EchoEventHandler(client, _dispatcher));
            Console.WriteLine("Connecting client - {0}", client.Client.Handle);

        }

        public Socket Handle
        {
            get { return _listener.Server; }
        }
    }
}
