namespace TaskToGo.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<TodoTask> tasks { get; set; } = new HashSet<TodoTask>();
    }
}
