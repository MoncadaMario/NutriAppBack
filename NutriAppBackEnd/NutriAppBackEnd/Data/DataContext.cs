using NutriAppBackEnd.Models;
using Microsoft.EntityFrameworkCore;


namespace NutriAppBackEnd.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Consulta> Consultas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración para la tabla usuarios
        modelBuilder.Entity<Usuario>().ToTable("usuarios");
        modelBuilder.Entity<Usuario>().Property(c => c.IdUsuario).HasColumnName("id_usuario"); // Autoincremental
        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("nombre");
        modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("contrasena");
        modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("correo");
        modelBuilder.Entity<Usuario>().Property(u => u.Rol).HasColumnName("rol");
        modelBuilder.Entity<Usuario>().Property(u => u.Genero).HasColumnName("genero");

        // Configuración para la tabla consultas
        modelBuilder.Entity<Consulta>().ToTable("consultas");
        modelBuilder.Entity<Consulta>().Property(c => c.IdConsulta).HasColumnName("id_consulta"); // Autoincremental
        modelBuilder.Entity<Consulta>().Property(c => c.Edad).HasColumnName("edad");
        modelBuilder.Entity<Consulta>().Property(c => c.Altura).HasColumnName("altura");
        modelBuilder.Entity<Consulta>().Property(c => c.Peso).HasColumnName("peso");
        modelBuilder.Entity<Consulta>().Property(c => c.Grasa).HasColumnName("grasa");
        modelBuilder.Entity<Consulta>().Property(c => c.Fecha).HasColumnName("fecha");
        modelBuilder.Entity<Consulta>().Property(c => c.Recomendacion).HasColumnName("recomendacion");
        modelBuilder.Entity<Consulta>().Property(c => c.IdUsuario).HasColumnName("id_usuario"); // Referencia a la tabla usuarios
    }
}