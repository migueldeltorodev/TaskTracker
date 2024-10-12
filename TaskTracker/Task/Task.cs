namespace TaskTracker.Task
{
    public class Task
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public Status status { get; set; } = Status.Todo;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public enum Status
        {
            Todo,
            In_Progress,
            Done
        }
    }
}