WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
app.MapGet("/getall", () => Results.Ok(new List<string>()
{
    "Example1",
    "Example2"
}));
app.MapGet("/create", (string work) =>
{
    Results.Ok(work + "slmn");
});

app.MapGet("/selamver", () =>
{
    Results.Ok("Hello canim benim");
})
app.Run();
