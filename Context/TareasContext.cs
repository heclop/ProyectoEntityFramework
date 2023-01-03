using Microsoft.EntityFrameworkCore;
using ProyectoEntityFramework.Models;

namespace ProyectoEntityFramework.Context;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("b872a04c-e096-46c1-bb26-6679d043a8fb"),Nombre = "Actividades pendientes",Peso =20});
        categoriasInit.Add(new Categoria() {CategoriaId = Guid.Parse("b872a04c-e096-46c1-bb26-6679d043a802"),Nombre = "Actividades personales",Peso =50});
        
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);

            categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=> p.Peso);

            categoria.HasData(categoriasInit); //Recibe un vector de categorias
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("b872a04c-e096-46c1-bb26-6679d043a8fb"),CategoriaId = Guid.Parse("b872a04c-e096-46c1-bb26-6679d043a8fb"),PrioridadTarea = Prioridad.Media,Titulo = "Pago de servicios publicos",FechaCreacion = DateTime.Now,Peso = 10});
        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("b872a04c-e096-46c1-bb26-6679d043a849"),CategoriaId = Guid.Parse("b872a04c-e096-46c1-bb26-6679d043a802"),PrioridadTarea = Prioridad.Baja,Titulo = "Terminar de ver pelicula en Netflix",FechaCreacion = DateTime.Now,Peso = 5});

        modelBuilder.Entity<Tarea>(tarea => 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            tarea.Ignore(p=> p.Resumen);
            tarea.Property(p=> p.Peso);

            tarea.HasData(tareasInit);
        });
    }
   
}
