namespace TodoWebAPI.Models.Todo
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
