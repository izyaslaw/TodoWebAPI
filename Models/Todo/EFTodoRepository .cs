namespace TodoWebAPI.Models.Todo
{
    public class EFTodoRepository : ITodoRepository
    {
        private EFTodoDBContext Context;
        public EFTodoRepository(EFTodoDBContext context)
        {
            Context = context;
        }
        public IEnumerable<TodoItem> Get() => Context.TodoItems;
        public TodoItem? Get(int id) => Context.TodoItems.Find(id);
        public void Create(TodoItem item)
        {
            item.CreationDate = item.CreationDate ?? DateTime.Now;
            Context.TodoItems.Add(item);
            Context.SaveChanges();
        }
        public void Update(TodoItem item)
        {
            var currentItem = Get(item.Id);
            if (currentItem != null)
            {
                currentItem.Subject = item.Subject;
                currentItem.Description = item.Description;
                currentItem.IsComplete = item.IsComplete;
                currentItem.Deadline = item.Deadline;
                currentItem.IsDeleted = item.IsDeleted;
                Context.TodoItems.Update(currentItem);
                Context.SaveChanges();
            }
        }

        public TodoItem? Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                item.IsDeleted = true;
                Update(item);
                Context.SaveChanges();
            }
            return item;
        }
    }
}
