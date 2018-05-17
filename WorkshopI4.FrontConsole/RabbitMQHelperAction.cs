using System;
using System.Collections.Generic;
using System.Text;
using WorkshopI4.Core.Helpers;
using WorkshopI4.Core.Extentions;

namespace WorkshopI4.IHMConsole
{
    public class RabbitMQHelperAction : IRabbitMQHelperAction
    {
        public void ActionMessage(string message)
        {

        }

        public void ActionMessage(object message, IRabbitMQHelperAction newAction = null)
        {
            if(message is object)
            {
                message = message.ToJson();
            }

            Console.WriteLine(message);
        }
    }
}
