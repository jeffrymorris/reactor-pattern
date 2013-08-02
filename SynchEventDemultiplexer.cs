using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    /// <summary>
    /// Synchronously checks for changes from one or more registered client connections and sends request to the dispatcher 
    /// </summary>
    public class SynchEventDemultiplexer
    {
        public IEnumerable<Socket> Select(ICollection<Socket> handles)
        {
            Console.Write("Waiting for pending connections...");
            var pending = new ArrayList(handles.ToArray());
            Socket.Select(pending, null, null, 10000);
            Console.WriteLine("done");
            return pending.Cast<Socket>();
        }
    }
}
