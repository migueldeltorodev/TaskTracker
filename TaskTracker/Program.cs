using Cocona;
using TaskTracker.Task;
using Microsoft.Extensions.DependencyInjection;

var builder = CoconaApp.CreateBuilder();
builder.Services.AddSingleton<TaskService>();

var app = builder.Build();

app.AddCommand("add", (string task, TaskService service) =>
{
    service.Add(task);
});

app.Run();