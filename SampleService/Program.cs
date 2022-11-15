using SampleService;

var builder = WebApplication.CreateBuilder(args);

var AllowSvelteSPA = "AllowSvelteSPA";

builder.Services.AddCors(options =>
{
  options.AddPolicy(AllowSvelteSPA, builder =>
  {
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
  });
});

var app = builder.Build();
app.UseCors(AllowSvelteSPA);

var todoService = new TodoService(new TodoRepository());

app.MapGet("/items", () => todoService.GetItems());
app.MapPost("/items", (Item item) => todoService.AddItem(item));
app.MapPut("/items/{id}", (int id, Item item) => todoService.UpdateItem(id, item));
app.MapDelete("/items/{id}", (int id) => 
{
  var result = todoService.DeleteItem(id);
  if (result)
  {
    return Results.Ok();
  }
  return Results.NotFound();
});
app.MapGet("/items/seed", () => todoService.Seed());

app.Run();
