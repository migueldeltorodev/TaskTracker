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

app.AddCommand("update", (int id, string task, TaskService service) =>
{
    service.Update(--id, task);
});

app.AddCommand("delete", (int id, TaskService service) =>
{
    service.Delete(--id);
});

app.AddCommand("mark-in-progress", (int id, TaskService service) =>
{
    service.MarkInProgress(--id);
});

app.AddCommand("mark-done", (int id, TaskService service) =>
{
    service.MarkDone(--id);
});

app.AddCommand("list", (TaskService service) =>
{
    service.ListAll();
});

app.Run();