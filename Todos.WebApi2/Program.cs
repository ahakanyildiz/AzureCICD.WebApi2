using Microsoft.EntityFrameworkCore;
using Todos.WebApi2.Context;
using Todos.WebApi2.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ToDoContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));

});
WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
app.MapGet("/getall", () => Results.Ok(new List<string>()
{
    "Example1",
    "Example2"
}));
app.MapGet("/create", (ToDoContext context, string work) =>
{
    ToDo todo = new()
    {
        Work = work
    };
    context.ToDos.Add(todo);
    context.SaveChanges();
    Results.Ok(work);
});

app.MapGet("/selamver", () => "Hola Dunia");
app.Run();
