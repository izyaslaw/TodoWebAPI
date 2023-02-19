using Microsoft.EntityFrameworkCore;

namespace TodoWebAPI.Models.Todo
{
    public class EFTodoDBContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public EFTodoDBContext(DbContextOptions<EFTodoDBContext> options) : base(options) { }
    }
}
