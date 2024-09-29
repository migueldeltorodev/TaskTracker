namespace TaskTracker.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Status ActualStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public enum Status
        {
            Todo,
            InProgress,
            Done
        }

        public Task()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}