using zadanie5;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
var animals = new List<Animal>();
app.MapGet("/animals", () => Results.Ok(animals));
app.MapGet("/animals/{id}", (int id) =>
{
    var animal = animals.FirstOrDefault(a => a.id == id);
    if (animal != null)
    {
        return Results.Ok(animal);
    }
    else
    {
        return Results.NotFound($"Animal with ID {id} not found in list.");
    }
});
app.Run();