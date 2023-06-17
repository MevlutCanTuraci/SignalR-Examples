using SignalR.WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SignalR Adding extension. Is required.
builder.Services.AddSignalR();
builder.Services.AddSignalR().AddMessagePackProtocol();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


#region SignalR Hubs

//Example adding hub map
// app.MapHub<HubClassName>("/HubPath");

app.MapHub<MyHub>("/MyHub");


#endregion


app.UseAuthorization();

app.MapControllers();

app.Run();
