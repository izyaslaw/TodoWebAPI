namespace TodoWebAPI.Models.Todo
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> Get();
        TodoItem? Get(int id);
        void Create(TodoItem item);
        void Update(TodoItem item);
        TodoItem? Delete(int id);
    }
}
