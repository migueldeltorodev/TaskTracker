Task tracker is a project used to track and manage your tasks. This is a simple command line interface (CLI) to track what you need to do, what you have done, and what you are currently working on. This is a project that I get from https://roadmap.sh/projects/task-tracker

## Requirements

The application should run from the command line, accept user actions and inputs as arguments, and store the tasks in a JSON file. The user should be able to:

- Add, Update, and Delete tasks
- Mark a task as in progress or done
- List all tasks
- List all tasks that are done
- List all tasks that are not done
- List all tasks that are in progress

## Technical Requirements

Before run the app you should install this basics nuget packages from NuGet Package Selector:

- Cocona
- Microsoft.Extensions.DependencyInjection
- System.Text.Json

## Basics commands:

1. To add a new task we run: `dotnet run -- add --task TaskName` 
2. To update a task we run: `dotnet run -- update --id 1`
3. To delete a task we run: `dotnet run -- delete --id 1`
4. To mark a task as in progress: `dotnet run -- mark-in-progress --id 1`
5. To mark a task as in done: `dotnet run -- mark-done --id 1`
6. To list all tasks: `dotnet run -- list`
7. To list all tasks that are done: `dotnet run -- list-done`
8. To list all tasks that are not done: `dotnet run -- list-todo`
9. To list all tasks that are in progress: `dotnet run -- list-in-progress
