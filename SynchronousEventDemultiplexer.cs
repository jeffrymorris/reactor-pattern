using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    public class SynchronousEventDemultiplexer
    {
        public IEnumerable<Socket> Select(ICollection<Socket> handles)
        {
            var pending = new ArrayList(handles.ToArray());
            Socket.Select(pending, null, null, 10000);
            return pending.Cast<Socket>();
        }
    }
}
