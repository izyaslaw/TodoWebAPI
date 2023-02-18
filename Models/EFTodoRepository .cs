namespace TodoWebAPI.Models
{
    public class EFTodoRepository : ITodoRepository
    {
        private EFTodoDBContext Context;
        public EFTodoRepository(EFTodoDBContext context)
        {
            Context = context;
        }
        public IEnumerable<TodoItem> Get() => Context.TodoItems;
        public TodoItem Get(int id) => Context.TodoItems.Find(id);
        public void Create(TodoItem item)
        {
            Context.TodoItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(TodoItem item)
        {
            var currentItem = Get(item.Id);
            currentItem.IsComplete = item.IsComplete;
            currentItem.TaskDescription = item.TaskDescription;

            Context.TodoItems.Update(currentItem);
            Context.SaveChanges();
        }

        public TodoItem Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                Context.TodoItems.Remove(item);
                Context.SaveChanges();
            }
            return item;
        }
    }
}
