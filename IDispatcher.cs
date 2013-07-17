using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rantdriven.Patterns.Reactor
{
    public interface IDispatcher
    {
        void HandleRequests();
        void Remove(IEventHandler handler);
        void Register(IEventHandler handler);
    }
}
