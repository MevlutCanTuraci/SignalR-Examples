using Microsoft.AspNetCore.SignalR;
using SignalR.WebAPI.Model;
using System.Text.Json;


namespace SignalR.WebAPI.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessage(List<MyModel> requestData, string connectionId)
        {
            var json = JsonSerializer.Serialize(requestData);
            Console.WriteLine($"Your sended data (json): {json}");

            var serverResponse = new MyResponse
            {
                Id      = Random.Shared.Next(500, 2500),
                Date    = DateTime.Now,
                Status  = "Request is ok."
            };

            await Clients.Clients(connectionId).SendAsync("ReceiveMethod", serverResponse);

        }

    }
}