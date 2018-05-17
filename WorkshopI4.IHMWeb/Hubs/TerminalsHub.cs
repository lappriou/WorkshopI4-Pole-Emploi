using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopI4.Core.Messages;

namespace WorkshopI4.IHMWeb.Hubs
{
    public class TerminalsHub : Hub
    {
        public Task Send(UpdateStatusTerminalMessage message)
        {
            return Clients.All.SendAsync("Send", message);
        }
    }
}
