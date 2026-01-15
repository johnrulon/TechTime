
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register channels (extension point)
builder.Services.AddSingleton<INotificationChannel, EmailChannel>();
builder.Services.AddSingleton<INotificationChannel, SmsChannel>();
builder.Services.AddSingleton<INotificationChannel, PushChannel>();

// To add a new channel, we create a new class implementing INotificationChannel
// and register it here, without modifying NotificationService or NotificationChannelFactory
builder.Services.AddSingleton<INotificationChannel, SlackChannel>();

// Register factory + service (stable core)
builder.Services.AddSingleton<INotificationChannelFactory, NotificationChannelFactory>();
builder.Services.AddSingleton<NotificationService>();

var app = builder.Build();

// Endpoints to send notifications
app.MapPost("/notify/{channel}", async (string channel, string message, NotificationService svc) =>
{
    await svc.SendAsync(message, channel);
    return Results.Ok(new { channel, message });
});

app.Run();