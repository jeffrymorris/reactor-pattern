using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    public interface IEventHandler
    {
        void HandleRequest();
        Socket Handle { get; }
    }
}
