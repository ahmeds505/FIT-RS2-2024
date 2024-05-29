// See https://aka.ms/new-console-template for more information

using EasyNetQ;
using eProdaja.Model.Messages;

Console.WriteLine("Hello, World!");

var bus = RabbitHutch.CreateBus("host=localhost");

await bus.PubSub.SubscribeAsync<ProizvodiActivated>("console_printer", msg =>
{
    Console.WriteLine($"Product activated: {msg.Proizvod.Naziv}");
});

Console.WriteLine("Listening to messages, press <return> key to close!");
Console.ReadLine();