using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace FormulaAirLine.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var vactory= new ConnectionFactory(){
                HostName="localhost",
                UserName="user",
                Password="mypass",
                VirtualHost="/"
            };

            var conn=vactory.CreateConnection();
            using var channel=conn.CreateModel();

            channel.QueueDeclare("bookings", durable:true, exclusive:false);

            var jsonstring= JsonSerializer.Serialize(message);
            var body= Encoding.UTF8.GetBytes(jsonstring);

            channel.BasicPublish("", "bookings", body:body);
        }
    }
}