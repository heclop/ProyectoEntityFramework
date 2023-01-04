using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEntityFramework.Context;
using ProyectoEntityFramework.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria "+dbContext.Database.IsInMemory());
});
//EndPoint para consultar las tareas
app.MapGet("/api/tareas",async([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));
});

app.MapPost("/api/tareas",async([FromServices] TareasContext dbContext,[FromBody] Tarea tarea)=>
{
    tarea.TareaId = Guid.NewGuid(); // sobrescribimos la id
    tarea.FechaCreacion = DateTime.Now; // sobrescribimos la fecha
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
app.Run();
