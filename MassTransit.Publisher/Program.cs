using MassTransit;
using MassTransit.Shared.Messages;

string rabbitMQUri = "amqps://fcmaggwn:TpRu16I7bFKa1XA_GshJzlbuox3qo19_@woodpecker.rmq.cloudamqp.com/fcmaggwn";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
});

ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new($"{rabbitMQUri}/{queueName}"));

Console.WriteLine("Gönderilecek mesaj: ");
string message = Console.ReadLine();

await sendEndpoint.Send<IMessage>(new ExampleMessage() { Text = message });

Console.Read();