using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkshopI4.Core.Messages;

namespace WorkshopI4.Core.Helpers
{
    public interface IRabbitMQHelperAction
    {
        void ActionMessage(object message, IRabbitMQHelperAction newAction = null);
    }
}