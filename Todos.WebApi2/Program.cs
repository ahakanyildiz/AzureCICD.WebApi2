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
app.MapGet("/getall", (ToDoContext context) => Results.Ok(context.ToDos.ToList()));
app.MapGet("/farukaselam", () => Results.Ok("selam faruk"));

app.MapGet("/create", (ToDoContext context, string work) =>
{
    ToDo todo = new()
    {
        Work = work
    };
    context.ToDos.Add(todo);
    context.SaveChanges();
    Console.WriteLine("Hello world");
    Console.WriteLine("Kay�t ba�ar�yla yap�ld�.");
    Console.WriteLine("selamiden push yapt�m");
    return Results.Ok(work);
});

app.MapGet("/updatetodo", (ToDoContext context, int id, string name) =>
{
    ToDo? a = context.ToDos.Find(id);
    a.Work = name;
    context.ToDos.Update(a);
    context.SaveChanges();
    return Results.Ok(name + " olarak" + "Update edildi.");
});

app.MapGet("/selamver", () => "Hola Dunia");

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider srv = scope.ServiceProvider;
    ToDoContext context = srv.GetRequiredService<ToDoContext>();
    context.Database.Migrate();
}
app.Run();
