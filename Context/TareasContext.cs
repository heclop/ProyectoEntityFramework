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
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);

            categoria.Property(p=>p.Nombre).IsRequired().IsRequired();
            categoria.Property(p=> p.Descripcion);
        });
    }
}
