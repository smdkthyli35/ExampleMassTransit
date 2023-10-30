using MassTransit;
using MassTransit.Consumer.Consumers;

string rabbitMQUri = "amqps://fcmaggwn:TpRu16I7bFKa1XA_GshJzlbuox3qo19_@woodpecker.rmq.cloudamqp.com/fcmaggwn";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMQUri);
    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();