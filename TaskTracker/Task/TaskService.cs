using System.IO;
using System.Text.Json;

namespace TaskTracker.Task
{
    public class TaskService
    {
        private const string JsonFilename = "task_tracker.json";
        public List<Task> Tasks { get; private set; }

        public TaskService()
        {
            Tasks = LoadTasksFromFile();
        }

        private List<Task> LoadTasksFromFile()
        {
            if (!File.Exists(JsonFilename))
            {
                return new List<Task>(); // Return an empty list if file doesn't exist
            }

            try
            {
                string jsonString = File.ReadAllText(JsonFilename);
                return JsonSerializer.Deserialize<List<Task>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks from file: {ex.Message}");
                return new List<Task>(); // Return an empty list on error
            }
        }

        public void SaveTasksToFile()
        {
            string jsonString = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilename, jsonString);
            var lastTask = Tasks[Tasks.Count - 1];
            Console.WriteLine($"Task added successfully (ID: {lastTask.Id})");
        }

        public void Add(string newDescription)
        {
            var newTask = new Task { Description = newDescription };
            Tasks.Add(newTask);
            SaveTasksToFile();
        }
    }
}