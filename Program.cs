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
//EndPoint para Guardar las tareas
app.MapPost("/api/tareas",async([FromServices] TareasContext dbContext,[FromBody] Tarea tarea)=>
{
    tarea.TareaId = Guid.NewGuid(); // sobrescribimos la id
    tarea.FechaCreacion = DateTime.Now; // sobrescribimos la fecha
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});
//EndPoint para Actualizar las tareas
app.MapPut("/api/tareas/{id}",async([FromServices] TareasContext dbContext,[FromBody] Tarea tarea,[FromRoute] Guid id)=>
{
    var tareaActual = dbContext.Tareas.Find(id); // Buscamos el registro primero

    if(tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

//EndPoint para eliminar

app.MapDelete("/api/tareas/{id}",async([FromServices] TareasContext dbContext,[FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id); // Buscamos el registro primero

    if(tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
