using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitMq.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("linki buraya ekleyiniz");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            //Eğer publisher.2ın bunu tanımladığına eminseniz bunu silebilirsiniz.
            //Eğer publisher da tanımlanmadıysa burda tanımlama yapılır.
            //Her iki taraf için de tanımlama yapılacaksa parametreler aynı olmalı
            ////channel.QueueDeclare("hello-queue", true, false, false);

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("hello-queue", true, consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                Console.WriteLine("Gelen Mesaj:" + message);
            };


            Console.ReadLine();
        }

    }
}
