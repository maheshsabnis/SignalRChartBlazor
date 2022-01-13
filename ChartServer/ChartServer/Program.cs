using ChartServer.DataProvider;
using ChartServer.RHub;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS Policy

builder.Services.AddCors(option => {
    option.AddPolicy("cors", policy => { 
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader();
    });
});
builder.Services.AddSignalR();
// Register the Watcher
builder.Services.AddScoped<TimeWatcher>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("cors");
 

app.UseAuthorization();


app.MapControllers();

 
    // Add the SignalR Hub
    app.MapHub<MarketHub>("/marketdata");
 


app.Run();
