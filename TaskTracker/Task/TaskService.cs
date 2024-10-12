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

        private static int GetNextTaskId()
        {
            if (!File.Exists(JsonFilename))
            {
                return 1;
            }
            try
            {
                // We read the json content
                string jsonString = File.ReadAllText(JsonFilename);
                var tasks = JsonSerializer.Deserialize<List<Task>>(jsonString);

                // If task list is empty we return 1
                if (tasks == null || !tasks.Any())
                {
                    return 1;
                }

                // We get the Id of the last task and we increase by 1
                return tasks.Max(t => t.Id) + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el siguiente ID: {ex.Message}");
                // Handle the error
                return 1;
            }
        }

        public void SaveTasksToFile(int option)
        {
            string jsonString = JsonSerializer.Serialize(Tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilename, jsonString);

            if (option == 0)
            {
                var lastTask = Tasks[Tasks.Count - 1];
                Console.WriteLine($"Task added successfully (ID: {lastTask.Id})");
            }
        }

        public void Add(string newDescription)
        {
            var newTask = new Task { Id = GetNextTaskId(), Description = newDescription };
            Tasks.Add(newTask);
            SaveTasksToFile(0);
        }

        public int Update(int id, string description)
        {
            var task = Tasks[id];
            if (task == null)
            {
                Console.WriteLine("Error updating the task, Id doesn't exist");
                return 0;
            }
            task.Description = description;
            SaveTasksToFile(1);
            return 1;
        }

        public int Delete(int id)
        {
            var task = Tasks[id];
            if (task == null)
            {
                Console.WriteLine("Error deleting the task, Id doesn't exist");
                return 0;
            }
            Tasks.Remove(task);
            SaveTasksToFile(1);
            return 1;
        }

        public int MarkInProgress(int id)
        {
            var task = Tasks[id];
            if (task == null)
            {
                Console.WriteLine("Error updating the task, Id doesn't exist");
                return 0;
            }
            task.status = Task.Status.In_Progress;
            SaveTasksToFile(1);
            return 1;
        }

        public int MarkDone(int id)
        {
            var task = Tasks[id];
            if (task == null)
            {
                Console.WriteLine("Error updating the task, Id doesn't exist");
                return 0;
            }
            task.status = Task.Status.Done;
            SaveTasksToFile(1);
            return 1;
        }

        public void ListAll()
        {
            foreach (var item in Tasks)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}