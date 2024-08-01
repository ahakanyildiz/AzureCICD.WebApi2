using Microsoft.EntityFrameworkCore;
using Todos.WebApi2.Models;

namespace Todos.WebApi2.Context
{
    public sealed class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
