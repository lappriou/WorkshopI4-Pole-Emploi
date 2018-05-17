using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace WorkshopI4.Core.Helpers
{
    public class RabbitMQHelper
    {
        private static string hostName = Environment.GetEnvironmentVariable("hostNameRabbitMQ");
        private static int port = Int32.Parse(Environment.GetEnvironmentVariable("portRabbitMQ"));
        private static string userName = Environment.GetEnvironmentVariable("userNameRabbitMQ");
        private static string password = Environment.GetEnvironmentVariable("passwordRabbitMQ");

        public static string AskHelpNameQueue { get =>"AskHelp"; }
        public static string NewInteractionNameQueue { get => "NewInteraction"; }

        public static void Send(string queue, string data)
        {
            using (IConnection connection = GetConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    channel.BasicPublish(string.Empty, queue, null, Encoding.UTF8.GetBytes(data));
                }
            }
        }

        public static IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = hostName;
            connectionFactory.UserName = userName;
            connectionFactory.Password = password;
            connectionFactory.Port = port;
            return connectionFactory.CreateConnection();
        }

        public static void Receive(string queue, IRabbitMQHelperAction action)
        {
            using (IConnection connection = GetConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult result = channel.BasicGet(queue, true);
                    if (result != null)
                    {
                        string data = Encoding.UTF8.GetString(result.Body);
                        var actionPredicat = new RabbitMQHelperActionPredicat();
                        actionPredicat.ActionMessage(data, action);
                    }
                }
            }
        }
    }
}
