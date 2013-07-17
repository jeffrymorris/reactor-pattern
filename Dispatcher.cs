using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    public class Dispatcher : IDispatcher 
    {
        private readonly SynchronousEventDemultiplexer demux = new SynchronousEventDemultiplexer();
        private readonly IDictionary<Socket, IEventHandler> handlers = new Dictionary<Socket, IEventHandler>();
        public void HandleRequests()
        {
            while (true)
            {
                foreach(var handle in demux.Select(handlers.Keys))
                {
                    handlers[handle].HandleRequest();
                }
            }
        }

        public void Remove(IEventHandler handler)
        {
            handlers.Remove(handler.Handle);
        }

        public void Register(IEventHandler handler)
        {
            handlers.Add(handler.Handle, handler);
        }
    }
}
