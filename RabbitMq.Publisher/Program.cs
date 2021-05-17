using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace RabbitMq.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("linki buraya yazınız");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("hello-queue", true, false, false);
            string message = "hello world";

            var messageBody = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);

            Console.WriteLine("mesaj gönderilmiştir");
            Console.ReadLine();
        }
    }
}
