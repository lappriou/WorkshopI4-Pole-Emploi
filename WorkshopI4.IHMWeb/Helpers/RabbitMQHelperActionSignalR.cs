using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkshopI4.Core.Helpers;
using WorkshopI4.Core.Messages;
using WorkshopI4.IHMWeb.Hubs;

namespace WorkshopI4.IHMWeb.Helpers
{
    public class RabbitMQHelperActionSignalR : IRabbitMQHelperAction
    {
        public void ActionMessage(object message, IRabbitMQHelperAction newAction = null)
        {
            if(message is UpdateStatusTerminalMessage)
            {
                var hub = new TerminalsHub();
                hub.Send((UpdateStatusTerminalMessage) message);
            }
        }
    }
}
