using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing.Impl;
using System;
using System.Threading;
using System.Threading.Tasks;
using WorkshopI4.Core.Helpers;
using WorkshopI4.Core.Messages;
using WorkshopI4.IHMConsole;

namespace WorkshopI4.FrontConsole
{
    class Program 
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RabbitMQHelper.Receive(RabbitMQHelper.NewInteractionNameQueue, new RabbitMQHelperAction());
            }

            Console.ReadLine();
        }
    }
}
