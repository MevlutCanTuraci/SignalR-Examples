using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using SignalR.Console.Client.Model;
using System.Text.Json;

Console.WriteLine("Please wait...");


//We write the url address to whichever hub we will connect to in Messagepack and SignalR for SignalR.
var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7282/MyHub")
    .AddMessagePackProtocol()
    .WithAutomaticReconnect() //We used it to automatically connect in case of disconnection.
    .Build();


Console.WriteLine($"Connecting to server.. Please wait..");
await connection.StartAsync(); //Here we connect to SignalR server.

if (connection.State == HubConnectionState.Connected)
{
    //When we connect to the SignalR server, it creates a unique id value for each client.
    //We send this id value to SignalR server. So that it knows which link to send it to.
    string? connectionId = connection.ConnectionId;


    //Here 'ReceiveMethod' is the function name that allows us to capture the message sent by SignalR.
    connection.On<MyResponse>("ReceiveMethod", response =>
    {
        var json = JsonSerializer.Serialize(response);
        Console.WriteLine($"SignalR server getting data is: {json}");
    });

    Console.Clear();
    Console.WriteLine($"Connected SignalR server..");
    Console.WriteLine("Message send to press 'M' key.");

    while (true)
    {
        if (Console.ReadKey().Key == ConsoleKey.M)
        {
            Console.Clear();
            var dataList = LittleDataSet.RangePerson(min: 1, max: 4);

            //SendMessage is function name in MyHub class
            await connection.SendAsync("SendMessage", dataList, connectionId);

            //The working logic is as follows; The first parameter is the name of the function in the hub.
            //The data is entered in order, whatever the function wants as a parameter.
            //Example: await connection.SendAsync(<Hub_in_function_name>, <Param-1>, <Param-2>.....);
        }
    }

}

else
{
    Console.Clear();
    Console.WriteLine($"Not conncet SignalR Server :((");
}


Console.Read();