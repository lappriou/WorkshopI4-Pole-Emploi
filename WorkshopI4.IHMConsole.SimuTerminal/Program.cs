using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using WorkshopI4.Core.Helpers;
using WorkshopI4.Core.Messages;
using WorkshopI4.Core.Models;
using WorkshopI4.Core.Extentions;

namespace WorkshopI4.IHMConsole.SimuTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 10, i =>
            {
                SimuTerminal(i);
            });

            void SimuTerminal(int id)
            {
                Array valuesTypeAction = Enum.GetValues(typeof(ETypeAction));
                Array valuesTypeComponentUI = Enum.GetValues(typeof(ETypeUIElement));
                Random random = new Random();

                var rnd = new Random();
                while (true)
                {
                    Thread.Sleep(rnd.Next(1000, 60000));
                    var message = new NewInteractionMessage();
                    message.Date = DateTime.Now;
                    message.IDComponent = rnd.Next(20).ToString();
                    message.IDPage = rnd.Next(15).ToString();
                    message.IDTerminal = id.ToString();
                    message.TypeAction = (ETypeAction) valuesTypeAction.GetValue(random.Next(valuesTypeAction.Length));
                    message.TypeComponentUI = (ETypeUIElement) valuesTypeAction.GetValue(random.Next(valuesTypeAction.Length));
                    RabbitMQHelper.Send(RabbitMQHelper.NewInteractionNameQueue, message.ToJson());
                }
                

            }
        }
    }
}
