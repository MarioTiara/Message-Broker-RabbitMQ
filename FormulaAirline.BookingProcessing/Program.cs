using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Ticket Consummer");

        var factory= new ConnectionFactory(){
                HostName="localhost",
                UserName="user",
                Password="mypass",
                VirtualHost="/"
            };

        var conn=factory.CreateConnection();
        using var channel=conn.CreateModel();

        channel.QueueDeclare("bookings", durable:true, exclusive:false);

        var consummer= new EventingBasicConsumer(channel);
        consummer.Received+= (model, eventArgs)=>{
            var body= eventArgs.Body.ToArray();
            var message= Encoding.UTF8.GetString(body);

            Console.WriteLine($"New ticke processing is initiated for - {message}");
        };

        channel.BasicConsume("bookings", true, consummer);
        Console.ReadKey();
    }
}