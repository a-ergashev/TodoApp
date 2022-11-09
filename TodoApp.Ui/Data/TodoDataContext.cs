using Microsoft.EntityFrameworkCore;
using TodoApp.Domain;

namespace TodoApp.Ui.Data
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext(DbContextOptions<TodoDataContext> options) 
            : base(options) { }


        public DbSet<TodoList> TodoLists { get; set; }
        
        public DbSet<Todo> Todos { get; set; }
    }
}
